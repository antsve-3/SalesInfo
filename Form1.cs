using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name;
            String personalNumber;
            String district;
            int soldArticles = 0;
            bool inputOk = true;
            List<SalesPerson> salesPersonsList = new List<SalesPerson>();
            String displayText;
            ErrorHandling error = new ErrorHandling();

            name = tbxName.Text;
            if(name =="" )
            {
                inputOk = error.BlankField(lblError, tbxName, "Namn");
            }
            personalNumber = tbxPersonalNumber.Text;
            if (personalNumber == "")
            {
                inputOk = error.BlankField(lblError, tbxPersonalNumber, "Personnummer");
            }
            district = tbxDistrict.Text;
            if (district == "")
            {
                inputOk = error.BlankField(lblError, tbxDistrict, "Distrikt");
            }
            try
            {
                soldArticles = Convert.ToInt32(tbxSoldArticles.Text);
            }
            catch (FormatException)
            {
                lblError.Text = "Antal artiklar måste anges i heltal.";
                lblError.Visible = true;
                inputOk = false;
            }

            String personalNumberError = error.PersonalNumberCheck(personalNumber);
            if(personalNumberError != "")
            {
                lblError.Text = personalNumberError;
                lblError.Visible = true;
                inputOk = false;
            }

            if (inputOk)
            {
                //skapa salespersoninfoobjekt
                SalesPerson newSalesPerson = new SalesPerson(name, personalNumber, district, soldArticles);
                //lägg till i en array
                salesPersonsList.Add(newSalesPerson);
                displayText = "Namn" + "\t" + "Personnummer" + "\t" + "Distikt" + "\t" + "Antal sålda artiklar" + "\n";
                //skriv ut hela arrayn
                foreach (SalesPerson salesPerson in salesPersonsList)
                {
                    displayText += salesPerson.getSalesPersonInfo();
                }
                lblSalesResult.Text = displayText;
                lblSalesResult.Visible = true;
                
            }
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

        private void testMethod(object sender, EventArgs e)
        {
            ////test
            //ErrorHandling err = new ErrorHandling();
            //String testText = err.PersonalNumberMonth("199300315052");
            //lblError.Text = testText;
            //lblError.Visible = true;
        }
    }
}
