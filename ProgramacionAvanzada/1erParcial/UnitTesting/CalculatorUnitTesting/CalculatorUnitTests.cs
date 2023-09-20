namespace CalculatorUnitTesting;

using System.Numerics;
using calculatorLib;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Sdk;

public class CalculatorUnitTests
{

    [Fact] //Annotation, si o tiene fact, no la va a tomar en consideracion
    public void TestAdd2And2()
    {

        //arrage
        double a = 2;
        double b = 2;
        double expected = 4; // especificamos el valor que esperamos como resultado
        Calculator calc = new();

        //Act
        double actual = calc.Add(a, b);

        //Assert
        Assert.Equal(expected, actual);


    }

    [Fact]
    public void TestAdd2and3()
    {

        //arrage
        double a = 2;
        double b = 3;
        double expected = 5; // especificamos el valor que esperamos como resultado
        Calculator calc = new();

        //Act
        double actual = calc.Add(a, b);

        //Assert
        Assert.Equal(expected, actual);


    }


    [Fact]
    public void TestExAddMax() // trataremos de obtener una excepcion al alcanzar un valor mayor al maximo, OverflowException
    {
       double a = double.MaxValue, b = double.MaxValue, c = 0;
       
        Calculator calc = new();
    
         Action throwingAction = () => 
    { 

        c = calc.Add(a,b); // por la forma en como trabajan los double(estimación) no podemos llegar a un valor maximo como tal
         if(double.IsPositiveInfinity(c)) // en vez de esto obtendremos un infinito Positivo en este caso, el cual tomaremos como indicador de una """Overflow Exception"""
         {
            throw new OverflowException();

         }
     
    };

        Assert.Throws<OverflowException>(throwingAction);

    }

      [Fact]
    public void TestExAddConvertPInf() // en este caso haremos algo similar, obtendremos un valor positivo infinito, pero en este caso lo convertiremos a Int para ver que sucede
    {
       double a = double.MaxValue, b = double.MaxValue;
        int c = 0;
       
        Calculator calc = new();
    
         Action throwingAction = () => 
    { 

        c = Convert.ToInt32(calc.Add(a,b)); // el resultado de esto es que al ser un valor ""Infinito"", este no cabe en un Int, por lo que se lanza la OverflowException
         
     
    };

        Assert.Throws<OverflowException>(throwingAction);

    }


    // Desde aqui estan los casos mas Elaborados 


        [Fact]
    public void TestExAddNull() // aqui buscamos acceder a un arreglo de doubles, pero este es nulo 
    {
       double[] x = null; // no hay nada :(
       double y = 0;
       
        Calculator calc = new();


         Action throwingAction = () => 
    { 


     

         y  = calc.Add(x[0], x[1]); // Por lo que al tratar de acceder a alguna localidad de este arreglo, no dira que estamos haciendo referencia a un valor nulo
      
        
     
    };

        Assert.Throws<NullReferenceException>(throwingAction);



    }


    [Fact]
    public void TestExAddFormatoIncorrecto() // aqui lo que buscamos es engañar vilmente a nuestra funcion 
    {
       double a = double.MinValue, b = double.MinValue;
       int  c = 0;
       
        Calculator calc = new();


         Action throwingAction = () => 
    { 

        string engaño = "Esto claramente no es un numero";

          calc.Add(a,Convert.ToDouble(engaño)); // Lo que hacemos es darle a convertir a double un numero que claramente no es un numero
          // lo que genera esta exepcion es que nuestro valor en engaño no tenga el formato adecuado para pasarse a double, esto no pasaria si el valor dentro de engaño fuera un numero 
          
        
     
    };

        Assert.Throws<FormatException>(throwingAction);



    }



    [Fact]
    public void TestExDivNoHex() // En este error estamos haciendo un Parse con un formato no adecuado para lo que queremos 
    {
       double a = 0, b = 0, c = 0; 
       
        Calculator calc = new();
        string numeroNoHex = "777";


       Action throwingAction = () => 
    { 
        
        c = calc.Div(a,double.Parse(numeroNoHex, System.Globalization.NumberStyles.HexNumber)); // aqui lo que malvadamente tratamos de hacer es que no sea valida la conversion a double ya que
        // primero, le estamos pasando un string, hasta eso no deberia ocurrir nada malo, pero en el momento en el que le decimos que se lo de como un Hexadecimal, ahi es donde 
        // simplemente las cosas ya no encajan 
  
    };

    Assert.Throws<ArgumentException>(throwingAction);

       

    }



    [Fact]
    public void TestExDivConvertNaNOverflow() // en este caso trataremos de hacer una conversion de un valor NaN a int
    {
       double a = 0, b = 0;
       int c = 0;
       
        Calculator calc = new();


       Action throwingAction = () => 
    { 
        
        c = Convert.ToInt32(calc.Div(a,b)); // curiosamente el resultado de hacer esto es una OverflowException, a pesar de que NaN no tenga un valor realmente
        // Esto de debe a que no hay forma de encajar esto en un Int, no hay nada que sea similar realmente 
        
    };

    Assert.Throws<OverflowException>(throwingAction);

       

    }







    



}