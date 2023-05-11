// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// MODULE 9: Database and MVC Fundamentals
// AUTHOR: Steven Partlow
// DATE: 17/02/2023

// EXCEPTION ENTITY CLASS DEFINITION

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{

    /* This class will map one-to-one with our Exceptions table in our database with each property matching a column in the table */

    public class ExceptionEntity
    {
        /* PROPERTIES */ 

        public int Id { get; set; } // The primary key of the Exceptions table and the id column
        public string ExceptionType { get; set; } // The ExceptionType column from the exceptions table
        public string ExceptionMessage { get; set; } // The ExceptionMessage column from the exceptions table
        public DateTime TimeStamp { get; set; } // The TimeStamp column from the exceptions table

    } // End ExceptionEntity Class

} // End TwentyOne NAMESPACE
