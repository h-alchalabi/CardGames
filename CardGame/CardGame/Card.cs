using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Card 
    {
        private char suite;
        private string value;

        //Getters & Setters. 
        public char getSuite(){return this.suite;}
        public string getValue(){return this.value;}

        public Card(char suite, String value){                  //Constuctor 
            this.suite = suite;
            this.value = value;
        }

        public String toString(){                               //ToString
            return this.value + this.suite;
        }

        public int valueStringToInt()                               //Converting string to int based on the value of the card. Used when sorting. 
        {
            if (this.value.Equals("A", StringComparison.CurrentCultureIgnoreCase))
                return 1;
            else if (this.value.Equals("J", StringComparison.CurrentCultureIgnoreCase))
                return 11;
            else if (this.value.Equals("Q", StringComparison.CurrentCultureIgnoreCase))
                return 12;
            else if (this.value.Equals("K", StringComparison.CurrentCultureIgnoreCase))
                return 13;
            else
                return Int32.Parse(this.value);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            Card c = (Card)obj;

            if (this.value.Equals(c.getValue()) && this.suite == c.getSuite()) return true;
            else return false;
        }

    }
}
