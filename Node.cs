using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInfo
{
    class Node
    {
        private SalesPerson Person;
        private Node Next;

        public Node(SalesPerson person, Node next)
        {
            Person = person;
            Next = next;
        }
    }
}
