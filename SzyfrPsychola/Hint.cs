using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SzyfrPsychola
{
    public class Hint
    {
       
        public string accessCode { get; set; }
        public string messeage { get; set; }

        public string input { get; set; }
        public string output { get; set; }
        public Brush color;
        public Hint(string ac, string m, Brush c)
        {
            this.output= "Nie można wyświetlić wiadomości,\n [wpisz poprawnie kod aktywacyjny]";
            this.accessCode = ac;
            this.messeage = m;
            this.color = c;
        }

        public bool Validate(string inp)
        {
            if(this.accessCode== inp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
