﻿using System;
using System.Text.RegularExpressions;
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
        private string pattern = @"(\A[pP]\s?$)|^(([aAjJqQkK]|[2-9]|10)[hHdDsScC]\s)+$";
        private Regex regex;

        public Player()
        {
            counter = 0;
            hand = new List<Card>();
        }

        //Getters & Setters
        public List<Card> getHand() { return this.hand; }
        public void setHand(List<Card> hand) { this.hand = hand; }
        public void setPosition(Card c) { hand.Add(c); }

        public void draw(Card c) //Player drawing a card
        {
            hand.Add(c);
            this.sort();
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

        //Sorting Algorithm using List's built in sorting Algorithm, using comparing based on card's value strictly. 
        public void sort() { hand.Sort(delegate(Card c1, Card c2) { return c1.valueStringToInt().CompareTo(c2.valueStringToInt()); }); }

        //Play for Crazy Eight variant
        /*
         * 1: Ask the user for input.
         * 2: Parse the input.
         * 3: if the user enters P, pass your turn without playing card(s)
         * 4: Convert the input from a string to card(s) 
         * 5: Check if the input is a subset of the players hand
         * 6: if it isn't, go to 1. Else remove the card(s)
         * 7: return the cards.
        */
        public Card[] playCE(Card c)
        {
            Card card = null;
            this.sort();
            this.printHand();
            String s;
            regex = new Regex(pattern);
            

            //Start of method: Asking user for input, in a specified format.
            Reinput:  
            Console.WriteLine("Enter the card(s) that you want to play." +
                    "\nfirst entering the value and then entering the suite seperated by a space for each card." +
                    "\nOr Enter P to pass");
            //If the input isn't in the correct format, loop until you get a correctly formatted string
            while (true)
            {
                s = Console.ReadLine();
                if (regex.IsMatch(s)) { break; }
                Console.WriteLine("The input wasn't in the correct format, please re-enter following the above stated rules.");
            }
            //if the first char is P then pass the turn.
            if (s.Split()[0].Equals("P", StringComparison.CurrentCultureIgnoreCase)) return null;
            //Convert the string into cards which are delimited by the whitespace
            Card[] cards = this.convertToCards(s.Split());

            int valid = 0;
            //Checking if the Player has the cards.
            foreach (Card x in cards)
            {
                if (hand.Any<Card>(q => q.getValue() == x.getValue() && q.getSuite() == x.getSuite()) )                                                     //TODO: FIX THE EQUALS COMPARER. 
                {
                    valid++;
                }
            }
            //if the Player enters cards that they don't have, tell them to start over
            if (valid != cards.Length){
                Console.WriteLine("You don't have the right cards. Please start over. ");
                goto Reinput; 
            }
            //if the user input is correct, remove the cards that they inputted.
            foreach (Card x in cards)
            {
                hand.Remove(x);
            }
            
            return cards;

        }

        //Checks if the player has a card that can be played.
        public bool validCE(Card c)
        {
            foreach (Card x in hand)
            {
                if (x.getSuite() == c.getSuite() || x.getValue() == c.getValue() || x.getValue() == "8")
                {
                    return true;
                }
            }
            return false;
        }
        //Parsing input method. 
        public Card[] convertToCards(String[] delimited)
        {
            Card[] cards = new Card[delimited.Length - 1];
            char[] b;
            for (int i = 0; i < delimited.Length - 1; i++)
            {
                if (delimited[i].Length == 2)
                {
                    b = delimited[i].ToCharArray();
                    cards[i] = new Card(b[1], b[0].ToString());
                }
                else if (delimited[i].Length == 3)
                {
                    b = delimited[i].ToCharArray();
                    cards[i] = new Card(b[2], b[0].ToString() + b[1].ToString());
                }
            }
            return cards;
        }


        /*
        public bool userInput()
        {
                while (true)
                {
                    Console.WriteLine("Enter the card(s) that you want to play." +
                        "\nfirst entering the value and then entering the suite seperated by a space for each card." +
                        "\nOr Enter P to pass");
                    s = Console.ReadLine();

                    if (regex.IsMatch(s)) { break; }

                    Console.WriteLine("The input wasn't in the correct format, please re-enter following the following rules: ");
                }
        }*/




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
