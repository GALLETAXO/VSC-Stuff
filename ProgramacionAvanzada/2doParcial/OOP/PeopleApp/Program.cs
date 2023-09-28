

using System.Collections.Generic;
using System.Collections;
using PA17F.shared;
using static PA17F.shared.Person;
//hola



Person wachi = new();
wachi.Name = "Alberto";
wachi.DateOfBirth = new DateTime(2002,12,22);

// No se pueden duplicar llaves o todas las llaves deben de ser del mismo tipo
Dictionary<int, string> LookUpInstring = new();
LookUpInstring.Add(1,"Alfa");
LookUpInstring.Add(2,"Delta");
LookUpInstring.Add(3,"Gamma");
LookUpInstring.Add(4,"Tetha");

//getting values from dictionary
foreach (var key in LookUpInstring.Keys)
{
    WriteLine($"Key: {key} has a value of : {LookUpInstring[key]}");

}

//callmethod();
//public string callmethot (int id);
// lo primero que revisa un delegado es la firma del metodo que va a llamar
//esto es el tipo que pide y el tipo que regresa "Method Signature"

// Old way too call a method
Person Jordi = new();
int answer = Jordi.MethodIWantToCall("Alfred");
// puedo crear un delegadp que encaje con la firma del metodo que quiero llamar
// the cool way Bv
//using delegate to call a method
// creating an instance 
DelegateWithMatchingsignature d = new(Jordi.MethodIWantToCall);
int answer2 = d("Isaac");
WriteLine(answer);
WriteLine(answer2);


//Event assing 
wachi.Shout = jordi_shout;
// Trigger
Jordi.Poke();
Jordi.Poke();
Jordi.Poke();
Jordi.Poke();



