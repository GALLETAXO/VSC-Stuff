namespace AlmacenLib;

using System.Numerics;
using System.Xml.Serialization;


public class Funciones
{
    public bool Login(string? nombre, string? contraseña)
    {
        string? pass;

        List<Almacenista>? almacenistas = new()
        {
            new("Toño", "Fox", "123")
        };

        try
        {
            pass = almacenistas.Find(x => x.Name!.Contains(nombre!))!.password;
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

    public void Eliminar()
    {

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
    public Profesor(int nomina, string? name, string? lname, string? pass, string? division)
    {
        Nomina = nomina;
        Name = name;
        LName = lname;
        password = pass;
        Division = division;
    }


    [XmlAttribute("Nomina")]
    public int Nomina {get; set;}
    [XmlAttribute("Name")]
    public string? Name {get; set;}
    [XmlAttribute("Last-Name")]
    public string? LName {get; set;}
    [XmlAttribute("Password")]
    public string? password {get; set;}
    [XmlAttribute("Materias")]
    public HashSet<string>? Materias { get; set; }
     [XmlAttribute("Division")]
    public string? Division {get; set;}


    
    
    


}
