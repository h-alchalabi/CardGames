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

        public char getSuite()
        {
            return this.suite;
        }
        public string getValue()
        {
            return this.value;
        }

        public Card(char suite, String value){
            this.suite = suite;
            this.value = value;
        }

        public String toString(){
            return this.value + this.suite;
        }

        public int valueStringToInt()                               //Converting string to int based on the value of the card. Used when sorting. 
        {
            if (this.value == "A")
                return 1;
            else if (this.value == "J")
                return 11;
            else if (this.value == "Q")
                return 12;
            else if (this.value == "K")
                return 13;
            else
                return Int32.Parse(this.value);
        }
    }
}
