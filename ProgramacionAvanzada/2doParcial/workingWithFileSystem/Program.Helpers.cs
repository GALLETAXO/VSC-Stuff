

Partial class Program

static void SectionTitle(string title)
{
    ConsoleColor previuosColor = foregroundColor;
    foreground = ConsoleColor.Yellow; 
    WriteLine("*");
    WriteLine($"*{title}");
    WriteLine("*");
    ForegroundColor = previuosColor;
}