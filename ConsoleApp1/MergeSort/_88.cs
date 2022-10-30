namespace ConsoleApp1.MergeSort;

// Last visit 24/10/2022
public class _88
{
    //Faster because of only one loop
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var pointer1 = m - 1;
        var pointer2 = n - 1;
        for (var i = nums1.Length - 1; i >= 0; i--)
        {
            if (pointer1 < 0)
            {
                nums1[i] = nums2[pointer2--];
                continue;
            }
            else if (pointer2 < 0)
            {
                nums1[i] = nums1[pointer1--];
                continue;
            }
            if (nums1[pointer1] >= nums2[pointer2])
            {
                nums1[i] = nums1[pointer1--];
            }
            else
            {
                nums1[i] = nums2[pointer2--];
            }
        }
    }

    public void Merge2(int[] nums1, int m, int[] nums2, int n)
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