// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// FINAL PROJECT: Final Assignment - Code First Database Assignment
// AUTHOR: Steven Partlow
// DATE: 18/03/2023

/// STUDENT CONTEXT CLASS DEFINITION

using System.Data.Entity;

namespace CodeFirstDBAssign
{

    class SchoolContext: DbContext // Inherit the DbContext class from entity framework, allowing us to use te DbSet type
    {

        public SchoolContext(): base()
        {

        } // End CONSTRUCTOR

        // The DbSet entity framework type will create tables in our Student Database using the Student and Grade classes as a template allowing CRUD operations on them as tables,
        // becuase the DbSet's represent multiple entities of the same data we pluralise the names Student and Grade 

        public DbSet<Student> Students { get; set; } // Instructs entity framework to create a table called Students using the Student class as a template
        public DbSet<Grade> Grades { get; set; } // Instructs entity framework to create a table called Grades using the Grade class as a template

    } // End SchoolContext CLASS

} // End CodeFirstDBAssign NAMESPACE
