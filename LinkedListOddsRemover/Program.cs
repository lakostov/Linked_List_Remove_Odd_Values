using System;

namespace LinkedListOddsRemover
{
    class Program
    {
        class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }

            public Node(int value)
            {
                Value = value;
                Next = null;
            }
        }

        class LinkedList
        {
            public Node Head { get; set; }

            public LinkedList()
            {
                Head = null;
            }

            public void AddNode(Node newNode)
            {
                if (Head == null)
                {
                    Head = newNode;
                    newNode.Next = null;
                }
                else
                {
                    Node currentNode = Head;
                    while (currentNode.Next != null)
                    {
                        currentNode = currentNode.Next;
                    }

                    currentNode.Next = newNode;
                    newNode.Next = null;
                }
            }

            public void RemoveNodeByPosition(int position)
            {
                if (Head == null || position < 1)
                {
                    return;
                }
                else if (position == 1)
                {
                    Head = Head.Next;
                }
                else
                {
                    //3->5->15->20->25->30->35
                    Node previousNode = Head;
                    Node currentNode = Head.Next;
                    int counter = 1;
                    while (currentNode != null && counter < position - 1)
                    {
                        previousNode = previousNode.Next;
                        currentNode = currentNode.Next;
                        counter++;
                    }

                    if (currentNode == null)
                    {
                        return;
                    }
                    else
                    {
                        previousNode.Next = currentNode.Next;
                        currentNode = null;
                    }

                }
            }

            public void RemoveNodeByValue(int value)
            {
                if (Head == null)
                {
                    return;
                }
                else
                {
                    Node previousNode = Head;
                    Node currentNode = Head.Next;

                    while (currentNode != null)
                    {
                        if (currentNode.Value == value)
                        {
                            previousNode.Next = currentNode.Next;
                            currentNode = null;
                            return;
                        }
                        currentNode = currentNode.Next;
                        previousNode = previousNode.Next;
                    }
                }
            }

            public void PrintList()
            {
                Node currentNode = Head;
                while (currentNode.Next != null)
                {
                    Console.WriteLine(currentNode.Value);

                    currentNode = currentNode.Next;
                }
                Console.WriteLine(currentNode.Value);
            }

            public void RemoveOddNodes()
            {
                if (Head == null)
                {
                    return;
                }
                else
                {
                    //3->5->15->20->25->30->35
                    while (Head.Value % 2 != 0)
                    {
                        Head = Head.Next;
                    }
                    Node previousNode = Head;
                    Node currentNode = Head.Next;

                    while (currentNode.Next != null)
                    {
                        if (currentNode.Value % 2 != 0)
                        {
                            previousNode.Next = currentNode.Next;
                        }
                        else
                        {
                            previousNode = currentNode;
                        }
                        currentNode = currentNode.Next;
                    }
                    if (currentNode.Value % 2 != 0)
                    {
                        previousNode.Next = null;
                    }
                   
                }
            }
        }

        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.AddNode(new Node(1));
            list.AddNode(new Node(5));
            list.AddNode(new Node(8));
            list.AddNode(new Node(20));
            list.AddNode(new Node(25));
            list.AddNode(new Node(30));
            list.AddNode(new Node(35));

            Console.WriteLine("This is the initial list:");
            list.PrintList();
            Console.WriteLine("This is the list with odds removed:");
            list.RemoveOddNodes();
            list.PrintList();
            Console.WriteLine("This is the initial list with third node removed:");
            list.RemoveNodeByPosition(3);
            list.PrintList();
            Console.WriteLine("This is the initial list with value 20 removed:");
            list.RemoveNodeByValue(20);
            list.PrintList();
        }
    }
}
