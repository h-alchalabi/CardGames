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
            int amountOfPlayers = 5;
            Deck deck = new Deck(52);
            Player[] playerArray = new Player[amountOfPlayers];
            CrazyEight crazyEight = new CrazyEight(amountOfPlayers, deck);
            crazyEight.Play();



            //for (int i = 0; i < playerArray.Length; i++)
            //{
            //    playerArray[i] = new Player(amountToDeal);
            //}

            //Console.WriteLine(deck.toString());

            //deck.setDeck(deck.shuffle());

            //for (int i = 0; i <= 3; i++)
            //{
            //    deck.setDeck(deck.shuffle());
            //}

            //Console.WriteLine("\nShuffled Deck: \n" + deck.toString());

            //deck.deal(playerArray, amountToDeal);

            //Console.WriteLine("\nPlayer Hands: ");

            //foreach (Player p in playerArray)
            //{
            //    Card[] temp = p.getHand();

            //    for (int i = 0; i < temp.Length; i++)
            //    {
            //        Console.Write(temp[i].toString() + " ");
            //    }
            //    Console.WriteLine();
            //}





            Console.ReadKey();
        }
    }
}
