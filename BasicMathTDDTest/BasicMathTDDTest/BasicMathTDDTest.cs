// Unit Testing Practice
// by Steven Partlow
// DATE: 11/06/2023

using System;
using BasicMath; // Use BasicMath CLASS
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicMathTDDTest
{

    [TestClass]
    public class BasicMathTDDTest
    {

        // Test the AddMethod of the BasicMath Class
        [TestMethod]
        public void Test_AddMethod()
        {

            BasicMaths bm = new BasicMaths(); // Create a new instance of the BasicMaths class named bm
            double res = bm.Add(20.50, 20.50); // Define a double data type which is the result of sum of the two values passed in to the bm.Add method
            Assert.AreEqual(41, res); // If the value of res is equal to 41 the test is a pass otherwise it fails

        } // End Test_AddMethod METHOD

        // Test the AddMethod of the BasicMath Class
        [TestMethod]
        public void Test_MultiplyMethod()
        {

            BasicMaths bm = new BasicMaths(); // Create a new instance of the BasicMaths class named bm
            double res = bm.Multiply(10, 10); // Define a double data type which is the result of sum of the two values passed in to the bm.Multiply method
            Assert.AreEqual(100, res); // If the value of res is equal to 100 the test is a pass otherwise it fails

        } // End Test_MultiplyMethod Method

    } // End BasicMathTDDTest CLASS

} // End BasicMathTDDTest NAMESPACE
