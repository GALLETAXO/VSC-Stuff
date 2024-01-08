using System.Linq;

public class Solution {
    public bool IsAnagram(string s, string t) {
        int i = 0;

        if(s.Length != t.Length)
        {
            return false;

        }
        else
        {
            s = String.Concat(s.Order());
            t = String.Concat(t.Order());
            if(s == t)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        
    }
}