using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesInfo
{
    class LinkedList
    {
        //klassen används för att skapa upp länkade listor innehållande noder

        //head är första noden för den länkade listan
        private Node head;
        //level är den aktuella säljnivån
        private string level;
        //articles är beskrivningen av antalet artiklar 
        //som krävs för att uppnå den aktuella nivån
        private string articles;

        //gör fälten tillgängliga utanför klassen
        public Node Head
        {
            get
            {
                return head;
            }
        }

        public string Level
        {
            get
            {
                return level;
            }
        }
        public string Articles
        {
            get
            {
                return articles;
            }
        }

        //konstruktorn
        public LinkedList(string level, string articles)
        {
            this.level = level;
            this.articles = articles;
        }

        public void AddInOrder(SalesPerson salesPerson)
        {
            //metod för att lägga till en ny säljperson i den länkade listan
            //och i o m detta skapa upp en ny node.
            //personen läggs på rätt plats i ordningen så att ingen sortering
            //behöver göras senare

            SalesPerson person = salesPerson;
            //kontrollerar om det finns någon node i listan sedan tidigare
            //om inte görs den aktuella noden till head för listan
            if (head == null)
            {
                head = new Node(person);
                return;
            }
            //sätter head-noden till current (det är den noden som vi ska
            //börja jämföra med)
            Node current = head;
            //head-noden är först och har därför ingen node före sig i listan
            Node previous = null;
            //skapar upp en temp-variabel om säljpersonen visar
            //sig ha sålt färre artiklar än nuvarande head.
            Node newHead = null;
            
            //jämför säljpersonens antal sålda artiklar med 
            //den aktuella nodens säljpersons sålda artiklar
            //så länge den aktuella nodens säljperson har färre går man vidare till nästa 
            while (current.Person.SoldArticles < person.SoldArticles)
            {
                //om det inte finns någon person härnäst i listan
                //lägger man till säljpersonen i en ny node härnäst i listan
                if (current.Next == null)
                {
                    current.Next = new Node(person);
                    return;
                }
                previous = current;
                current = current.Next;
            }
            //om säljpersonen har sålt färre än den nuvarande nodens säljperson
            //och den nuvarande noden är head, läggs säljpersonen till som head istället
            if (current == head)
            {
                newHead = new Node(person);
                newHead.Next = current;
                head = newHead;
                return;
            }
            //om säljpersonen ska infogas mitt i listan bryter man länken mellan
            //den tidigare och nuvarande noden genom att lägga till en ny node med 
            //säljpersonen som Next i den node man just passerat
            previous.Next = new Node(person);
            //för att lägga till den nuvarande noden som next i den nyskapade
            //går man tillbaka till den tidigare, för att hänvisa till
            //nästa nodes Next
            previous.Next.Next = current;
        }
    }
}
