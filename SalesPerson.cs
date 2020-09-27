using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesInfo
{
    class SalesPerson
    {
        //en klass för att hålla säljpersonerna och deras info
        private String name;
        private String personalNumber;
        private String district;
        private int soldArticles;
        //hämtar tab-variablen för att använda samma tabavstånd som i Form1-klassen
        String tab = Form1.Tab;

        //konstruktorn
        public SalesPerson(String name, String personalNumber, String district, int soldArticles)
        {
            this.name = name;
            this.personalNumber = personalNumber;
            this.district = district;
            this.soldArticles = soldArticles;
        }

        //Gör sålda artiklar tillgängliga utanför klassen
        public int SoldArticles
        {
            get
            {
                return soldArticles;
            }
        }

        public string PersonalNumber
        {
            get
            {
                return personalNumber;
            }
        }
        public String getSalesPersonInfo()
        {
            //metod för att returnera en textsträng med info om säljaren och säljresultat
            String salesPersonInfo = name + tab + personalNumber + tab 
                + district + tab + soldArticles + "\r\n";
            return salesPersonInfo;
        }
    }
}
