// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// MODULE 12: ASP.NET MVC Entity Framework Assignment
// AUTHOR: Steven Partlow
// DATE: 13/03/2023

// ALL INSUREE QUOTES VIEW MODEL

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsurance.ViewModels
{

    public class QuotesVm
    {

        /* This is a view model for the Admin view that only shows the insurees First and Last name along with there email address and the quote they were issued with */

        public string FirstName { get; set; } // Current insurees firstName property, this is a string value
        public string LastName { get; set; } // Current insurees lastName property, this is a string value
        public string EmailAddress { get; set; } // Current insurees emailAddress property, this is a string value
        public decimal Quote { get; set; } // Current insurees quote property, this is a decimal value

    } // End Quotes CLASS

} // End CarInsurance.ViewModels NAMESPACE