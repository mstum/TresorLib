using System;
using System.Collections.Generic;
using System.Text;

namespace TresorLib
{
    internal static class ExtensionMethods
    {
        internal static T GetAtIndex<T>(this LinkedList<T> linkedList, int index, bool remove = false)
        {
            var node = linkedList.First;            

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            if(remove)
            {
                linkedList.Remove(node);
            }

            return node.Value;
        }
    }
}
