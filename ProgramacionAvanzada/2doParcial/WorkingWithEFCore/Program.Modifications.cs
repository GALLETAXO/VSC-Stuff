using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WorkingWithEFCore;

partial class Program
{
    // READ
    static void ListProducts(int[]? productsToHiglight = null)
    {
        using (Northwind db = new())
        {
            if((db.Products is null) || (!db.Products.Any()))
            {
                Fail("There are no products");
                return;
            }
            WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,5} | {4}",
            "Id", "Product Name", "Cost", "Stock", "Disc");


            foreach (var product in db.Products)
            {
                ConsoleColor backgroundColor = ForegroundColor;
                if((productsToHiglight is not null) && productsToHiglight.Contains(product.ProductId))
                {
                    ForegroundColor = ConsoleColor.Red;
                }
                WriteLine("| {0:000} | {1,-35} | {2,8:$#,##0.00} | {3,5} | {4}",
                product.ProductId, product.ProductName, product.Cost, product.Stock, product.Discontinued);
                ForegroundColor = backgroundColor;
            }
        }
    }



    static void paginator(int cuantas)
    {

        using (Northwind db = new())
        {
            Console.Clear();
            if((db.Products is null) || (!db.Products.Any()))
            {
                Fail("There are no products");
                return;
            }

            WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,5} | {4}",
            "Id", "Product Name", "Stock", "Disc", "Category");
       
            int cuenta = 0;
            int pagactual =0;
            IQueryable<Product> products = db.Products.Include(c => c.Category);
            List<Product> prod = products.ToList();

            prod.Find(x=> x.ProductId == 2);
            
            for(int x = 1; x <= prod.Count(); x ++)
            {
                
    
            
                Product product = prod.Find(p=> p.ProductId == x)!;
                
                
                string disco;
                if (product.Discontinued == true)
                {
                    disco = "Yes";
                }
                else
                {
                    disco = "No";
                }
                
                WriteLine("| {0:000} | {1,-35} | {2,8} | {3,5} | {4}",
                product.ProductId, product.ProductName, product.Stock, disco, product.Category.CategoryName);
                cuenta ++;

                if(cuenta == cuantas || x == prod.Count)
                {
                    pagactual++;
                    
                    int pags = products.Count() / cuantas;
                    WriteLine("___________________________________________________________________________");
                    WriteLine("| {0,-3} | {1,-35} |{2}",
                    cuantas, $"{pagactual}/{pags + 1}", products.Count());
                    bool go = false;
                    ConsoleKeyInfo z;

                    do 
                    {
                    z = ReadKey();
                    go = false;

                    switch(z.Key)
                    {
                        case ConsoleKey.RightArrow:
                        {
                            go = true;
                            Console.Clear();
                            WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,5} | {4}",
                            "Id", "Product Name", "Stock", "Disc", "Category");
                            if(x == prod.Count)
                            {
                                x = x - cuenta;
                                pagactual --;
                            }
                            break;
                        }

                        case ConsoleKey.LeftArrow:
                        {
                            go = true;
                            Console.Clear();
                        
                            WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,5} | {4}",
                            "Id", "Product Name", "Stock", "Disc", "Category");
                            if(x == prod.Count)
                            {
                                x = x - cuenta - cuantas;
                                pagactual = pagactual - 2;
                            }
                            else
                            {
                                x = x - (cuenta * 2);
                                pagactual = pagactual - 2;
                            }

                            if((x - cuantas) < 0 )
                            {
                                x = 0;
                                pagactual = 0;
                            }

                            if(x == prod.Count)
                            {

                            }
                            break;
                        }
                        case ConsoleKey.S:
                        {
                            return;
                        }

                        default:
                        {
                            go = false;
                            break;
                        }
                    }

                    }while(go == false);
                    cuenta = 0;

                    
                

                }
            


            }
        }



    }

    // Insert , Create
    static (int affected, int productId) AddProduct(int categoryId, string productName, decimal? price)
    {
        using(Northwind db = new())
        {
            if(db.Products is null) return (0,0);
            Product p = new()
            {
                CategoryId = categoryId,
                ProductName = productName,
                Cost = price,
                Stock = 72
            };

            EntityEntry<Product> entity = db.Products.Add(p);
            WriteLine($"State: {entity.State} ProductId: {p.ProductId}" );
            // SAVE THE CHANGES ON DB
            int affected = db.SaveChanges();
            WriteLine($"State: {entity.State} ProductId: {p.ProductId}" );
            return (affected, p.ProductId);
        }
    }

    // UPDATE
    // If you do the Update First you got the delete because the delete is the simpler way to update
    static (int affected, int productId) UpdateProductPrice(string productNameStartWith, decimal amount)
    {
        using(Northwind db = new())
        {
            if(db.Products is null) return (0,0);
            // Get the first product that start with productNameStartWith
            Product updateProdcut =
            db.Products.First(
                p => p.ProductName!.StartsWith(productNameStartWith));
            updateProdcut.Cost = amount;
            // equals? ---> db.Products.First(p=>p.ProductName.StartsWith(productNameStartWith)).Cost = amount;
            int affected = db.SaveChanges();
            return (affected, updateProdcut.ProductId);
        }
    }


    static (int affected, int[]? productsId) UpdateProductPriceBetter(string productNameStartWith, decimal amount)
    {
        using(Northwind db = new())
        {
            if(db.Products is null) return (0,null);
            // Get the first product that start with productNameStartWith
            IQueryable<Product>? products =
            db.Products.Where(
                p => p.ProductName!.StartsWith(productNameStartWith)); // here we take all the products that match with our productNameStartWith
            int affected = products.ExecuteUpdate(u => u.SetProperty(
                p => p.Cost, // Property Selector
                p => p.Cost + amount // Value to edit
                // here we use that products we collect, we execute an update to the same variable in all the products we found
            ));
            int[] productIds = products.Select( p => p.ProductId).ToArray(); // here we obtain all the id's from the updated products
            return (affected, productIds);
        }
    }

    // DELETE
    static int DeleteProducts(string productNameStartWith)
    {
        using(Northwind db = new())
        {
            IQueryable<Product>? products = db.Products?.Where(
                p => p.ProductName!.StartsWith(productNameStartWith));
            if(products is null || !products.Any())
            {
                WriteLine("No products to delete");
                return 0;
            }
            else
            {
                if( db.Products is null) return 0;
                db.Products.RemoveRange(products); // before this, we obtain all the products that match, then we remove them all at the same time 
            }
            int affected = db.SaveChanges();
            return affected;
            
        }
    }
    
    // Better Delete
    static int DeleteProductsBetter(string productNameStartWith)
    {
        using(Northwind db = new())
        {
            int affected = 0;
            IQueryable<Product>? products = db.Products?.Where(
                p => p.ProductName!.StartsWith(productNameStartWith));
            if(products is null || !products.Any())
            {
                WriteLine("No products to delete");
                return 0;
            }
            else
            {
                affected = products.ExecuteDelete(); //here we have the matching products so we executedelete to erase all the products that matched with the query from the variable products
            }
            return affected;
            
        }
    }
}