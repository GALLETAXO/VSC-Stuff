// En este espacio se encuentran todas las funciones que despues se usaran en Program, con el fin de que este todo ordenado 
using static System.IO.Directory; 
using static System.IO.Path; 
using static System.Environment;
using System.Security.Cryptography.X509Certificates;

partial class Program
{

    static string  busqueda(string dir)
    {
        WriteLine("Ingresa el nombre del documento incluyendo su extension y presiona ENTER");
        String? input = ReadLine();
        try
        {
            
            string textFile = Combine (dir, input);
            if (textFile.Equals(dir))
            {
                WriteLine("No ingresaste ningun nombre, intentalo de nuevo, ENTER para continuar");
                ReadLine();
                return "noup";
            }

            if(Path.Exists(textFile))
            {
                WriteLine("Archivo encontrado!!!");
                return textFile;

            }
            else
            {
                WriteLine("Fracaso, intentalo de nuevo, ENTER para continuar");
                ReadLine();
                return "noup";


            }
            
        }
        catch(OverflowException)
        {
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
        catch (Exception ex)
        {
            WriteLine($"Oh Nooooo!!!  {ex.GetType} says {ex.Message}");
            WriteLine("Fracaso, intentalo de nuevo, ENTER para continuar");
            ReadLine();
            return "noup";
        }

        


    }

    static string Vocales(string texto, char letra)
    {
        int cont = 0, punto = 0;

        for(int i = 0; i < texto.Length; i++)
        {

            if(texto[i].Equals(letra))
            {
        
                cont++;
                punto = i;
            }
        }
        if (cont > 0)
        {

            texto = texto.Insert(punto, cont.ToString());
            cont = 0;
            for(int i = 0; i < texto.Length; i++)
            {

                if(texto[i].Equals(letra))
                {

                    cont++;
                    punto = i;
                }
        }

        texto = texto.Remove(punto, 1);
        WriteLine(cont);
        }
         return texto;

    }

    

    

    



}