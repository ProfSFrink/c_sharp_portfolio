// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// FINAL PROJECT: Final Assignment - Code First Database Assignment
// AUTHOR: Steven Partlow
// DATE: 18/03/2023

/// STUDENT CLASS DEFINITION

using System;

namespace CodeFirstDBAssign
{

    // Student class will represent the Student table in our Student database

    class Student
    {

        /* PROPERTIES */

        public int StudentID { get; set; } // StudentID, an integer variable to represent the StudentID column in the Student table and the table primary key
        public string StudentName { get; set; } // StudentName, a string variable to represent the StudentName column in the Student table
        public DateTime? DateOfBirth { get; set; } // DateOfBirth, a datetime variable to represent the DateOfBirth column in the Student table
        public double Height { get; set; } // Height, a double variable to represent the Height column in the Student table
        public double Weight { get; set; } // Weight, a double variable to represent the Weight column in the Student table

        public Grade Grade { get; set; } // Grade, an instance of the Grade class and represents the Grade column in the Student table, which acts as foreign key for the Grades table

        /* METHODS */

        public void displayStudent() // A method to output the properties of this instance of the Student class
        {

            Console.WriteLine("\nNAME: " + this.StudentName); // Concatenate this string thing output to the console window
            Console.WriteLine("DATE OF BIRTH: " + Convert.ToString(this.DateOfBirth)); // Concatenate this string thing output to the console window
            Console.WriteLine("HEIGHT: " + Convert.ToString(this.Height)); // Concatenate this string thing output to the console window
            Console.WriteLine("WEIGHT: " + Convert.ToString(this.Weight) + "lbs"); // Concatenate this string thing output to the console window
            Console.WriteLine("COURSE: " + this.Grade.CourseName); // Concatenate this string thing output to the console window
            Console.WriteLine("GRADE: " + this.Grade.GradeName); // Concatenate this string thing output to the console window

        } // End displayStudent METHOD

    } // End Student CLASS

} // End CodeFirstDBAssign NAMESPACE
