// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// MODULE 11: Creating MVC Applications
// AUTHOR: Steven Partlow
// DATE: 26/02/2023

// INSTRUCTOR CLASS DEFINITION

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMVC.Models
{

    public class Instructor
    {
        public int Id { get; set; } // Define a Id property as a integer data type
        public string FirstName { get; set; } // Define a FirstName property as a string data type  
        public string LastName { get; set; } // Define a LastName property as a string data type
    } // END Instructor CLASS

} // END StudentMVC.Models