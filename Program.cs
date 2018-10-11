using System;
using System.Linq;
using System.Collections.Generic;

namespace PracticeLINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            SeedDatabase();

        }
        public static void WherePractice()
        {
            using(var db = new AppDbContext())
            {
                /*
                    SELECT FirstName 
                    FROM Students
                    WHERE Rank != Senior
                 */
                
                var filteredResult = db.Students.Where(s => s.Rank != "Senior").Select(s => s.Rank);

                PrintList(filteredResult);
            }
        }
        public static void WherePracticeOne()
        {
            using(var db = new AppDbContext())
            {
                /*
                    SELECT *
                    FROM Students
                    WHERE StudentFName start with M or lower
                 */                
                var filteredResult = from s in db.Students
                    where s.StudentFName.StartsWith('M') 
                    select s.StudentFName;

                PrintList(filteredResult);
            }
        } 

        public static void WherePracticeTwo()
        {
            using(var db = new AppDbContext())
            {
                /*
                    SELECT *
                    FROM Students
                    WHERE SudentLName start with L and higher and longer than 6 character
                 */                
                var filteredResult = from s in db.Students
                    where s.StudentLName.StartsWith('L') && s.StudentLName.Length >= 6
                    select s.StudentLName;

                PrintList(filteredResult);
            }
        } 

        public static void FindPracticeOne()
        {
            using(var db = new AppDbContext())
            {
                // find a student named "John"
                var findResult = db.Students.Where(s => s.StudentFName == "John");

                foreach (var nameFind in findResult)
                {
                    Console.WriteLine($"Result: {nameFind}");

                }
                
            }
        }

        public static void PrintList(IEnumerable<Object> list)
        {
            foreach(var s in list)
            {
                Console.WriteLine(s);
            }
        }

        public static void SeedDatabase()
        {
            using(var db = new AppDbContext())
            {
                try
                {

                    
                    db.Database.EnsureCreated();

                    if(!db.Students.Any() )
                    {
                        

                        IList<Student> studentList = new List<Student>() { 
                            new Student() { StudentID = 1, StudentFName = "Laith",StudentLName = "Alfaloujeh",  Rank = "Junior", },
                            new Student() { StudentID = 2, StudentFName = "Mekkala",StudentLName = "Bourapa", Rank = "Junior", },
                            new Student() { StudentID = 3, StudentFName = "Charles ",StudentLName = "Coufal",  Rank = "Sophomore", },
                            new Student() { StudentID = 4, StudentFName = "John",StudentLName = "Cunningham",  Rank = "Junior", },
                            new Student() { StudentID = 5, StudentFName = "Michael",StudentLName = "Hayes",  Rank = "Senior", },
                            new Student() { StudentID = 6, StudentFName = "Aaron",StudentLName = "Hebert",  Rank = "Junior", },
                            new Student() { StudentID = 7, StudentFName = "Yi",StudentLName = "Ji",  Rank = "Sophomore", },
                            new Student() { StudentID = 8, StudentFName = "Todd",StudentLName = "Kile",  Rank = "Junior", },
                            new Student() { StudentID = 9, StudentFName = "Mara",StudentLName = "Kinoff",  Rank = "Senior", },
                            new Student() { StudentID = 10, StudentFName = "Cesareo",StudentLName = "Lona",  Rank = "Junior", },
                            new Student() { StudentID = 11, StudentFName = "Michael",StudentLName = "Matthews",  Rank = "Junior", },
                            new Student() { StudentID = 12, StudentFName = "Mason",StudentLName = "McCollum",  Rank = "Junior", },
                            new Student() { StudentID = 13, StudentFName = "Alexander",StudentLName = "McDonald",  Rank = "Senior", },
                            new Student() { StudentID = 14, StudentFName = "Phelps",StudentLName = "Merrell",  Rank = "Sophomore", },
                            new Student() { StudentID = 15, StudentFName = "Quan",StudentLName = "Nguyen",  Rank = "Junior", },
                            new Student() { StudentID = 16, StudentFName = "Alexander",StudentLName = "Roder",  Rank = "Senior", },
                            new Student() { StudentID = 17, StudentFName = "Amy",StudentLName = "Saysouriyosack",  Rank = "Junior", },
                            new Student() { StudentID = 18, StudentFName = "Claudia",StudentLName = "Silva",  Rank = "Junior", },
                            new Student() { StudentID = 19, StudentFName = "Gabriela",StudentLName = "Valenzuela",  Rank = "Senior", },
                            new Student() { StudentID = 20, StudentFName = "Kayla",StudentLName = "Washington",  Rank = "Junior", },
                            new Student() { StudentID = 21, StudentFName = "Matthew",StudentLName = "Webb",  Rank = "Junior", },
                            new Student() { StudentID = 22, StudentFName = "Cory",StudentLName = "Williams",  Rank = "Senior", },

                        
                            
                        };  

                        db.Students.AddRange(studentList);

                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("We have existing records in the db");
                    }
                }

                
                
                catch(Exception exp)
                {
                    Console.Error.WriteLine(exp.Message);
                }
            }
        }
    }
}

                
        