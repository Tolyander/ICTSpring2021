
public class Class1
{
    public int[] RunningSum(int[] nums)
    {
        var res = new int[nums.Length];
        int ans = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            ans += nums[i];
            res[i] = ans;
        }
        return res;
    }
    
}
