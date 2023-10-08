namespace AlmacenUnitTesting;
using static System.IO.Directory; 
using static System.IO.Path; 
using static System.Environment;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Xunit.Sdk;
using AlmacenLib;
// mis terribles unit testing, un poco feas, pero en mi defenza, las hice mientras desarrollaba el programa para ir probando las partes, pero despues fui moviendo las funciones hacia su clase
// por que no las deje aqui? por tonto 

public class AlmacenUnitTesting
{
    

    [Fact]
    public void LoginEncriptacion() // aqui revisaremos que el login sea exitoso
    {
        Funciones func = new();
        bool actual = func.Login("Gael", func.GetMD5("1234"));

        bool expected = true;

        Assert.Equal(expected,actual);
   

    }


    [Fact]
    public void Kill() // revisaremos que la funcion regrese correctamente el valor, segun si se hizo o no la accion 
    {
        Funciones func = new();
        
        bool actual = func.Eliminar("Octavio");
        bool expected = true;

        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void NoKill() // revisaremos que la funcion regrese correctamente el valor, segun si se hizo o no la accion, en este caso debera fallar 
    {
        Funciones func = new();
        
        bool actual = func.Eliminar("Incorrecto");
        bool expected = false;

        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void MatAgregarCorrecta() // revisaremos que la funcion regrese correctamente el valor, segun si se hizo o no la accion, viendo que procese los datos correctamente 
    {
        Funciones func = new();
        bool actual = func.Materia("Luis", "5", "Pruebologia");
        bool expected = true;
        


        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void MatAgregarIncorrecta() // revisaremos que la funcion regrese correctamente el valor, segun si se hizo o no la accion, revisaremos que regrese lo que debe si falla 
    {
        Funciones func = new();
        bool actual = func.Materia("Luis", "7", "Pruebologia");
        bool expected = false;
        
        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void MatEliminar() // revisaremos que efectivamente se eliminen las cosas como se debe y nos lo notifique 
    {
        Funciones func = new();
        bool actual = func.Materia("Luis", "6", "Caceria de Fantasmas");
        bool expected = true;
        
        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void MatElimAgregarNoencontrado() // revisamos el caso en el que no encuentre el objetivo 
    {
        Funciones func = new();
        bool actual = func.Materia("Luis", "6", "Botanica");
        bool expected = false;
        
        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void CambiarBien() // revisaremos que se haga correctamente un cambio 
    {
        Funciones func = new();
        bool actual = func.Cambiar("Mario", "3", "Triviño");
        bool expected = true;
        
        Assert.Equal(expected,actual);
   

    }


    [Fact]
    public void CambiarNoOpcion() // ahora,  revisaremos que pasa si no encuentra la opcion 
    {
        Funciones func = new();
        bool actual = func.Cambiar("Luis", "10", "Triviño");
        bool expected = false;
        
        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void CambiarNoObjetivo() // en el caso de que no encentre el objetivo 
    {
        Funciones func = new();
        bool actual = func.Cambiar("Yo", "3", "Triviño");
        bool expected = false;
        
        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void ContraFunciona() // revisaremos la funcion de cambiar contraseña del administrador para revisar que haga el proceso correcto y lo notifique 
    {
        Funciones func = new();
        bool actual = func.Contra("Emiliano","345");
        bool expected = true;
        
        Assert.Equal(expected,actual);
   

    }

    [Fact]
    public void ContraNoEncuentra()// este es el caso en el que no encuentre el objetivo a cambiar 
    {
        Funciones func = new();
        bool actual = func.Contra("Yo","345");
        bool expected = false;
        
        Assert.Equal(expected,actual);
   

    }





} // fin :), ahora si 