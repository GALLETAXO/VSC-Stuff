// En este espacio se encuentran todas las funciones que despues se usaran en Program, con el fin de que este todo ordenado 
using static System.IO.Directory; 
using static System.IO.Path; 
using static System.Environment;
using System.Security.Cryptography.X509Certificates;

partial class Program
{

    static string  Busqueda(string dir) // esta funcion se encarga de buscar el archivo de texto que agregaste, en base a su nombre, el cual deberas proporcionarle
    {
        string textFile; // aqui guardaremos la direccion del archivo de texto
        WriteLine("Ingresa el nombre del documento incluyendo su extension y presiona ENTER");
        String? input = ReadLine(); // en esta parte solicitamos y recibimos el nombre junto con la extension del archivo de texto a revisar
        
        try
        {
            if(string.IsNullOrEmpty(input)) // en caso de no haberse ingresado nada, regresaremos un valor que se tomara como incorrecto para volver a intentar la busqueda
            {
                WriteLine("No ingresaste ningun nombre, intentalo de nuevo, ENTER para continuar");
                ReadLine();
                return "noup";

            }
            else // si recibimos un dato, este lo agregaremos a la direccion que ya teniamos de nuestra carpeta
            {
                textFile = Combine (dir, input);
            }
            if(Path.Exists(textFile))// posteriormente revisaremos si ese nombre ingresa efectivamente existe 
            {
                WriteLine("Archivo encontrado!!!");
               
                return textFile; // en caso positivo regresaremos la direccion completa del archivo de texto

            }
            else // en el caso opuesto indicaremos que no se encontro el archivo y pasaremos un noup en señal de que se debe volver a intentar la busqueda
            {
                WriteLine("Fracaso, intentalo de nuevo, ENTER para continuar");
                ReadLine();
                return "noup";


            }
            
        }
        catch(OverflowException) // puesto que estoy pidiendo al usuario que ingrese un valor,
        {                        //prefiero tomar precausiones y controlar algunas exepciones que igualmente reintentaran la busqueda
            WriteLine("Es un dato muy muy grande!!!");
            WriteLine("Fracaso, intentalo de nuevo, ENTER para continuar");
            ReadLine();
            return "noup";

        }
        catch(FormatException)
        {
            WriteLine("El dato que ingresaste no es valido!!!");
            WriteLine("Fracaso, intentalo de nuevo, ENTER para continuar");
            ReadLine();
            return "noup";

        }
        catch (Exception ex) // esta es una exepcion mas general por si llega a ocurrir algo no contemplado anteriormente
        {
            WriteLine($"Oh Nooooo!!!  {ex.GetType} says {ex.Message}");
            WriteLine("Fracaso, intentalo de nuevo, ENTER para continuar");
            ReadLine();
            return "noup";
        }

        


    }


    static int Vocales( ref string texto, char letra) // en esta funcion realizamos la busqueda de las vocales repetidas
    {
        
        int cont = 0, punto = 0;

        for(int i = 0; i < texto.Length; i++) // revisaremos cada espacion del texto que obtuvimos 
        {

            if(texto[i].Equals(letra)) // si una letra del texto coinside con la vocal que buscamos...
            {
        
                cont++; // aumentara el contador
                punto = i; // y guardaremos su ubicacion para en el caso de que sea la ultima, poder reemplazarla con la cuenta que llevos de la vocal 
            }
        }
        if (cont > 0) // en caso de haber encontrado aun que sea 1 vocal 
        {

            texto = texto.Insert(punto+1, cont.ToString()); // buscaremos la ultima vocal gracias a que guardamos su ubicacion y agregaremos la cuenta a un lado
            texto = texto.Remove(punto, 1); // posteriormente eliminaremos la vocal 
            // puesto que es muy probable que utilicemos numeros de mas de 1 cifra, es mas conveniente insertar el numero a un lado conocido, para despues borrar la letra
            
        }

        WriteLine($"{letra} - {cont}"); // finzalizamos mostrando en consola el numero de vocales encontrado, solo por comodidad
        return cont; // regresaremos la cantidad de ejemplares encontrados de la vocal especificada

    }


    static string Palindromear(string texto) // aqui realizaremos la busqueda del palindromo mas largo de todo el texto
    {
        string pal = ""; // creamos un string vacio para malvadamente ir agregando letra por letra cada palabra hasta encontra algo que no sea letra
        string bigpal = ""; // aqui iremos guardando los palindromos en caso de que sean mas grandes que el que ya habiamos encontrado
        int bigtam = 0; // el tamaño del palindromo mas grande, si ya se, ya era un poco tarde y se me hacia mas comodo asi jajaja


        for(int i = 0; i< texto.Length; i++) // revisaremos letra por letra el texto 
        {
            if(texto[i] > 96 && texto[i] < 123) // si lo que tiene en esa posicion el texto es una letra...
            {
              pal += texto[i]; // lo agregaremos a la palabra
            }
        else  // si no es una letra, significa que acabo nuestra palabra, por lo que podemos analizarla
        {
            
            int st = 0; // esta variable indica el inicio de la palabra
            bool def = true; 
            for(int j = pal.Length -1; j >= 0; j--) // revisamos cada letra
            {
                if(pal[st] == pal[j]) // si la primera y ultima letra son iguales seguiremos, revisando cada contraparte
                {
                    st++;
                }
                else // en el caso contrario...
                {
                    def = false; // definimos que esta palabra no es un palindromo y no la tomaremos en cuenta
                    break; // acabamos el for, ya que ya determinamos que no es un palindromo 

                }
           }

           if(def == true && pal.Length > bigtam ) // en esta parte, primero revisamos que la palabra ya sea validada como palindromo y 
            {                                      //luego revisamos si mide mas que nuestro anteior palindromo mas grande
                
                bigpal = pal; // si estas condiciones se cumplen, cambiaremos nuestro palindromo mas grande
               bigtam = pal.Length;

            }
    
           pal = ""; // luego borraremos la palabra 
        
        }
        }
        return bigpal; // al finalizar de revisar cada palabra, regresaremos el palindromo mas grande


    }

}