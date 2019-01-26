using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;

namespace TwoSum
{
    public class TwoSums
    {
        //Given an array of integers, return indices of the two numbers such that they add up to a specific target.

        //You may assume that each input would have exactly one solution, and you may not use the same element twice.

        //Example:

        //Given nums = [2, 7, 11, 15], target = 9,

        //Because nums[0] + nums[1] = 2 + 7 = 9,
        //return [0, 1].
       

        SortedMethods helper = new SortedMethods();

        public static void Main(string[] args)
        {
            TwoSums t = new TwoSums();
            int target = 6;
            int[] nums = new int[] { 3, 2 , 4 };
            int[] answer = new int[] { };

            //solution for n*n
            answer = t.TwoSumSolutionForNSquare(nums, target);
            if (answer[0] != -1)
            {
                Console.Write("[" + answer[0] + ", " + answer[1] + "]");
            }
            else
            {
                Console.Write("Not found match number!");
            }


            //solution for n*logn
            answer = t.TwoSumSolutionForNLogN(nums, target);
            if (answer[0] != -1)
            {
                Console.WriteLine("[" + answer[0] + ", " + answer[1] + "]");
            }
            else
            {
                Console.WriteLine("Not found match number!");
            }

            Console.Read();
        }

        public int[] TwoSumSolutionForNSquare(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { -1 };
        }

        public int[] TwoSumSolutionForNLogN(int[] nums, int target)
        {
            int i = 0, j = nums.Length - 1;
            int[] numsSorted = new int[nums.Length];
            for(int z = 0; z < nums.Length; z++)
            {
                numsSorted[z] = nums[z];
            }

            helper.heapsort(numsSorted);

            while (i < j)
            {
                int sum = numsSorted[i] + numsSorted[j];

                if (sum == target)
                {
                    int first = -1, second = -1;
                    int k = 0;
                    while (first == -1 || second == -1)
                    {
                        
                        if(nums[k] == numsSorted[i] || nums[k] == numsSorted[j])
                        {
                            if (first < 0)
                            {
                                first = k;
                            }
                            else
                            {
                                second = k;
                            }
                        }
                        k++;
                    }

                    return new int[] { first, second };
                }

                if (sum < target)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }

            return new int[] { -1, -1 };

        }

        
    }
}
