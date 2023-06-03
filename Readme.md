# __C# Projects Portfolio__

This is a collection of the C# and .NET projects that I have as part of my portfolio thus far, again these vary from smaller code snippets to larger programs. They where all developd in Visual Studio 2019.  

&nbsp;
## __Blackjack (TwentyOne) Game - .NET Console Application__ [(CODE)](https://github.com/ProfSFrink/c_sharp_portfolio/tree/master/TwentyOne/TwentyOne)

---

### __IMPLEMENTS: Object-Orientated Programming, ADO.NET, Exception Handling with Database Logging__

A blackjack game developed as a .NET framework console application. The application consists of the main TwentyOne game application with the rest of the application stored in casino library. This library is designed so that the base classes to represent the playing cards and player / dealer decks can be reused in other card games. We establish a base set of rules for card games which can be reused in other card games later. Then we have the main logic for the blackjack game itself, with one class for the games rules, dealer behaviour and the main game logic. The application enacts data validation implemented through try catch / blocks and logging of exceptions, these are logged into an exception object and logged to a database through use of ADO.NET. The program implements the three pillars of object-orientated programming encapsulation, inheritance, and polymorphism in the implementation of it's various classes.

&nbsp;
## __Newsletter Sign-up Web Application - ASP.NET MVC Web Application__ [(CODE)](https://github.com/ProfSFrink/c_sharp_portfolio/tree/master/NewsletterAppMVC/NewsletterAppMVC)

---

### __IMPLEMENTS: ASP.NET, Model-View-Controller Desgin Pattern, Entity Framework, Database Logging, Bootstrap__

An ASP.NET web application allowing for people to sign-up for a newsletter. This application was creating implementing the MVC (Model-View-Controller) design pattern, the main index view allows for new sign-ups and implements data validation to ensure correct data entry by the user, the application also implements an administrator view, which is implemented using a view model to control which data the admin can see, this view also allows the admin to remove a signup from the database. The Home controller logs new sign-ips into SQL database, all database handling it achieved through use of the Entity framework, and an admin controller is implemented for to power the admin view, also the CSS for the views makes use of bootstrap.  

&nbsp;
## __Car Insurance Quote Generator - ASP.NET MVC Web Application__ [(CODE)](https://github.com/ProfSFrink/c_sharp_portfolio/tree/master/CarInsurance/CarInsurance)

---

### __IMPLEMENTS: ASP.NET, Model-View-Controller Desgin Pattern, DB-First Entity FW Implementation, Database Logging, Bootstrap__

&nbsp;
Another ASP.NET web application, this generates a car insurance quote based on data prodvided by the user. The quote is calucated based of the users age, the age and make of the car, the number of speeding tickets, if they have ever a DUI and type of coverage. The business logic that calculates the quote is contained within the insuree controller, also generated quotes are logged to a SQL database through use of the entity framework, data validation is again presents to ensuree correctly generated quotes. An admin view is also implemented, this uses a Quotes view model and shows all generated quotes to an administrator, and the CSS makes use of a combination of Bootstrap and plain CSS.

&nbsp;
## __A Simple Code First Student Database - .NET Console Application__ [(CODE)](https://github.com/ProfSFrink/c_sharp_portfolio/tree/master/CodeFirstDBAssign/CodeFirstDBAssign)

---

### __IMPLEMENTS: ASP.NET, Object-Orientated Programming, Code-First Entity FW Implementation, Database Logging, Bootstrap__

&nbsp;
A simple example of a code-first database implementation. We create student and grade classes, then a school class which we use as the base to create our database tables using the student and grades classes as templates. We then create three instances of the student objects, give them a course and a grade and log them to our newly created student database.

## __FizzBuzz Problem__ [(CODE)](https://github.com/ProfSFrink/c_sharp_portfolio/tree/master/FizzBuzz/FizzBuzz/FizzBuzz)

---

### __IMPLEMENTS: Conditional Statements, Loops, Exception Handling__

&nbsp;
A C# version of the FizzBuzz problem, uses a TRY / CATCH block to exceptions, check that the number entered is a whole number with no decimal places , then checks for FizzBuzz (divisable by 3 and 5), Fizz (divisable by 3) and Buzz (divisable by 5) before a general message if none of those three apply, then the program ends.
