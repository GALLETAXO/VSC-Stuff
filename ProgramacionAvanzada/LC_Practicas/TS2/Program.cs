public class Solution {
    public int MaxOperations(int[] nums, int k) {

        List<int> no = new();
        int res = 0;
        foreach(int num in nums)
        {
            if(no.Contains(num))
            {

            }
            else
            {
                for(int i = 0; i < nums.Length; i ++)
                {
                    if(no.Contains(nums[i]))
                    {

                    }
                    else
                    {
                        int sum = num + nums[i];
                        if(sum == k)
                        {
                             ++;
                        }


                    }
                }

            }
        }

        
    }
}