using System.Runtime.InteropServices;
using AlmacenLib;
using static System.Environment;
using static System.IO.Path;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using FastJson = System.Text.Json.JsonSerializer;
using System.Diagnostics.SymbolStore;

// las librerias que necesitaremos para el codigazo :D

Funciones func = new(); // creamos un objeto de la clase func, donde estan todas las funciones que utilizamos en el programa, por que se hace asi?
// bueno esto es para tener todo en un mismo lugar y tratar de hacer las funciones mas "modulares" digamos, ademas, asi podemos usar un mismo archivo para muchas cosas
bool validar = false; // variable malvada declarada de una vez, se usará para validar que las acciones hechas por las funciones se completen correctamente
 //en esta parte estamos creando las listas de las 4 clases, decidi darles valores por defecto desde un inicio para no batallar ingresando datos a media clase
 // hacemos uso de los constructores para solo pasarles los datos de una forma mas practica 
List<Profesor>? profesor = new() 
{
    new(func.GetMD5("2683692"),"Gerardo","Ruiz Cabañas",func.GetMD5("contraseña"),"Programacion","Programacion Avanzada"),
    new(func.GetMD5("9739726"),"Ochoa","Beltral Alatorre",func.GetMD5("p4sw0rD"),"Redes","Sistemas Operativos"),
    new(func.GetMD5("2568361"),"Octavio","Lopez Trujillo",func.GetMD5("5032005"),"Electronica","Temas de Electronica"),
    new(func.GetMD5("8369827"),"Mario","Mario",func.GetMD5("ravioli"),"Fontaneria","Conduccion"),
    new(func.GetMD5("4649976"),"Luis","Mario",func.GetMD5("boo"),"Paranomalidad","Caceria de Fantasmas")


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
    new("20300703","Luis","Martinez Ferrer", func.GetMD5("qwer"), "SL1","SL2","SL3"),
    new("20300892","Luisa","Hernandez Plaza", func.GetMD5("rewq"), "LE1","LE2","LE3"),
    new("20300445","Fernanda","Gomez Lopez", func.GetMD5("iuyt"), "SLA","SLB","SLC"),
    new("20300763","Alberto","De la Cruz Diaz", func.GetMD5("tyui"), "LE1","LE1","LE3"),
    new("20100001","Antonio","Fox", func.GetMD5("mipapaesfox"), "SL1","SL2","SL3")
};
List<Salon>? salones = new()
{
    new("SLA", "7F1","4H1","5J1","Gerardo","Ochoa","Octavio"),
    new("SLB", "6F1","3H1","4J1","Gerardo","Mario","Octavio"),
    new("SLC", "5F1","2H1","3J1","Gerardo","Mario","Luis"),
    new("LE1", "4F1","1H1","2J1","Luis","Mario","Octavio"),
    new("LE2", "3F1","5H1","1J1","Ochoa","Mario","Luis")
};


profesor = profesor!.OrderBy(x=> x.Materias!.FirstOrDefault()).ToList(); // reorganizamos la lista de profesores

// en esta parte ya iniciamos con la serializacion de las clases para pasarlas a los archivos xml y json
// aqui hacemos el serializador de cada tipo de lista 
XmlSerializer xsA = new(type: almacenista.GetType());
XmlSerializer xsP = new(type: profesor.GetType());
XmlSerializer xsH = new(type: alumnos.GetType());
XmlSerializer xsS = new(type: salones.GetType());


// en estas partes estaremos heciendo la direccion donde se guardaran los xml, ademasm revisaremos si exixte ya el xml, en caso positivo, lo deserializaremos para usar esos datos, 
// en el caso contrario usaremos nuestros datos por defecto 
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


// en esta parte hacemos el lugar donde se crearan los archivos json, a la vez que escribimos estos documentos con los datos de nuestras listas hasta ahora
string JpathAlma = Combine(CurrentDirectory, "Persona.json");
    using (StreamWriter jsonStream = File.CreateText(JpathAlma))
    {
        WriteLine($"Written {new FileInfo(JpathAlma).Length} bytes of Json to {JpathAlma}");
        Newtonsoft.Json.JsonSerializer jss = new();
        jss.Serialize(jsonStream, almacenista);
    }
string JpathAlumno = Combine(CurrentDirectory, "alumno.json");
File.WriteAllText(JpathAlumno,JsonSerializer.Serialize(alumnos));
string JpathProfesor = Combine(CurrentDirectory, "profesor.json");
File.WriteAllText(JpathProfesor,JsonSerializer.Serialize(profesor));
string JpathSalon = Combine(CurrentDirectory, "salon.json");
File.WriteAllText(JpathSalon,JsonSerializer.Serialize(salones));

// aqui tenemos el inicio de sesion 
while(validar == false) // se repetira hasta que ingreses los datos correctos 
{
    WriteLine("//Inicio de Sesion//"); 
    Write("Usuario: ");
    string? us = ReadLine(); // preguntamos por el nombre del almacenista
    Write("Contraseña: ");
    string? ps = ReadLine(); // su contraseña
    if(string.IsNullOrWhiteSpace(ps) == false || string.IsNullOrWhiteSpace(us) == false) // revisamos que si nos proporcionara datos 
    {
         validar = func.Login(us,func.GetMD5(ps!)); // le mandamos a nuetra funcion de log in los datos, junto con la contraseña ya encriptada para facilitar el proceso
    }
   
 
}

    

        
// pasado el inicio de sesion, se presenta a el menu
bool salir = false;
while(salir == false) // se repetira hasta que el usuario quiera salir
{
WriteLine("Bienvenido Usuario, Que te gustaria hacer?"); // presentamos las opciones
WriteLine("1.- Agregar Profe");
WriteLine("2.- Editar Profe");
WriteLine("3.- Matar Profe");
WriteLine("4.- Cambiar Contrasena");
WriteLine("5.- Reportes");
WriteLine("6.- Salir");
Write("Ingresa una opcion: ");
string? opcion = ReadLine(); // leemos la opcion





switch(opcion) // aqui inicia la realizacion de cada opcion
{
    case "1":
    {
        // en el caso de agregar profesor, lo hacemos directamente en el main, por que? por que se hace hace gran cosa, por lo que seria mas enredoso hacerlo una funcion 
        WriteLine("Agregaremos un nuevo profesor!!!");
        WriteLine("Ingresa los datos de este profesor"); // pedimos los datos para el profesor 
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
            WriteLine("Falto algun dato por ingresar!!!"); // revisamos que todos los datos sean ingresados
            break;
        }
        Profesor agregar = new(func.GetMD5(nomina!), nombre, ape, func.GetMD5(pass!), division, materia); // creamos un objeto usando el contructor
        

        profesor!.Add(agregar); // añadimos ese objeto a la lista 
        profesor = profesor!.OrderBy(x=> x.Materias!.FirstOrDefault()).ToList(); // reorganizamos la lista 

       

        
        // a continuacion actualizamos nuestros archivos
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
        bool regreso; // en esta parte editaremos a un profesor 
        WriteLine("Vamos a editar los datos de un profesor");
        Write("Que maestro buscas modificar? Ingresa el nombre: "); // por lo que necesitamos el profesor a editar 
        string? nombre = ReadLine();
        WriteLine("Que dato gustas alterar?");
        WriteLine("1.- Nomina");
        WriteLine("2.- Nombre(s)");
        WriteLine("3.- Apellidos");
        WriteLine("4.- Contraseña");
        WriteLine("5.- Agregar Materias");
        WriteLine("6.- Quitar Materias");
        WriteLine("7.- Division");
        Write("Ingresa una opcion: "); // preguntamos por la accion a realizar 
        string? op = ReadLine();
        if(op == "5" || op == "6") // en el caso de que queramos eliminar o agregar una materia, usaremos una funcion distinta un dato distinto
        {
            WriteLine("Que materia quieres Agregar/Eliminar?"); // preguntaremos por la materia con la que se hara el proceso 
            Write("R: ");
            string? mat = ReadLine();
            regreso = func.Materia(nombre,op,mat); // le pasaremos a la funcion, el objetivo, la accion a hacer y  la materia en cuestion
            if(regreso is true) // aqui analizaremos lo que nos regreso la funcion, para determinar si el proceso se realizo o no 
            {
                WriteLine("Operacion Exitosa");
            }
            else
            {
                WriteLine("Operacion Fallida");
            }
            
           break;
        }

        Write("Ahora, ingresa el nuevo valor: "); // este es el caso para las demas opciones, donde deberas escribir el dato nuevo
        string? nuevo = ReadLine();
        regreso = func.Cambiar(nombre, op, nuevo); // le pasaremos estos datos a la funcion
        if(regreso is true) // revisaremos si la accion fue exitosa o no 
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
        WriteLine("Bueno, como gustes"); // en este caso aniliquilaremos a un maestro
        Write("Ingresa el nombre del maestro a MATAR Mua ja-ja-ja-ja-ja-ja-ja: ");
        string? nom = ReadLine(); // deberas dar su nombre
        bool estado = func.Eliminar(nom); // le pasaremos a la funcion el nombre del profesor a erradicar
        if (estado is true) // analizaremos el resultado como en los casos anteriores
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
        WriteLine("Correcto, a quien le quieres cambiar la contraseña?"); // aqui cambiaremos la contraseña, por lo que necesiitaremos determinar el objetivo
        WriteLine("1.- Almacenista");
        WriteLine("2.- Maestro"); // si es maestro o almacenista 
        Write("R: ");
        string? caso = ReadLine();
        WriteLine("Cual es su nombre?");// tambien necesitamos su nombre
        string? nom = ReadLine();
        Write("Ingresa la nueva contraseña: "); // y la nueva contraseña 
        string? con = ReadLine();
        if(caso == "2") // revisaremos si es el primer o segundo caso, ya que si haremos un cambio a un maestro, haremos uso de de la funcion anterior, mas sencillo
        {
            regreso = func.Cambiar(nom, "4", con);

        }
        else if(caso == "1") // en el caso de un almacenista, haremos uso de una funcion unica para el 
        {
            regreso = func.Contra(nom,con);

        }

        if(regreso is true) // analizaremos si la accion fue un exito o fracaso 
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
        bool regreso; // como nuestra ultima funcion, haremos un reporte de los maestros

        WriteLine("Ok, con que quieres hacer un reporte, Perfecto"); // para esto necesitaremos que el usuario elija segun que dato se ordenaran los profesores en el reporte 
        WriteLine("Y en base a que dato lo quieres ordenar?");
        WriteLine("1.- Nomina");
        WriteLine("2.- Nombre(s)");
        WriteLine("3.- Apellidos");
        WriteLine("4.- Contraseña");
        WriteLine("5.- Materias");
        WriteLine("7.- Division");
        Write("Ingresa una opcion: ");
        string? op = ReadLine();
        Write("Perfecto, ingresa un nombre para el archivo: "); // despues le pediremos un nombre para el archivo
        string? nom = ReadLine();
        regreso = func.Reporte(op,nom);
        if(regreso is true) // igual, revisaremos si la accion se realizo correctamente 
        {
            WriteLine("Operacion exitosa");
            string newpath = Combine(GetFolderPath(SpecialFolder.MyDocuments), nom + ".xml" );
            WriteLine($"Tu documento esta en: {newpath}"); // le diremos al usuario donde se guardará el archivo 

        }
        else
        {
            WriteLine("Operacion fallida");

        }
        
        break;
    }

    case "6":
    {
        WriteLine("hasta luego!!!"); // con esta funcion el usuario podra terminar el programa
        salir = true;
        break;
    }

    default: 
    {
        WriteLine("Opcion Incorrecta!!!"); // en el caso de que no ingreseuna opcion correcta 
        break;
    }
}

}