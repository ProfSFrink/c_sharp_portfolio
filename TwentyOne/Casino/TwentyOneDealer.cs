// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// MODULE 7: Creating a Game of Blackjack and Intermediate C# Programming
// AUTHOR: Steven Partlow
// DATE: 21/01/2023

// TWENTY ONE DEALER DEFINITION

// Definition of a dealer specifically for a Twenty One (Blackjack) game

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.TwentyOne
{

    public class TwentyOneDealer : Dealer // Inherit the Dealer class
    {
        /* PROPERTIES */

        private List<Card> _hand = new List<Card>(); // Instance a private list of the Card class called _hand, this ensure we already have an empty list
        public List<Card> Hand { get { return _hand; } set { _hand = value; } } // A list of card objects to represent the Players hand, points to the private instance _hand
        public bool Stay { get; set; } // A boolean variable to represent if the dealer wants to stay
        public bool isBusted { get; set; } // A boolean variable to represent if the dealer has gone bust

    } // End TwentyOneDealer CLASS

} // End Casino NAMESPACE
