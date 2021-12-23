using System;


class Node
{
    public int data;
    public Node next;
};

class LinkedList
{
    public Node head;
   
    public LinkedList()
    {
        head = null;
    }

    
    public void PrintList()
    {
        Node temp = new Node();
        temp = this.head;
        if (temp != null)
        {
            Console.Write("The list contains: ");
            while (true)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
                if (temp == this.head)
                    break;
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("The list is empty.");
        }
    }

    public void AddLast(int data)
    {
        if(head == null)
        {
            head = new Node()
            {
                data = data
            };
            head.next = head;
            return;
        }
        Node M = head;
        while(M.next != head)
        {
            M = M.next;
        }

        M.next = new Node()
        {
            data = data,
            next = head
        };
    }
    public Node FindMax()
    {
        if (head == null)
        {
            return null;
        }
        Node M = head;
        Node T = M;
        while (M.next != head)
        {
            if(T.data < M.data)
            {
                T = M;
            }
            
            M = M.next;
        }
        if (T.data < M.data)
        {
            T = M;
        }
        return T;

    }

    public void AddAfterMax(int data)
    {
        if (head == null)
        {
            head = new Node()
            {
                data = data
            };
            head.next = head;
            return;
        }
        Node Max = FindMax();
        Node MaxNext = Max.next;
        Node Elem = new Node()
        {
            data = data
        };
        Max.next = Elem;
        Elem.next = MaxNext;
    }
} 


