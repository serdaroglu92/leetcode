using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSubstringWithoutRepeatingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string testString = "";
            string resultString = "";

            Console.WriteLine("Please enter string");

            while (true)
            {
                testString = Console.ReadLine();

                resultString = GetLongestSubstringWithoutRepeatingCharactersN(testString);

                Console.WriteLine("The answer is '" + resultString + "', with the length of " + resultString.Length + ".");
            }
        }

        private static string GetLongestSubstringWithoutRepeatingCharactersN(string testString)
        {
            string resultString = "";
            char[] testStringArray = testString.ToCharArray();
            List<char> list = new List<char>();

            for (int i = 0; i < testStringArray.Length; i++)
            {
                if (list.Contains(testStringArray[i]))
                {
                    list.RemoveRange(0, list.IndexOf(testStringArray[i]) + 1);
                }

                list.Add(testStringArray[i]);

                if (list.Count > resultString.ToCharArray().Length)
                {
                    resultString = new string(list.ToArray());
                }
            }

            return resultString;
        }

        private static string GetLongestSubstringWithoutRepeatingCharactersNSquare(string testString)
        {
            string resultString = "";
            string tempString = "";
            char[] testStringArray = testString.ToCharArray();

            if (testStringArray.Length == 0 || testStringArray.Length == 1)
                return testString;

            for (int i = 0; i < testStringArray.Length - 1; i++)
            {
                tempString = testStringArray[i].ToString();

                for (int j = i + 1; j < testStringArray.Length; j++)
                {
                    if (tempString.IndexOf(testStringArray[j]) == -1)
                    {
                        tempString = String.Concat(tempString, testStringArray[j]);
                        if (j == testStringArray.Length - 1 && (tempString.Length > resultString.Length))
                            resultString = tempString;
                    }
                    else if (tempString.Length > resultString.Length)
                    {
                        resultString = tempString;
                        tempString = testStringArray[j].ToString();
                    }
                    else
                    {
                        tempString = testStringArray[j].ToString();
                    }
                }
            }

            return resultString;
        }
    }
}