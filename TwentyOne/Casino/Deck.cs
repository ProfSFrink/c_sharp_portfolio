// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// MODULE 7: Creating a Game of Blackjack and Intermediate C# Programming
// AUTHOR: Steven Partlow
// DATE: 21/01/2023

// DECK CLASS DEFINITION

// A class which represents a full deck of playing cards, this inherits the card class definition and again can be reused in any game that requires a deck of playing cards

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Deck
    {
        /* CLASS CONSTRUCTOR */

        public Deck()
        {
            Cards = new List<Card>(); // Create a empty list of cards for our deck object
            
            for (int i = 0; i <13; i++ ) // Iterate starting i at zero until i is equal or greater than thirteen, incrementing i after each loop
            {

                for (int j =0; j < 4; j++) // Iterate starting i at zero until j is equal or greater than four, incrementing j after each loop
                {
                    Card card = new Card(); // Instantiate a new instance of the Card class and assign it to the card variable
                    card.Face = (Face)i; // Cast the element within the Face enum that matches the value of i and assign it to the card objects Face property
                    card.Suit = (Suit)j; // Cast the element with the Suit enum that matches the value of j and assign it to the card objects Suit property
                    Cards.Add(card); // Add the card objects to the Cards list
                } // End FOR

            } // End FOR

        } // End of CONSTRUCTOR

        /* PROPERTIES */

        public List<Card> Cards { get; set; }

        /* METHODS */

        public void Shuffle(int times = 1) // A custom method with three parameters a Deck object for the method to shuffle, the second paramter is an output parameter which will specify the number of times the deck was shuffled, then a a final optional parameter which by default is set to one which controls the number of times the deck will be shuffled
        {

            for (int i = 0; i < times; i++)
            {
                List<Card> TempList = new List<Card>(); // Create a new list consisting of Card objects called TempList
                Random random = new Random(); // Create a new instance of the Random object and call it random

                while (this.Cards.Count > 0) // Keep iterating as long as their is at least one card in deck
                {
                    int randomIndex = random.Next(0, this.Cards.Count); // Generate a random integer between 0 and the current number of element left with in the deck list
                    TempList.Add(this.Cards[randomIndex]); // Add the card at the index position randomIndex that is in the deck list and add it to TempList
                    this.Cards.RemoveAt(randomIndex); // Now remove the card at position randomIndex from the list deck
                } // End WHILE

                this.Cards = TempList; // Replace the entire contents of deck with the contents of TempList
            } // End FOR

        } // End Shuffle Method

    } // End CLASS

} // End Casino NAMESPACE
