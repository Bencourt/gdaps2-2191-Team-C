using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_StacksAndQueues
{
    // DO NOT MODIFY THIS CODE
    interface IQueue
    {
        /// <summary>
        /// Gets the current count of items in the queue
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets whether or not there are items in the queue
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Look at and return the front of the queue.
        /// </summary>
        String Peek();

        /// <summary>
        /// Adds new data to the end of the queue
        /// </summary>
        /// <param name="item">The data to add</param>
        void Enqueue(String item);

        /// <summary>
        /// Removes and returns the data in the front
        /// of the queue.
        /// </summary>
        String Dequeue();
    }
}