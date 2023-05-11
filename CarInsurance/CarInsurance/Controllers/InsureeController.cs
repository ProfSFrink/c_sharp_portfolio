// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// MODULE 12: ASP.NET MVC Entity Framework Assignment
// AUTHOR: Steven Partlow
// DATE: 09/03/2023

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{

    public class InsureeController : Controller
    {

        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

      
        // This action is executed when the user clicks the Get your Quote button in the create view
        [HttpPost] // This is post method
        [ValidateAntiForgeryToken]

        // Take in the information that the insuree entered into the web form
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {

                db.Insurees.Add(insuree); // Add the insuree to the database
                db.SaveChanges(); // Save the changes to the database
                GenerateQuote(insuree.Id); // Generate quote for the current insuree ID
                return View("~/Views/Home/Success.cshtml");

            } // End IF

            return View(insuree);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                GenerateQuote(insuree.Id); // Generate quote for the current insuree ID
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        /* The main business logic which generates the quote for the insuree has one parameter which is their id property */
        public ActionResult GenerateQuote(int Id)
        {

            using (InsuranceEntities db = new InsuranceEntities()) // Open a new connection to the InsuranceEntities database called db
            {

                var insuree = db.Insurees.Find(Id); // Find the relevant insuree in the database by their id

                /* CALCULATE INSUREES EXACT AGE */
                var age = DateTime.Today.Year - insuree.DateOfBirth.Year; // Take year fron the current date and subtract the year from the user date of birth to work out there approximate age
                if (DateTime.Today.Month <= insuree.DateOfBirth.Month && DateTime.Today.Day < insuree.DateOfBirth.Day) { age -= 1; } // Check if the user has had a birthday or not this year and if they have not then we take one year off the calulated age

                var carYear = insuree.CarYear; // Variabe to represent the year the car was made
                var carModel = insuree.CarModel; // Variable to represent the car model
                var carMake = insuree.CarMake; // Variable to represent the car make
                var speedingTickets = insuree.SpeedingTickets; // Variable to represent the number of speeding tickets the insuree has had
                var dui = insuree.DUI; // Variable to repsresent if the insuree has ever had a DUI
                var coverageType = insuree.CoverageType; // Variable to represent the type of insurance coverage the insuree has

                decimal quote = 50m; // Variable to represent our insurance quote which starts with an inital value of $50, this is of the decimal data type as the quote is a monetary value

                /* BUSINESS LOGIC FOR CALCULATING INSUREE QUOTE */

                /*  AGE BL */

                // If the insuree under the age of 18, add $100 to the quote
                if (age <= 18) { quote += 100m; }
                // If the insuree is between the ages of 19 and 25, add $50 to the quote
                else if (age >= 19 && age <= 25) { quote += 50m; }
                // If the insuree is over the age of 25, add $25 to the quote
                else if (age > 25) { quote += 25m; }

                /* CAR BUSINESS LOGIC */

                // If the year of the make is before 2000, add $25 to the quote
                if (carYear < 2000) { quote += 25m; }
                // If the year of the make is after 2015, add $25 to the quote
                else if (carYear > 2015) { quote += 25m; }

                // If the car's make is a porche and it's a 911 carrera, add $50 to the quote
                if (carMake.ToUpper() == "PORCHE" && carModel.ToUpper() == "911 CARRERA") { quote += 50m; }
                // If the car's make is just a porche, add $25 to the quote
                else if (carMake.ToUpper() == "PORCHE") { quote += 25m; }

                /* SPEEDING TICKET AND DUI BUSINESS LOGIC */

                // Add $10 to the quote for every speeding ticket the insuree has ever had
                quote += speedingTickets * 10m; // Multiply the value of speedingTickets by ten and add the value to the total quote

                // If the insuree has ever had a DUI, calculate 25% of the total quote and add it to the total
                if (dui == true) { quote *= 1.25m; } // Calculate 25% of the current value of quote and add it to quote

                /* COVERAGE TYPE BUSINESS LOGIC */

                // If the insuree wants full coverage, calulate 50% of the total quote and add it to the total
                if (coverageType == true) { quote *= 1.5m; }

                insuree.Quote = quote; // Set the final calculated value of quote to the insurees personal quote column
                db.SaveChanges(); // Save the updated quote to the database

            } // End USING (Close db connection)

            return View("Index"); // Return to the index view

        } // End GenerateQuote Method

    } // End CLASS

} // End NAMESPACE