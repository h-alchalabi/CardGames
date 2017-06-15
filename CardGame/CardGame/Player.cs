using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Player 
    {
        private int counter;
        private List<Card> hand;

        public Player()
        {
            counter = 0;
            hand = new List<Card>();
        }

        //Getters & Setters
        public List<Card> getHand() { return this.hand; }
        public void setHand(List<Card> hand) { this.hand = hand; }
        public void setPosition(Card c) { hand.Add(c); }

        public void draw(Card c) //TODO: implement draw. 
        {
            hand.Add(c);
            hand.Sort();
        }

        public void printHand() //Prints the player's hand. 
        {
            StringBuilder s = new StringBuilder();
            s.Append("Hand: ");
            foreach (Card c in hand)
            {
                s.Append(c.toString() + " ");
            }
            Console.WriteLine(s);
        }

        public void sort() { hand.Sort(delegate(Card c1, Card c2) { return c1.valueStringToInt().CompareTo(c2.valueStringToInt()); }); }







        /* Legacy Code. 

        public void sort(int left, int right)                                            //QuickSort implementation to sort player's hand strictly based on value.
        {
            int low = left, high = right;
            int pivot = hand[((low + high) / 2)].valueStringToInt();
            while (low <= high)
            {
                while (hand[low].valueStringToInt().CompareTo(pivot) < 0) { low++; }
                while (hand[high].valueStringToInt().CompareTo(pivot) > 0) { high--; }
                if (low <= high)
                {
                    Card temp = hand[low];
                    hand[low] = hand[high];
                    hand[high] = temp;
                    low++;
                    high--;
                }
                if (left < high) { sort(left, high); }
                if (low < right) { sort(low, right); }
            }
        }
         */
        
        

    }
}
