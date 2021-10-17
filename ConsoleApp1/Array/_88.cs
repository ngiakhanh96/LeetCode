namespace ConsoleApp1.Array;

public class _88
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var i = m - 1;
        var j = n - 1;
        while (i >= 0 && j >= 0)
        {
            if (nums1[i] > nums2[j])
            {
                nums1[i + j + 1] = nums1[i];
                i--;
            }
            else
            {
                nums1[i + j + 1] = nums2[j];
                j--;
            }
        }

        while (i >= 0)
        {
            nums1[i] = nums1[i];
            i--;
        }

        while (j >= 0)
        {
            nums1[i] = nums2[j];
            j--;
        }
    }
}