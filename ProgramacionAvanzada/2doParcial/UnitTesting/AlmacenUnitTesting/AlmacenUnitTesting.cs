namespace AlmacenUnitTesting;
// En este espacio se encuentran todas las funciones que despues se usaran en Program, con el fin de que este todo ordenado 
using static System.IO.Directory; 
using static System.IO.Path; 
using static System.Environment;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Xunit.Sdk;
using AlmacenLib;


public class AlmacenUnitTesting
{
    public string[]? log = new string[] {"Toño", "Fox", "123"};

    [Fact]
    public void Login()
    {
        Funciones func = new();
        bool actual = func.Login(log![0], log[2]);

        bool expected = true;

        Assert.Equal(expected,actual);
   

    }


    [Fact]
    public void Kill()
    {
        Funciones func = new();
        
        bool actual = func.Eliminar(log![0]);
        bool expected = true;

        Assert.Equal(expected,actual);
   

    }
}