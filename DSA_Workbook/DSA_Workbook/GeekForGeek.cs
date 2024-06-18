using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Workbook
{
    public static class GeekForGeek
    {
        #region Missing number in an array
//Given an array of size n-1 such that it only contains distinct integers in the range of 1 to n. Return the missing element.
//Examples:
//Input: n = 5, arr[] = { 1, 2, 3, 5 }
//Output: 4
//Explanation: All the numbers from 1 to 5 are present except 4.
//Input: n = 2, arr[] = { 1 }
//Output: 2
//Explanation: All the numbers from 1 to 2 are present except 2.
public static int MissingNumber(int n, int[] arr)
{

    if (n > 0)
    {
        Array.Sort(arr);
        for (int i = 1; i < n; i++)
        {
            if (i != arr[i - 1])
            {
                return i;
            }
        }
    }
    return n;
}
#endregion

#region Array Duplicates
//Given an array arr of size n which contains elements in range from 0 to n-1, you need to find all the elements occurring more than once in the given array. Return the answer in ascending order. If no such element is found, return list containing [-1].
//Note: Try and perform all operations within the provided array. The extra (non-constant) ) space needs to be used only for the array to be returned.
//Examples:
//Input: arr[] = { 0, 3, 1, 2 }, n = 4
//Output: -1
//Explanation: There is no repeating element in the array. Therefore output is -1.
//Input: arr[] = { 2, 3, 1, 2, 3 }, n = 5
//Output: 2 3
//Explanation: 2 and 3 occur more than once in the given array.
public static List<int> duplicates(long[] arr, int n)
{
    Array.Sort(arr);
    HashSet<int> distinct=new HashSet<int>();
    HashSet<int> duplicate=new HashSet<int>();

    foreach(var item in arr)
    {
        if(!distinct.Add((int)item))
            duplicate.Add((int)item);
    }

    if (duplicate.Count <= 0)
        duplicate.Add(-1);

    return duplicate.ToList();
}
#endregion
    }
}
