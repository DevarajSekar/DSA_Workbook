namespace DSA_Workbook
{
    public static class InterviewProbs
    {
        #region #1 - IBM testing assessment question - test encryption using alphabets
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

        #region #2 In a given list of integers - first half of the list should be desc order and the next half shoudl be ascending order
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
}
