/*

#region exeptions
WriteLine("Before Parsing");
WriteLine("Write your age: ");
String? input = ReadLine();
try
{
    int age = int.Parse(input);
    WriteLine($"Your age is {age}");

}
catch(OverflowException)
{
    WriteLine("The imput is really big!!!");

}
catch(FormatException)
{
    WriteLine("Coudn't convert the imput!!!");

}
catch (Exception ex)
{
    WriteLine($"Oh Nooooo!!!  {ex.GetType} says {ex.Message}");
}


WriteLine("After parsing");
#endregion
*/

#region where
/*

Write("Enter an Amount: ");
string? amount = ReadLine();

if(string.IsNullOrEmpty(amount))
return;

try
{
    decimal amountValue = decimal.Parse(amount);
    WriteLine($"Amount formatted as currency {amount: C}");
    
}
catch (FormatException)when (amount.Contains("$")) 
{
    WriteLine("You don't need to add a: $ ");
    
}
catch(FormatException)
{

}

checked
{
int i = int.MaxValue;

i++;
i++;
i++;


}
*/

checked
{
int max = 500;
for(byte i = 0; i < max; i++)
{
    WriteLine(i);
}

}



#endregion