using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using WorkingWithEFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Net.Http.Headers;

Northwind db = new();
WriteLine($"Provider : {db.Database.ProviderName}");


/*
string input;
int cuanta = 0;
bool go = false;

do
{

Console.Clear();
WriteLine("Escribe de cuanto en cuanto se mostrarán ej: 1, 5, 10, 25, 50, s para salir");
input = ReadLine()!;

switch(input)
{
    case "1":
    {
        cuanta = 1;
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
        go = false;
        break;

    }
}
if (go == false)
{
    paginator(cuanta);
}

}while(go == false);


*/



            List<Product> prod = db.Products!.ToList();


            WriteLine(prod.Moda(1));
            WriteLine(prod.Moda(2));
            WriteLine(prod.Moda(3));
            WriteLine(prod.Moda(1M));
            WriteLine(prod.Media(1));
            WriteLine(prod.Media(2));
            WriteLine(prod.Media(3));
            WriteLine(prod.Media(1M));
            decimal? var = prod.Mediana(1);
            WriteLine(var);
            var = prod.Mediana(2);
            WriteLine(var);
            var = prod.Mediana(3);
            WriteLine(var);
            var = prod.Mediana(1M);
            WriteLine(var);

            if(prod.Moda(true))
            {
                WriteLine("La moda es estar descontinuado");
            }
            else
            {
                WriteLine("La moda es  NO estar descontinuado");
            }

            WriteLine($"En promedio el {prod.Media(true)}% de los productos no han sido descontinuados");

            switch(prod.Mediana(true))
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

            WriteLine($"El caracter que mas se repite en los nombres(moda) es: {prod.Moda("N")}");
            WriteLine($"El caracter que mas se repite en la cantidad por unidad(moda) es: {prod.Moda("C")}");
            WriteLine($"La media de todos los valores de todos los caracteres de los nombres es: {prod.Media("N")}");
            WriteLine($"La media de todos los valores de todos los caracteres de la cantidad por unidades es: {prod.Media("C")}");
            WriteLine($"La mediana de todos los caracteres de los nombres es: {prod.Mediana("N")}");
            WriteLine($"La mediana de todos los caracteres de la cantidad por unidads es: {prod.Mediana("C")}");
            




            
            





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

