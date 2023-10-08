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
    

    [Fact]
    public void LoginEncriptacion()
    {
        Funciones func = new();
        bool actual = func.Login("Gael", func.GetMD5("1234"));

        bool expected = true;

        Assert.Equal(expected,actual);
   

    }


    [Fact]
    public void Kill()
    {
        Funciones func = new();
        
        bool actual = func.Eliminar("Octavio");
        bool expected = true;

        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void NoKill()
    {
        Funciones func = new();
        
        bool actual = func.Eliminar("Incorrecto");
        bool expected = false;

        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void MatAgregarCorrecta()
    {
        Funciones func = new();
        bool actual = func.Materia("Luis", "5", "Pruebologia");
        bool expected = true;
        


        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void MatAgregarIncorrecta()
    {
        Funciones func = new();
        bool actual = func.Materia("Luis", "7", "Pruebologia");
        bool expected = false;
        
        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void MatEliminar()
    {
        Funciones func = new();
        bool actual = func.Materia("Luis", "6", "Caceria de Fantasmas");
        bool expected = true;
        
        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void MatElimAgregarNoencontrado()
    {
        Funciones func = new();
        bool actual = func.Materia("Luis", "6", "Botanica");
        bool expected = false;
        
        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void CambiarBien()
    {
        Funciones func = new();
        bool actual = func.Cambiar("Mario", "3", "Triviño");
        bool expected = true;
        
        Assert.Equal(expected,actual);
   

    }


    [Fact]
    public void CambiarNoOpcion()
    {
        Funciones func = new();
        bool actual = func.Cambiar("Luis", "10", "Triviño");
        bool expected = false;
        
        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void CambiarNoObjetivo()
    {
        Funciones func = new();
        bool actual = func.Cambiar("Yo", "3", "Triviño");
        bool expected = false;
        
        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void ContraFunciona()
    {
        Funciones func = new();
        bool actual = func.Contra("Emiliano","345");
        bool expected = true;
        
        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void ContraNoEncuentra()
    {
        Funciones func = new();
        bool actual = func.Contra("Yo","345");
        bool expected = false;
        
        Assert.Equal(expected,actual);
   

    }





}