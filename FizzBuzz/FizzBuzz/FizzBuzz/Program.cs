﻿// FizzBuzz
// by Steven Partlow
// DATE: 01/06/2023

/* A C# version of the FizzBuzz problem, uses a TRY / CATCH block to exceptions, check that the number entered is a whole number with no
 decimal places , then checks for FizzBuzz (divisable by 3 and 5), Fizz (divisable by 3) and Buzz (divisable by 5) before a general message 
if none of those three apply, then the program ends */

using System;

namespace FizzBuzz
{

    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {

                double userNum; // Define variable userNum as a double data type
                try // Try this code, get the user to enter a whole number and catch any errors
                {
                    // Output the following text to the console
                    Console.WriteLine("FizzBuzz");
                    Console.WriteLine("--------\n");

                    Console.Write("Please enter a WHOLE number: "); // Ask the user to enter a whole number
                    userNum = Convert.ToDouble(Console.ReadLine()); // Take the inputted user string, convert to type int and store in variable userNum

                    bool isInt = userNum == (int)userNum; // Check if the number entered is a whole number with no decimal places
                    if (isInt == false) // If it is not a whole number
                    {
                        Console.WriteLine("\nPlease enter a WHOLE, no decimal places, Please try again!.\n"); // Output this text to the console
                        continue; // Restart the loop and get the user enter a number again
                    } // End IF
                    else if (userNum == 0)
                    {
                        Console.WriteLine("\nPlease do not enter a ZERO, Thank You!.\n"); // Output this text to the console
                        continue; // Restart the loop and get the user enter a number again
                    } // End ELSE IF

                } // End TRY

                catch (FormatException ex) // Catch the user attempting to enter a string instead of a number
                {
                    Console.WriteLine("\nPlease enter a WHOLE number, no text, Thank You!.\n"); // Output this text to the console
                    continue; // Restart the loop and get the user enter a number again
                } // End CATCH Format Exception

                catch (DivideByZeroException ex) // Catch the user attempting to divide by zero
                {
                    Console.WriteLine("\nPlease do not enter ZERO, Thank You!\n."); // Output this text to the console
                    continue; // Restart the loop and get the user enter a number again
                } // End CATCH Divide by Zero Exception

                catch (Exception ex) // Catch any other type of error
                {
                    Console.WriteLine("\nThere was an error, please try again, Thank You!.\n"); // Output this text to the console
                    continue; // Restart the loop and get the user enter a number again
                } // End CATCH General Exception

                // End of CATCH Block

                // FizzBuzz LOGIC
                if (userNum % 3 == 0 && userNum % 5 == 0) // If the the value the user entered is divisable by three and five then
                {
                    Console.WriteLine("\nFizzBuzz"); // Output 'FizzBuzz' to the console
                    Console.WriteLine("\nThe application will now exit, Press any KEY to continue.\n"); // Output this text to the console
                    Console.ReadKey(); // Peuse the application until the user presses a key
                    break; // Break the WHILE loop
                } // End IF
                else if (userNum % 3 == 0) // If the the value the user entered is divisable by three then
                {
                    Console.WriteLine("\nFizz"); // Output 'Fizz' to the console
                    Console.WriteLine("\nThe application will now exit, Press any KEY to continue.\n"); // Output this text to the console
                    Console.ReadKey(); // Peuse the application until the user presses a key
                    break; // Break the WHILE loop
                } // End ELSE IF
                else if (userNum % 5 == 0) // If the the value the user entered is divisable by five then
                {
                    Console.WriteLine("\nBuzz"); // Output 'Buzz' to the console
                    Console.WriteLine("\nThe application will now exit, Press any KEY to continue.\n"); // Output this text to the console
                    Console.ReadKey(); // Peuse the application until the user presses a key
                    break; // Break the WHILE loop
                } // End ELSE IF
                else // If none of the the three condition above are met
                {
                    Console.WriteLine("\nSorry not Fizz or Buzz :("); // Output this text to the console
                    Console.WriteLine("\nThe application will now exit, Press any KEY to continue.\n"); // Output this text to the console
                    Console.ReadKey(); // Peuse the application until the user presses a key
                    break; // Break the WHILE loop
                } // End ELSE

            } //End WHILE

        } // End MAIN Program

    } // END Program CLASS

} // END FizzBuzz NAMESPACE