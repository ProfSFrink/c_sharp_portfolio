// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// MODULE 8: Libraries and Additional C# Features
// AUTHOR: Steven Partlow
// DATE: 13/02/2023

// PLAYER CLASS DEFINITION

// A class definition for a player in a card game, this class can be used by any card game

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Player
    {
        /* CONSTRUCTOR */

        /* This chains off the original constructor for this clsss and only needs a player name as an argument, we set the balance to a default value of one hundred, no further implementation is required as we will reuse the code from the original constructor */

        public Player(string name) : this(name, 100)
        {
        } // End CALL CHAIN CONSTRUCTOR Player

        /* A constructor which is created on object instantiation containing two input parameters, name and beginningBalance */

        public Player(string name, int beginningBalance)
        {
            Hand = new List<Card>(); // Instantiate the Hand properties list
            Balance = beginningBalance; // Assign input parameter beginningBalance to property Balance
            Name = name; // Assign input parameter name to property Name
        } // End CONSTRUCTOR

        /* PROPERTIES  */

        private List<Card> _hand = new List<Card>(); // Instance a new private list of the Card class called _hand
        public List<Card> Hand { get { return _hand;  } set { _hand = value; } } // A list data type containing instances of the Card class, this object will represent the players hand of card in the game, points to the private instance of the list _hand
        public int Balance { get; set; } // An integer data type to represent the player's current balance
        public string Name { get; set; } // A string data type to represent the player's name
        public bool IsActivelyPlaying { get; set; } // A boolean data type to track if it's this instance of the player classes turn in during the game
        public bool Stay { get; set; } // A boolean data type to represent if the player wants to stay
        public Guid Id { get; set; } // A Guid data type to give this instance of the player class a unqiue identifier

        /* METHODS */

        /* A custom method to allow the Player to place a bet, has one input parameter which is an integer to cover the amount the player wants to bet, method returns a boolean which will return true if the player has enough in their balance to place the bet and false if they do not */
        public bool Bet(int amount)
        {
            if (Balance - amount < 0 ) // If after deducting the amount the Player wants to bet from their balance, said balance is less than zero
            {
                Console.WriteLine("You do not have enough to place a bet of that size."); // Output this text to the console
                return false; // The method will return false as the player does not have enough to place the bet
            } // End IF
            else // Then the player does have enough in their balance to place the bet
            {
                Balance -= amount; // Deduct the amount from the Player's balance
                return true; // Then we return true as the Player has enough in their balance to place the bet 
            } // End ELSE
        } // End Bet Method

        /* A method which overloads the '+' operator so we can add two objects together an instance of the Game class and Player class, the method will return an instance of the Game object */
        public static Game operator+ (Game game, Player player)
        {
            game.Players.Add(player); // Add the passed in Player object to the list property Players of the game object
            return game; // Return the updated game object
        } // End operator+ Method

        /* A method which overloads the '-' operator so we can subtract two objects, an instance of the Game class and Player class, the method will return an instance of the Game object */
        public static Game operator- (Game game, Player player)
        {
            game.Players.Remove(player); // Remove the passed in Player object to the list property Players of the game object
            return game; // Return the updated game object
        } // End operator+ Method

    } // End PLayer CLASS Definition

} // End Casino NAMESPACE
