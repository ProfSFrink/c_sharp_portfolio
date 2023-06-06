// FizzBuzz
// by Steven Partlow
// DATE: 06/06/2023

// FIZZ BUZZ Class Defintion

using System;

namespace FizzBuzz
{

    class FizzBuzz // A class for the main FizzBuzz application logic
    {
        // Definition for method FizzBuzzLogic, the number entered by the user in the main program is passed in, the method does not return anything
        public static string FizzBuzzLogic(int N, int M)
        {
            string Sequence = "\n"; // We use the string Sequence to start the result of our calculations as we go, we start on a new line

            for (int i = N; i <= M; i++) // We iterate from N upto and including M with i representing the current value
            {
                if (i % 3 == 0 && i % 5 == 0) Sequence += "FizzBuzz"; // If i is divisable by both 3 and 5 with no remainder we add "FizzBuzz" to the sequence
                else if (i % 3 == 0) Sequence += "Fizz"; // If i is divisable by 3 with no remainder we add "Fizz" to the sequence
                else if (i % 5 == 0) Sequence += "Buzz"; // If i is divisable by 5 with no remainder we add "Buzz" to the sequence
                else Sequence += i; // If it is not divisable by either with just add the current value of i to the sequence

                if (i < M) Sequence += ", "; // If we are not equal to M yet, we add a comma and a space to sequence, this ensures no comma on the end of the string
            } // End FOR

            return Sequence; // Now that the FORR loop has ended we return the value of sequence

        } // End FizzBuzzLogic METHOD

    } // END FizzBuzz CLASS

} // END FizzBuzz NAMESPACE
