// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// MODULE 5: C# Class Concepts
// AUTHOR: Steven Partlow
// DATE: 10/01/2023

// IWalkAway INTERFACE DEFINITION

// An interface that allows the player to walk away from the game when they please. (NOT IN USE)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Interfaces
{
    interface IWalkAway // Create an interface called IWalkAway
    {
        void WalkAway(Player player); // Create a method called Walkaway with one input an instance of the player object
    } // End IWalkAway Interface

} // End Casino NAMESPACE
