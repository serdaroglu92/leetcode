using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoNumbers
{
    class AddTwoNumbers
    {
        //You are given two non-empty linked lists representing two non-negative integers.
        //The digits are stored in reverse order and each of their nodes contain a single digit.
        //Add the two numbers and return it as a linked list.

        //You may assume the two numbers do not contain any leading zero, except the number 0 itself.

        //Example:

        //Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
        //Output: 7 -> 0 -> 8
        //Explanation: 342 + 465 = 807.



        static void Main(string[] args)
        {
            AddTwoNumbers t = new AddTwoNumbers();
            ListNode l1 = new ListNode(2) { next = new ListNode(4) { next = new ListNode(3) } };
            ListNode l2 = new ListNode(5) { next = new ListNode(6) { next = new ListNode(4) } };
            //ListNode l1 = new ListNode(5);
            //ListNode l2 = new ListNode(5);
            ListNode l3 = new ListNode(0);

            l3 = t.AddTwoNumbersSolution(l1, l2);

            string result = "[";

            while(l3 != null)
            {
                result += l3.val;
                if(l3.next != null)
                {
                    result += ", ";
                }
                l3 = l3.next;
            }
            result += "]";
            Console.WriteLine(result);
            Console.Read();
        }

        public ListNode AddTwoNumbersSolution(ListNode l1, ListNode l2)
        {
            List<ListNode> list = new List<ListNode>();
            ListNode l3 = null;
            int plus = 0;

            while ((l1 != null || l2 != null) || plus == 1)
            {
                int first, second;
                if (l1 == null) { first = 0; } else { first = l1.val; }
                if (l2 == null) { second = 0; } else { second = l2.val; }

                int sum = first + second + plus;

                if (sum >= 10)
                {
                    plus = 1;
                    sum = sum % 10;
                }
                else
                {
                    plus = 0;
                }

                list.Add(new ListNode(sum));

                if (l1 != null) { l1 = l1.next; }
                if (l2 != null) { l2 = l2.next; }
            }

            for (int i = 0; i < list.Count - 1; i++)
            {
                list[i].next = list[i + 1];
            }

            l3 = list[0];

            return l3;
        }
    }
}
