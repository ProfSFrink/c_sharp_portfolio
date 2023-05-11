// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// MODULE 12: ASP.NET MVC Entity Framework Assignment
// AUTHOR: Steven Partlow
// DATE: 13/03/2023

// ADMIN CONTROLLER

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models; // Allows us to access our Insurance database
using CarInsurance.ViewModels; // Allows us to access our QuotesVm View Model

namespace CarInsurance.Controllers
{

    public class AdminController : Controller
    {

        // GET: Admin
        // Type https://localhost:<portnumber>/Admin/Index in browser URL to access this page

        public ActionResult Index() /* This action is executed everytime the main index page of the admin is loaded */
        {

            // Create new connection to the InsureanceEntities database called db
            using (InsuranceEntities db = new InsuranceEntities())
            {

                /* Select all rows in the Insuree table from the InsuranceEntites database and cast them to a list of insuree model objects called quotes */
                var quotes = (from column in db.Insurees
                              select column).ToList();

                var quotesVms = new List<QuotesVm>(); // Create a list of QuotesVm view model objects

                foreach (var quote in quotes) // Iterate throgh the quotes list, assigning each element to the local instance of the insuree model called quote
                {

                    var quotesVm = new QuotesVm(); // Create a local instance of the QuotesVm View Model

                    quotesVm.FirstName = quote.FirstName; // Map the current iteration of quote.FirstName column to the quotesVm.FirstName property
                    quotesVm.LastName = quote.LastName; // Map the current iteration of quote.LastName column to the quotesVm.LastName property
                    quotesVm.EmailAddress = quote.EmailAddress; // Map the current iteration of quote.EmailAddress column to the quotesVm.EmailAddress property
                    quotesVm.Quote = quote.Quote; // Map the current iteration of quote.Quote column to the quotesVm.Quote property

                    quotesVms.Add(quotesVm); // Take the local instance of the QuoteVm view model called quotesVm and add to our quotesVms list

                } // End FOREACH

                return View(quotesVms); // Pass the quotesVms to the View

            } // End USING ending connection to the InsuranceEntities database

        } // End Index METHOD

    } // End AdminController CLASS

} // End CarInsurance.Controllers NAMESPACE