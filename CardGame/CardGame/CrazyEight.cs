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
        private Stack<Card> drawStack;
        private int turn, amountToDeal, counter = 0, amountOfPlayers;

        public CrazyEight(int amountOfPlayers, Deck deck)                       //Constructor, sets amount to deal to 8 
        {                                                                       //Sets the max size for the playedPile, each entry is init to null
            amountToDeal = 8;
            this.amountOfPlayers = amountOfPlayers;
            playedPile = new Card[52];
            drawStack = new Stack<Card>();
            players = new Player[amountOfPlayers];                              //Sets the approriate amountOfPlayers
            for (int i = 0; i < amountOfPlayers; i++) { players[i] = new Player(); }
            deck.setDeck(deck.shuffle());                                       //Shuffles the deck
            players = deck.deal(players, amountToDeal);                         //Deals the Cards to the players.
            deck.setDeck(deck.CopyTo(deck, amountToDeal * amountOfPlayers));    //Copies the cards that are not to dealt to players to a draw pile.
            for (int i = deck.getDeck().Length - 1; i >= 0; i--) { drawStack.Push(deck.getDeck()[i]); }
            Random random = new Random();
            turn = random.Next(amountOfPlayers);                                //Sets the starting player randomly.
            playedPile[0] = drawStack.Pop();                                    //Starts the game by playing the top card of drawPile. 
        }

        public void Play()                                                      //TODO: implement functionality of play. 
        {
            Console.WriteLine("Player " + turn + "'s turn to play. Top card is: " + playedPile[counter].toString());
            if (!players[turn].validCE(playedPile[counter]))
            {
                players[turn].draw(drawStack.Pop());
                if (players[turn].validCE(playedPile[counter]))
                    players[turn].playCE(playedPile[counter]);
            }
            else 
                players[turn].playCE(playedPile[counter]);




           // turn = ++turn % players.Length;                                    //giving the turn to the next player
        }

        //Getters & Setters 
        public Card[] getPlayedPile() { return this.playedPile; }
        public void setPlayedPile(Card[] playedPile) { this.playedPile = playedPile; }
        public Player[] getPlayers() { return this.players; }
        public void setPlayers(Player[] players) { this.players = players; }

    }
}
