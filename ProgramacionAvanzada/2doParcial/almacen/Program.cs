using System.Runtime.InteropServices;
using AlmacenLib;
using static System.Environment;
using static System.IO.Path;
using System.Xml.Serialization;

Funciones func = new();
bool validar = false;

List<Profesor>? profesor = new();
List<Almacenista>? almacenista = new()
{
    new("Gael", "Gamez", func.GetMD5("1234")),
    new("Emiliano", "Rodriguez", func.GetMD5("4321")),
    new("Uriel", "Garcia", func.GetMD5("5678")),
    new("Oscar", "Penilla", func.GetMD5("8765")),
    new("Ricardo", "Solorzano", func.GetMD5("fnaf"))

};

XmlSerializer xsA = new(type: almacenista.GetType());

XmlSerializer xsP = new(type: profesor.GetType());





string pathAlma = Combine(CurrentDirectory, "almacenista.xml");
if(Path.Exists(pathAlma))
{
    
    // lo deserializas
    using (FileStream xmlLoad = File.Open(pathAlma,FileMode.Open))
    {
       
        almacenista = xsA.Deserialize(xmlLoad) as List<Almacenista>;
  
    }

}
else
{
    using (FileStream stream = File.Create(pathAlma))
    {
        
        xsA.Serialize(stream, almacenista);
    }


}


string pathProfe = Combine(CurrentDirectory, "profesor.xml");
if(Path.Exists(pathProfe))
{
    // lo deserializas
    using (FileStream xmlLoad = File.Open(pathProfe,FileMode.Open))
    {
       
        profesor = xsP.Deserialize(xmlLoad) as List<Profesor>;
  
    }

}
else
{
    using (FileStream stream = File.Create(pathProfe))
    {
        
        xsP.Serialize(stream, profesor);
    }


}

while(validar == false)
{
    WriteLine("//Inicio de Sesion//");
    Write("Usuario: ");
    string? us = ReadLine();
    Write("Contraseña: ");
    string? ps = ReadLine();
    if(string.IsNullOrWhiteSpace(ps) == false || string.IsNullOrWhiteSpace(us) == false)
    {
         validar = func.Login(us,func.GetMD5(ps!));
    }
   
 
}

    

        

bool salir = false;
while(salir == false)
{
WriteLine("Bienvenido Usuario, Que te gustaria hacer?");
WriteLine("1.- Agregar Profe");
WriteLine("2.- Editar Profe");
WriteLine("3.- Matar Profe");
WriteLine("4.- Cambiar Contrasena");
WriteLine("5.- Reportes");
WriteLine("6.- Salir");
Write("Ingresa una opcion: ");
string? opcion = ReadLine();





switch(opcion)
{
    case "1":
    {
        WriteLine("Agregaremos un nuevo profesor!!!");
        WriteLine("Ingresa los datos de este profesor");
        Write("Nomina: ");
        string? nomina = ReadLine();
        Write("Nombre(s): ");
        string? nombre = ReadLine();
        Write("Apellidos: ");
        string? ape = ReadLine();
        Write("Contrasena: ");
        string? pass = ReadLine();
        Write("Division: ");
        string? division = ReadLine();
        if( string.IsNullOrWhiteSpace(nomina)|| string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(ape) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(division))
        {
            WriteLine("Falto algun dato por ingresar!!!");
            break;
        }
        Profesor agregar = new(func.GetMD5(nomina!), nombre, ape, func.GetMD5(pass!), division);
        
        
        profesor!.Add(agregar);

       

        
      
        using (FileStream stream = File.Create(pathProfe))
        {
            xsP.Serialize(stream, profesor);
        }
        break;
    }

    case "2":
    {
        bool regreso;
        WriteLine("Vamos a editar los datos de un profesor");
        Write("Que maestro buscas modificar? Ingresa el nombre: ");
        string? nombre = ReadLine();
        WriteLine("Que dato gustas alterar?");
        WriteLine("1.- Nomina");
        WriteLine("2.- Nombre(s)");
        WriteLine("3.- Apellidos");
        WriteLine("4.- Contraseña");
        WriteLine("5.- Agregar Materias");
        WriteLine("6.- Quitar Materias");
        WriteLine("7.- Division");
        Write("Ingresa una opcion: ");
        string? op = ReadLine();
        if(op == "5" || op == "6")
        {
            WriteLine("Que materia quieres Agregar/Eliminar?");
            Write("R: ");
            string? mat = ReadLine();
            regreso = func.Materia(nombre,op,mat);
            if(regreso is true)
            {
                WriteLine("Operacion Exitosa");
            }
            else
            {
                WriteLine("Operacion Fallida");
            }
            // aqui actualizariamos los xml y json
           break;
        }

        Write("Ahora, ingresa el nuevo valor: ");
        string? nuevo = ReadLine();
        regreso = func.Cambiar(nombre, op, nuevo);
        if(regreso is true)
        {
            WriteLine("Operacion Exitosa");
        }
        else
        {
            WriteLine("Operacion Fallida");
        }




        break;
    }

    case "3":
    {
        WriteLine("Bueno, como gustes");
        Write("Ingresa el nombre del maestro a MATAR Mua ja-ja-ja-ja-ja-ja-ja: ");
        string? nom = ReadLine();
        bool estado = func.Eliminar(nom);
        if (estado is true)
        {
            WriteLine("Aniquiliación exitosa");
        }
        else
        {
            WriteLine("No encontramos al objetivo");
        }

        break;
    }

    case "4":
    {
        bool regreso = false;
        WriteLine("Correcto, a quien le quieres cambiar la contraseña?");
        WriteLine("1.- Almacenista");
        WriteLine("2.- Maestro");
        Write("R: ");
        string? caso = ReadLine();
        WriteLine("Cual es su nombre?");
        string? nom = ReadLine();
        Write("Ingresa la nueva contraseña: ");
        string? con = ReadLine();
        if(caso == "2")
        {
            regreso = func.Cambiar(nom, "4", con);

        }
        else if(caso == "1")
        {
            regreso = func.Contra(nom,con);

        }

        if(regreso is true)
        {
            WriteLine("Operacion Exitosa");
        }
        else
        {
            WriteLine("Operacion Fallida");
        }

        
        break;
    }

    case "5":
    {
        break;
    }

    case "6":
    {
        WriteLine("hasta luego!!!");
        salir = true;
        break;
    }

    default:
    {
        WriteLine("Opcion Incorrecta!!!");
        break;
    }
}

}