// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// MODULE 12: Continuing to Develop in C# and MVC
// AUTHOR: Steven Partlow
// DATE: 06/03/2023

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsletterAppMVC.ViewModels
{

    public class SignupVm
    {
        public int Id { get; set; } // A integer variable to match to our Id column
        public string FirstName { get; set; } // A string variable to match to our FirstName column
        public string LastName { get; set; } // A string variable to match to our LastName column
        public string EmailAddress { get; set; } // A string variable to match to our EmailAddress column
    } // End SignupVm CLASS

} // End NewsletterAppMVC.ViewModels NAMESPACE