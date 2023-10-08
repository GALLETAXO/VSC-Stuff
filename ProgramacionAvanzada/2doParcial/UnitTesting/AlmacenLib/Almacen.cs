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

public class Funciones
{
    /*
    List<Profesor>? profesor = new(){new("lol", "lol", "lol", "lol", "lol")};
    XmlSerializer xsP = new(type: profesor!.GetType());
    string pathProfe = Combine(CurrentDirectory, "profesor.xml");

    List<Almacenista>? almacenistas = new(){new("Gael", "Gamez", "1234")};
    XmlSerializer xsA = new(type: almacenistas!.GetType());
    string pathAlma = Combine(CurrentDirectory, "almacenista.xml");
    */
    
    public string GetMD5(string input)
{

        using MD5 z = MD5.Create();

        byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
        bs = z.ComputeHash(bs);
        System.Text.StringBuilder s = new();

        foreach (byte b in bs)
        {
            s.Append(b.ToString("x2").ToLower());
            
        }

        string hash = s.ToString();

        return hash;


    }


    public bool Login(string? nombre, string? contraseña)
    {
        List<Almacenista>? almacenistas = new(){new("Gael", "Gamez", "1234")};
        XmlSerializer xsA = new(type: almacenistas!.GetType());
        string pathAlma = Combine(CurrentDirectory, "almacenista.xml");
        string? pass;
        

        using (FileStream xmlLoad = File.Open(pathAlma,FileMode.Open))
        {
       
            almacenistas = xsA.Deserialize(xmlLoad) as List<Almacenista>;
  
        }

        if(string.IsNullOrWhiteSpace(nombre))
        {
            return false;
        }

        try
        {
            pass = almacenistas!.Find(x => x.Name!.Contains(nombre))!.password;
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

    public bool Eliminar(string? nombre)
    {
        List<Profesor>? profesor = new(){new("lol", "lol", "lol", "lol", "lol","lol")};
        XmlSerializer xsP = new(type: profesor!.GetType());
        string pathProfe = Combine(CurrentDirectory, "profesor.xml");


        using (FileStream xmlLoad = File.Open(pathProfe,FileMode.Open))
        {
       
            profesor = xsP.Deserialize(xmlLoad) as List<Profesor>;
  
        }

        List<Salon>? salones = new(){new("lol", "lol", "lol", "lol", "lol","lol","lol")};
        XmlSerializer xsS = new(type: salones!.GetType());
        string pathSalon = Combine(CurrentDirectory, "salon.xml");
        

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
            bool elim = profesor!.Remove(profesor.Find(x => x.Name!.Contains(nombre))!);
            
            

                foreach(Salon s in salones!)
                {
                    if(salones!.Contains(salones.Find(x=>x.Profesor!.Contains(nombre))!))
                    {
                        salones!.Contains(salones.Find(x=>x.Profesor!.Remove(nombre))!);
                    }

                }
                profesor = profesor!.OrderBy(x=> x.Materias!.FirstOrDefault()).ToList();
                
            using (FileStream stream = File.Create(pathProfe))
            {

                xsP.Serialize(stream, profesor);
            }
            using (FileStream stream = File.Create(pathSalon))
            {

                xsS.Serialize(stream, salones);
            }

            

            string JpathProfesor = Combine(CurrentDirectory, "profesor.json");
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

     public bool Materia(string? nombre, string? opcion,string? mat)
    {
        List<Profesor>? profesor = new(){new("lol", "lol", "lol", "lol", "lol","lol")};
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

        if(string.IsNullOrWhiteSpace(mat))
        {
            return false;
        }

        try
        {
            if(opcion!.Equals("5"))
            {
                if(profesor!.Find(x => x.Name!.Contains(nombre))!.Materias == null)
                {
                    profesor.Find(x => x.Name!.Contains(nombre))!.Materias = new();
                    regreso = profesor.Find(x => x.Name!.Contains(nombre))!.Materias!.Add(mat);
                    profesor.Find(x => x.Name!.Contains(nombre))!.Materias = profesor.Find(x => x.Name!.Contains(nombre))!.Materias!.OrderBy(x=>x).ToHashSet();

                }
                else
                {
                    regreso = profesor.Find(x => x.Name!.Contains(nombre))!.Materias!.Add(mat);
                    profesor.Find(x => x.Name!.Contains(nombre))!.Materias = profesor.Find(x => x.Name!.Contains(nombre))!.Materias!.OrderBy(x=>x).ToHashSet();
                }
                
                

            }
            else
            {
                regreso = profesor!.Find(x => x.Name!.Contains(nombre))!.Materias!.Remove(mat);
                

            }

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

    public bool Cambiar(string? nombre, string? opcion, string? nuevo)
    {
        List<Profesor>? profesor = new(){new("lol", "lol", "lol", "lol", "lol","lol")};
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
            switch(opcion)
            {
                case "1":
                {
                    profesor!.Find(x => x.Name!.Contains(nombre))!.Nomina = GetMD5(nuevo);
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

            }
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

    public bool Contra (string? nombre, string? pass)
    {
        List<Almacenista>? almacenistas = new(){new("Gael", "Gamez", "1234")};
        XmlSerializer xsA = new(type: almacenistas!.GetType());
        string pathAlma = Combine(CurrentDirectory, "almacenista.xml");
       
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
            almacenistas!.Find(x => x.Name!.Contains(nombre))!.password = GetMD5(pass);      
            using (FileStream stream = File.Create(pathAlma))
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

    public bool  Reporte(string? op, string? nom)
    {

        List<Profesor>? profesor = new(){new("lol", "lol", "lol", "lol", "lol","lol")};
        XmlSerializer xsP = new(type: profesor!.GetType());

        string pathProfe = Combine(CurrentDirectory, "profesor.xml");
        
        using (FileStream xmlLoad = File.Open(pathProfe,FileMode.Open))
        {
       
            profesor = xsP.Deserialize(xmlLoad) as List<Profesor>;
  
        }

        bool regreso = false;

         if(string.IsNullOrWhiteSpace(op))
        {
            return false;
        }


        try
        {

            nom = Regex.Replace(nom!.Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "");
            string newpath = Combine(GetFolderPath(SpecialFolder.MyDocuments), nom + ".xml" );
            string jnewpath = Combine(GetFolderPath(SpecialFolder.MyDocuments), nom + ".json" );
         
        

            switch(op)
            {
                case "1":
                {
                    profesor = profesor!.OrderBy(x=> x.Nomina).ToList();
                    using (FileStream stream = File.Create(newpath)){xsP.Serialize(stream, profesor);}
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

public class Almacenista
{

    public Almacenista(){}

    public Almacenista(string? name, string? lname, string? pass)
    {
        Name = name;
        LName = lname;
        password = pass;
    }

    [XmlAttribute("Name")]
    public string? Name {get; set;}
    [XmlAttribute("Last-Name")]
    public string? LName {get; set;}
    [XmlAttribute("Password")]
    public string? password {get; set;}

}

public class Profesor
{

    public Profesor(){}
    public Profesor(string? nomina, string? name, string? lname, string? pass, string? division, string? materia)
    {
        Nomina = nomina;
        Name = name;
        LName = lname;
        password = pass;
        Division = division;
        Materias = new(){materia!};

    }


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


public class Alumno
{

    public Alumno(){}
    public Alumno(string? reg, string? name, string? lname, string? pass, string? salon1, string? salon2, string? salon3)
    {
        Registro = reg;
        Name = name;
        LName = lname;
        Password = pass;
        Salon = new(){salon1!, salon2!, salon3!};
    }


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

public class Salon
{

    public Salon(){}

    public Salon(string? name, string? group1, string? group2, string? group3, string? profe1, string? profe2, string? profe3)
    {
        Name = name;
        Grupo = new(){group1!, group2!, group3!};
        Profesor = new(){profe1!, profe2!, profe3!};
       
    }

    [XmlAttribute("Nombre")]
    public string? Name {get; set;}
    public HashSet<string>? Grupo { get; set; }
    public HashSet<string>? Profesor { get; set; }
   
}

