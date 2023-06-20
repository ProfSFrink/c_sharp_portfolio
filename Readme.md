# __C# Projects Portfolio__

This is a collection of the C# and .NET projects that I have as part of my portfolio thus far, again these vary from smaller code snippets to larger programs. They where all developd in Visual Studio 2019.  

&nbsp;
## __Blackjack (TwentyOne) Game - .NET Console Application__ [(CODE)](https://github.com/ProfSFrink/c_sharp_portfolio/tree/master/TwentyOne/TwentyOne) [(README)](https://github.com/ProfSFrink/c_sharp_portfolio/tree/master/TwentyOne/TwentyOne/Readme.md)

## __Newsletter Sign-up Web Application - ASP.NET MVC Web Application__ [(CODE)](https://github.com/ProfSFrink/c_sharp_portfolio/tree/master/NewsletterAppMVC/NewsletterAppMVC) [(README)](https://github.com/ProfSFrink/c_sharp_portfolio/tree/master/NewsletterAppMVC/NewsletterAppMVC/Readme.md)

## __Car Insurance Quote Generator - ASP.NET MVC Web Application__ [(CODE)](https://github.com/ProfSFrink/c_sharp_portfolio/tree/master/CarInsurance/CarInsurance)

---

### __IMPLEMENTS: ASP.NET, Model-View-Controller Desgin Pattern, DB-First Entity FW Implementation, Database Logging, Bootstrap__

&nbsp;
Another ASP.NET web application, this generates a car insurance quote based on data prodvided by the user. The quote is calucated based of the users age, the age and make of the car, the number of speeding tickets, if they have ever a DUI and type of coverage. The business logic that calculates the quote is contained within the insuree controller, also generated quotes are logged to a SQL database through use of the entity framework, data validation is again presents to ensuree correctly generated quotes. An admin view is also implemented, this uses a Quotes view model and shows all generated quotes to an administrator, and the CSS makes use of a combination of Bootstrap and plain CSS.

&nbsp;
## __Unit Testing Practice Math Application - Test (TDD) Approach__ [(CODE)](https://github.com/ProfSFrink/c_sharp_private/tree/master/BasicMathTDDTest)

### __IMPLEMENTS: Object-Orientated Programming, Access Modifiers, Unit Testing__

&nbsp;A simple demo of using Test-Driven Development unit testing on a basic math class. The basic math class has four methods for addition, subtraction, divison, and multiplication. There is then one unit test for each method. This was done using the Test Driven Development approach so the tests were written first.
## __A Simple Code First Student Database - .NET Console Application__ [(CODE)](https://github.com/ProfSFrink/c_sharp_portfolio/tree/master/CodeFirstDBAssign/CodeFirstDBAssign)

---

### __IMPLEMENTS: ASP.NET, Object-Orientated Programming, Code-First Entity FW Implementation, Database Logging, Bootstrap__

&nbsp;
A simple example of a code-first database implementation. We create student and grade classes, then a school class which we use as the base to create our database tables using the student and grades classes as templates. We then create three instances of the student objects, give them a course and a grade and log them to our newly created student database.

## __FizzBuzz Problem__ [(CODE)](https://github.com/ProfSFrink/c_sharp_portfolio/tree/master/FizzBuzz/FizzBuzz/FizzBuzz)

---

### __IMPLEMENTS: Conditional Statements, Loops, Exception Handling, Object-Orientated Programming__

&nbsp;
A C# version of the FizzBuzz problem, uses a TRY / CATCH block to exceptions, check that the numbers entered are whole numbers with no decimal places , then checks for FizzBuzz (divisable by 3 and 5), Fizz (divisable by 3) and Buzz (divisable by 5), or if none of those apply, adding each result to a string before outputting the result
