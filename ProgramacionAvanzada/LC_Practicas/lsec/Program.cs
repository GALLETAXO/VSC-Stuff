public class Solution {
    public int LongestConsecutive(int[] nums) {

        HashSet<int> numeros = new HashSet<int>(nums);
      int i = int.ma;

      numeros = (HashSet<int>)numeros.Order();

      int l = 0;

      foreach(int num in numeros)
      {
        if(num < l)
        l= num;
      }

      while(numeros.Contains(l + i))
      {
        i++;
      }


    


      return i; 
    }
}