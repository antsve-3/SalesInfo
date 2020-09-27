using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInfo
{
    class Node
    {
        //Node-klassen används för tillsammans med den länkade listan
        //Den håller en säljperson och info om nästkommande node i listan
        private SalesPerson person;
        private Node next;

        //När noden konstrueras finns inte alltid info om vilken som är nästa node
        //därför krävs endast säljperson som parameter i kontruktorn
        public Node(SalesPerson person)
        {
            this.person = person;
        }

        //Gör fälten i klassen tillgängliga även utanför klassen.
        public SalesPerson Person
        {
            get
            {
                return person;
            }
            set
            {
                person = value;
            }
        }
        public Node Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }
    }
}
