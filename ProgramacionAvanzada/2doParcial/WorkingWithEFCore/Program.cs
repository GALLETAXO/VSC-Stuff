using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using WorkingWithEFCore;

Northwind db = new();
WriteLine($"Provider : {db.Database.ProviderName}");



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

