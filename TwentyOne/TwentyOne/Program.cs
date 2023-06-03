// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// MODULE 9: Database and MVC Fundamentals
// AUTHOR: Steven Partlow
// DATE: 17/02/2023

/* The main program of our application */

using System; // Main system library
using System.Collections.Generic;
using Casino; // Casino class contains all our base classes for our TwentyOne Application
using Casino.TwentyOne; // Casino.TwentyOne contains our main classes and logic for our TwentyOne game
using System.IO; // Use the IO namespace so we can utilise file-handling
using System.Data.SqlClient;
using System.Data;


namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            const string casinoName = "Grand Hotel and Casino"; // A constant to define the name of our casino
            Console.Write("Welcome to the {0}. Let's start by telling me your name? ", casinoName); // Concatenate the const casino name with this strinng and output this text to the console
            string playerName = Console.ReadLine(); // Assign the user input to the string variable playerName

            if (playerName.ToLower() == "admin") // If playerName is equal to admin
            {

                List<ExceptionEntity> Exceptions = ReadExceptions(); // Take the list returned by ReadExceptions and store in the list object called Exceptions
                foreach (var exception in Exceptions) // Iterate through each individual exception in the Exceptions list
                {

                    Console.Write(exception.Id + " | "); // Output the value of exception.id to the console
                    Console.Write(exception.ExceptionType + " | "); // Output the value of exception.ExecptionType to the console
                    Console.Write(exception.ExceptionMessage + " | "); // Output the value of exception.ExceptionMessage to the console
                    Console.Write(exception.TimeStamp + " | "); // Output the value of exception.TimeStamp to the console
                    Console.WriteLine(); // Write a new line in the console window

                } // End FOREACH 
                Console.Read(); // Pause the application here
                return;

            } // End IF

            bool validAnswer = false; // Define a boolean variable called validAnswer and set it's default value to false
            int bank = 0; // Define an integer variable called bank and set it's default value to zero
            while (!validAnswer) // Keep the loop going as long as validAnswer is false
            {
                Console.WriteLine("And how much did you bring today?"); // Output this text to the console
                validAnswer = int.TryParse(Console.ReadLine(), out bank); // Attempt to cast the user input to an integer, then set validAnswer to true or false depending if it is successful, if the cast does succeded store the output in bank
                if (!validAnswer) Console.WriteLine("Please enter digits only, no decimals."); // Output this text to the console
            } // End WHILE
            
            Console.WriteLine("Hello, {0}. Would you like to join a game of 21 right now?", playerName); // Utilise string formatting to concatenate this string and output it to the console
            string answer = Console.ReadLine().ToLower(); // Assign the user input to the string variable answer and convert it to lowercase

            // If answer equals any of the below listed values
            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya") 
            {
                /* Instantiate a new instance of the Player class called player, passing in the player and bank values */
                Player player = new Player(playerName,bank);
                player.Id = Guid.NewGuid(); // Assign the Guid Id property of the new instance of the player class a unique identifier

                /* using (StreamWriter file = new StreamWriter(@"C:\Users\Pitma\sp\Logs\Logs.txt", true)) */
                using (StreamWriter file = new StreamWriter(@"C:\Users\ProfS\Logs\Logs.txt", true))
                /* using (StreamWriter file = new StreamWriter(@"C:\Users\Steven Partlow\Logs.txt", true)) */ // Create a new StreamWriter object called file assign it the file in the provided path and set that we wish to append to the file to true, the using statement frees up memory after we are done
                { 
                    file.WriteLine(player.Id); // Write the value the guid player property to file
                } // End STEAMWRTIER
                Game game = new TwentyOneGame(); // Instantiate a new instance of the TwentyOneGame class but utilise polymorphism to convert it back to the inherited class Game so we can make use of our overloaded operators
                game += player; // Add the new created instance of the Player class player to our new instance of the Game class, this make use of our overloaded "+" operator
                player.IsActivelyPlaying = true; // As the player wants to play the game we set this boolean to true

                /* While player.IsActivelyPlaying equals true and their balance is greater than zero */
                while (player.IsActivelyPlaying && player.Balance > 0)
                {
                    try
                    {
                        game.Play(); // Execute the Play() method of the game object
                    } // End Try

                    catch (FraudException ex) // This code executes when a FraudException is caught, the exception is stored in ex
                    {
                        Console.WriteLine(ex.Message); // Output this text to the console
                        UpdateDbWithException(ex); // Run the log exception method passing in the caught exception ex as a parameter
                        Console.ReadLine(); // Pause the application at this point
                        return; // End the application
                    } // End CATCH

                    catch (Exception ex) // This code executes when a Exception is caught, the exception is stored in ex
                    {
                        Console.WriteLine("An error occurred. Please contact your System Administrator."); // Output this text to the console
                        UpdateDbWithException(ex); // Run the log exception method passing in the caught exception ex as a parameter
                        Console.ReadLine(); // Pause the application at this point
                        return; // End the application
                    } // End CATCH
                } // End WHILE

                game -= player; // Remove the player from the game object
                Console.WriteLine("Thank you for playing"); // Output this text to the console
            } // End IF

            Console.WriteLine("Feel free to look around the casino. Bye for now."); // Output this text to the console
            Console.Read(); // Pause the application
        } // End MAIN

        private static void UpdateDbWithException(Exception ex) // This method will log the type, message and time and date everytime an exception is caught by the application
        {

            // A string that contains the information needed to connect to our exceptions database
            string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=TwentyOneGame;
                                        Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                        TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False";

            // A string that contains a SQL query which will insert new data into our database tables, we will insert the values of variables @ExceptionType, @ExceptionMessage, @TimeStamp into the table rows ExceptionType, ExceptionMessage and TimeStamp
            string queryString = @"INSERT INTO Exceptions (ExceptionType, ExceptionMessage, TimeStamp) 
                                   VALUES (@ExceptionType, @ExceptionMessage, @TimeStamp)";

            // Open a new SQL connection to the database we point to in the connectionString variable above, the connection is called command
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection); // Use the SQLCommand command declared above and passing the queryString and connection declared above

                command.Parameters.Add("@ExceptionType", SqlDbType.VarChar); // Specify the @ExceptionType parameter in the above queryString is VarChar SQL data type
                command.Parameters.Add("@ExceptionMessage", SqlDbType.VarChar); // Specify the @ExceptionMessage parameter in the above queryString is VarChar SQL data type
                command.Parameters.Add("@TimeStamp", SqlDbType.DateTime); // Specify the @TimeStamp parameter in the above queryString is a DateTime SQL data type

                command.Parameters["@ExceptionType"].Value = ex.GetType().ToString(); // Set the @ExceptionType parameter and set it to the string value of our exception ex exception type
                command.Parameters["@ExceptionMessage"].Value = ex.Message; // Set the @ExceptionMessage parameter and set it to the value of ex.Message
                command.Parameters["@TimeStamp"].Value = DateTime.Now; // Set the value of the @TimeStamp to the current date and time

                connection.Open(); // Open the connection to the database
                command.ExecuteNonQuery(); // Execute the command in our queryString
                connection.Close(); // Close the connection to the database
            } // End SqlConnection

        } // End UpdateDbWithException

        // Read all the rows in the Exceptions DB table into a list of ExceptionEntity objects
        private static List<ExceptionEntity> ReadExceptions()
        {

            // A string that contains the information needed to connect to our exceptions database
            string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=TwentyOneGame;
                                        Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                        TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False";

            // A string which contains a SQL query which selects all entries from the exceptions table
            string queryString = @"SELECT Id, ExceptionType, ExceptionMessage, TimeStamp FROM Exceptions";

            List<ExceptionEntity> Exceptions = new List<ExceptionEntity>(); // Create a new list of ExceptionEntity objects called Exceptions

            using (SqlConnection connection = new SqlConnection(connectionString)) // Create a new SQL connection object
            {

                SqlCommand command = new SqlCommand(queryString, connection); // Create a new SQL command object
                connection.Open(); // Open the SQL conneciton
                SqlDataReader reader = command.ExecuteReader(); // Create a new SQL reader object so we can read from the database we have connected to, called reader

                while (reader.Read()) // While there are still entries in the database left to read
                {
                    
                    ExceptionEntity exception = new ExceptionEntity(); // Create a new ExceptionEntity object called exception

                    exception.Id = Convert.ToInt32(reader["Id"]); // Take the Id column from the current row and convert it to an integer then assign the value to exception.id
                    exception.ExceptionType = reader["ExceptionType"].ToString(); // Take the ExceptionType column from the current row and convert it to a string then assign the value to exception.ExceptionType
                    exception.ExceptionMessage = reader["ExceptionMessage"].ToString(); // Take the ExceptionMesssage column from the current row and convert it to a string then assign the value to exception.ExceptionMessage
                    exception.TimeStamp = Convert.ToDateTime(reader["TimeStamp"]); // Take the TimeStamp column from the current row and convert it to a DateTime object then assign the value to exception.TimeStamp
                    Exceptions.Add(exception); // Add exception to the Exceptions list

                } // End WHILE

                connection.Close(); // Close the connection to the database

            } // End SqlConnection

            return Exceptions; // Return the Exceptions list

        } // End ReadExceptions

    } // End CLASS

} // End NAMESPACE
