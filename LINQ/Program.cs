﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using EducationLibrary;

namespace LINQ
{
    class Program
    {
        void Run()
        {
            var students = StudentCollection.Select();

            //to get students with GPA >= 3.5 and SAT > 1400 without LINQ:
            // StudentCollection DeansListStudents = new StudentCollection();
            // foreach (var s in student) {
            // if(s.GPA >= 3.5 && s.SAT > 1400){
            //     DeansListStudents.Add(s);
            // }
            // }


            //this is using LINQ:
            var TopStudents = students.Where(stud => stud.GPA >= 3.5 && stud.SAT > 1400).OrderByDescending(s => s.GPA);     




            foreach(var student in TopStudents)
            {
                Debug.WriteLine($"{student.FirstName} {student.LastName} GPA is {student.GPA} and SAT is {student.SAT}");
            }
            var StudentMajors = students.Where(stud => stud.MajorId >= 4).OrderByDescending(s => s.LastName);

            foreach (var student in StudentMajors)
            {
                Debug.WriteLine($"{student.FirstName} {student.LastName} having a majorId of {student.MajorId}");
            }
        }
        static void Main(string[] args)
        {
            new Program().Run();
        }
    }
}
