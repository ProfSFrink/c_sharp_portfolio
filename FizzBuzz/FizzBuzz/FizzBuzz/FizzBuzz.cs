// FizzBuzz
// by Steven Partlow
// DATE: 02/06/2023

// FIZZ BUZZ Class Defintion

using System;

namespace FizzBuzz
{

    class FizzBuzz // A class for the main FizzBuzz application logic
    {
        // Definition for method FizzBuzzLogic, the number entered by the user in the main program is passed in, the method does not return anything
        public static void FizzBuzzLogic(double userNum)
        {

            // FizzBuzz LOGIC
            if (userNum % 3 == 0 && userNum % 5 == 0) // If the the value the user entered is divisable by three and five then
            {
                Console.WriteLine("\nFizzBuzz"); // Output 'FizzBuzz' to the console
                Console.WriteLine("\nThe application will now exit, Press any KEY to continue.\n"); // Output this text to the console
                Console.ReadKey(); // Peuse the application until the user presses a key
            } // End IF

            // Fizz LOGIC
            else if (userNum % 3 == 0) // If the the value the user entered is divisable by three then
            {
                Console.WriteLine("\nFizz"); // Output 'Fizz' to the console
                Console.WriteLine("\nThe application will now exit, Press any KEY to continue.\n"); // Output this text to the console
                Console.ReadKey(); // Peuse the application until the user presses a key
            } // End ELSE IF

            // Buzz LOGIC
            else if (userNum % 5 == 0) // If the the value the user entered is divisable by five then
            {
                Console.WriteLine("\nBuzz"); // Output 'Buzz' to the console
                Console.WriteLine("\nThe application will now exit, Press any KEY to continue.\n"); // Output this text to the console
                Console.ReadKey(); // Peuse the application until the user presses a key
            } // End ELSE IF
            
            // LOGIC for any other outcome
            else // If none of the the three condition above are met
            {
                Console.WriteLine("\nSorry not Fizz or Buzz :("); // Output this text to the console
                Console.WriteLine("\nThe application will now exit, Press any KEY to continue.\n"); // Output this text to the console
                Console.ReadKey(); // Peuse the application until the user presses a key
            } // End ELSE

        } // End FizzBuzzLogic METHOD

    } // END FizzBuzz CLASS

} // END FizzBuzz NAMESPACE
