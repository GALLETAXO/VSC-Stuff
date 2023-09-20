namespace calculatorLib;
public class Calculator
{
    public double Add (double a, double b)
    {
        return a + b;
    }

    public double Div (double a, double b)
    {
        checked
        {
             return a / b;
        }
       
    }




}
