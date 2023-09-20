using System.Security.Principal;

Random rnd = new Random();

Write("Please tell me how many numbers do you want: ");
string? input = ReadLine();
int x = 0;

try
{
    x = int.Parse(input);
    
    
}
catch (FormatException)
{
    WriteLine("You only need to enter numbers!!!");
}
catch(OverflowException)
{
    WriteLine("That number is Tooo big");
}
catch(Exception ex)
{
    WriteLine($"Oh noooo!!! {ex.GetType} says: {ex.Message}");
}

if(x == 0)
{
    WriteLine("Well, thats it!!!!");

}
byte[] num = new Byte[x];

rnd.NextBytes(num);

for(int i = 0; i < x; i++)
{
    
}


