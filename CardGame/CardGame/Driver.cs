using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Driver
    {
        static void Main(string[] args)
        {
            int amountOfPlayers = 5, amountToDeal = 8;                                                //TODO: let user define amount of players.
            Deck deck = new Deck(52);                                       
            Player[] playerArray = new Player[amountOfPlayers];
            CrazyEight crazyEight = new CrazyEight(amountOfPlayers, deck);


            while (true) { 
                crazyEight.Play();
            }           
            
            
            //for (int i = 0; i < playerArray.Length; i++)
            //{
            //    playerArray[i] = new Player(amountToDeal);
            //}

            //Console.WriteLine(deck.toString());

            //setDeck(deck.shuffle());

            //for (int i = 0; i <= 3; i++)
            //{
            //    deck.setDeck(deck.shuffle());
            //}

            //Console.WriteLine("\nShuffled Deck: \n" + deck.toString());

            //deck.deal(playerArray, amountToDeal);

            //Console.WriteLine("\nPlayer Hands: ");

            //foreach (Player p in playerArray)
            //{
               
            //    p.sort();
            //    List<Card> temp = p.getLHand();
            //    Console.Write("Hand: ");
            //    foreach (Card c in temp)
            //    {
            //        Console.Write(c.toString() + " " );
            //    }
            //    Console.WriteLine(); 
            //}





            Console.ReadKey();                              //To keep console open.
        }
    }
}
