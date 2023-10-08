using System.Runtime.InteropServices;
using AlmacenLib;
using static System.Environment;
using static System.IO.Path;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics.SymbolStore;

Funciones func = new();
bool validar = false;

List<Profesor>? profesor = new()
{
    new("2683692","Gerardo","Ruiz Cabañas","contraseña","Programacion","Programacion Avanzada"),
    new("9739726","Ochoa","Beltral Alatorre","p4sw0rD","Redes","Sistemas Operativos"),
    new("2568361","Octavio","Lopez Trujillo","5032005","Electronica","Temas de Electronica"),
    new("8369827","Mario","Mario","ravioli","Fontaneria","Conduccion"),
    new("4649976","Luis","Mario","boo","Paranomalidad","Caceria de Fantasmas")


};
List<Almacenista>? almacenista = new()
{
    new("Gael", "Gamez", func.GetMD5("1234")),
    new("Emiliano", "Rodriguez", func.GetMD5("4321")),
    new("Uriel", "Garcia", func.GetMD5("5678")),
    new("Oscar", "Penilla", func.GetMD5("8765")),
    new("Ricardo", "Solorzano", func.GetMD5("fnaf"))

};
List<Alumno>? alumnos = new()
{
    new("20300703","Luis","Martinez Ferrer", "qwer", "SL1","SL2","SL3"),
    new("20300892","Luisa","Hernandez Plaza", "rewq", "LE1","LE2","LE3"),
    new("20300445","Fernanda","Gomez Lopez", "iuyt", "SLA","SLB","SLC"),
    new("20300763","Alberto","De la Cruz Diaz", "tyui", "LE1","LE1","LE3"),
    new("20100001","Antonio","Fox", "mipapaesfox", "SL1","SL2","SL3")
};
List<Salon>? salones = new()
{
    new("SLA", "7F1","4H1","5J1","Gerardo","Ochoa","Octavio"),
    new("SLB", "6F1","3H1","4J1","Gerardo","Mario","Octavio"),
    new("SLC", "5F1","2H1","3J1","Gerardo","Mario","Luis"),
    new("LE1", "4F1","1H1","2J1","Luis","Mario","Octavio"),
    new("LE2", "3F1","5H1","1J1","Ochoa","Mario","Luis")
};


XmlSerializer xsA = new(type: almacenista.GetType());
XmlSerializer xsP = new(type: profesor.GetType());
XmlSerializer xsH = new(type: alumnos.GetType());
XmlSerializer xsS = new(type: salones.GetType());

string JpathAlma = Combine(CurrentDirectory, "almacenista.json");
File.WriteAllText(JpathAlma,JsonSerializer.Serialize(almacenista));
string JpathAlumno = Combine(CurrentDirectory, "alumno.json");
File.WriteAllText(JpathAlumno,JsonSerializer.Serialize(alumnos));
string JpathProfesor = Combine(CurrentDirectory, "profesor.json");
File.WriteAllText(JpathProfesor,JsonSerializer.Serialize(profesor));
string JpathSalon = Combine(CurrentDirectory, "salon.json");
File.WriteAllText(JpathSalon,JsonSerializer.Serialize(salones));






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

string pathAlumno = Combine(CurrentDirectory, "alumno.xml");
if(Path.Exists(pathAlumno))
{
    
    // lo deserializas
    using (FileStream xmlLoad = File.Open(pathAlumno,FileMode.Open))
    {
       
        alumnos = xsH.Deserialize(xmlLoad) as List<Alumno>;
  
    }

}
else
{
    using (FileStream stream = File.Create(pathAlumno))
    {
        
        xsH.Serialize(stream, alumnos);
    }


}
string pathSalon = Combine(CurrentDirectory, "salon.xml");
if(Path.Exists(pathSalon))
{
    
    // lo deserializas
    using (FileStream xmlLoad = File.Open(pathSalon,FileMode.Open))
    {
       
        salones = xsS.Deserialize(xmlLoad) as List<Salon>;
  
    }

}
else
{
    using (FileStream stream = File.Create(pathSalon))
    {
        
        xsS.Serialize(stream, salones);
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
        Write("Materia: ");
        string? materia = ReadLine();
        if( string.IsNullOrWhiteSpace(nomina)|| string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(ape) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(division) || string.IsNullOrWhiteSpace(materia))
        {
            WriteLine("Falto algun dato por ingresar!!!");
            break;
        }
        Profesor agregar = new(func.GetMD5(nomina!), nombre, ape, func.GetMD5(pass!), division, materia);
        

        profesor!.Add(agregar);
        profesor = profesor!.OrderBy(x=> x.Materias!.FirstOrDefault()).ToList();

       

        
      
        using (FileStream stream = File.Create(pathProfe))
        {
            xsP.Serialize(stream, profesor);
        }

        File.WriteAllText(JpathAlma,JsonSerializer.Serialize(almacenista));

        File.WriteAllText(JpathAlumno,JsonSerializer.Serialize(alumnos));

        File.WriteAllText(JpathProfesor,JsonSerializer.Serialize(profesor));

        File.WriteAllText(JpathSalon,JsonSerializer.Serialize(salones));
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
        bool regreso;

        WriteLine("Ok, con que quieres hacer un reporte, Perfecto");
        WriteLine("Y en base a que dato lo quieres ordenar?");
        WriteLine("1.- Nomina");
        WriteLine("2.- Nombre(s)");
        WriteLine("3.- Apellidos");
        WriteLine("4.- Contraseña");
        WriteLine("5.- Materias");
        WriteLine("7.- Division");
        Write("Ingresa una opcion: ");
        string? op = ReadLine();
        Write("Perfecto, ingresa un nombre para el archivo: ");
        string? nom = ReadLine();
        regreso = func.Reporte(op,nom);
        if(regreso is true)
        {
            WriteLine("Operacion exitosa");
            string newpath = Combine(GetFolderPath(SpecialFolder.MyDocuments), nom + ".xml" );
            WriteLine($"Tu documento esta en: {newpath}");

        }
        else
        {
            WriteLine("Operacion fallida");

        }
        
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