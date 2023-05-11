// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// MODULE 11: Creating MVC Applications
// AUTHOR: Steven Partlow
// DATE: 26/02/2023

// HOME CONTROLLER

using StudentMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        } // END Index

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        } // END About

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page - Academy of Learning";

            return View();
        } // END Contact

        public ActionResult Instructor(int id) // Take parameter taken in from browser URL and store value as integer id
        {
            ViewBag.Id = id; // Add value of id to ViewBag dictionary

            Instructor dayTimeInstructor = new Instructor // Instaniate a new instance of the Instructor class called dayTimeInstructor
            {
                Id = 1, // Set the Id property
                FirstName = "Erik", // Set the FirstName Property
                LastName = "Gross" // Set the LastName Property
            }; // END Instantiation Instructor

            return View(dayTimeInstructor); // Return Instructor view
        } // END Instructor
         
        public ActionResult Instructors()
        {

            List<Instructor> instructors = new List<Instructor> // Instatiate a new List called instructors consisting of Intructor objects and add three objects to the list
            {
                new Instructor // Add a new instructor to the list with these properties
                {
                    Id = 1,
                    FirstName = "Rick",
                    LastName = "Ramen"
                },
                new Instructor // Add a new instructor to the list with these properties
                {
                    Id = 2,
                    FirstName = "Brett",
                    LastName = "Calendar"
                },
                new Instructor // Add a new instructor to the list with these properties
                {
                    Id = 3,
                    FirstName = "Adam",
                    LastName = "Smithsonian"
                }
            }; // End Instaniation of instructors list

            return View(instructors);
        } // END Instructors
    }
}