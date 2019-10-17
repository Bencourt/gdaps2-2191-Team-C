using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_StacksAndQueues
{
    // DO NOT MODIFY THIS CODE
    interface IStack
    {
        /// <summary>
        /// Gets the current count of items in the stack
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets whether or not there are items in the stack
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Look at and return the top of the stack. Returns
        /// null if the stack is empty.
        /// </summary>
        String Peek();

        /// <summary>
        /// Adds new data to the top of the stack.
        /// </summary>
        /// <param name="item">The data to add</param>
        void Push(String item);

        /// <summary>
        /// Removes and returns the data on top
        /// of the stack. Returns null if the stack is empty.
        /// </summary>
        String Pop();

    }
}