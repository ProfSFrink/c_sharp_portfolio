// Unit Testing Practice
// by Steven Partlow
// DATE: 11/06/2023

// A very simple math class library I created to learn and practice unit testing in Visual Studio

namespace BasicMath
{

    public class BasicMaths
    {

        public double Add(double num1, double num2) // Define Add Method with two double parameters num1 and num2
        {

            return num1 + num2; // Return the sum of num1 and num2

        } // End Add METHOD

        public double Subtract(double num1, double num2) // Define Subtract Method with two double parameters num1 and num2
        {

            return num1 - num2; // Return the subtrahend of num1 and num2

        } // End Subtract METHOD

        public double Divide(double num1, double num2)
        {

            return num1 / num2; // Return the quotient of num1 and num2

        } // End Divide METHOD

        public double Multiply(double num1, double num2)
        {

            return num1 * num2; // Return the product of num1 and num2

        }// End Multiply METHOD

    } // End BasicMath CLASS

} // End BasicMath NAMESPACE
