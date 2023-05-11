// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// MODULE 7: Creating a Game of Blackjack and Intermediate C# Programming
// AUTHOR: Steven Partlow
// DATE: 21/01/2023

// GAMES CLASS DEFINITION

// This generic game class contains properties and methods which are common to all card games, and can be reused later by other card games

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{

    public abstract class Game // Make the Game class and abstract class as we will never need to create an instance of this class instead only inherit from it
    {
        /* PROPERTIES */

        private List<Player> _players = new List<Player>(); // Add private instance of players list so we automatically instantiate an empty list
        private Dictionary<Player, int> _bets = new Dictionary<Player, int>(); // Add private instance of Bets dictionary so we automatically instantiate an empty dictionary

        public List<Player> Players { get { return _players; } set { _players = value; } } // A list of Player objects called Players, with each element representing a player in the game, points to the already instantiated private _players list
        public string Name { get; set; } // The name of the game (Blackjack, Poker, Texas Hold-em, Solitaire, etc
        public Dictionary<Player, int> Bets { get { return _bets; } set { _bets = value; } } // A dictionary called Bets to track the bets the players have made the key is an instance of the Player class with value being an integer value to represent the amount bet, points to the already instantiated private _bets dictionary

        /* This method is simply to take the list of player names and output them to the console, something that again all card games would have in common */

        /* METHODS */

        public abstract void Play(); // Create an abstract method call Play() which will implement in any inheriting class

        public virtual void ListPlayers() // The virtual keyword allows this method to be inherited but also overriden
        {
            foreach (Player player in Players) // Iterate through each element of the list Players assigning the value to the string player
            {
                Console.WriteLine(player.Name); // Output the current value assigned to the player.name property to the console
            } // End FOREACH
        } // End ListPlayers Method

    } // End GAME Class

} // End Casino NAMESPACE
