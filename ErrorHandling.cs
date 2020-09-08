using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesInfo
{
    class ErrorHandling
    {
        public bool BlankField(Label errorLable, TextBox textBox, String name)
        {
            errorLable.Text = $"{name} måste anges för att registrera säljresultatet";
            errorLable.Visible = true;
            textBox.Focus();
            return false;
        }

        public String PersonalNumberCheck(String personalNumber)
        {
            String errorText = "";
            errorText = PersonalNumberInt(personalNumber);
            if(errorText!="")
            {
                return errorText;
            }
            errorText = PersonalNumberLength(personalNumber);
            if (errorText != "")
            {
                return errorText;
            }
            errorText = PersonalNumberMonth(personalNumber);
            if (errorText != "")
            {
                return errorText;
            }
            errorText = PersonalNumberDay(personalNumber);
            return errorText;
        }

        private String PersonalNumberInt(String personalNumber)
        {
            String errorText = "";
            try
            {
                long personalNumberInt = Convert.ToInt64(personalNumber);
            }
            catch (FormatException)
            {
                errorText = "Personnumret kan inte innehålla några andra symboler än siffror.";
            }

            return errorText;
        }

        private String PersonalNumberLength(String personalNumber)
        {
            String errorText = "";
            if (personalNumber.Length != 12)
            {
                errorText = "Personnumret måste anges med 12 siffror i formatet YYYYMMDDXXXX";
            }

            return errorText;
        }

        private String PersonalNumberMonth(String personalNumber)
        {
            String errorText = "";
            int month = Convert.ToInt32(personalNumber.Substring(4, 2));

            if (month < 1 || month > 12)
            {
                errorText = "Månadsnumret i personnumret måste vara mellan 01 och 12";
            }

            return errorText;
        }

        private String PersonalNumberDay(String personalNumber)
        {
            String errorText = "";
            int month = Convert.ToInt32(personalNumber.Substring(4, 2));
            int day = Convert.ToInt32(personalNumber.Substring(6, 2));
            int noOfdaysInMonth;
            int[] monthsWith31Days = { 1, 3, 5, 7, 8, 10 };
            int[] monthsWith30Days = { 4, 6, 9, 11 };

            bool monthHas31Days = Array.Exists(monthsWith31Days, element => element == month);
            if (monthHas31Days)
            {
                noOfdaysInMonth = 31;
            }
            else
            {
                bool monthHas30Days = Array.Exists(monthsWith30Days, element => element == month);
                if (monthHas30Days)
                {
                    noOfdaysInMonth = 30;
                }
                else
                {
                    int year = Convert.ToInt32(personalNumber.Substring(0, 4));
                    if (DateTime.IsLeapYear(year))
                    {
                        noOfdaysInMonth = 29;
                    }
                    else
                    {
                        noOfdaysInMonth = 28;
                    }
                }
            }
            if (day > noOfdaysInMonth)
            {
                errorText = "Antalet dagar angivet i personnumret \növerskrider den angivna månadens dagar.";
            }

            return errorText;
        }
    }
}
