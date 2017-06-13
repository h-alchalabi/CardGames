using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Card
    {
        private char suite {get; set;}
        private string value {get; set;}

        public Card(char suite, String value){
            this.suite = suite;
            this.value = value;
        }

        public String toString(){
            return this.value + this.suite;
        }
    }
}
