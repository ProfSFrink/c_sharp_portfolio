// FizzBuzz
// by Steven Partlow
// DATE: 06/06/2023

/* A C# version of the FizzBuzz problem, uses a TRY / CATCH block to exceptions, check that the numbers entered are whole numbers with no
 decimal places , then checks for FizzBuzz (divisable by 3 and 5), Fizz (divisable by 3) and Buzz (divisable by 5), or if none of those apply,
 adding each result to a string before outputting the result */

using System;
using FizzBuzz;

namespace FizzBuzz
{

    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {

                double startNum; // Define variable startNum as a double data type, this represents the start of the range
                double endNum; // Define variable endNum as a double data type, this represents the end of the range
                try // Try this code, get the user to enter a whole number and catch any errors
                {
                    // Output the following text to the console
                    Console.WriteLine("FizzBuzz");
                    Console.WriteLine("--------\n");

                    Console.Write("Please enter the NUMBER for START of the RANGE: "); // Ask the user to enter a whole number
                    startNum = Convert.ToDouble(Console.ReadLine()); // Take the inputted user string, convert to type int and store in variable startNum

                    bool startInt = startNum == (int)startNum; // Check if the number entered is a whole number with no decimal places
                    if (startInt == false) // If it is not a whole number
                    {
                        Console.WriteLine("\nPlease enter a WHOLE, no decimal places, Please try again!.\n"); // Output this text to the console
                        continue; // Restart the loop and get the user enter a number again
                    } // End IF
                    else if (startNum == 0)
                    {
                        Console.WriteLine("\nPlease do not enter a ZERO, enter as least 1, Thank You!.\n"); // Output this text to the console
                        continue; // Restart the loop and get the user enter a number again
                    } // End ELSE IF

                    Console.Write("Please enter the NUMBER for the END of the RANGE: "); // Ask the user to enter a whole number
                    endNum = Convert.ToDouble(Console.ReadLine()); // Take the inputted user string, convert to type int and store in variable startNum

                    bool endInt = endNum == (int)endNum; // Check if the number entered is a whole number with no decimal places
                    if (endInt == false) // If it is not a whole number
                    {
                        Console.WriteLine("\nPlease enter a WHOLE, no decimal places, Please try again!.\n"); // Output this text to the console
                        continue; // Restart the loop and get the user enter a number again
                    } // End IF
                    else if (endNum == 0)
                    {
                        Console.WriteLine("\nPlease do not enter a ZERO, enter as least 1, Thank You!.\n"); // Output this text to the console
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

                // Execute the FizzBuzzLogic method of the FizzBuzz class passing in both startNum and endNum as converted integers, store the returned string in sequence
                string sequence = FizzBuzz.FizzBuzzLogic(Convert.ToInt32(startNum), Convert.ToInt32(endNum));

                Console.WriteLine(sequence); // Output the value of sequence to the console
                break; // As we have successfully validated the user input and run the FizzBuzz logic, and displayed the result, we can break the loop and end the application

            } //End WHILE

        } // End MAIN Program

    } // END Program CLASS

} // END FizzBuzz NAMESPACE
