


using Microsoft.VisualBasic;

Solution hola = new();
int[] prueba = { 9, 7,6,7,6 };
string jeje = hola.LargestMultipleOfThree(prueba);
WriteLine(jeje);
public class Solution
{
    public string LargestMultipleOfThree(int[] digits)
    {

        digits = digits.Order().ToArray();
        int sol = 0;

        for (int i = 0; i < digits.Length; i++)
        {
            sol = sol + digits[i];

        }
        if ((sol/ 3) == 0)
        {
            return "0";
        }

        if (sol < 3)
        {
            return "";
        }

        List<int> digs = digits.ToList();


        if ((sol % 3) == 0)
        {
            return string.Join("", digs.OrderDescending());
        }
        else if ((sol % 3) == 1)
        {

            var inter = digs.Where(d => d % 3 == 1);
            if (inter.Any())
            {
                digs.Remove(inter.First());
                return string.Join("", digs.OrderDescending());
            }
            else
            {
                while ((sol % 3) == 1 || (sol % 3) == 2)
                {
                    inter = digs.Where(d => d % 3 == 2);
                    if (inter.Any())
                    {
                        digs.Remove(inter.First());
                        
                    }
                    inter = digs.Where(d => d % 3 == 1);
                    if (inter.Any())
                    {
                        digs.Remove(inter.First());
                        
                    }
                    sol = cuenta(digs);
                }
                return string.Join("", digs.OrderDescending());

            }


        }
        else if ((sol % 3) == 2)
        {

            var inter = digs.Where(d => d % 3 == 2);
            if (inter.Any())
            {
                digs.Remove(inter.First());
                return string.Join("", digs.OrderDescending());
            }
            else
            {
                while ((sol % 3) == 2 || (sol % 3) == 1)
                {
                    inter = digs.Where(d => d % 3 == 1);
                    if (inter.Any())
                    {
                        digs.Remove(inter.First());
                        
                    }
                    inter = digs.Where(d => d % 3 == 2);
                    if (inter.Any())
                    {
                        digs.Remove(inter.First());
                        
                    }
                    sol = cuenta(digs);
                }
            }


            return string.Join("", digs.OrderDescending());

        }





        return "";

    }
    public int cuenta(List<int> digits)
    {
        int sol = 0;
        for (int i = 0; i < digits.Count; i++)
        {
            sol = sol + digits[i];

        }

        return sol;
    }
}