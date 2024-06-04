// See https://aka.ms/new-console-template for more information
using System.Numerics;

//Sample execution
LeetcodeSolution.FedExQuestion();
Console.ReadLine();

public static class LeetcodeSolution
{
    #region #2 - add two numbers of two diff singly linked list
    public static ListNode AddTwoNumbers()
    {
        //Input
        ListNode l1 = new ListNode()
        {
            val = 1,
            next = new ListNode()
            {
                val = 2,
                next = new ListNode()
                {
                    val = 3,
                }
            }
        };

        ListNode l2 = new ListNode()
        {
            val = 5,
            next = new ListNode()
            {
                val = 6,
                next = new ListNode()
                {
                    val = 4,
                }
            }
        };

        //End of input

        l1 = Reverse(l1);
        l2 = Reverse(l2);

        string l1string = l1.val.ToString();
        string l2string = l2.val.ToString();

        while (l1.next != null)
        {
            l1 = l1.next;
            l1string = l1string + l1.val.ToString();
        }

        while (l2.next != null)
        {
            l2 = l2.next;
            l2string = l2string + l2.val.ToString();
        }

        BigInteger finalintVal = BigInteger.Parse(l1string) + BigInteger.Parse(l2string);

        char[] finalString = finalintVal.ToString().ToArray();

        ListNode resultNode = new ListNode();
        resultNode = string_to_SLL(finalintVal.ToString(), resultNode);
        resultNode = Reverse(resultNode);
        return resultNode;
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    static ListNode string_to_SLL(String text, ListNode head)
    {
        head = add(text[0] - '0');
        ListNode curr = head;
        // curr pointer points to the current node
        // where the insertion should take place
        for (int i = 1; i < text.Length; i++)
        {
            ListNode newNode = new ListNode(text[i] - '0');
            ListNode tempNode = head;
            while (tempNode.next != null)
            {
                tempNode = tempNode.next;
            }
            tempNode.next = newNode;
        }
        return head;
    }

    static ListNode add(int data)
    {
        ListNode newnode = new ListNode();
        newnode.val = data;
        newnode.next = null;
        return newnode;
    }

    public static ListNode Reverse(ListNode listNode)
    {
        ListNode prev = null;
        ListNode next = null;
        ListNode current = listNode;

        while (current != null)
        {
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }
        listNode = prev;

        return listNode;
    }
    #endregion

    #region #3 - relative ranks issue solution
    public static string[] FindRelativeRanks()
    {
        int[] score = new int[] { 10, 3, 8, 9, 4 };
        string[] finalResult = new string[score.Length];
        List<int> temp = new List<int>();
        for (int i = 0; i < score.Length; i++)
        {
            temp.Add(score[i]);
        }
        temp.Sort();
        temp.Reverse();

        Array.Reverse(temp.ToArray());

        for (int i = 0; i < score.Length; i++)
        {
            int index = temp.IndexOf(score[i]);
            if (index < 3)
            {
                if (index == 0)
                {
                    finalResult[i] = "Gold Medal";
                }
                else if (index == 1)
                {
                    finalResult[i] = "Silver Medal";
                }
                else if (index == 2)
                {
                    finalResult[i] = "Bronze Medal";
                }
            }
            else
            {
                finalResult[i] = (index + 1).ToString();
            }
        }

        return finalResult;
    }
    #endregion

    #region #4 - Max Length of longest sub string without repetation
    public static int LengthOfLongestSubstring(string s)
    {
        //string s = "abcabcbb";
        //s = "bbbb";
        //s = "pwwkew";
        //s = "dvdf";
        if (string.IsNullOrEmpty(s))
            return 0;
        else
        {
            int ipointer = 0, jpointer = 0, max = 0;
            List<char> tempCharColl = new List<char>();
            while (jpointer < s.Length)
            {
                if (tempCharColl.Contains(s[jpointer]))
                {
                    tempCharColl.Remove(s[ipointer]);
                    ipointer++;
                }
                else
                {
                    tempCharColl.Add(s[jpointer]);
                    max = Math.Max(tempCharColl.Count, max);
                    jpointer++;
                }
            }
            return max;
        }
    }
    #endregion

    #region #5 - IBM testing assessment question - test encryption using alphabets
    //given a alphabets a-z, we need to get a decrypted string based on encrypted string
    //example: VTA -> 2 letters before each charater /cyclic alphabets 2 letters before v=T, t=R, a=Y op:TRY
    public static string SipherString()
    {
        string encryption = "VTA";
        int intervalKeyValue = 2;
        if (string.IsNullOrEmpty(encryption))
            return string.Empty;
        char[] alphabetArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        char[] inputArray = encryption.ToCharArray();
        char[] outputArray = new char[encryption.Length];
        for (int i = 0; i < encryption.Length; i++)
        {
            int index = Array.IndexOf(alphabetArray, inputArray[i]);
            if (index <= 0)
                index += alphabetArray.Count();
            outputArray[i] = alphabetArray[index - intervalKeyValue];
        }
        return new string(outputArray);
    }
    #endregion

    #region #6 Palindrome of integer
    public static bool IsIntegerPalindrome(int num)
    {
        //int num = 323;
        //Fails for num = 1534236469
        int temp, rev, sum = 0;
        temp = num;
        while (temp < 0)
        {
            rev = temp % 10;
            sum = (sum * 10) + rev;
            temp = temp / 10;
        }
        if (sum == num)
            return true;
        else
            return false;
    }
    #endregion

    #region #7 Palindrom - Shortest way
    public static bool IsStringPalindrome(string s)
    {
        if (!string.IsNullOrEmpty(s))
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[(s.Length - 1) - i])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
    #endregion

    #region #8 Longest Palindromic Substring 
    //Example 1:
    //Input: s = "babad"
    //Output: "bab"
    //Explanation: "aba" is also a valid answer.
    //Example 2:

    //Input: s = "cbbd"
    //Output: "bb"

    public static string LongestPalindrome(string s)
    {
        if (!string.IsNullOrEmpty(s) && (s.Length >= 1 && s.Length <= 1000))
        {
            int i = 0;
            int j = 0;
            int maxLength = 0;
            string maxPalindrome = string.Empty;
            List<char> chars = new List<char>();
            for (i = 0; i < s.Length; i++)
            {
                chars = new List<char>();
                for (j = i; j < s.Length; j++)
                {
                    chars.Add(s[j]);
                    string temp = new string(chars.ToArray());
                    if (IsStringPalindrome(temp))
                    {
                        if (maxLength <= temp.Length)
                        {
                            maxLength = temp.Length;
                            maxPalindrome = temp;
                        }
                    }
                }
            }
            return maxPalindrome;
        }
        return string.Empty;
    }
    #endregion

    #region #9 ZigZag conversion
    public static string iConvert(string s, int numRows)

    {

        if (numRows <= 1) return s;

        List<char> firstRow = new List<char>();

        List<char> secondRow = new List<char>();

        List<char> thirdRow = new List<char>();

        var step = 1;

        var index = 0;

        foreach (char ch in s)

        {

            switch (index)

            {

                case 0:

                    firstRow.Add(ch);

                    break;

                case 1:

                    secondRow.Add(ch);

                    break;

                case 2:

                    thirdRow.Add(ch);

                    break;

            }

            if (index == 0)

                step = 1;

            if (index == numRows - 1)

                step = -1;

            index += step;

        }

        string newString = new string(firstRow.ToArray()) + new string(secondRow.ToArray()) + new string(thirdRow.ToArray());

        return newString;

    }

    #endregion

    #region #10 Integert to Roman letters
    public static string IntToRoman(int num)
    {
        if (num >= 1000) return "M" + IntToRoman(num - 1000);

        if (num >= 900) return "CM" + IntToRoman(num - 900);

        if (num >= 500) return "D" + IntToRoman(num - 500);

        if (num >= 400) return "CD" + IntToRoman(num - 400);

        if (num >= 100) return "C" + IntToRoman(num - 100);

        if (num >= 90) return "XC" + IntToRoman(num - 90);

        if (num >= 50) return "L" + IntToRoman(num - 50);

        if (num >= 40) return "XL" + IntToRoman(num - 40);

        if (num >= 10) return "X" + IntToRoman(num - 10);

        if (num >= 9) return "IX" + IntToRoman(num - 9);

        if (num >= 5) return "V" + IntToRoman(num - 5);

        if (num >= 4) return "IV" + IntToRoman(num - 4);

        if (num >= 1) return "I" + IntToRoman(num - 1);

        return "";
    }
    #endregion

    #region #11 Roman to integer
    public static int RomanToInt(string s)

    {

        s = "LVIII";

        int num = 0;

        if (!string.IsNullOrEmpty(s))

        {

            Dictionary<char, int> map = new Dictionary<char, int>();

            map.Add('I', 1);

            map.Add('V', 5);

            map.Add('X', 10);

            map.Add('L', 50);

            map.Add('C', 100);

            map.Add('D', 500);

            map.Add('M', 1000);



            for (int i = s.Length - 1; i >= 0; i--)

            {

                int currVal = map[s[i]];

                if (currVal < num)

                    num -= currVal;

                else

                    num += currVal;
            }
        }
        return num;

    }
    #endregion

    #region #12 Longest prefix string
    //        Example 1:

    //Input: strs = ["flower","flow","flight"]
    //        Output: "fl"

    public static string LongestCommonPrefix(string[] strs)

    {
        strs = new string[] { "cir", "car" };
        string prefix = string.Empty;
        if (strs != null && strs.Length > 1)
        {
            char[] baseLetters = strs[0].ToArray();
            for (int i = 1; i < strs.Length; i++)
            {
                char[] followingLetters = strs[i].ToArray();
                int maxLength = Math.Min(baseLetters.Length, followingLetters.Length);
                for (int j = 0; j < maxLength; j++)
                {
                    if (baseLetters[j] == followingLetters[j])
                    {
                        prefix += baseLetters[j];
                    }
                    else
                    {
                        break;
                    }
                }
                baseLetters = prefix.ToCharArray();
                prefix = string.Empty;
            }
            prefix = new string(baseLetters.ToArray());
            return prefix;
        }
        else if (strs != null && strs.Length == 1)
            return strs[0];
        return prefix;
    }

    #endregion

    #region #13 Letter Combinations of a Phone Number
    //        Input: digits = "23"
    //Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]

    public static IList<string> LetterCombinations(string digits)
    {
        #region
        List<string> list = new List<string>();
        if (!string.IsNullOrEmpty(digits) && digits.Length > 0 && digits.Length <= 4)
        {
            Dictionary<int, string[]> maps = new Dictionary<int, string[]>();
            maps.Add(2, new string[] { "a", "b", "c" });
            maps.Add(3, new string[] { "d", "e", "f" });
            maps.Add(4, new string[] { "g", "h", "i" });
            maps.Add(5, new string[] { "j", "k", "l" });
            maps.Add(6, new string[] { "m", "n", "o" });
            maps.Add(7, new string[] { "p", "q", "r", "s" });
            maps.Add(8, new string[] { "t", "u", "v" });
            maps.Add(9, new string[] { "w", "x", "y", "z" });

            if (digits.Length == 1 && char.IsNumber(digits[0]))
            {
                int key = Convert.ToInt32(digits[0] - '0');
                return maps[key].ToList();
            }
            else
            {
                for (int i = 0; i < digits.Length; i++)
                {
                    if (char.IsNumber(digits[i]))
                    {
                        int key = Convert.ToInt32(digits[i] - '0');
                        List<string> currentList = new List<string>();
                        if (maps.Keys.Contains(key))
                        {
                            currentList = maps[key].ToList();
                        }
                        list = CombineList(list, currentList);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        return list;
        #endregion
    }

    private static List<string> CombineList(List<string> prevList, List<string> currentList)
    {
        if (prevList.Count <= 0)
            return currentList;

        List<string> list = new List<string>();
        for (int i = 0; i < prevList.Count; i++)
        {
            for (int j = 0; j < currentList.Count; j++)
            {
                list.Add(prevList[i] + currentList[j]);
            }
        }
        return list;
    }
    #endregion

    #region #14 In a given list of integers - first half of the list should be desc order and the next half shoudl be ascending order
    public static void FedExQuestion()
    {
        List<int> numbs = new List<int>() { 1, 55, 4, 5, 6, 8, 32, 5, 8, 77 };
        int count = numbs.Count / 2;
        int[] descendingOrder = new int[count];
        int[] ascendingOrder = new int[count];
        for (int i = 0; i < numbs.Count; i++)
        {
            if (i < count)
            {
                descendingOrder[i] = numbs[i];
            }
            else
            {
                ascendingOrder[i - count] = numbs[i];
            }
        }
        Array.Sort(descendingOrder);
        Array.Reverse(descendingOrder);
        Array.Sort(ascendingOrder);

        //To print in console app
        foreach (var item in descendingOrder)
        {
            Console.WriteLine(item.ToString());
        }
        foreach (var item in ascendingOrder)
        {
            Console.WriteLine(item.ToString());
        }
    }
    #endregion
}