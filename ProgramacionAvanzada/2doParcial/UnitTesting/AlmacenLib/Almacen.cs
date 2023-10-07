namespace AlmacenLib;

using System.Numerics;
using System.Xml.Serialization;
using System.Security.Cryptography;

using static System.Environment;
using static System.IO.Path;





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
        List<Profesor>? profesor = new(){new("lol", "lol", "lol", "lol", "lol")};
        XmlSerializer xsP = new(type: profesor!.GetType());
        string pathProfe = Combine(CurrentDirectory, "profesor.xml");

        using (FileStream xmlLoad = File.Open(pathProfe,FileMode.Open))
        {
       
            profesor = xsP.Deserialize(xmlLoad) as List<Profesor>;
  
        }
        
        if(string.IsNullOrWhiteSpace(nombre))
        {
            return false;
        }


        

        try
        {
            bool elim = profesor!.Remove(profesor.Find(x => x.Name!.Contains(nombre))!);
            using (FileStream stream = File.Create(pathProfe))
            {

                xsP.Serialize(stream, profesor);
            }
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
        List<Profesor>? profesor = new(){new("lol", "lol", "lol", "lol", "lol")};
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
                }
                else
                {
                    regreso = profesor.Find(x => x.Name!.Contains(nombre))!.Materias!.Add(mat);
                }
                
                

            }
            else
            {
                regreso = profesor!.Find(x => x.Name!.Contains(nombre))!.Materias!.Remove(mat);
                

            }

            using (FileStream stream = File.Create(pathProfe))
            {

                xsP.Serialize(stream, profesor);
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

    public bool Cambiar(string? nombre, string? opcion, string? nuevo)
    {
        List<Profesor>? profesor = new(){new("lol", "lol", "lol", "lol", "lol")};
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
            using (FileStream stream = File.Create(pathProfe))
            {

                xsP.Serialize(stream, profesor);
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
    public Profesor(string? nomina, string? name, string? lname, string? pass, string? division)
    {
        Nomina = nomina;
        Name = name;
        LName = lname;
        password = pass;
        Division = division;
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
