﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Player
    {
        private Card[] hand { get; set; }
        private int counter;

        public Player(int i){
            hand = new Card[i];
            counter = 0; 
        }
        public Card[] getHand()
        {
            return hand;
        }

        public void setHand(Card[] hand)
        {
            this.hand = hand;
        }
	
        public void setPosition(int i, Card c){
            hand[i] = c;
        }

        public void draw(int i) //TODO: implement draw. 
        {
            i = 2; 
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

        public void sort()
        {
            hand.OrderBy(card => card.getSuite);
        }

    }
}
