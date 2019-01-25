using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.DataStructure.LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            CallInsertNodeAtTail();
            CallInsertNodeAtHead();
            CallInsertNodeAtPosition();
            CallDeleteANode();
            CallReversePrint();
            ReverseALinkedList();
            CallcompareTwoLinkedList();
            CallTwosortedLinkedLists();
            CallGetNode();
            CallRemoveDuplicates();
            CallDetectCycle();
            CallFindMergePointofTwoList();
            CallSortedDoublyInsert();
            CallReverseDoublyLinkedList();
            Console.ReadLine();
        }

        #region CallingMethods
        static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
        {
            while (node != null)
            {
                textWriter.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    textWriter.Write(sep);
                }
            }
        }
        private static void CallInsertNodeAtHead()
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            SinglyLinkedList llist = new SinglyLinkedList();

            int llistCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(Console.ReadLine());
                SinglyLinkedListNode llist_head = insertNodeAtHead(llist.head, llistItem);
                llist.head = llist_head;
            }



            //PrintSinglyLinkedList(llist->head, "\n", textWriter);
            //textWriter.WriteLine();

            //textWriter.Flush();
            //textWriter.Close();
        }
        private static void CallInsertNodeAtTail()
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            SinglyLinkedList llist = new SinglyLinkedList();

            int llistCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(Console.ReadLine());
                SinglyLinkedListNode llist_head = insertNodeAtTail(llist.head, llistItem);
                llist.head = llist_head;

            }

            Console.WriteLine(llist);

            //PrintSinglyLinkedList(llist.head, "\n", textWriter);
            //textWriter.WriteLine();

            //textWriter.Flush();
            //textWriter.Close();
        }
        private static void CallInsertNodeAtPosition()
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            SinglyLinkedList llist = new SinglyLinkedList();

            int llistCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(Console.ReadLine());
                llist.InsertNode(llistItem);
            }

            int data = Convert.ToInt32(Console.ReadLine());

            int position = Convert.ToInt32(Console.ReadLine());

            SinglyLinkedListNode llist_head = insertNodeAtPosition(llist.head, data, position);

            //PrintSinglyLinkedList(llist_head, " ", textWriter);
            //textWriter.WriteLine();

            //textWriter.Flush();
            //textWriter.Close();
        }
        private static void CallDeleteANode()
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            SinglyLinkedList llist = new SinglyLinkedList();

            int llistCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < llistCount; i++)
            {
                int llistItem = Convert.ToInt32(Console.ReadLine());
                llist.InsertNode(llistItem);
            }

            int position = Convert.ToInt32(Console.ReadLine());

            SinglyLinkedListNode llist1 = deleteNode(llist.head, position);

            //PrintSinglyLinkedList(llist1, " ", textWriter);
            //textWriter.WriteLine();

            //textWriter.Flush();
            //textWriter.Close();
        }
        private static void CallReversePrint()
        {
            int tests = Convert.ToInt32(Console.ReadLine());

            for (int testsItr = 0; testsItr < tests; testsItr++)
            {
                SinglyLinkedList llist = new SinglyLinkedList();

                int llistCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llistCount; i++)
                {
                    int llistItem = Convert.ToInt32(Console.ReadLine());
                    llist.InsertNode(llistItem);
                }

                reversePrint(llist.head);
            }
        }
        private static void ReverseALinkedList()
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int tests = Convert.ToInt32(Console.ReadLine());

            for (int testsItr = 0; testsItr < tests; testsItr++)
            {
                SinglyLinkedList llist = new SinglyLinkedList();

                int llistCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llistCount; i++)
                {
                    int llistItem = Convert.ToInt32(Console.ReadLine());
                    llist.InsertNode(llistItem);
                }

                SinglyLinkedListNode llist1 = reverse(llist.head);

                //PrintSinglyLinkedList(llist1, " ", textWriter);
                //textWriter.WriteLine();
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
        private static void CallTwosortedLinkedLists()
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int tests = Convert.ToInt32(Console.ReadLine());

            for (int testsItr = 0; testsItr < tests; testsItr++)
            {
                SinglyLinkedList llist1 = new SinglyLinkedList();

                int llist1Count = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llist1Count; i++)
                {
                    int llist1Item = Convert.ToInt32(Console.ReadLine());
                    llist1.InsertNode(llist1Item);
                }

                SinglyLinkedList llist2 = new SinglyLinkedList();

                int llist2Count = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llist2Count; i++)
                {
                    int llist2Item = Convert.ToInt32(Console.ReadLine());
                    llist2.InsertNode(llist2Item);
                }

                SinglyLinkedListNode llist3 = mergeLists(llist1.head, llist2.head);

                //PrintSinglyLinkedList(llist3, " ", textWriter);
                //textWriter.WriteLine();
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
        private static void CallcompareTwoLinkedList()
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int tests = Convert.ToInt32(Console.ReadLine());

            for (int testsItr = 0; testsItr < tests; testsItr++)
            {
                SinglyLinkedList llist1 = new SinglyLinkedList();

                int llist1Count = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llist1Count; i++)
                {
                    int llist1Item = Convert.ToInt32(Console.ReadLine());
                    llist1.InsertNode(llist1Item);
                }

                SinglyLinkedList llist2 = new SinglyLinkedList();

                int llist2Count = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llist2Count; i++)
                {
                    int llist2Item = Convert.ToInt32(Console.ReadLine());
                    llist2.InsertNode(llist2Item);
                }

                bool result = CompareLists(llist1.head, llist2.head);

                //textWriter.WriteLine((result ? 1 : 0));
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
        private static void CallGetNode()
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int tests = Convert.ToInt32(Console.ReadLine());

            for (int testsItr = 0; testsItr < tests; testsItr++)
            {
                SinglyLinkedList llist = new SinglyLinkedList();

                int llistCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llistCount; i++)
                {
                    int llistItem = Convert.ToInt32(Console.ReadLine());
                    llist.InsertNode(llistItem);
                }

                int position = Convert.ToInt32(Console.ReadLine());

                int result = getNode(llist.head, position);

                //textWriter.WriteLine(result);
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
        private static void CallRemoveDuplicates()
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                SinglyLinkedList llist = new SinglyLinkedList();

                int llistCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llistCount; i++)
                {
                    int llistItem = Convert.ToInt32(Console.ReadLine());
                    llist.InsertNode(llistItem);
                }

                SinglyLinkedListNode llist1 = removeDuplicates(llist.head);

                //PrintSinglyLinkedList(llist1, " ", textWriter);
                //textWriter.WriteLine();
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
        private static void CallDetectCycle()
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int tests = Convert.ToInt32(Console.ReadLine());

            for (int testsItr = 0; testsItr < tests; testsItr++)
            {
                int index = Convert.ToInt32(Console.ReadLine());

                SinglyLinkedList llist = new SinglyLinkedList();

                int llistCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llistCount; i++)
                {
                    int llistItem = Convert.ToInt32(Console.ReadLine());
                    llist.InsertNode(llistItem);
                }

                SinglyLinkedListNode extra = new SinglyLinkedListNode(-1);
                SinglyLinkedListNode temp = llist.head;

                for (int i = 0; i < llistCount; i++)
                {
                    if (i == index)
                    {
                        extra = temp;
                    }

                    if (i != llistCount - 1)
                    {
                        temp = temp.next;
                    }
                }

                temp.next = extra;

                bool result = hasCycle(llist.head);

                //textWriter.WriteLine((result ? 1 : 0));
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
        private static void CallFindMergePointofTwoList()
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int tests = Convert.ToInt32(Console.ReadLine());

            for (int testsItr = 0; testsItr < tests; testsItr++)
            {
                int index = Convert.ToInt32(Console.ReadLine());

                SinglyLinkedList llist1 = new SinglyLinkedList();

                int llist1Count = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llist1Count; i++)
                {
                    int llist1Item = Convert.ToInt32(Console.ReadLine());
                    llist1.InsertNode(llist1Item);
                }

                SinglyLinkedList llist2 = new SinglyLinkedList();

                int llist2Count = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llist2Count; i++)
                {
                    int llist2Item = Convert.ToInt32(Console.ReadLine());
                    llist2.InsertNode(llist2Item);
                }

                SinglyLinkedListNode ptr1 = llist1.head;
                SinglyLinkedListNode ptr2 = llist2.head;

                for (int i = 0; i < llist1Count; i++)
                {
                    if (i < index)
                    {
                        ptr1 = ptr1.next;
                    }
                }

                for (int i = 0; i < llist2Count; i++)
                {
                    if (i != llist2Count - 1)
                    {
                        ptr2 = ptr2.next;
                    }
                }

                ptr2.next = ptr1;

                int result = findMergeNode(llist1.head, llist2.head);

                //textWriter.WriteLine(result);
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
        private static void CallSortedDoublyInsert()
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                DoublyLinkedList llist = new DoublyLinkedList();

                int llistCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llistCount; i++)
                {
                    int llistItem = Convert.ToInt32(Console.ReadLine());
                    llist.InsertNode(llistItem);
                }

                int data = Convert.ToInt32(Console.ReadLine());

                DoublyLinkedListNode llist1 = sortedInsert(llist.head, data);

                //PrintDoublyLinkedList(llist1, " ", textWriter);
                //textWriter.WriteLine();
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
        private static void CallReverseDoublyLinkedList()
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                DoublyLinkedList llist = new DoublyLinkedList();

                int llistCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llistCount; i++)
                {
                    int llistItem = Convert.ToInt32(Console.ReadLine());
                    llist.InsertNode(llistItem);
                }

                DoublyLinkedListNode llist1 = reverse(llist.head);

                //PrintDoublyLinkedList(llist1, " ", textWriter);
                //textWriter.WriteLine();
            }

            //textWriter.Flush();
            //textWriter.Close();
        }
        #endregion

        #region linkedlists

        // Complete the printLinkedList function below.
        /*
         * For your reference:
         *
         * SinglyLinkedListNode {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */
        static void printLinkedList(SinglyLinkedListNode head)
        {
            if (head == null)
            {
                return;
            }

            SinglyLinkedListNode node = head;
            while (true)
            {
                Console.WriteLine(node.data);
                if (node.next != null)
                {
                    node = node.next;
                }
                else
                {
                    break;
                }
            }

        }

        // Complete the insertNodeAtTail function below.
        /*
         * For your reference:
         *
         * SinglyLinkedListNode {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */
        static SinglyLinkedListNode insertNodeAtTail(SinglyLinkedListNode head, int data)
        {
            if (head == null)
            {
                head = new SinglyLinkedListNode(data);
            }
            else
            {
                SinglyLinkedListNode node = head;
                while (node.next != null)
                {
                    node = node.next;
                }
                node.next = new SinglyLinkedListNode(data);
            }
            return head;
        }

        // Complete the insertNodeAtHead function below.
        /*
         * For your reference:
         *
         * SinglyLinkedListNode {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */
        static SinglyLinkedListNode insertNodeAtHead(SinglyLinkedListNode llist, int data)
        {

            if (llist == null)
                llist = new SinglyLinkedListNode(data);
            else
            {
                var temp = llist;

                llist = null;

                llist = new SinglyLinkedListNode(data);
                while (llist.next == null)
                {
                    llist.next = temp;
                }

            }
            return llist;
        }

        // Complete the insertNodeAtPosition function below.
        /*
         * For your reference:
         *
         * SinglyLinkedListNode {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */
        static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode head, int data, int position)
        {
            SinglyLinkedListNode node = null;
            if (position == 0)
            {
                node = new SinglyLinkedListNode(data);
                node.next = head;

                return node;
            }

            SinglyLinkedListNode prev = head;

            for (int i = 1; i < position; i++)
            {
                prev = prev.next;
            }

            node = new SinglyLinkedListNode(data);
            node.next = prev.next;
            prev.next = node;

            return head;
        }

        // Complete the deleteNode function below.
        /*
         * For your reference:
         *
         * SinglyLinkedListNode {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */
        static SinglyLinkedListNode deleteNode(SinglyLinkedListNode head, int position)
        {
            SinglyLinkedListNode node = head;
            if (position == 0)
                return node.next;

            while (--position > 0)
                node = node.next;

            node.next = node.next.next;
            return head;
        }

        // Complete the reversePrint function below.
        /*
         * For your reference:
         *
         * SinglyLinkedListNode {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */
        static void reversePrint(SinglyLinkedListNode head)
        {
            if (head == null)
            {
                Console.WriteLine("");
            }
            SinglyLinkedListNode node = null;
            while (head != null)
            {
                SinglyLinkedListNode i = node;
                node = new SinglyLinkedListNode(head.data);
                node.next = i;
                head = head.next;
            }
            while (node != null)
            {
                Console.WriteLine(node.data);
                node = node.next;
            }
        }

        // Complete the reverse function below.
        /*
         * For your reference:
         *
         * SinglyLinkedListNode {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */
        static SinglyLinkedListNode reverse(SinglyLinkedListNode head)
        {
            if (head == null)
            {
                return null;
            }
            SinglyLinkedListNode node = null;
            while (head != null)
            {
                SinglyLinkedListNode i = node;
                node = new SinglyLinkedListNode(head.data);
                node.next = i;
                head = head.next;
            }
            return node;
        }

        // Complete the CompareLists function below.
        /*
         * For your reference:
         *
         * SinglyLinkedListNode {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */
        static bool CompareLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {

            if (head1 == null && head2 == null)
            {
                return true;
            }
            while (head1.data == head2.data)
            {
                if (head1.next == null && head2.next == null)
                {
                    return true;
                }

                else if (head1.next == null || head2.next == null)
                {
                    return false;
                }
                else
                {
                    head1 = head1.next;
                    head2 = head2.next;
                }

            }
            return false;

        }

        // Complete the CompareLists function below.
        private static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            //SinglyLinkedListNode result = head1;
            if (head1 == null)
                return head2;
            else if (head2 == null)
                return head1;

            if (head1.data < head2.data)
            {
                head1.next = mergeLists(head1.next, head2);
                return head1;
            }
            else
            {
                head2.next = mergeLists(head1, head2.next);
                return head2;
            }
            //while (result.next!=null)
            //{
            //    result = result.next;
            //}
            //result.next = head2;

            //return head1;
        }

        // Complete the getNode function below.
        /*
         * For your reference:
         *
         * SinglyLinkedListNode {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */
        static int getNode(SinglyLinkedListNode head, int positionFromTail)
        {
            //if (positionFromTail == 0)
            //{
            //    return head.data;
            //}

            //int counter = 0;

            //while (head != null)
            //{
            //    if (counter==positionFromTail)
            //        break;

            //    counter++;
            //    head = head.next;
            //}

            //return head.data;

            int nodes = 0;
            SinglyLinkedListNode i = head;
            while (i != null)
            {
                i = i.next;
                nodes++;
            }
            nodes -= positionFromTail;
            while (--nodes > 0)
            {
                head = head.next;
            }
            return head.data;

        }

        // Complete the removeDuplicates function below.
        /*
         * For your reference:
         *
         * SinglyLinkedListNode {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */
        static SinglyLinkedListNode removeDuplicates(SinglyLinkedListNode head)
        {
            SinglyLinkedListNode node = head;
            if (head == null)
            {
                return null;
            }
            while (head.next != null)
            {
                if (head.data == head.next.data)
                {
                    head.next = head.next.next;
                }
                else
                {
                    head = head.next;
                }
            }
            return node;
        }

        // Complete the hasCycle function below.
        /*
         * For your reference:
         *
         * SinglyLinkedListNode {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */
        static bool hasCycle(SinglyLinkedListNode head)
        {
            if (head != null && head.next != null)
            {
                var slow = head;
                var fast = head.next;
                while (slow.next != null && fast.next != null && fast.next.next != null)
                {
                    if (slow == fast)
                    {
                        return true;
                    }
                    slow = slow.next;
                    fast = fast.next.next;
                }
                return false;
            }
            else
            {
                return head != null ? (head == head.next) : false;
            }

        }

        // Complete the findMergeNode function below.
        /*
         * For your reference:
         *
         * SinglyLinkedListNode {
         *     int data;
         *     SinglyLinkedListNode next;
         * }
         *
         */
        static int findMergeNode(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            int head1Len = 0, head2Len = 0;
            SinglyLinkedListNode head1copy = head1, head2copy = head2;
            while (head1copy != null)
            {
                head1copy = head1copy.next;
                head1Len++;
            }
            while (head2copy != null)
            {
                head2copy = head2copy.next;
                head2Len++;
            }
            while (head1Len > head2Len)
            {
                head1 = head1.next;
                head1Len--;
            }
            while (head2Len > head1Len)
            {
                head2 = head2.next;
                head2Len--;
            }
            while (head1 != null)
            {
                if (head1 == head2)
                {
                    return head1.data;
                }
                head1 = head1.next;
                head2 = head2.next;
            }
            return -1;

        }

        // Complete the sortedInsert function below.
        /*
         * For your reference:
         *
         * DoublyLinkedListNode {
         *     int data;
         *     DoublyLinkedListNode next;
         *     DoublyLinkedListNode prev;
         * }
         *
         */
        static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode head, int data)
        {
            DoublyLinkedListNode result = new DoublyLinkedListNode(data);
            if (head == null)
            {
                return result;
            }
            DoublyLinkedListNode node = head;
            while (node != null)
            {
                if (node.data >= data)
                {
                    DoublyLinkedListNode i = new DoublyLinkedListNode(data);
                    i.prev = node.prev;
                    i.next = node;
                    node.prev = i;
                    if (i.prev == null)
                    {
                        return i;
                    }
                    else
                    {
                        i.prev.next = i;
                        return head;
                    }
                }
                if (node.next == null)
                {
                    DoublyLinkedListNode i = new DoublyLinkedListNode(data);
                    i.prev = node;
                    i.next = null;
                    node.next = i;
                    break;
                }
                node = node.next;
            }
            return head;

        }

        // Complete the reverse function below.
        /*
         * For your reference:
         *
         * DoublyLinkedListNode {
         *     int data;
         *     DoublyLinkedListNode next;
         *     DoublyLinkedListNode prev;
         * }
         *
         */
        static DoublyLinkedListNode reverse(DoublyLinkedListNode head)
        {
            if (head == null)
            {
                return null;
            }
            while (head != null)
            {
                DoublyLinkedListNode i = head.prev;
                head.prev = head.next;
                head.next = i;
                if (head.prev == null)
                {
                    return head;
                }
                head = head.prev;
            }
            return head;

        }

        #endregion
    }
}

#region linkedList print classes
class SinglyLinkedListNode
{
    public int data;
    public SinglyLinkedListNode next;

    public SinglyLinkedListNode(int nodeData)
    {
        this.data = nodeData;
        this.next = null;
    }
}

class SinglyLinkedList
{
    public SinglyLinkedListNode head;
    public SinglyLinkedListNode tail;

    public SinglyLinkedList()
    {
        this.head = null;
        this.tail = null;
    }

    public void InsertNode(int nodeData)
    {
        SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

        if (this.head == null)
        {
            this.head = node;
        }
        else
        {
            this.tail.next = node;
        }

        this.tail = node;
    }
}

class DoublyLinkedListNode
{
    public int data;
    public DoublyLinkedListNode next;
    public DoublyLinkedListNode prev;

    public DoublyLinkedListNode(int nodeData)
    {
        this.data = nodeData;
        this.next = null;
        this.prev = null;
    }
}

class DoublyLinkedList
{
    public DoublyLinkedListNode head;
    public DoublyLinkedListNode tail;

    public DoublyLinkedList()
    {
        this.head = null;
        this.tail = null;
    }

    public void InsertNode(int nodeData)
    {
        DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

        if (this.head == null)
        {
            this.head = node;
        }
        else
        {
            this.tail.next = node;
            node.prev = this.tail;
        }

        this.tail = node;
    }
}
#endregion
