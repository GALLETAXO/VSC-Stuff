


using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace WorkingWithEFCore;

public static partial class ProductExtensions
{
    public static int Moda(this List<Product> prod, int col)
    {
        WriteLine("INT");

        int[] prev = {0,0};
        int cuenta;

        List<int> datos = new();
        for(int x = 0; x < prod.Count; x++)
        {
            switch(col)
            {
                case 1:
                {
                    
                    datos.Add(prod[x].ProductId);
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
                    datos.Add(0);
                    break;
                }
            }
        }

        

        for(int x = 0; x < datos.Count; x ++)
        {
            cuenta = 0;
            
            for(int y = 0; y < datos.Count; y ++)
            {

                if(datos[x] == datos[y])
                {
                    cuenta++;
                }

            }

            if(cuenta > prev[1])
            {
                prev[0] = datos[x];
                prev[1] = cuenta;
            }
                     
        }
        return prev[0];


    }


public static decimal? Moda(this List<Product> prod, decimal col)
    {
        WriteLine("Cost");

        decimal?[] prev = {0,0};
        int cuenta;


        for(int x = 0; x < prod.Count; x ++)
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


    public static double Media(this List<Product> prod, int col)
    {
        switch(col)
        {
            case 1:
            {
                WriteLine("ProdID");
                return prod.Average(p=>p.ProductId);
            }
            case 2:
            {
                WriteLine("Stock");
                return prod.Average(p=>p.Stock);
            }
            case 3:
            {
                WriteLine("CategID");
                return prod.Average(p=>p.CategoryId);
            }
            default:
            {
                break;
            }
        }
        return 0;
    }

    public static decimal? Media(this List<Product> prod, decimal col)
    {
        WriteLine("Cost");
        return prod.Average(p=>p.Cost);
    }

    public static decimal Mediana(this List<Product> prod, int col)
    {
        int med = 0;
        int inter =prod.Count/2;
        inter++;
        switch(col)
        {
            case 1:
            {
                WriteLine("ProdID");
                prod = prod.OrderBy(p=>p.ProductId).ToList();
                if((prod.Count % 2) > 0)
                {
                    return prod[inter].ProductId;
                }
                else
                {
                    med = prod[prod.Count/2].ProductId + prod[(prod.Count/2) + 1].ProductId;
                    return med/ 2;
                }
            }
            case 2:
            {
                WriteLine("Stock");
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
            case 3:
            {
                WriteLine("CategID");
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
            default:
            {
                break;
            }
        }

  

        return 0;
    }

    public static decimal? Mediana(this List<Product> prod, decimal col)
    {
        WriteLine("Cost");
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

    public static bool Moda(this List<Product> prod, bool col)
    {
        WriteLine("Discontinued");

        int t = 0, f = 0;

        for(int x = 0; x < prod.Count; x ++)
        {
            if(prod[x].Discontinued)
            {
                t++;
            }
            else
            {
                f++;
            }    
        }

        if( t > f)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public static float Media(this List<Product> prod, bool col)
    {
        WriteLine("Discontinued");
        float f = 0, t = 0;
        for(int x = 0; x < prod.Count; x ++)
        {
            if(prod[x].Discontinued == false)
            {
                f++;
            }
        }

        t = f * 100;
        return t/prod.Count;
        
    }


    public static int Mediana(this List<Product> prod, bool col)
    {
        WriteLine("Discontinued");
        int inter =prod.Count/2;
        inter++;
        prod = prod.OrderBy(p=>p.Discontinued).ToList();
        if((prod.Count % 2) > 0)
        {
            if(prod[inter].Discontinued)
            {
                return 1;
            }
            else
            {
                return 2;
            }
            
        }
        else
        { 
            return 3;
        }
    }


    public static char Moda(this List<Product> prod, string col)
    {
        string all = "";

        switch(col)
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

        all = Regex.Replace(all.Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "");
        all = all.Replace(" ", "");

        
        int cuenta, ant = 0;
        char prev = ' ';

        for(int x = 0; x < all.Length; x ++)
        {
            cuenta = 0;
            
            for(int y = 0; y < all.Length; y ++)
            {

                if(all[x] == all[y])
                {
                    cuenta++;
                }

            }

            if(cuenta > ant)
            {
                prev = all[x];
                ant = cuenta;
            }
                     
        }




        return prev;
    }

    public static double Media(this List<Product> prod, string col)
    {

        double res = 0;

        string all = "";

        switch(col)
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

        all = Regex.Replace(all.Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "");
        all = all.Replace(" ", "");

        for(int x = 0; x < all.Length; x ++)
        {
            res = res + all[x];
        }

        res = res/ all.Length;

        return res;

    }

    public static string Mediana(this List<Product> prod, string col)
    {

        List<char> car = new();
        string all = "";

        switch(col)
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
        all = all.Replace(" ", "");


        for(int x = 0; x < all.Length; x ++)
        {
            car.Add(all[x]);
        }

        car = car.Order().ToList();


        
        int inter =car.Count/2;
        string res = " ";
        inter++;
        if((car.Count % 2) > 0)
        {
            res = res + car[inter];
        }
        else
        {
            res = res + car[car.Count/2];
            res = res + car[inter];
        }
        return res;

    }







    








}