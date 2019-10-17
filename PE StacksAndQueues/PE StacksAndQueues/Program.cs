using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_StacksAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            // DO NOT MODIFY THIS CODE

            // We're going to create both a stack and a queue and
            // add the same data to them in the same order.
            IStack testStack = new MyStack();
            IQueue testQueue = new MyQueue();

            testStack.Push("a");
            testStack.Push("b");
            testStack.Push("c");
            testStack.Push("d");
            testStack.Push("e");

            testQueue.Enqueue("a");
            testQueue.Enqueue("b");
            testQueue.Enqueue("c");
            testQueue.Enqueue("d");
            testQueue.Enqueue("e");

            // Now remove one by one from the STACK and print it out
            Console.WriteLine("The stack has " + testStack.Count + " items in it.");
            Console.WriteLine("\tStarting at the top they are: ");
            while (testStack.Count > 0)
            {
                Console.WriteLine("\t\t" + testStack.Pop());
            }
            Console.WriteLine();

            // Now remove one by one from the QUEUE and print it out
            Console.WriteLine("The queue has " + testQueue.Count + " items in it.");
            Console.WriteLine("\tStarting at the front they are: ");
            while (testQueue.Count > 0)
            {
                Console.WriteLine("\t\t" + testQueue.Dequeue());
            }
            Console.WriteLine();
        }
    }
}