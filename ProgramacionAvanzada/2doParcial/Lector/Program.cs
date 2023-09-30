//Este es el codigo principal, asistido por Program.Functions donde se tiene todas las funciones necesarias
// esto con el fin de tener todo bien ordenado 

using static System.IO.Directory; 
using static System.IO.Path; 
using static System.Environment;
using System.Text;
//primero las librerias para todo el  manejo y uso de direcciones y directorios :p



string AgregaTuTexto = Combine(GetFolderPath(SpecialFolder.MyDocuments), "AgregaTuTexto"), dir;
WriteLine("Hola apreciado usuario, ve preparando un archivo de texto!!!");
WriteLine($"Se ha creado una nueva carpeta para que agregues ahi tu archivo {AgregaTuTexto}");
CreateDirectory(AgregaTuTexto);

if(Path.Exists(AgregaTuTexto))
{
    WriteLine($"Se ha creado una nueva carpeta para que agregues ahi tu archivo {AgregaTuTexto}");
}
else
{
    WriteLine("Oh no, un desafortunado error ha ocurrido");

}

dir = busqueda(AgregaTuTexto);

while(dir.Equals("noup"))
{
    dir = busqueda(AgregaTuTexto);
}


StreamReader textReader = File.OpenText(dir);
string texto = textReader.ReadToEnd();
textReader.Close();
texto = texto.ToLower();
WriteLine(texto);

texto = Vocales(texto, 'a');
texto = Vocales(texto, 'e');
texto = Vocales(texto, 'i');
texto = Vocales(texto, 'o');
texto = Vocales(texto, 'u');


StreamWriter textWriter = File.CreateText(dir);
textWriter.WriteLine(texto);
textWriter.Close();
