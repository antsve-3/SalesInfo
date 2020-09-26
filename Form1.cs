using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesInfo
{
    public partial class Form1 : Form
    {
        //skapar upp en länkad lista per säljnivå
        private static LinkedList level1 = new LinkedList("nivå 1", "under 50");
        private static LinkedList level2 = new LinkedList("nivå 2", "50-99");
        private static LinkedList level3 = new LinkedList("nivå 3", "100-199");
        private static LinkedList level4 = new LinkedList("nivå 4", "över 199");
        //lägger till alla länkade listor i en array
        private static LinkedList[] levelLists = { level1, level2, level3, level4 };
        //deklarerar en tab-variabel som används för att slippa ändra
        //antalet mellanslag/tabbar på flera ställen om jag skulle vilja
        //ändra kolumnavståndet i utmatningen
        private static string tab = "    ";
        //gör Tab-variabeln tillgänglig utanför klassen.
        public static string Tab
        {
            get
            {
                return tab;
            }
        }
        //deklarerar en sträng med kolumnrubriker
        private static string displayColumns = "Namn" + tab + "Personnummer" + tab
                + "Distikt" + tab + "Antal sålda artiklar" + "\r\n";
        //variabel för att hålla texten som ska visas i utmatningen.
        private static string displayText;
        //skapar en lista för att hålla alla personnummer
        //detta kommera användas för att kontrollera så att man
        //inte skriver in samma personnummer flera gånger
        private static List<string> personalNumbers = new List<string>();
        //gör listan tillgänglig utanför klassen
        public static List<string> PersonalNumbers
        {
            get
            {
                return personalNumbers;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void btnAddSalesInfo_click(object sender, EventArgs e)
        {
            //nollställer utmatningssträngen och lägger till kolumnrubikerna
            displayText = displayColumns;
            //skapar en säljperson utifrån användarens inmatning
            SalesPerson newSalesPerson = RetrieveUserInput();

            //Fortsätter endast om en ny säljperson har skapats upp.
            if (newSalesPerson != null)
            {
                // skapar en ny Node och lägger till säljpersonen
                Node newNode = new Node(newSalesPerson);

                //lägger till node i en länkadlista baserat på 
                //vilken nivå som har uppnåtts
                if (newSalesPerson.SoldArticles < 50)
                {
                    level1.AddInOrder(newSalesPerson);
                }
                else if (newSalesPerson.SoldArticles < 100)
                {
                    level2.AddInOrder(newSalesPerson);
                }
                else if (newSalesPerson.SoldArticles < 200)
                {
                    level3.AddInOrder(newSalesPerson);
                }
                else
                {
                    level4.AddInOrder(newSalesPerson);
                }

                //lägger till personnumret i personnummerlistan
                personalNumbers.Add(newSalesPerson.PersonalNumber);

                //loopar igenom de länkade listorna för att lägga till 
                //varje säljpersons information i textsträngen som
                //senare ska utmatas eller skrivas till fil
                AddSalesInfoToDisplayText();
                
                
                //lägger till utmatningssträngen i visningstextboxen 
                tbxSalesResults.Text = displayText;

                //återställer textboxarna
                ResetTextBoxes();
                
                //gör det möjligt för användaren att spara innehållet till fil
                //genom att göra knappen synlig.
                btnFilePrint.Visible = true;
            }
        }

        private SalesPerson RetrieveUserInput()
        {
            //Metoden tar emot inmatning från användare
            //om inmatningen är ok returneras ett person-objekt
            //om något är fel med inmatningen returneras null

            //deklaration
            string name;
            string personalNumber;
            string district;
            int soldArticles = 0;
            //skapar en instans av felhanteringsklassen där merparten av 
            //felhanteringen görs
            ErrorHandling error = new ErrorHandling();
            
            //hämtar namn från textboxen. om fältet är tomt ges ett felmeddelande
            name = tbxName.Text;
            if (name == "")
            {
                error.BlankField(lblError, tbxName, "Namn");
                return null;
            }
            //hämtar personnummer från textboxen. om fältet är tomt ges ett felmeddelande
            personalNumber = tbxPersonalNumber.Text;
            if (personalNumber == "")
            {
                error.BlankField(lblError, tbxPersonalNumber, "Personnummer");
                return null;
            }
            //hämtar distrikt från textboxen. om fältet är tomt ges ett felmeddelande
            district = tbxDistrict.Text;
            if (district == "")
            {
                error.BlankField(lblError, tbxDistrict, "Distrikt");
                return null;
            }
            //hämtar antal sålda artiklar från textboxen. 
            //om användaren angivit något annat än heltal lämnas ett felmeddelande.
            try
            {
                soldArticles = Convert.ToInt32(tbxSoldArticles.Text);
            }
            catch (FormatException)
            {
                lblError.Text = "Antal artiklar måste anges i heltal.";
                lblError.Visible = true;
                return null;
            }

            //genomför ett antal personnummerkontroller i felhanteringsklassen
            string personalNumberError = error.PersonalNumberCheck(personalNumber);
            //om ett felmeddelande returneras ges detta till användaren
            //null returneras i så fall från metoden
            if (personalNumberError != "")
            {
                lblError.Text = personalNumberError;
                lblError.Visible = true;
                return null;
            }

            //om inget fel har hittats skapas ett SalesPerson-objekt upp och returneras från metoden
            SalesPerson person = new SalesPerson(name, personalNumber, district, soldArticles);
            return person;
        }

        private void AddSalesInfoToDisplayText()
        {
            //metoden hämtar säljarnas info från respektive nivå och
            //sparar ner i utmatningssträngen tillsammans med en sammanfattning
            //från respektive nivå
            foreach (LinkedList level in levelLists)
            {
                //deklarerar en räknare och sätter den till 0
                //denna räknare kommer senare användas då vi ska
                //sammanfatta antalet säljare inom den aktuella nivån
                int count = 0;
                //börja med att kolla på den första noden i listan
                Node current = level.Head;
                //om det inte finns någon säljperson inom nivån
                //hoppa vidare till nästa lista
                if (current == null)
                {
                    continue;
                }

                //loopar igenom noderna i listan
                while (current != null)
                {
                    //lägger till säljinfo för den aktuella personen i utmatningssträngen
                    displayText += current.Person.getSalesPersonInfo();
                    //hoppar till nästa node
                    current = current.Next;
                    //räknar upp antalet säljare inom nivån
                    count += 1;
                }
                //Lägger till en sammanfattning för nivån
                displayText += $"{count} säljare har nått {level.Level}: {level.Articles} artiklar \r\n\r\n";
            }
        }

        private void ResetTextBoxes()
        {
            //metoden återställer textboxarna
            tbxName.Text = "";
            tbxPersonalNumber.Text = "YYYYMMDDXXXX";
            tbxDistrict.Text = "";
            tbxSoldArticles.Text = "";
        }

        private void tbxPersonalNumber_OnFocus(object sender, EventArgs e)
        {
            //Tar bort placeholder-texten när focus sätts på textboxen
            if (tbxPersonalNumber.Text == "YYYYMMDDXXXX")
            {
                tbxPersonalNumber.Text = "";
            }

        }

        private void tbxPersonalNumber_DeFocus(object sender, EventArgs e)
        {
            //Sätter tillbaka placeholdertexten om användaren lämnar fältet oifyllt
            if (tbxPersonalNumber.Text == "")
            {
                tbxPersonalNumber.Text = "YYYYMMDDXXXX";
            }
        }

        private void SaveFile()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.Create(saveFileDialog1.FileName).Close(); // Create file
                using (StreamWriter sw = File.AppendText(saveFileDialog1.FileName))
                {
                    sw.WriteLine(displayText); // Write text to .txt file
                }
            }

        }

        private void btnFilePrint_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void tbxPersonalNumber_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void tbxDistrict_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void tbxSoldArticles_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }
    }
}
