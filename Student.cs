using System;
using System.Linq;
using System.Collections.Generic;

namespace PracticeLINQ
{
    public class Student
    {
        //PK
        public int StudentID { get; set; }  
        public string StudentFName { get; set; } 

        public string StudentLName{get; set;} 
        public string Rank {get;set;} 

       

        public override string ToString()
        {
            return $"{StudentFName} - {StudentLName} - {Rank}";
        }

    }
}