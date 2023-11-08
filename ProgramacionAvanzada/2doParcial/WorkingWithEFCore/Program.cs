using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using WorkingWithEFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Net.Http.Headers;

Northwind db = new(); 
WriteLine($"Provider : {db.Database.ProviderName}");



string input; // el dato que usaremos para determinar de cuanto en cuanto mostraremos las paginas
int cuanta = 0; // los datos que se mostraran por paginas 
bool go = false; // nos ayuda para crear un ciclo hasta que el usuario ingrese una s

do
{

Console.Clear();// borramos la consola para que sea mas entendible el asunto
WriteLine("Escribe de cuanto en cuanto se mostrarán ej: 1, 5, 10, 25, 50, s para salir");
input = ReadLine()!; // pedimos la opcion al usuario

switch(input) // vemos los casos segun la opcion
{
    case "1":
    {
        cuanta = 1; // en estos casos, determinamos la cantidad de elementos por pagina
        go = false;
        break;

    }
    case "5":
    {
        cuanta = 5;
        go = false;
        break;

    }
    case "10":
    {
        cuanta = 10;
        go = false;
        break;

    }
    case "25":
    {
        cuanta = 25;
        go = false;
        break;

    }
    case "50":
    {
        cuanta = 50;
        go = false;
        break;

    }
    case "s":
    {
        go = true;
        break;
    }
    default:
    {
        go = false; // si se ingresa un dato que no este contemplado, el ciclo se repetirá
        break;

    }
}
if (go == false)
{
    paginator(cuanta); // llamamos a nuestra funcion que muestra los datos, le decimos de cuanto en cuantos los queremos
}

}while(go == false); // salimos del ciclo cuando se ingrese una s





            List<Product> prod = db.Products!.ToList(); // obtenemos la tabla productos y la ingresamos a una lista

            Console.Clear(); // borramos la consola para hacerlo mas entendible
            WriteLine("ProductID"); // mostramos media, mediana y moda, de Product ID
            WriteLine(prod.Media(1)); // le pasamos un entero para que use la funcion que es especificamente para enteros, podemos pasarle un 1, 2 o 3
            WriteLine(prod.Mediana(1)); // si le pasamos un 1, significa que es ProductID, si es 2 es Stock, y si es 3, es CategoryID
            WriteLine(prod.Moda(1)); // esto aplica para las funciones de Media mediana y moda de enteros, se diferencian ya que estas reciben un int
            ReadLine();
            WriteLine("Stock"); // mostramos media, mediana y moda, del Stock
            WriteLine(prod.Media(2));
            WriteLine(prod.Mediana(2));
            WriteLine(prod.Moda(2));
            ReadLine();
            WriteLine("CategoryID"); // mostramos media, mediana y moda, de Category ID
            WriteLine(prod.Media(3));
            WriteLine(prod.Mediana(3));
            WriteLine(prod.Moda(3));
            ReadLine();
            WriteLine("Cost"); // mostramos media, mediana y moda, de Cost
            WriteLine(prod.Media(1M)); // en el caso de cost, tenemos una funcion que recibe decimal, de esa forma diferenciamos que es para cost
            WriteLine(prod.Mediana(1M)); // igualmente desde aqui le enviamos un decimal para que use la funcion que le corresponde
            WriteLine(prod.Moda(1M));
            ReadLine();


            WriteLine($"En promedio el {prod.Media(true)}% de los productos no han sido descontinuados");
            // aqui decido obtener el porcentaje de productos que han sido descontinuados, es lo mas cercano a una media que no sea simplemente la mitad de la cantidad de numeros

            switch(prod.Mediana(true)) // aqui la funcion regresa un valor del 1 al 3, esto para determinar si 1, el valor en medio es Verdadero, 2 es falso y 3, es par y puede haber valores verdaderos y falsos
            {
                case 1:
                {
                    WriteLine("Verdadero");
                    break;
                }
                case 2:
                {
                    WriteLine("Falso");
                    break;
                }
                case 3:
                {
                    WriteLine("Oh no, una paradoja");
                    break;
                }
                default:
                {
                    break;
                }
            }

             WriteLine("Discontinued"); // mostramos media, mediana y moda, de Discontinued
            if(prod.Moda(true)) // llamamos de esta forma a la funcion ya que la funcion devuelve el valor que mas se repitio, ya sea que fue falso o verdadero
            {
                WriteLine("La moda es estar descontinuado");
            }
            else
            {
                WriteLine("La moda es  NO estar descontinuado");
            }
            ReadLine();

            WriteLine("ProductName"); // mostramos media, mediana y moda de Product name
            WriteLine($"La media de todos los valores de todos los caracteres de los nombres es: {prod.Media("N")}"); // le pasamos un string para usar la funcion que trabaja con strings, nos devuelve el promedio de los valores  de cada caracter
            WriteLine($"La mediana de todos los caracteres de los nombres es: {prod.Mediana("N")}"); // aqui nos devolvera el caracter que este justo al medio, ordenando segun el valor de cada caracter
            WriteLine($"El caracter que mas se repite en los Nombres(moda) es: {prod.Moda("N")}"); // en este caso nos devuelve un char con la letra que mas se repitio
            ReadLine();
            WriteLine("Quantity");  // mostramos media, mediana y moda, de Quantity
            WriteLine($"La media de todos los valores de todos los caracteres de la cantidad por unidades es: {prod.Media("C")}");// le pasamos un string para usar la funcion que trabaja con strings, nos devuelve el promedio de los valores  de cada caracter
            WriteLine($"La mediana de todos los caracteres de la cantidad por unidads es: {prod.Mediana("C")}");// aqui nos devolvera el caracter que este justo al medio, ordenando segun el valor de cada caracter
            WriteLine($"El caracter que mas se repite en la cantidad por unidad(moda) es: {prod.Moda("C")}");// en este caso nos devuelve un char con la letra que mas se repitio

            

            




            
            





// QueryingCategories();
// FilterIncludes();
// QueryingProducts();
// QueryingWithLike();
// GetRandomProduct();

/*
#region CRUD
ListProducts();
    // Use of Create
    var resultAdd = AddProduct(categoryId: 6, productName: "La Pizza de Don Cangrejo", price: 500M);
    AddProduct(categoryId: 6, productName: "La Pizza de Don Cangrejo", price: 500M);
    AddProduct(categoryId: 6, productName: "La Pizza de Don Cangrejo", price: 500M);
    AddProduct(categoryId: 6, productName: "La Pizza de Don Cangrejo", price: 500M);
    if(resultAdd.affected == 1)
    {
        WriteLine($"Add product succesful with ID: {resultAdd.productId}");
    }
ListProducts(new int[] {resultAdd.productId});

// Use of Update
// var resultUpdate = UpdateProductPrice(productNameStartWith:"La ", amount:40M);
// if(resultUpdate.affected == 1)
// {
//     WriteLine($"Increase price success for ID : {resultUpdate.productId}");
// }
// ListProducts(productsToHiglight: new[] {resultUpdate.productId});

// Use of better Update
var resultUpdateBetter = UpdateProductPriceBetter(productNameStartWith: "La ", amount: 20M);
if(resultUpdateBetter.affected > 0)
{
    WriteLine("Increase product price succesful.");
}
ListProducts(resultUpdateBetter.productsId);

// Use of Delete and Better Delete
WriteLine("About to delete all products that start with La ");
Write("Press Enter to continue : ");
if(ReadKey(intercept: true).Key == ConsoleKey.Enter)
{
    int deleted = DeleteProductsBetter(productNameStartWith: "La ");
    WriteLine($"{deleted} product(s) were deleted");
}
else
{
    WriteLine("Delete was cancelced");
}

ListProducts();


#endregion

*/

