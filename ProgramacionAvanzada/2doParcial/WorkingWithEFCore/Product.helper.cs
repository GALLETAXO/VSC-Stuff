


using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;

namespace WorkingWithEFCore;

public static partial class ProductExtensions // los metodos que hacen toda la magia :3
{
    public static int Moda(this List<Product> prod, int col) // aqui tenemos el metodo destinado a los valores Int 
    {
        int[] prev = {0,0}; // aqui guardaremos el caracter provisional, en uno guardamos el numero y en el otro las veces que se repitio
        int cuenta; // con esta variable llevamos la cuenta de el numero que estamos contando en ese momento

        List<int> datos = new(); // creamos una lista de Int donde guardaremos todos los valores de la columna que se necesite
        for(int x = 0; x < prod.Count; x++) // iremos guardando valor por valor
        {
            switch(col) // gracias a este switch determinamos de que columna estamos sacando los datos
            {
                case 1:
                {
                    
                    datos.Add(prod[x].ProductId); // vamos a la posicion en la lista productos y obtenemos el valor en cuestion para agregarlo a nuestra lista de int 
                    break;
                }
                case 2:
                {
                    
                    datos.Add(prod[x].Stock); 
                    break;
                }
                case 3:
                {
                    
                    datos.Add(prod[x].CategoryId);
                    break;
                }
                default:
                {
                    datos.Add(0); // caso malicioso en el que se llame mal la funcion :p
                    break;
                }
            }
        }

        

        for(int x = 0; x < datos.Count; x ++) // ahora, aqui ocurre la magia, iremos contando cuantas veces aparece cada caracter en la lista
        {
            cuenta = 0; // reiniciamos la cuenta
            
            for(int y = 0; y < datos.Count; y ++) // comparamos un caracter con todo los demas de la lista
            {

                if(datos[x] == datos[y]) // si encuentra una coinsidencia sumará la cuenta
                {
                    cuenta++;
                }

            }

            if(cuenta > prev[1]) // si al acabar con un caracter, la cuenta actual es mayor a la del caracter con mayor numero de apariciones, este se hara el nuevo caracter ms repetido
            {
                prev[0] = datos[x];
                prev[1] = cuenta;
            }
                     
        }
        return prev[0]; // al finalizar de todo ahora regresaremos el valor con mayor cantidad de coinsidencias


    }


public static decimal? Moda(this List<Product> prod, decimal col) // funciona igual que el metodo anterior, solo que esta adaptado a a usar el tipo decimal
    {

        decimal?[] prev = {0,0}; // cambiamos a un arreglo de decimales para alojar correctamente el valor de los costos
        int cuenta;


        for(int x = 0; x < prod.Count; x ++) // se hace el mismo proceso, el cambio mas drastico ademas del decimal, es que ahora obtenemos los valores directamente de la lista de producos 
        {
            cuenta = 0;
            
            for(int y = 0; y < prod.Count; y ++)
            {

                if(prod[x].Cost == prod[y].Cost)
                {
                    cuenta++;
                }

            }

            if(cuenta > prev[1])
            {
                prev[0] = prod[x].Cost;
                prev[1] = cuenta;
            }
                     
        }
        return prev[0];


    }


    public static double Media(this List<Product> prod, int col) // en este caso, hacemos algo similar, int col, nos funciona para diferenciar que esta funcion acepta int's 
    {
        switch(col) // usamos col para  determinar la columna de la que sacamos los datos
        {
            case 1:
            {
                return prod.Average(p=>p.ProductId); // simplemente sacamos el promedio de los datos de la columna en cuestion
            }
            case 2:
            {
                return prod.Average(p=>p.Stock);
            }
            case 3:
            {
                return prod.Average(p=>p.CategoryId);
            }
            default:
            {
                break;
            }
        }
        return 0;
    }

    public static decimal? Media(this List<Product> prod, decimal col) // funciona de igual forma que la de int's, solo que ahora con decimal 
    {
        return prod.Average(p=>p.Cost); // al no tener mas columnas con decimales, sabemos que nos referimos a cost, por lo que le sacamos directamente el promedio y listo
    }

    public static decimal Mediana(this List<Product> prod, int col) // para el caso de la mediana de int
    {
        int med = 0; // aqui guardaremos el resultado de la mediana
        int inter =prod.Count/2; // obtenemos la posicion donde se aloja la mediana
        inter++; // lo ajustamos un poco jsjs
        switch(col)
        {
            case 1: //  hacemos el mismo proceso en los 3 casos, lo que varia es la columna en cual nos basamos para ordenarlos y el dato de la mediana
            {
                prod = prod.OrderBy(p=>p.ProductId).ToList(); // ordenamos los datos en base a la columna
                if((prod.Count % 2) > 0) // revisamos que tengamos una cantidad par o inpar de datos
                {
                    return prod[inter-1].ProductId; // en el caso de ser impar, solo obtenemos el valor que este justamente en medio de todos
                }
                else
                {
                    med = prod[prod.Count/2].ProductId + prod[(prod.Count/2) + 1].ProductId; // para el caso de que la cantidad sea par, obtendriamos un promedio de ambos datos que estan a la mitad
                    return med/ 2; // regresarios dicho promedio 
                }
            }
            case 2: // hacemos el mismo proceso pero para las otras columnas
            {
                prod = prod.OrderBy(p=>p.Stock).ToList();
                if((prod.Count % 2) > 0)
                {
                    return prod[inter].Stock;
                }
                else
                {
                    med = prod[prod.Count/2].Stock + prod[(prod.Count/2) + 1].Stock;
                    return med/ 2;
                }
            }
            case 3: // hacemos el mismo proceso pero para las otras columnas
            {
                prod = prod.OrderBy(p=>p.CategoryId).ToList();
                if((prod.Count % 2) > 0)
                {
                    return prod[inter].CategoryId;
                }
                else
                {
                    med = prod[prod.Count/2].CategoryId + prod[(prod.Count/2) + 1].CategoryId;
                    return med/ 2;
                }
            }
            default: // en caso de que se ingrese el dato de forma erronea solo se regresara un triste 0 :/
            {
                break;
            }
        }

  

        return 0;
    }

    public static decimal? Mediana(this List<Product> prod, decimal col) // el proceso es el mismo para los datos decimales, lo que cambia es que como sabes la columna, no hay necesidad de hacer un int
    {
        int inter =prod.Count/2;
        inter++;
        prod = prod.OrderBy(p=>p.Cost).ToList();
        if((prod.Count % 2) > 0)
        {
            return prod[inter].Cost;
        }
        else
        {
            decimal? med = 0;
            med = prod[prod.Count/2].Cost + prod[(prod.Count/2) + 1].Cost;
            return med/ 2;
        }
    }

    public static bool Moda(this List<Product> prod, bool col) // para obtener la moda hacemos lo siguiente
    {
        int t = 0, f = 0; // variables para contar las veces que aparece un falso o un verdadero

        for(int x = 0; x < prod.Count; x ++) // revisamos cada dato de la columna
        {
            if(prod[x].Discontinued) // si este dato es verdadero sumaremos a la variable t
            {
                t++;
            }
            else // de no serlo, significa que es falso, sumamos a f 
            {
                f++;
            }    
        }

        if( t > f) // en caso de que t sea mayor a f, regresaremos un true, ya que es el valor que mas se repite
        {
            return true;
        }
        else // caso contrario regresaremos un false, por que es el que mas se repite
        {
            return false;
        }
        
    }

    public static float Media(this List<Product> prod, bool col) // para la media de los bool
    {
        float f = 0, t = 0; // tendremos dos variables, f, para la cantidad de valores falsos encontrados y t para el resultado jiji
        for(int x = 0; x < prod.Count; x ++) // revisamos todos los valores de la columna
        {
            if(prod[x].Discontinued == false) // si es falso, sumaremos a f 
            {
                f++;
            }
        }

        t = f * 100; // sacaremos el porcentaje de falsos en esta columna
        return t/prod.Count; // segun la cantidad de datos 
        
    }


    public static int Mediana(this List<Product> prod, bool col) // la mediana es algo curioso
    {
        int inter =prod.Count/2; // determinamos la posicion del dato que este en el centro
        inter++;
        prod = prod.OrderBy(p=>p.Discontinued).ToList(); // ordenamos los datos segun la columna discontinued
        if((prod.Count % 2) > 0) // si tenemos una cantidad de datos impar 
        {
            if(prod[inter-1].Discontinued) // revisaremos el valor de el dato en mero en medio
            {
                return 1; // si es verdadero regresaremos un 1, indicando que es verdadero
            }
            else
            {
                return 2; // un dos si es falso 
            }
            
        }
        else
        { 
            return 3; // regresaremos un 3 si la cantidad es par, indicando que justo en medio puede hacer true y false al mismo tiempo 
        }
    }


    public static char Moda(this List<Product> prod, string col) // aqui llega lo divertido :D
    {
        string all = ""; // crearemos un string donde guardaremos TODAS las palabras en la columna deseada

        switch(col) // determinamos de que columna obtendremos los datos
        {
            case "N": // N para nombres de productos
            {
                foreach(var product in prod)// revisaremos 1 por 1 cada valor de nombre
                {
                    all = all +product.ProductName; // y lo sumaremos a nuestro string
                }

                break;
            }
            case "C": // C para Quantity jsjsjs
            {
                foreach(var product in prod) // revisamos dato por dato 
                {
                    all = all +product.Quantity; // y lo agregamos al string
                }

                break;
            }
            default: // en caso de error no hay nada :p
            {
                return ' ';
            }

        }

        all = Regex.Replace(all.Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", ""); // le quitaremos tod rastro de acento o caracter malicioso
        all = all.Replace(" ", ""); // erradicaremos todos los espacios

        
        int cuenta, ant = 0; // esta parte se parece a los otros procedimientos para sacar la moda, cuenta es las veces que se repite el caracter actual y ant, las veces que se repitio el anterior mas repetido :p
        char prev = ' '; // aqui guardaremos el caracter que mas se repita

        for(int x = 0; x < all.Length; x ++) // revisamos caracter pro caracter 
        {
            cuenta = 0; // reiniciamos la cuenta 
            
            for(int y = 0; y < all.Length; y ++) // revisaremos cada caracter con todos los demas
            {

                if(all[x] == all[y]) // comparamos, si hay coinsidencia, la cuenta aumentara 
                {
                    cuenta++;
                }

            }

            if(cuenta > ant) // si nuestra cuenta actual es mayor que la anterior mas grande, estos valores pasaran a ser los mas repetidos 
            {
                prev = all[x];
                ant = cuenta;
            }
                     
        }




        return prev; // regresaremos el caracter mas repetido 
    }

    public static double Media(this List<Product> prod, string col) // la funcion de media para strings Omg
    {

        double res = 0; // aqui guardaremos el resultado y lo retornaremos

        string all = ""; // nuestro string para guardar guardar todas las palabra

        switch(col) // seguimos el mismo proceso de guardar en un string todas las palabras de una u otra columna
        {
            case "N":
            {
                foreach(var product in prod)
                {
                    all = all +product.ProductName;
                }

                break;
            }
            case "C":
            {
                foreach(var product in prod)
                {
                    all = all +product.Quantity;
                }

                break;
            }
            default:
            {
                return ' ';
            }

        }

        all = Regex.Replace(all.Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", ""); // tambien le quitamos cualquier acento o modificacion a los caracteres
        all = all.Replace(" ", ""); // quitamos todos los espacios

        for(int x = 0; x < all.Length; x ++) // ahora iremos caracter por caracter del string, sumaremos el valor de cada char a res 
        {
            res = res + all[x]; // :,)
        }

        res = res/ all.Length; // sacaremos la media segun la cantidad de caracteres del string

        return res;

    }

    public static string Mediana(this List<Product> prod, string col) // ahoratenemos la funcion para la mediana
    {

        List<char> car = new();  // es una mouse-querramienta que nos ayudara mas tarde >:), basicamente es una lista de char donde guardaremos un cada caracter de cada palabra de las columna deseada
        string all = ""; // que por que con una lista? Por que estoy Loooooco., en fin, la misma variable para guardar todo el texto 

        switch(col) // realizamos el mismo procedimiento de guardar todas las palabras de la columna en un solos string
        {
            case "N":
            {
                foreach(var product in prod)
                {
                    all = all +product.ProductName;
                }

                break;
            }
            case "C":
            {
                foreach(var product in prod)
                {
                    all = all +product.Quantity;
                }

                break;
            }
            default:
            {
                return " ";
            }

        }

        all = Regex.Replace(all.Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "");
        all = all.Replace(" ", ""); // le quitamos espacios,  acentos y todo lo que pueda estorbar


        for(int x = 0; x < all.Length; x ++) // aqui esta la perversion, agregamos una por una todas las letras de todas las palabras de la columna a una lista de chars
        {
            car.Add(all[x]); // basicamente esto es con el fin de ordenar las letras jsjsjs
        }

        car = car.Order().ToList(); // ordenamos la lista 


        
        int inter =car.Count/2; // hacemos un proceso similar a las otras medianas, obtenemos la posicion del valor que esta en medio 
        string res = " "; // aqui guardaremos el resultado, es un string ya que como puede hacer dos valores enmendio, de esta forma mandamos los dos valores sin problemas
        inter++;
        if((car.Count % 2) > 0) // si la cantidad de valores es impar, mandaremos el valor que este justo al medio
        {
            res = res + car[inter];
        }
        else
        {
            res = res + car[car.Count/2]; // caso contrario, mandaremos los 2 valores que estan al medio, esto para poder mandar caracteres y no tener que mandar un promedio de los valores de mabos caracteres :p 
            res = res + car[inter];
        }
        return res; // regresamos el resultado en cuestion :p

    }







    








}