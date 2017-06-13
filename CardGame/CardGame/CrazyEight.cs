using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class CrazyEight
    {
        private Card[] playedPile;
        private Player[] players;
        private Card[] drawPile;
        private int turn, amountToDeal, counter = 0, amountOfPlayers; 

        public CrazyEight(int amountOfPlayers, Deck deck)                       //Constructor, sets amount to deal to 8 
        {                                                                       //Sets the max size for the playedPile, each entry is init to null
            amountToDeal = 8;
            this.amountOfPlayers = amountOfPlayers;
            playedPile = new Card[52];
            players = new Player[amountOfPlayers];                              //Sets the approriate amountOfPlayers
            for (int i = 0; i < amountOfPlayers; i++)                           //Creates instances of the players
            {
                players[i] = new Player(amountToDeal);
            }
            deck.setDeck(deck.shuffle());                                       //Shuffles the deck
            players = deck.deal(players, amountToDeal);                         //Deals the Cards to the players.
            drawPile = deck.CopyTo(deck, amountToDeal * amountOfPlayers);       //Copies the cards that are not to dealt to players to a draw pile. 
            Random random = new Random();
            turn = random.Next(amountOfPlayers);                                //Sets the starting player randomly.
            playedPile[0] = drawPile[counter++];                                //Starts the game by playing the top card of drawPile. 
        }



        public void Play()                                                      //TODO: implement functionality of play. 
        {
            //players[turn++ % amountOfPlayers].printHand();
            foreach (Player p in players)
            {
                p.sort(0, p.getHand().Length-1);
                p.printHand();
            }
        }

        //Getters & Setters 
        public Card[] getPlayedPile()
        {
            return this.playedPile;
        }

        public void setPlayedPile(Card[] playedPile)
        {
            this.playedPile = playedPile;
        }

        public Player[] getPlayers()
        {
            return this.players;
        }

        public void setPlayers(Player[] players)
        {
            this.players = players;
        }

        public Card[] getDrawPile()
        {
            return this.drawPile;
        }

        public void setDrawPile(Card[] drawPile)
        {
            this.drawPile = drawPile;
        }



    }
}
