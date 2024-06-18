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
            HashSet<int> distinct = new HashSet<int>();
            HashSet<int> duplicate = new HashSet<int>();

            foreach (var item in arr)
            {
                if (!distinct.Add((int)item))
                    duplicate.Add((int)item);
            }

            if (duplicate.Count <= 0)
                duplicate.Add(-1);

            return duplicate.ToList();
        }
        #endregion

        #region Array Leaders
        //Given an array arr of n positive integers, your task is to find all the leaders in the array. An element of the array is considered a leader if it is greater than all the elements on its right side or if it is equal to the maximum element on its right side. The rightmost element is always a leader.
        //Examples
        //Input: n = 6, arr[] = { 16, 17, 4, 3, 5, 2 }
        //Output: 17 5 2
        //Explanation: Note that there is nothing greater on the right side of 17, 5 and, 2.
        //Input: n = 5, arr[] = { 10, 4, 2, 4, 1 }
        //Output: 10 4 4 1
        //Explanation: Note that both of the 4s are in output, as to be a leader an equal element is also allowed on the right. side
        //Input: n = 4, arr[] = { 5, 10, 20, 40 } 
        //Output: 40
        //Explanation: When an array is sorted in increasing order, only the rightmost element is leader.
        public static List<int> leaders(int n, int[] arr)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < arr.Length; i++)//first item left side items will be handled here
            {
                bool canAdd = false;
                for (int j = i + 1; j < arr.Length; j++)//from the selected item, the following right side item will be here
                {
                    if (arr[i] >= arr[j])//If the left side item is greater through out the loop it will be added.
                    {
                        canAdd = true;
                    }
                    else
                    {
                        canAdd = false;
                        break;
                    }
                }
                if (canAdd || i == arr.Length - 1)//arr.length-1 -> this condition is used to chekc the last item. Always the last item must be added
                    result.Add(arr[i]);
            }
            return result;
        }
        #endregion
    }
}
