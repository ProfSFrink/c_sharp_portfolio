// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// MODULE 8: Libraries and Additional C# Features
// AUTHOR: Steven Partlow
// DATE: 13/02/2023

// DEALER CLASS DEFINITION

// A class to represent a dealer in a card game, which can be used by any potential playing card game

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Casino
{
    public class Dealer
    {
        /* PROPERTIES */

        public string Name { get; set; } // A string data type to represent the dealer's name
        public Deck Deck { get; set; } // A deck data type to represent the dealer's deck of cards
        public int Balance { get; set; } // A integer data type to represent the dealer's balance

        /* METHODS */

        public void Deal(List<Card> Hand) // A method which allows the dealer to add cards to their hand of card, one input parameter which is a list containing elements of the Card Class called Hand 
        {
            /* Utilise the built-in Add() method of the Hand object to add a card to the dealers deck, then use the built-in method First() of the Cards object to take the first element in that list, then print the name of the card added to the console */
            Hand.Add(Deck.Cards.First()); // Utilise the built-in Add() method of the Hand object to add a card to the dealers deck
            string card = string.Format(Deck.Cards.First().ToString() + "\n"); // Take the value of the card dealt and convert to a string assign to the string variable card
            Console.WriteLine(card); // Write the value of the card variable to the console
            /* using (StreamWriter file = new StreamWriter(@"C:\Users\Pitma\sp\Logs\Logs.txt", true)) */
            using (StreamWriter file = new StreamWriter(@"C:\Users\ProfS\Logs\Logs.txt", true))
            /* using (StreamWriter file = new StreamWriter(@"C:\Users\Steven Partlow\Logs.txt", true)) */ // Create a new StreamWriter object called file assign it the file in the provided path and set that we wish to append to the file to true, the using statement frees up memory after we are done
            {
                file.WriteLine(DateTime.Now); // Write the current date and time to file
                file.WriteLine(card); // Write the value of the string card to file
            } // End STEAMWRTIER
            Deck.Cards.RemoveAt(0); // Finally use the built-in method RemoveAt() which will remove the card at index 0 from the Deck object as we have added to the Dealers hand so can remove it from the original deck
        } // End Deal Method

    } // End CLASS definition Dealer

} // End Casino NAMESPACE
