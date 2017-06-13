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
    }
}
