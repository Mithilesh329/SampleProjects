using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// You are given two linked lists representing two non-negative numbers.The digits are stored in 
// reverse order and each of their nodes contain a single digit.Add the two numbers and return it as a linked list.
// Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
// Output: 7 -> 0 -> 8

namespace SampleProjects
{  
    public class AddTwoNumbersSolution
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        ListNode head = null;
        ListNode temp = null;

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {

            AddNum(l1, l2, 0);

            return head;
        }

        private void AddNum(ListNode l1, ListNode l2, int carry)
        {
            if (l1 == null && l2 == null && carry == 0)
            {
                return;
            }

            ListNode node = new ListNode(0);
            if (carry > 0 && l1 == null && l2 == null)
            {
                node.val = carry;
                carry = 0;
            }
            else
            {
                if (l1 == null)
                {
                    node.val = (l2.val + carry) % 10;
                    carry = (l2.val + carry) / 10;
                }
                else if (l2 == null)
                {
                    node.val = (l1.val + carry) % 10;
                    carry = (l1.val + carry) / 10;
                }
                else
                {
                    node.val = (l1.val + l2.val + carry) % 10;
                    carry = (l1.val + l2.val + carry) / 10;
                }
            }

            if (head == null)
            {
                head = node;
                temp = head;
            }
            else
            {
                temp.next = node;
                temp = node;
            }

            AddNum(l1 == null ? null : l1.next, l2 == null ? null : l2.next, carry);
        }
    }
}
