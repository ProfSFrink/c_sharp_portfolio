// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// MODULE 9: Database and MVC Fundamentals
// AUTHOR: Steven Partlow
// DATE: 17/02/2023

// TWENTYONEGAME CLASS DEFINITION

// This TwentyOneGame class is specifically for our TwentyOne (Blackjack) game and will inherit the Game class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Interfaces;

namespace Casino.TwentyOne
{

    public class TwentyOneGame : Game, IWalkAway // Inherit the Game Class and the IWalkAway interface
    {
        /* CLASS PROPERTIES */

        public TwentyOneDealer Dealer { get; set; } // Instantiate an instance of the TwentyOneDealer class and call it dealer

        /* CLASS METHODS */

        /* This is the main play method and represent the core of our program */

        public override void Play() // As this is an inherited abstract method from the Game class we need the override keywrod
        {
            /* -------------- SETUP FOR A NEW GAME -------------- */

            Dealer = new TwentyOneDealer(); // Instantiate a new instance of TwentyOneDealer called Dealer
            foreach (Player player in Players) // Iterate through the list of Players and assign each instance to the player variable
            {
                player.Hand = new List<Card>(); // Creates a new empty hand of playing cards for the Player
                player.Stay = false; // Reset the Stay property to false of the current player object
            } // End FOREACH
            Dealer.Hand = new List<Card>(); // Create a new empty hand of playing cards for the Dealer
            Dealer.Stay = false; // Set the Dealer's stay property to false
            Dealer.Deck = new Deck(); // Issue the Dealer with a new deck of playing cards
            Dealer.Deck.Shuffle(); // Shuffle the Dealer's new deck of playing cards

            /* -------------- PLACE BETS -------------- */

            //Console.WriteLine("Place your bet:"); // Output this text to the console

            foreach(Player player in Players) // Iterate through the list of Players and assign each instance to the player 
            {
                bool validAnswer = false; // Define a boolean variable called validAnswer and set it's default value to false
                int bet = 0; // Define an integer variable called bet and set it's default value to zero
                
                while (!validAnswer) // Keep the loop going as long as validAnswer is false
                {
                    Console.WriteLine("Place your bet:"); // Output this text to the console
                    validAnswer = int.TryParse(Console.ReadLine(), out bet); // Attempt to cast the user input to an integer, then set validAnswer to true or false depending if it is successful, if the cast does succeded store the output in bet
                    if (!validAnswer) Console.WriteLine("Please enter digits only, no decimals."); // Output this text to the console
                } // End WHILE

                if (bet < 0) // If the bet amount entered is below zero
                {
                    throw new FraudException("Security! Kick this person out."); // Throw an exception
                } // End IF

                bool successfullyBet = player.Bet(bet); // Attempt to place the bet and store if it was successful in the boolean variable successfullyBet
                if (!successfullyBet) // If the attempt to place the Players bet is unsucessful
                {
                    return; // Exit the Play() method
                } // End IF
                Bets[player] = bet; // Because the bet has been placed successfully we add the bet amount to the player bet property which is a dictionary
            } // End FOREACH

            /* -------------- DEAL CARDS -------------- */

            /* -------------- PLAYER DEAL ------------- */

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Dealing..."); // Output this text to the console
                foreach (Player player in Players) // Iterate through the list of players and assign each instance to player
                {
                    Console.Write("{0}: ", player.Name); // Concatenate player name property and this string and output to the console
                    Dealer.Deal(player.Hand); // The dealer deals a card from their deck and deals it to the current instance of Player 
                    if (i == 1) // We check if i is equal to one here as this means we are on the second iteration of the loop which means there is at least two cards in the players hand which means they could have a blackjack at this point
                    {
                        bool blackJack = TwentyOneRules.CheckForBlackJack(player.Hand); // Define a boolean variable called blackJack then execute the CheckForBlackJack method within the TwentyOneRules class then store the boolean return by the method in the blackJack variable
                        if (blackJack) // If blackJack is true then the player won the current hand
                        {
                            Console.WriteLine("Blackjack! {0} wins {1}", player.Name, Bets[player]); // Concatenate the players name and current bet to this string and then output it to the console
                            player.Balance += Convert.ToInt32((Bets[player] * 1.5) + Bets[player]); // Add the value of the current player bet plus fifty percent and the value of the original bet to the players balance
                            return; // Exit the method
                        } // End IF
                    } // End IF
                } // End FOREACH


            /* -------------- DEALER DEAL ------------- */

                Console.Write("Dealer: "); // Output this text to the console
                Dealer.Deal(Dealer.Hand); // Deal a card from the dealers deck of playing cards to the dealers hand
                if (i == 1) // We check if i is equal to one here as this means we are on the second iteration of the loop which means there is at least two cards in the dealers hand which means they could have a blackjack at this point
                {
                    bool blackJack = TwentyOneRules.CheckForBlackJack(Dealer.Hand);
                    if (blackJack) // If blackJack is true then the dealer won the current hand
                    {
                        Console.WriteLine("Dealer has BlackJack! Everyone loses!"); // Output this text to the console
                        foreach (KeyValuePair<Player, int> entry in Bets) // Iterate through the Bets dictionary
                        {
                            Dealer.Balance += entry.Value; // Add the value of each bet in the dictionary to the Dealer's balance
                        } // End FOREACH
                        return; // End the Play() method as the current round is over
                    } // End IF
                } // End IF
            } // End FOR

            /* ASK EACH PLAYER IF THEY WANT TO HIT OR STAY */

            foreach (Player player in Players) // Iterate through the Players list and assign each instance to the player value
            {

                while (!player.Stay) // While the current instance of player's stay property is equal to false
                {

                    Console.WriteLine("Your cards are: "); // Output this text to the console
                    foreach (Card card in player.Hand) // Iterate through the current Players Hand and assign the current Card to card
                    {
                        Console.Write("{0} ", card.ToString()); // Call the toString() method attach to the current card which will display the cards face and suit
                    } // End FOREACH
                    Console.WriteLine("\n\nHit or stay?"); // Go down two lines and then output this text to the console
                    string answer = Console.ReadLine().ToLower(); // Take the user input assign it to the string answer and also convert it to lowercase

                    /* ------------ PLAYER STAYS ------------ */

                    if (answer == "stay") // If the value of answer is equal to stay
                    {
                        player.Stay = true; // Set the current players Stay property to true
                        break; // Break the current iteration of the while loop and check if we meet the condition to execute the loop again
                    } // End IF
                    
                    /* ------------ PLAYER HITS ------------- */
                    
                    else if (answer == "hit") // If the value of answer is equal to hit
                    {
                        Dealer.Deal(player.Hand); // Add another card from the dealers deck to the players current hand
                    } // End ELSE IF


                    /* ------------ PLAYER BUSTED ---------- */

                    bool busted = TwentyOneRules.IsBusted(player.Hand); // Utilise the TwentyOneRules.IsBusted() Method and pass in the current players hand and store the returned boolean into the boolean variable busted
                    if (busted) // If the hand is busted then
                    {
                        Dealer.Balance += Bets[player]; // Then the value of the current players bet to the dealer
                        Console.WriteLine("{0} Busted! You lose your bet of {1}. Your balance is now {2}.", player.Name, Bets[player], player.Balance); // Concatenate the current players name, bet value and balance to this string of text and output it to the console

                        /* ------------ ASK THE PLAYER IF WANT TO KEEP PLAYING ------------ */

                        Console.WriteLine("Do you want to play again "); // Output this text to the console
                        answer = Console.ReadLine().ToLower(); // Take the user input assign it to the variable answer and convert it to lowercase
                        if (answer == "yes" || answer == "yeah" || answer == "y") // If the value of answer equates to a variation of yes then
                        {
                            player.IsActivelyPlaying = true; // Set the current players isActivelyPlaying property to true
                            return;
                        } // End IF
                        else // Then answer does not equate to a variation of yes
                        {
                            player.IsActivelyPlaying = false; // Set the current players isActivelyPlaying property to false
                            return;
                        } // End ELSE
                    } // End IF

                } // End WHILE

            } // End FOREACH

            /* ------------ DEALER HIT OR STAY ------------ */

            Dealer.isBusted = TwentyOneRules.IsBusted(Dealer.Hand); // Pass the current Dealers hand into the isBusted() method then take the retruned boolean value and assign it to the Dealers isBusted property
            Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand); // Check the dealer current hand to determine if they should stay and assign the returned result to the dealers stay property
            
            while (!Dealer.Stay && !Dealer.isBusted) // Loop as long as the dealer does not stay or is not busted
            {
                Console.WriteLine("Dealer is hitting..."); // Output this text to the console
                Dealer.Deal(Dealer.Hand); // Deal a card from the dealers current deck to their current playing hand
                Dealer.isBusted = TwentyOneRules.IsBusted(Dealer.Hand); // Now check again if the dealer has gone bust or not
                Dealer.Stay = TwentyOneRules.ShouldDealerStay(Dealer.Hand); // Now check again if the dealer should stay or not
            } // End WHILE

            /* ------------ DEALER STAYS ------------ */

            if (Dealer.Stay) // If the dealer stays
            {
                Console.WriteLine("Dealer is staying."); // Output this text to the console
            } // End IF

            /* ------------ DEALER BUST ------------ */

            if (Dealer.isBusted) // If the dealer has gone bust
            {
                Console.WriteLine("Dealer Busted!."); // Output this text to the console
                foreach (KeyValuePair<Player, int> entry in Bets) // Iterate through the Bets dictionary and assign each KV pair to entry
                {
                    Console.WriteLine("{0} won {1}", entry.Key.Name, entry.Value); // Concatenate the current entries Name and Value to this string and output it to the console

                    /* We go through the Players list and find the one that matches the current KV pair assigned to the entry value and add double their bet to that players balance */
                    Players.Where(x => x.Name == entry.Key.Name).First().Balance += (entry.Value * 2);
                    Dealer.Balance -= entry.Value; // Deduct the amount the player won from the dealers balance
                 } // End FOREACH
                return; // End the Play() method and current round as the dealer has gone bust and the a player has won
            } // End IF

            /* ------------ COMPARE PLAYER & DEALER HANDS ------------ */

            foreach (Player player in Players) // Iterate through the list of Players and assign the current Player to player
            {
                bool? playerWon = TwentyOneRules.CompareHands(player.Hand, Dealer.Hand); // Create a boolean playerWon with the option to have null as a value then execute the CompareHands method to compare the hands of the player and dealer and store the returned boolean in playerWon

                if (playerWon == null) // If playerWon is null then we have a tie
                {
                    /* ------------ TIED ------------ */
                    Console.WriteLine("Push! No one wins."); // Output this text to the console
                    player.Balance += Bets[player]; // Add the amount the player bet back to their balance
                } // End IF
                else if(playerWon == true) // If playerWon is true then the player won the round
                {
                    /* ------------ PLAYER WINS ------------ */
                    Console.WriteLine("{0} won {1}!", player.Name, Bets[player]); // Take the player name and amount they bet and concatenate them to this string
                    player.Balance += (Bets[player] * 2); // Award the player there winning which is double the original bet
                    Dealer.Balance -= Bets[player]; // Deduct that amount from the dealers balance
                } // End ELSE IF
                else // If playerWon is false then the dealer won the round
                {
                    /* ------------ DEALER WINS ------------  */
                    Console.WriteLine("Dealer wins {0}!", Bets[player]); // Concatenate the amount the player bet to this string and output to the console
                    Dealer.Balance += Bets[player]; // Add the amount the player bet to the dealers balance
                } // End ELSE

                Console.WriteLine("Play again?"); // Output this text to the console
                string answer = Console.ReadLine().ToLower(); // Convert the user input to lowercase and assign it to the string variable answer
                if (answer == "yes" || answer == "yeah" || answer == "y") // If the value of answer matches one of these inputs
                {
                    player.IsActivelyPlaying = true; // Set the IsActivelyPlaying property to true
                } // End IF
                else // Then none of the above inputs match
                {
                    player.IsActivelyPlaying = false; // Set the IsActivelyPlaying property to false
                } // End ELSE

            } // End FOREACH

        } // End Play Method

        public override void ListPlayers() // We are overiding the inherited ListPlayers() method with this instance of the method
        {
            Console.WriteLine("21 Players:"); // Ouput this text to the console
            base.ListPlayers(); // Execute the base version of this method that we are inheriting
        } // End ListPlayers Method

        public void WalkAway(Player player) // This is an inherited method from the interface IWalkAWay which we have to implement here as we are inheriting it
        {
            throw new NotImplementedException(); // Throw an error inform the user that this method has not been implementated at this time
        } // End WalkAway Method

    } // End TwentyOneGame Class

} // End Casino NAMESPACE
