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
        //Felhanteringsklassen tar hand om större delen av felhanteringen
        //detta gör metoderna i Form1 lite mer lättlasta och överskådliga
        public void BlankField(Label errorLable, TextBox textBox, string name)
        {
            //om ett fält lämnats tomt ges en anvisning till anvädaren att
            //fylla i fältet. 
            errorLable.Text = $"{name} måste anges för att gå vidare";
            errorLable.Visible = true;
            //fokus sätts på fältet ifråga
            textBox.Focus();
        }

        public string PersonalNumberCheck(string personalNumber)
        {
            //metoden genomför ett antal kontroller av personnumret. 
            //så snart ett fel har hittats returneras detta 
            //utan att några fortsatta kontroller görs.
            //om inget fel hittas returneras en tom sträng i slutet av metoden
            string errorText = "";
            errorText = PersonalNumberInt(personalNumber);
            if (errorText != "")
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
            if (errorText != "")
            {
                return errorText;
            }
            errorText = PersonalNumber21Check(personalNumber);
            if (errorText != "")
            {
                return errorText;
            }
            errorText = PersonalNumberUsed(personalNumber);
            if (errorText != "")
            {
                return errorText;
            }
            return errorText;

        }

        private string PersonalNumberInt(string personalNumber)
        {
            //metoden kontrollerar så att personnumret är ett heltal
            //d v s att inga andra tecken än siffror har angets
            //om något annat tecken har angets returnerar metoden ett felmeddelanden
            //om inget fel påträffas returneras en tom sträng
            string errorText = "";
            try
            {
                long personalNumberInt = Convert.ToInt64(personalNumber);
            }
            catch (FormatException)
            {
                errorText = "Personnumret kan inte innehålla några andra tecken än siffror.";
            }

            return errorText;
        }

        private string PersonalNumberLength(string personalNumber)
        {
            //metoden kontrollerar så att rätt antal siffror har angivits i personnumret
            //om fel antal har angivits returnerar metoden ett felmeddelande
            //om inget fel påträffas returneras en tom sträng.
            string errorText = "";
            if (personalNumber.Length != 12)
            {
                errorText = "Personnumret måste anges med 12 siffror i formatet YYYYMMDDXXXX";
            }

            return errorText;
        }

        private string PersonalNumberMonth(string personalNumber)
        {
            //metoden kontrollerar så att månadsvärdet i personnumret ligger mellen 1-12
            //om fel värde angivits returneras ett felmeddelande
            //om inget fel påträffas returneras en tom sträng.
            string errorText = "";
            int month = Convert.ToInt32(personalNumber.Substring(4, 2));

            if (month < 1 || month > 12)
            {
                errorText = "Månadsnumret i personnumret måste vara mellan 01 och 12";
            }

            return errorText;
        }

        private string PersonalNumberDay(string personalNumber)
        {
            //metoden kontrollerar så att dagarna angivna i personnumret
            //inte överskrider den angivna månadens dagar
            //om antalet dagar överskrider returneras ett felmeddelande
            //om inget fel påträffas returneras en tom sträng.
            string errorText = "";
            //konverterar månad och dag från personnumret
            int month = Convert.ToInt32(personalNumber.Substring(4, 2));
            int day = Convert.ToInt32(personalNumber.Substring(6, 2));
            //variabel för att håll antal dagar i den specifika månaden
            int noOfdaysInMonth;
            //arrayer för månader med 31 respektive 30 dagar
            int[] monthsWith31Days = { 1, 3, 5, 7, 8, 10, 12 };
            int[] monthsWith30Days = { 4, 6, 9, 11 };

            //kollar om den aktuella månaden finns med i arrayen med 31-dagars månader
            bool monthHas31Days = Array.Exists(monthsWith31Days, element => element == month);
            if (monthHas31Days)
            {
                noOfdaysInMonth = 31;
            }
            else
            {
                //kollar om den aktuella månaden finns med i arrayen med 30-dagars månader
                bool monthHas30Days = Array.Exists(monthsWith30Days, element => element == month);
                if (monthHas30Days)
                {
                    noOfdaysInMonth = 30;
                }
                else
                {
                    //månaden är februari. kollar om det var skottår, det aktuella året
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
            //om den angivna dagen är störren än antalet dagar i den aktualla månaden
            //lägg till en feltext
            if (day > noOfdaysInMonth)
            {
                errorText = "Antalet dagar angivet i personnumret \növerskrider den angivna månadens dagar.";
            }
            //returnera strängen errorText antingen blank eller med feltexten
            return errorText;
        }
        private string PersonalNumber21Check(string personalNumber)
        {
            //metoden kontrollerar personnumret enligt 21-algoritmen
            //om fel återfinns returneras en feltext
            //om inget fel påträffas returneras en tom sträng

            //förkortar personnumret eftersom beräkningen görs på tiosiffrigt personnummer
            string shortPersonalNumber = personalNumber.Substring(2, 10);
            //sätter en counter och summa variabel
            int counter = 0;
            int sum = 0;
            string errorText = "";
            //loopar igenom varje siffra i personnumret
            foreach (char numberChar in shortPersonalNumber)
            {
                int number = (int)Char.GetNumericValue(numberChar);
                counter++;

                //varannan siffra ska multipliceras med 2.
                if (counter % 2 != 0)
                {
                    number *= 2;
                    //om resultatet överstiger 10 ska siffrorna läggas ihop
                    if (number > 9)
                    {
                        //loopar igenom talet så att jag ska kunna lägga ihop båda
                        //siffrorna
                        while (number > 0)
                        {
                            //lägger först till tiotalsiffran genom att kolla
                            //vilket restvärde som blir kvar när man tar 
                            //modulo 10
                            //delar sedan talet med 10 och fortsätter loopen
                            sum += number % 10;
                            number = number / 10;
                        }
                    }
                    else
                    {
                        //om resultatet inte översteg 10 kan det läggas till summan
                        sum += number;
                    }
                }
                else
                {
                    //varannan gång behöver ingen multiplicering göras 
                    //talet läggs till summan.
                    sum += number;
                }
            }

            //kontrollerar så att summan är delbar med 10.
            //om det inte är delbart läggs ett felmeddelande till
            if (sum % 10 != 0)
            {
                errorText = "Felaktigt personnummer angivet";
            }
            //felmedellandet eller en blank sträng returneras.
            return errorText;
        }

        private string PersonalNumberUsed(string personalNumber)
        {
            //metoden kontrollerar så att säljaren inte är registrerad sedan tidigare
            //genom att jämföra med en lista på tidigare registrerade personnummer
            //om personnumret redan är registrerats returneras ett felmeddelande
            //om personnumret inte använts innan lämnas en tom sträng

            //hämtar personnummerlistan från Form1-klassen
            List<string> personalNumbers = Form1.PersonalNumbers;
            //om personnummerlistan är tom, behöver ingen ytterligare kontroll göras
            if (personalNumbers == null)
            {
                return "";
            }
            //kontrollerar om personnumret återfinns i personnummerlistan
            bool personalNumberUsed = personalNumbers.Contains(personalNumber);
            //returnerar en felmeddelande text om personnumret redan har använts annars en tom sträng
            if (personalNumberUsed)
            {
                return "Säljaren har redan registrerats. Använd ett annat personnummer";
            }
            else
            {
                return "";
            }
        }
    }
}
