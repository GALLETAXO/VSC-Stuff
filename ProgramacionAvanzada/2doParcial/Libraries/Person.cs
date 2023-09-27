namespace PA17F.shared;

public class Person
{
   // Members

   public string? Name;
   public DateTime DateOfBirth;

   //delegates
   public int MethodIWantToCall(string input)
   {

      return input.Length;
   }

   public delegate int DelegateWithMatchingsignature(string s); //<--- Declaracion de la firma (string s)


//1st Step, Event Handler

public delegate void EventHandler (Object? sender, EventArgs e);
// Create our delegate field

public EventHandler?  Shout;
// Data field for delegate
public int Angerlevel;
public void Poke()
{
   Angerlevel++;
   if(Angerlevel >= 3)
   {
      //if something is listening
      if(Shout != null)
      {
         //then call the delegate
         Shout(this, EventArgs.Empty);
      }
   }
} 




}
