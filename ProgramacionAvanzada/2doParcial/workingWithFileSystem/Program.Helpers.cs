

partial class Program
{

static void SectionTitle(string title)
{
    ConsoleColor previuosColor = ForegroundColor;
    ForegroundColor = ConsoleColor.Yellow; 
    WriteLine("*");
    WriteLine($"*{title}");
    WriteLine("*");
    ForegroundColor = previuosColor;
}

}