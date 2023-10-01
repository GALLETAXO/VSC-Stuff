//Este es el codigo principal, asistido por Program.Functions donde se tiene todas las funciones necesarias
// esto con el fin de tener todo bien ordenado 

using static System.IO.Directory; 
using static System.IO.Path; 
using static System.Environment;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;
//primero las librerias para todo el  manejo y uso de direcciones y directorios :p



string AgregaTuTexto = Combine(GetFolderPath(SpecialFolder.MyDocuments), "AgregaTuTexto"), dir;// empezamos armando la direccion donde ira el archivo de texto
WriteLine("Hola apreciado usuario, ve preparando un archivo de texto!!!");
if(Path.Exists(AgregaTuTexto))
{
    WriteLine($" La carperta ay se habia creado anteriormente, esta en: {AgregaTuTexto}"); // No hace falta crear la carpeta puesto que ya existe
}
else
{
    CreateDirectory(AgregaTuTexto); // creamos la carpeta en la direccion especificada anteriormente
     
}
if(Path.Exists(AgregaTuTexto))
{
    WriteLine($"Se ha creado una nueva carpeta para que agregues ahi tu archivo {AgregaTuTexto}");// le decimos la ubicacion de la carpeta donde debe agregar su archivo de texto 
}
else
{
    WriteLine("Oh no, un desafortunado error ha ocurrido"); // un mensaje de error por si las moscas
    Environment.Exit(0); 
}

dir = Busqueda(AgregaTuTexto); // llamamos a esta funcion para que busque el archivo de texto que agregaste 

while(dir.Equals("noup")) // en esta parte detectaremos si la busqueda fue un fracaso, para en ese caso repetirla
{
    dir = Busqueda(AgregaTuTexto);
}


StreamReader textReader = File.OpenText(dir); // ya que tenemos la direccion correcta, empezaremos con la lectura del archivo 
string texto = textReader.ReadToEnd(); // ingresaremos el archivo completo a un int, de esta forma lo analizaremos mas comodamente 
textReader.Close(); // cerramos la lectura
// en esta parte hacemos algunas "correcciones" al texto, mas que nada para que sea mas facil trabajar con el 
texto = texto.ToLower(); // hacemos que todo el texto este en minusculas 
texto = Regex.Replace(texto.Normalize(NormalizationForm.FormD), @"[\u0300-\u0301-\u0302]+", ""); // borramos los acentos, y la ^ buscandolos directamente por su unicode para manejar mejor el texto
texto = Regex.Replace(texto.Normalize(NormalizationForm.FormD), @"[\u0308]+", ""); // hacemos lo mismo con la dieresis 

StreamWriter textWriter = File.CreateText(dir); // empezamos con la edicion del archivo de texto, en el orden que se va mencionando en la asignacion
textWriter.WriteLine($"a - {Vocales(ref texto, 'a')}"); // en esta parte escribimos en el archivo cuantos ejemplares fuimos encontrando de cada vocal
textWriter.WriteLine($"e - {Vocales(ref texto, 'e')}"); // ya que le pasamos el texto por referencia, en la funcion le hacemos cambios a este mismo texto
textWriter.WriteLine($"i - {Vocales(ref texto, 'i')}"); // de esta forma la funcion puede usarse para regresar la cantidad de repeticiones de una vocal
textWriter.WriteLine($"o - {Vocales(ref texto, 'o')}"); // y de paso escribir en la ultima  ejemplar de cada vocal ese mismo numero
textWriter.WriteLine($"u - {Vocales(ref texto, 'u')}");
textWriter.WriteLine("");
textWriter.WriteLine(texto); // volovemos a escribir en el archivo el texto ya modificado

string bigpal = Palindromear(texto); // por ultimo hacemos la busqueda del palindromo, pasando el texto 
if(bigpal == string.Empty || bigpal.Length < 2)
{
    textWriter.WriteLine("No se encontro ningun Palindromo :( "); // en el caso de que lo que regrese este vacio, significa que no encontro palindromo
}
else
{
    textWriter.WriteLine($"El palindromo mas largo fue: {bigpal}"); // en el caso opuesto agregaremos el palindromo que encontro al archivo de texto 
}

textWriter.Close(); // cerraremos la escritura del archivo de texto

// fin :)

