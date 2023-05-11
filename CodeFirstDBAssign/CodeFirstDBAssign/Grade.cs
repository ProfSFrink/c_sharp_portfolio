// Advanced Software and Web Developer Diploma
// Part X: C# and .NET Framework - Part 2
// by Pitman Training / The Tech Academy

// FINAL PROJECT: Final Assignment - Code First Database Assignment
// AUTHOR: Steven Partlow
// DATE: 18/03/2023

/// GRADE CLASS DEFINITION

using System.Collections.Generic;

namespace CodeFirstDBAssign
{

    // Grade class will represent the Grade table in our Student database, and has a one-to-many relationship with the Student table

    class Grade
    {

        public int GradeId { get; set; } // GradeID, an integer variable to represent the GradeId column in the Grades table, also the table primary key
        public string GradeName { get; set; } // GradeName, a string variable to represent the GradeName column in the Grades table
        public string CourseName { get; set; } // CourseName, a string variable to represent the CourseName column in the Grades table

        public ICollection<Student> Students { get; set; } // Students, a collection of Student class instances

    } // End Grade CLASS

} // End CodeFirstDBAssign NAMESPACE
