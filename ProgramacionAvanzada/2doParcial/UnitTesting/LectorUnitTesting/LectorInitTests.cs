namespace LectorUnitTesting;

using static System.IO.Directory; 
using static System.IO.Path; 
using static System.Environment;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

using System.Numerics;
using LectorLib;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Sdk;

public class LectorUnitTests
{
    [Fact]
    public void TestIngresoRespuestaIncorrecta() // aqui estaremos probando que la funcion regrese el dato adecuado si el dato que ingreso el usuario no es valido
    {
        Lector lector = new();
        string AgregaTuTexto = Combine(GetFolderPath(SpecialFolder.MyDocuments), "AgregaTuTexto");
        string actual = lector.Busqueda(AgregaTuTexto,0); // este seria un caso en el que el valor no es valido o no se encontro la direccion, esto haria que se pregunte de nuevo por el nombre del archivo

        string expected = "noup"; 

        Assert.Equal(expected, actual);
      


    }

    
    [Fact]
    public void TestIngresoRespuestaCorrecta() // en este caso, buscaremos que el programa efectivamente nos regrese la direccion como debe de ser 
    {
        Lector lector = new();
        string AgregaTuTexto = Combine(GetFolderPath(SpecialFolder.MyDocuments), "AgregaTuTexto");
        string actual = lector.Busqueda(AgregaTuTexto,1); // aqui especificamos que queremos el caso con la direccion correcta

        string expected = Combine(AgregaTuTexto, "paco.txt"); // fabricamos anticipadamente la respuesta que nos deberia de dar el programa al encontra la direccion correcta

        Assert.Equal(expected, actual);
      


    }

     
    [Fact]
    public void TestCuentaNormal() // en este caso, revisaremos que la funcion vocales, cuente correctamente el numero de vocales, ingresando un texto normal de letras minusculas
    {
        // esto es para probar el funcionamiento base de la funcion, sin ningun otro agregado
        Lector lector = new();
        string texto = "buenas, soy un texto de prueba que cuenta con 8 letras e"; // preparamos nuestro texto de pruebas
        int actual = lector.Vocales(ref texto, 'e'); // pasamos nuestros datosa revisar
        

        int expected = 8; // este deberia ser el valor que devuelva la funcion 
        Assert.Equal(expected, actual);
      


    }

     
    [Fact]
    public void TestCuentaMayusculas() // en este caso, revisaremos que la funcion vocales, cuente correctamente el numero de vocales, ingresando un texto normal con letras mayusculas intercaladas
    {
        // esto es para probar el funcionamiento base de la funcion, con una que otra mayuscula
        Lector lector = new();
        string texto = "buEnas, soy un texto de pruEba que cuenta con 8 lEtras e"; // preparamos nuestro texto de pruebas
        int actual = lector.Vocales(ref texto, 'e'); // pasamos nuestros datosa revisar
        

        int expected = 8; // este deberia ser el valor que devuelva la funcion 
        Assert.Equal(expected, actual);
      


    }

     
    [Fact]
    public void TestCuentaEspecial() // en este caso, revisaremos que la funcion vocales, cuente correctamente el numero de vocales, ingresando un texto con acentos y cosas del estilo
    {
        // esto es para probar el funcionamiento base de la funcion, agregando acentuaciones distintas en las letras
        Lector lector = new();
        string texto = "büénas, soy un tèxto de pruëba que cuênta con 8 lëtras é"; // preparamos nuestro texto de pruebas
        int actual = lector.Vocales(ref texto, 'e'); // pasamos nuestros datosa revisar
        

        int expected = 8; // este deberia ser el valor que devuelva la funcion 
        Assert.Equal(expected, actual);
      


    }

     
    [Fact]
    public void TestCuentaModifica() // en este caso, revisaremos que la funcion ademas de contar, agregue al texto la cantidad de veces que se encontro la vocal, reemplazando a su ultimo ejemplar
    {
        // esto es para probar si gracias al paso por referencia podemos realizar 2 cosas en la misma funcion, que de otro modo necesitaria mas codigo
        Lector lector = new();
        string texto = "buenas, soy un texto de prueba que cuenta con 8 letras e"; // preparamos nuestro texto de pruebas
        lector.Vocales(ref texto, 'e'); // pasamos nuestros datosa revisar
        string actual = texto; // para seguir usando el actual, le pasare el texto que ya deberia estar modificado, aunque podria simplemente no usar otra variable 
        

        string expected = "buenas, soy un texto de prueba que cuenta con 8 letras 8";// aqui fabricaremos el texto de acuerdo a como la funcion debe modificar el texto que le pasamos por referencia
        Assert.Equal(expected, actual);
      
    }

     [Fact]
    public void TestPalbusquedafallida() // Ahora revisaremos que la funcion palindromo, al no encontrar niguno, regrese un valor vacio, el cual despues interpretaremos
    {


        Lector lector = new();
        string actual = lector.Palindromear("buenas, soy un texto de prueba que no cuenta con palindromos"); // pasamos nuestros datosa revisar y el resultado lo agregamos a nuestro actual
        string expected = ""; // al no haber un palindromo, esperamos vacio
        

        Assert.Equal(expected, actual);
      
    }

     [Fact]
    public void TestPalbusquedaExitosa() // Ahora revisaremos que la funcion palindromo encuentre algun palindromo 
    {


        Lector lector = new();
        string actual = lector.Palindromear("buenas, soy un texto de prueba y he de reconocer que aqui solo hay un palindromo"); // pasamos nuestros datosa revisar y el resultado lo agregamos a nuestro actual
        string expected = "reconocer"; // esperamos reconocer ya que es el palindromo mas grande
        

        Assert.Equal(expected, actual);
      
    }

      [Fact]
    public void TestPalbusquedaEntrevarios() // Ahora revisaremos que la funcion palindromo encuentre el palindromo mas grande del texto
    {


        Lector lector = new();
        string actual = lector.Palindromear("buenas, soy un texto de prueba y he de reconocer que aqui no estamos solos ya que hay mas de un palindromo en el radar"); // pasamos nuestros datosa revisar y el resultado lo agregamos a nuestro actual
        string expected = "reconocer"; // esperamos reconocer, ya que es el palindromo mas grande
        

        Assert.Equal(expected, actual);
      
    }

      [Fact]
    public void TestPalbusquedaEspecial() // Ahora revisaremos que la funcion palindromo encuentre el palindromo correcto, de entre 3 con acentuaciones y cosas extrañas
    {


        Lector lector = new();
        string actual = lector.Palindromear("antañonatna PingüinoniügniP sometemos"); // usamos palabras con distintas acentuaciones o detalles que pueden confundir a la busqueda
                                                                                      // sin embargo, eliminamos cosas como la dieresis, o acentos, para facilitar la busqueda
                                                                                      // pero cosas como la virgulilla de la ñ no se quitan, ya que son letras mas distintas 
                                                                                      // que una vocal con distinto acento
        string expected = "pinguinoniugnip"; // esperamos  pinguinoniugip ya que es el palindromo mas grande, y para demostra que aun con mayuculas o caracteres especiales la busqueda funciona
        

        Assert.Equal(expected, actual);
      
    }










}