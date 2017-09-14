using System;
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

        void RunExamplesfromChapter21()
        {
            var customers = new[]
            {
                new {CustomerID = 1, FirstName = "Kim", LastName = "Abercrombie", CompanyName = "Alpine Ski House"},
                new {CustomerID = 2, FirstName = "Jeff", LastName = "Hay", CompanyName = "Coho Winery"},
                new {CustomerID = 3, FirstName = "Charlie", LastName = "Herb", CompanyName = "Alpine Ski House"},
                new {CustomerID = 4, FirstName = "Chris", LastName = "Preston", CompanyName = "Trey Research"},
                new {CustomerID = 5, FirstName = "Dave", LastName = "Barnett", CompanyName = "Wingtip Toys"},
                new {CustomerID = 6, FirstName = "Ann", LastName = "Beebe", CompanyName = "Coho Winery"},
                new {CustomerID = 7, FirstName = "John", LastName = "Kane", CompanyName = "Wingtip Toys"},
                new {CustomerID = 8, FirstName = "David", LastName = "Simpson", CompanyName = "Trey Research"},
                new {CustomerID = 9, FirstName = "Greg", LastName = "Chapman", CompanyName = "Wingtip Toys"},
                new {CustomerID = 10, FirstName = "Tim", LastName = "Litton", CompanyName = "Wide World Importers"},

            };

            var addresses = new[]
            {
                new {CompanyName = "Alpine Ski House", City = "Berne", Country = "Switzerland" },
                new {CompanyName = "Coho Winery", City = "San Francisco", Country = "United States" },
                new {CompanyName = "Trey Research", City = "New York", Country = "United States" },
                new {CompanyName = "Wingtip Toys", City = "London", Country = "United Kingdom" },
                new {CompanyName = "Wide World Importers", City = "Tetbury", Country = "United Kingdom" },
            };

            IEnumerable<string> customerFirstName = customers.Select(cust => cust.FirstName);

            foreach(string name in customerFirstName)
            {
                Debug.WriteLine(name);
            }

            IEnumerable<string> customerNames = customers.Select(cust => $"{cust.FirstName} {cust.LastName}");
            foreach(string name in customerNames)
            {
                Debug.WriteLine(name);
            }

            IEnumerable<string> usCompanies = addresses.Where(addr => String.Equals(addr.Country, "United States")).Select(usComp => usComp.CompanyName);
        
            foreach(string name in usCompanies)
            {
                Debug.WriteLine(name);
            }

            IEnumerable<string> companyNames = addresses.OrderBy(addr => addr.CompanyName).Select(comp => comp.CompanyName);

            foreach(string name in companyNames)
            {
                Debug.WriteLine(name);
            }


            var companiesGroupedByCountry = addresses.GroupBy(addrs => addrs.Country);

            foreach(var companiesPerCountry in companiesGroupedByCountry)
            {
                Debug.WriteLine($"Country: {companiesPerCountry.Key}\t{companiesPerCountry.Count()} companies");
                foreach(var companies in companiesPerCountry)
                {
                    Debug.WriteLine($"\t{companies.CompanyName}");
                }
            }

            int numberofCompanies = addresses.Select(addr => addr.CompanyName).Count();
            Debug.WriteLine($"Number of companies: {numberofCompanies}");

            int numberOfCountries = addresses.Select(addr => addr.Country).Distinct().Count();
            Debug.WriteLine($"Number of countries: {numberOfCountries}");

            var companiesAndCustomers = customers.Select(c => new { c.FirstName, c.LastName, c.CompanyName })
                .Join(addresses, custs => custs.CompanyName, addrs => addrs.CompanyName,
                (custs, addrs) => new { custs.FirstName, custs.LastName, addrs.Country });

            foreach(var row in companiesAndCustomers)
            {
                Debug.WriteLine(row);
            }


        }
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
            new Program().RunExamplesfromChapter21();
        }
    }
}
