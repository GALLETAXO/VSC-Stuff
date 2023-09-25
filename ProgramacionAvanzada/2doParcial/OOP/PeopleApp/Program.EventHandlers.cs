using PA17F.shared;
partial class Program
{

    //A method to handle the shout  (delegate) event

    static void jordi_shout(object? sender, EventArgs e)
    {
        if(sender is null) return;

        Person? p = sender  as Person;
        
        if (p is null) return;

        WriteLine($"{p.Name} is this angry: {p.Angerlevel}");

        
    }

}