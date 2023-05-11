// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// FINAL PROJECT: Final Assignment - Code First Database Assignment
// AUTHOR: Steven Partlow
// DATE: 18/03/2023

using CodeFirstDBAssign;
using System;
using System.Threading;

namespace CodeFirstDbAssign
{

    class Program
    {

        static void Main(string[] args)
        {

            // Output all the below text to the display
            Console.WriteLine("PITMAN TRAINING / THE TECH ACADEMY");
            Console.WriteLine("----------------------------------\n");
            Console.WriteLine("FINAL ASSIGNMENT: Code-First Entity Framework - Student Database");
            Console.WriteLine("----------------------------------------------------------------\n");

            Console.WriteLine("This application will create a database using the code-first approach then add three students to the database.\n");
            // Create a new database context using the SchoolContext class as template for the dB and Student and Grade tables
            using (var context = new SchoolContext())
            {

                /* ADD STUDENT ONE TO THE DATABASE */

                Console.WriteLine("CREATING NEW STUDENT OBJECT FOR THE DATABASE");

                var studentOne = new Student() // Create a new instance of the Student class called student 
                {
                    StudentName = "Steven Partlow", // Assign this value to the StudetName property
                    DateOfBirth = Convert.ToDateTime("10/08/1979"), // Create a new DateOfBirth object then assign this value to the DateOfBirth property
                    Height = 5.11, // Assign this value to the Height property
                    Weight = 147.84, // Assign this value to the Weight property

                    Grade = new Grade() // Create a new instance of the Grade class called grade for the Student Grade property
                    {
                        GradeName = "DISTINCTION", // Assign this value to the GradeName property
                        CourseName = "C# and .NET Framework" // Assign this value to the CourseName property
                    } // End GRADE INSTANTIATION

                }; // End STUDENT INSTANTIATION

                studentOne.displayStudent(); // Execute the built-in method displayStudent off the studentOne instance
                Thread.Sleep(1000); // Pause the application for one second
                context.Students.Add(studentOne); // Add the studentOne instance of the Student class to the Students table in the database
                Console.WriteLine("\nSTUDENT SUCCESSFULLY ADDED TO THE DATABASE!\n"); // Ouput this text to the console

                /* ADD STUDENT TWO TO THE DATABASE */

                Console.WriteLine("CREATING NEW STUDENT OBJECT FOR THE DATABASE");

                var studentTwo = new Student() // Create a new instance of the Student class called student 
                {
                    StudentName = "Charlotte Jewell", // Assign this value to the StudetName property
                    DateOfBirth = Convert.ToDateTime("08/01/1992"), // Create a new DateOfBirth object then assign this value to the DateOfBirth property
                    Height = 5.65, // Assign this value to the Height property
                    Weight = 131.22, // Assign this value to the Weight property

                    Grade = new Grade() // Create a new instance of the Grade class called grade for the Student Grade property
                    {
                        GradeName = "MERIT", // Assign this value to the GradeName property
                        CourseName = "Legal Audio Processing" // Assign this value to the CourseName property
                    } // End GRADE INSTANTIATION

                }; // End STUDENT INSTANTIATION

                studentTwo.displayStudent(); // Execute the built-in method displayStudent off the studentTwo instance
                Thread.Sleep(1000); // Pause the application for one second
                context.Students.Add(studentTwo); // Add the studentTwo instance of the Student class to the Students table in the database
                Console.WriteLine("\nSTUDENT SUCCESSFULLY ADDED TO THE DATABASE!\n"); // Ouput this text to the console

                ///* ADD STUDENT THREE TO THE DATABASE */

                Console.WriteLine("CREATING NEW STUDENT OBJECT FOR THE DATABASE");

                var studentThree = new Student() // Create a new instance of the Student class called student 
                {
                    StudentName = "Jason David Young", // Assign this value to the StudetName property
                    DateOfBirth = Convert.ToDateTime("22/06/1985"), // Create a new DateOfBirth object then assign this value to the DateOfBirth property
                    Height = 6.04, // Assign this value to the Height property
                    Weight = 165.11, // Assign this value to the Weight property

                    Grade = new Grade() // Create a new instance of the Grade class called grade for the Student Grade property
                    {
                        GradeName = "PASS", // Assign this value to the GradeName property
                        CourseName = "Certified Digital Marketing Professional" // Assign this value to the CourseName property
                    } // End GRADE INSTANTIATION

                }; // End STUDENT INSTANTIATION

                studentThree.displayStudent(); // Execute the built-in method displayStudent off the studentThree instance
                Thread.Sleep(1000); // Pause the application for one second
                context.Students.Add(studentThree); // Add the studentThree instance of the Student class to the Students table in the database
                Console.WriteLine("\nSTUDENT SUCCESSFULLY ADDED TO THE DATABASE!"); // Ouput this text to the console

                ///* SAVE DATABASE CHANGES */

                context.SaveChanges(); // Save the changes to the database
                Console.WriteLine("\nALL CHANGES SAVED TO THE DATABASE!"); // Output this text to the console window

            } // End USING

            Console.WriteLine("\nPress any key to exit the application"); // Output this text to the console
            Console.ReadKey(); // Pause the application until the user press any key

        } // End MAIN

    } // End Program CLASS

} // End CodeFirstDbAssign NAMESPACE
