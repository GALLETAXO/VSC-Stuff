using static System.Convert; // la incluimos para usar las conversiones
Random rnd = new Random(); // creamos un objeto de la clase random para usar sus metodos
Byte[] con = new Byte[128]; // creamos el arreglo de tipo Byte
rnd.NextBytes(con); // usamos el metodo para rellenar el arreglo con numeros aleatorios
WriteLine("Binary Object as bytes: ");
for(int i = 0; i < con.Length; i++) //hacemos un ciclo para que obtengamos el valor hexadecimal
{
    Write($"{ToHexString(con, i, 1 )} ");
} //de cada byte del arreglo, gracias a que indicamos el arreglo
WriteLine();                            // la posicion del valor, y cuantos valores queremos obtener
WriteLine("Binary Object as Base64: ");
WriteLine(ToBase64String(con)); // usamos esta conversion para imprimir todo el arreglo ya como string



int cont = int.Parse ("13"); // saltara una exepcion por formato
WriteLine("How many students there are?");
string? input = ReadLine();
if(int.TryParse(input, out int count))
{
    WriteLine($"There are {count} students");
}
else
{
    WriteLine("Coudn't Convert");
}
