// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// MODULE 12: Continuing to Develop in C# and MVC
// AUTHOR: Steven Partlow
// DATE: 07/03/2023

using NewsletterAppMVC.Models;
using NewsletterAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsletterAppMVC.Controllers
{
    public class AdminController : Controller
    {

        // GET: Admin
        public ActionResult Index()
        {

            /* ENTITY FRAMEWORK DATABASE CALLS */

            // Create new connection to the newsletter database called db
            using (db_NewsletterEntities db = new db_NewsletterEntities())
            {
                /* SELECT ALL NON-REMOVED USERS USING LAMBDA EXPRESSIONS */

                //var signups = db.SignUps.Where(x => x.Removed == null).ToList(); // Use a lambda expressions to select all rows from the SignUps table where the Removed property is set to null, then add all relevant records and assign them to a list and assign it the signups variable

                /* SELECT ALL NON-REMOVED USERS USING LINQ EXPRESSIONS */

                /* Select any row from the SignUps table, where c represents the current row being check, where the Removed column of that row is equal to null then assign all those row to a list and assign that list to the signups variable */
                var signups = (from c in db.SignUps
                               where c.Removed == null
                               select c).ToList();

                var signupVms = new List<SignupVm>(); // Create list of SignupVm view model objects
                foreach (var signup in signups) // Take the signups list and iterate through it assigning each instance to a local variable signup
                {
                    var signupVm = new SignupVm(); // Create a local instance of the signupVm view model
                    signupVm.Id = signup.Id; // Map the current instance of signup.Id to signupVm.Id
                    signupVm.FirstName = signup.FirstName; // Map the current instance of signup.FirstName to signupVm.FirstName
                    signupVm.LastName = signup.LastName; // Map the current instance of signup.LastName to signupVm.LastName
                    signupVm.EmailAddress = signup.EmailAddress; // Map the current instance of signup.EmailAddress to signupVm.EmailAddress
                    signupVms.Add(signupVm); // Take the local instance signupVm and add it to our main signupVms list
                } // End FOREACH

                return View(signupVms); // Pass the signupVms to the view
            } // End USING

        } // End of Index() Method

        /* Unsubscribe method */

        public ActionResult Unsubscribe(int Id) // Define Unsubscribe method with one input integer parameter Id
        {

            using (db_NewsletterEntities db = new db_NewsletterEntities()) // Open a connection to our Newsletter database
            {
                var signup = db.SignUps.Find(Id); // Find the row in our SignUps table with the matching Id provided by input parameter Id

                signup.Removed = DateTime.Now; // Assign the current date and time to the Removed column of the signup row
                db.SaveChanges(); // Save the update row to the database
            }

            return RedirectToAction("Index"); // Return the Admin index view

        } // End Unsubscribe Method

    }  // End CLASS AdminController

} // End NewsletterAppMVC.Controllers