namespace AlmacenLib;
using System.Text.Json;
using System.Text.Json.Serialization;

using System.Numerics;
using System.Xml.Serialization;
using System.Security.Cryptography;

using static System.Environment;
using static System.IO.Path;
using System.Text.RegularExpressions;
using System.Text;
// aqui estan las librerias a utilizar

public class Funciones // esta es nuestra libreria de funciones, donde  estan todas las acciones de nuestro programa
{
    /*
    List<Profesor>? profesor = new(){new("lol", "lol", "lol", "lol", "lol")};
    XmlSerializer xsP = new(type: profesor!.GetType());
    string pathProfe = Combine(CurrentDirectory, "profesor.xml");

    List<Almacenista>? almacenistas = new(){new("Gael", "Gamez", "1234")};
    XmlSerializer xsA = new(type: almacenistas!.GetType());
    string pathAlma = Combine(CurrentDirectory, "almacenista.xml");
    */
    // este es un curioso detalle, es un experimiento medio raro, es decir, en teoria deberia de funcionar, pero debido a los problemas que me ocasiono el serializador xml
    // preferi dejar esta parte comentada, ya que con el uso de esto por separado, el programa funciona :D, y si funciona, mejor ya no le muevo jajajaja
    
    
    public string GetMD5(string input) // esta es la funcion que utilizamos para encriptar lo que necesitemos encripatar 
{

        using MD5 z = MD5.Create(); // creamos un objeto de la clase MD5 para poder usar sus funciones

        byte[] bs = System.Text.Encoding.UTF8.GetBytes(input); // aqui haremos una cadena de bytes para contener la encriptacion de nuestro dato 
        bs = z.ComputeHash(bs); // luego haremos esta encriptacion
        System.Text.StringBuilder s = new(); // haremos un string builder para poder modificar nuestro dato

        foreach (byte b in bs) // haremos la modificacion de nuestro string pasando 1 por 1 los caracteres de nuestra cadena de bytes
        {
            s.Append(b.ToString("x2").ToLower());
            
        }

        string hash = s.ToString(); // lo pasaremos a string 

        return hash; // y regresaremos el dato ya encriptado 


    }


    public bool Login(string? nombre, string? contraseña) // esta es la funcion destinada para el inicio de sesio
    {
        List<Almacenista>? almacenistas = new(){new("Gael", "Gamez", "1234")}; // primero crearemos una lista donde ingresaremos los datos que estan en nuestros archivos 
        XmlSerializer xsA = new(type: almacenistas!.GetType());
        string pathAlma = Combine(CurrentDirectory, "almacenista.xml"); 
        string? pass;
        

        using (FileStream xmlLoad = File.Open(pathAlma,FileMode.Open)) // Estas lineas las usamos para obtener los datos del archivo 
        {
       
            almacenistas = xsA.Deserialize(xmlLoad) as List<Almacenista>;
  
        }

        if(string.IsNullOrWhiteSpace(nombre)) // revisamos por si acaso que los valores no esten vacios
        {
            return false;
        }

        try// en estos casos uso unos try - cath para poder usar las exepciones a mi favor, de forma que sean las que determinen si se pudo hacer la accion
        {
            pass = almacenistas!.Find(x => x.Name!.Contains(nombre))!.password; // en esta parte revisamos que la contraseña corresponda con un usuario existente 
            if(pass!.Equals(contraseña))
            {
                return true;

            }
            else
            {
                return false;
            }
            
        }
        catch (NullReferenceException)
        {
            return false;
        }
        catch (ArgumentNullException)
        {
            return false;
        }
     

    }

    public bool Eliminar(string? nombre) // en esta funcion buscaremos al maestro a eliminar por su nombre
    {
        List<Profesor>? profesor = new(){new("lol", "lol", "lol", "lol", "lol","lol")}; 
        XmlSerializer xsP = new(type: profesor!.GetType());
        string pathProfe = Combine(CurrentDirectory, "profesor.xml");


        using (FileStream xmlLoad = File.Open(pathProfe,FileMode.Open))
        {
       
            profesor = xsP.Deserialize(xmlLoad) as List<Profesor>;
  
        }
        // toda esta parte tiene el mismo proosito que el el codigo pasado 

        List<Salon>? salones = new(){new("lol", "lol", "lol", "lol", "lol","lol","lol")};
        XmlSerializer xsS = new(type: salones!.GetType());
        string pathSalon = Combine(CurrentDirectory, "salon.xml"); // aqui recabaremos tambien los daros de los salones para poderlos modificar
        

        using (FileStream xmlLoad = File.Open(pathSalon,FileMode.Open))
        {
       
            salones = xsS.Deserialize(xmlLoad) as List<Salon>;
  
        }
        
        if(string.IsNullOrWhiteSpace(nombre))
        {
            return false;
        }


        

        try
        {
            bool elim = profesor!.Remove(profesor.Find(x => x.Name!.Contains(nombre))!); // buscaremos el maestro a eliminar 
            
            

                foreach(Salon s in salones!) //  ya que hicimos esto, revisaremos los salones para poder eliminar al maestro de sus maestros asignados 
                {
                    if(salones!.Contains(salones.Find(x=>x.Profesor!.Contains(nombre))!))
                    {
                        salones!.Contains(salones.Find(x=>x.Profesor!.Remove(nombre))!);
                    }

                }
                profesor = profesor!.OrderBy(x=> x.Materias!.FirstOrDefault()).ToList(); // actualizamos la lista de maestros para que este en orden 
                
            using (FileStream stream = File.Create(pathProfe)) // hacemos la actualizacion de ambas listas en sus archivos xml 
            {

                xsP.Serialize(stream, profesor);
            }
            using (FileStream stream = File.Create(pathSalon))
            {

                xsS.Serialize(stream, salones);
            }

            

            string JpathProfesor = Combine(CurrentDirectory, "profesor.json"); //hacemos los cambios a los archivos json
            File.WriteAllText(JpathProfesor,JsonSerializer.Serialize(profesor));
            string JpathSalon = Combine(CurrentDirectory, "salon.json");
            File.WriteAllText(JpathSalon,JsonSerializer.Serialize(salones));

                
            return elim;

        }
        catch (NullReferenceException)
        {
            return false;
        }
        catch (ArgumentNullException)
        {
                    return false;
        }
     

    }

     public bool Materia(string? nombre, string? opcion,string? mat) // esta es la funcion especializada a hacer cambios con respecto a las materias
    {
        List<Profesor>? profesor = new(){new("lol", "lol", "lol", "lol", "lol","lol")};
        XmlSerializer xsP = new(type: profesor!.GetType());
        string pathProfe = Combine(CurrentDirectory, "profesor.xml");
        
        using (FileStream xmlLoad = File.Open(pathProfe,FileMode.Open))
        {
       
            profesor = xsP.Deserialize(xmlLoad) as List<Profesor>;
  
        } // lo mismo que en los casos anteriores
        bool regreso = false;

        if(string.IsNullOrWhiteSpace(nombre)) // revisamos que los datos no esten vacios
        {
            return false;
        }

        if(string.IsNullOrWhiteSpace(mat))
        {
            return false;
        }

        try
        {
            if(opcion!.Equals("5")) // haremos lo correspondiente a cada opcion
            {
                if(profesor!.Find(x => x.Name!.Contains(nombre))!.Materias == null)  // revisaremos si el profesor ya tiene materias asignadas
                {
                    profesor.Find(x => x.Name!.Contains(nombre))!.Materias = new();  // si no tiene, le crearemos una nueva 
                    regreso = profesor.Find(x => x.Name!.Contains(nombre))!.Materias!.Add(mat);
                    profesor.Find(x => x.Name!.Contains(nombre))!.Materias = profesor.Find(x => x.Name!.Contains(nombre))!.Materias!.OrderBy(x=>x).ToHashSet();

                }
                else // si tiene, pues solo agregaremos la nueva materia
                {
                    regreso = profesor.Find(x => x.Name!.Contains(nombre))!.Materias!.Add(mat);
                    profesor.Find(x => x.Name!.Contains(nombre))!.Materias = profesor.Find(x => x.Name!.Contains(nombre))!.Materias!.OrderBy(x=>x).ToHashSet();
                }
                
                

            }
            else // en el otro caso pues solo buscaremos y destruiremos la materia determinada
            {
                regreso = profesor!.Find(x => x.Name!.Contains(nombre))!.Materias!.Remove(mat);
                

            }

            profesor = profesor!.OrderBy(x=> x.Materias!.FirstOrDefault()).ToList(); // acomodamos 

            using (FileStream stream = File.Create(pathProfe)) // actualizamos los  archivos 
            {

                xsP.Serialize(stream, profesor);
            }

            

            string JpathProfesor = Combine(CurrentDirectory, "profesor.json");
            File.WriteAllText(JpathProfesor,JsonSerializer.Serialize(profesor));


            return regreso;
            
        
        }
        catch (NullReferenceException)
        {
            return false;
        }
        catch (ArgumentNullException)
        {
            return false;
        }

       
    }

    public bool Cambiar(string? nombre, string? opcion, string? nuevo) // esta es la funcio dediacada a hacer los cambios generales a el profesor 
    {
        List<Profesor>? profesor = new(){new("lol", "lol", "lol", "lol", "lol","lol")}; // lo de siempre 
        XmlSerializer xsP = new(type: profesor!.GetType());
        string pathProfe = Combine(CurrentDirectory, "profesor.xml");
        
        using (FileStream xmlLoad = File.Open(pathProfe,FileMode.Open))
        {
       
            profesor = xsP.Deserialize(xmlLoad) as List<Profesor>;
  
        }
        bool regreso = false;

         if(string.IsNullOrWhiteSpace(nombre))
        {
            return false;
        }

        if(string.IsNullOrWhiteSpace(nuevo))
        {
            return false;
        }

        try
        {
            switch(opcion) // aqui tenemos un switch para determnar que dato se cambiara 
            {
                case "1":
                {
                    profesor!.Find(x => x.Name!.Contains(nombre))!.Nomina = GetMD5(nuevo); // solo buscaremos el objetivo y sobreescribiremos el dato solicitado 
                    regreso = true;
                    break;
                }
                case "2":
                {
                    profesor!.Find(x => x.Name!.Contains(nombre))!.Name = nuevo;
                    regreso = true;
                    break;
                }
                case "3":
                {
                    profesor!.Find(x => x.Name!.Contains(nombre))!.LName = nuevo;
                    regreso = true;
                    break;
                }
                case "4":
                {
                    profesor!.Find(x => x.Name!.Contains(nombre))!.password = GetMD5(nuevo);
                    regreso = true;
                    break;
                }
                case "7":
                {
                    profesor!.Find(x => x.Name!.Contains(nombre))!.Division = nuevo;
                    regreso = true;
                    break;
                }

                default:
                {
                    return false;
                }

            } // despues de esto, ordenaremos y actualizaremos las listas y archivos
            profesor = profesor!.OrderBy(x=> x.Materias!.FirstOrDefault()).ToList();
            using (FileStream stream = File.Create(pathProfe))
            {

                xsP.Serialize(stream, profesor);
            }
            

            string JpathProfesor = Combine(CurrentDirectory, "profesor.json");
            File.WriteAllText(JpathProfesor,JsonSerializer.Serialize(profesor));



            return regreso;

          
            
        
        }
        catch (NullReferenceException)
        {
            return false;
        }
        catch (ArgumentNullException)
        {
            return false;
        }

    }

    public bool Contra (string? nombre, string? pass) // este es el caso especifico en el que el usuario quiera cambiar la contraseña de un almacenista
    {
        List<Almacenista>? almacenistas = new(){new("Gael", "Gamez", "1234")};
        XmlSerializer xsA = new(type: almacenistas!.GetType());
        string pathAlma = Combine(CurrentDirectory, "almacenista.xml"); // obtenemos los datos del almacenista 
       
        using (FileStream xmlLoad = File.Open(pathAlma,FileMode.Open))
        {
       
            almacenistas = xsA.Deserialize(xmlLoad) as List<Almacenista>;
  
        }

         if(string.IsNullOrWhiteSpace(nombre))
        {
            return false;
        }

        if(string.IsNullOrWhiteSpace(pass))
        {
            return false;
        }


        try
        {
            almacenistas!.Find(x => x.Name!.Contains(nombre))!.password = GetMD5(pass);      // buscaremos al almacenista y sobreescribiremos su contraseña  
            using (FileStream stream = File.Create(pathAlma)) // ya solo estamos actualizando los archivos 
            {
        
                xsA.Serialize(stream, almacenistas);
            }

            
            string JpathAlma = Combine(CurrentDirectory, "almacenista.json");
            File.WriteAllText(JpathAlma,JsonSerializer.Serialize(almacenistas));




            return true;
        }
        catch (NullReferenceException)
        {
            return false;
        }
        catch (ArgumentNullException)
        {
            return false;
        }

        
       
    }

    public bool  Reporte(string? op, string? nom) // esta es la parte de los reportes 
    {

        List<Profesor>? profesor = new(){new("lol", "lol", "lol", "lol", "lol","lol")};
        XmlSerializer xsP = new(type: profesor!.GetType());

        string pathProfe = Combine(CurrentDirectory, "profesor.xml");
        
        using (FileStream xmlLoad = File.Open(pathProfe,FileMode.Open))
        {
       
            profesor = xsP.Deserialize(xmlLoad) as List<Profesor>;
  
        } // obtenemos los datos de siempre 

        bool regreso = false;

         if(string.IsNullOrWhiteSpace(op))
        {
            return false;
        }


        try
        {

            nom = Regex.Replace(nom!.Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", ""); // le daremos un formato adecuado al nombre del archivo para que no cause problemas
            string newpath = Combine(GetFolderPath(SpecialFolder.MyDocuments), nom + ".xml" ); // crearemos las direcciones para los archivos xml y json 
            string jnewpath = Combine(GetFolderPath(SpecialFolder.MyDocuments), nom + ".json" );
         
        

            switch(op)
            {
                case "1": // en este switch determinaremos en torno a cual dato se hara la acomodacion
                {
                    profesor = profesor!.OrderBy(x=> x.Nomina).ToList(); // lo que hacemos es ordenar segun un dato 
                    using (FileStream stream = File.Create(newpath)){xsP.Serialize(stream, profesor);} // y pues actualizar los archivos 
                    File.WriteAllText(jnewpath,JsonSerializer.Serialize(profesor));
                    regreso = true;
                    break;
                }
                case "2":
                {
                    profesor = profesor!.OrderBy(x=> x.Name).ToList();
                    using (FileStream stream = File.Create(newpath)){xsP.Serialize(stream, profesor);}
                    File.WriteAllText(jnewpath,JsonSerializer.Serialize(profesor));
                    regreso = true;
                    break;
                }
                case "3":
                {
                    profesor = profesor!.OrderBy(x=> x.LName).ToList();
                    using (FileStream stream = File.Create(newpath)){xsP.Serialize(stream, profesor);}
                    File.WriteAllText(jnewpath,JsonSerializer.Serialize(profesor));
                    regreso = true;
                    break;
                }
                case "4":
                {
                    profesor = profesor!.OrderBy(x=> x.password).ToList();
                    using (FileStream stream = File.Create(newpath)){xsP.Serialize(stream, profesor);}
                    File.WriteAllText(jnewpath,JsonSerializer.Serialize(profesor));
                    regreso = true;
                    break;
                }
                case "5":
                {
                    
                    profesor = profesor!.OrderBy(x=> x.Materias!.FirstOrDefault()).ToList();
                    using (FileStream stream = File.Create(newpath)){xsP.Serialize(stream, profesor);}
                    File.WriteAllText(jnewpath,JsonSerializer.Serialize(profesor));
                    regreso = true;
                    break;
                }
                case "6":
                {
                    profesor = profesor!.OrderBy(x=> x.Division).ToList();
                    using (FileStream stream = File.Create(newpath)){xsP.Serialize(stream, profesor);}
                    File.WriteAllText(jnewpath,JsonSerializer.Serialize(profesor));
                    regreso = true;
                    break;
                }

                default:
                {
                    return false;
                }

            }
            
            return regreso;

          
            
        
        }
        catch (NullReferenceException)
        {
            return false;
        }
        catch (ArgumentNullException)
        {
            return false;
        }




    }


 



}

public class Almacenista // de aqui en adelante solo estan las clases, esta es la clase de almacenista 
{

    public Almacenista(){}

    public Almacenista(string? name, string? lname, string? pass) // tiene un constructor hecho para ingresar en el los datos  de una forma mas sencilla 
    {
        Name = name;
        LName = lname;
        password = pass;
    }

    // esto son lso datos que tienen los almacenistas 
    [XmlAttribute("Name")]
    public string? Name {get; set;}
    [XmlAttribute("Last-Name")]
    public string? LName {get; set;}
    [XmlAttribute("Password")]
    public string? password {get; set;}

}

public class Profesor // esta es la clase profesor 
{

    public Profesor(){}
    public Profesor(string? nomina, string? name, string? lname, string? pass, string? division, string? materia) // este constructor facilita el ingreso de nuevos profesores muchisimo 
    {
        Nomina = nomina;
        Name = name;
        LName = lname;
        password = pass;
        Division = division;
        Materias = new(){materia!}; // ya que ingresamos desde un inicio una de las materias del maestro 

    }

    // estos son los datos del profesor 
    [XmlAttribute("Nomina")]
    public string? Nomina {get; set;}
    [XmlAttribute("Name")]
    public string? Name {get; set;}
    [XmlAttribute("LastName")]
    public string? LName {get; set;}
    [XmlAttribute("Password")]
    public string? password {get; set;}
    public HashSet<string>? Materias { get; set; }
     [XmlAttribute("Division")]
    public string? Division {get; set;}


    
    
    


}


public class Alumno // esta es la clase del alumno 
{

    public Alumno(){}
    public Alumno(string? reg, string? name, string? lname, string? pass, string? salon1, string? salon2, string? salon3) // para hacer el ingreso de los alumnos, ya que ingresa varios salones
    {
        Registro = reg;
        Name = name;
        LName = lname;
        Password = pass;
        Salon = new(){salon1!, salon2!, salon3!}; // esto hace qeu ingresar alumnos sean mas sencillos
    }

    // los datos que tienen los alumnos 
    [XmlAttribute("Registro")]
    public string? Registro {get; set;}
    [XmlAttribute("Nombre")]
    public string? Name {get; set;}
    [XmlAttribute("Apellidos")]
    public string? LName {get; set;}
    [XmlAttribute("Contraseña")]
    public string? Password {get; set;}
    public HashSet<string>? Salon { get; set; }

}

public class Salon // la clase de salon 
{

    public Salon(){}

    public Salon(string? name, string? group1, string? group2, string? group3, string? profe1, string? profe2, string? profe3) // facilita muchisimo el ingreso de salones 
    {
        Name = name;
        Grupo = new(){group1!, group2!, group3!};
        Profesor = new(){profe1!, profe2!, profe3!}; // ingresamos ya de una vez 3 salones y tres profesores 
       
    }
    // aqui estan los datos de los salones 
    [XmlAttribute("Nombre")] 
    public string? Name {get; set;}
    public HashSet<string>? Grupo { get; set; }
    public HashSet<string>? Profesor { get; set; }
   
}

// fin :) 

