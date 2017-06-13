using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Deck
    {
        private Card[] deck {get; set;} 

        char[] suites = { 'H', 'D', 'S', 'C' }; //H = \u2661, D = \u2662, S = \u2660, C = \u2663 
        String[] value = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        public Deck(int size)
        {     											//Constructor Method
            this.deck = new Card[size];										//Setting the size of Deck, typically 52 as it is the standard size of a deck
            char curSuite;													//Creating a variable that will determine the cursuite
            for (int i = 0; i < deck.Length; i++) 
            {
                curSuite = suites[i / 13];									//i/13 because after 13 cards it will change suite
                deck[i] = new Card(curSuite, value[i % value.Length]);		//Setting the Suite and value for each index in the array. 
            }
        }

        public String toString(){											//Overridding toString.
            StringBuilder s = new StringBuilder();
            s.Append("Deck: ");
            for (int i = 0; i < deck.Length; i++)
            {
                s.Append(deck[i].toString() + " ");
            }
            return s.ToString();
        }

        public Card[] shuffle()  
        {											//Shuffling the deck
            Card temp;
            Random rand = new Random();
            int randomInt;
            for (int current = this.deck.Length - 1; current > 0; current--){
                randomInt = rand.Next(current);							    //Generate a random number between 0 and the current size of the array
                temp = deck[current];										//Swap the selected element with the last element of the array. 
                deck[current] = deck[randomInt];							//decrement the current size of the array. 
                deck[randomInt] = temp;
            }
            return this.deck;
        }

        public Player[] deal(Player[] playerArray, int amountToDeal)                //Right now it doesnt check to make sure the number of players is within 52.
        {
		int amountOfCards = playerArray.Length * amountToDeal; 
		    for(int i = 0; i < amountOfCards; i++)
            {
			playerArray[i%playerArray.Length].setPosition(i/playerArray.Length, deck[i]);
		    }
		
		return playerArray;
		
	    }

        public Card[] getDeck()
        {
            return deck;
        }

        public void setDeck(Card[] deck)
        {
            this.deck = deck;
        }

        public Card[] CopyTo(Deck deck, int i)
        {
            Card[] cardArray = new Card[52 - i];
            Card[] temp = deck.getDeck(); 

            for (int j = 0; j < cardArray.Length; j++)
            {
                cardArray[j] = temp[i++];
            }

                return cardArray; 
        }

    }
}
