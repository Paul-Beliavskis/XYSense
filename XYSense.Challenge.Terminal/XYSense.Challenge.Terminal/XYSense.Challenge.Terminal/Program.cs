using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using XYSense.Challenge.Terminal.Domain;
using XYSense.Challenge.Terminal.Utility;

namespace XYSense.Challenge.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var filePath = $"{Directory.GetCurrentDirectory()}\\Data\\random-names.txt";
            using (var reader = new StreamReader(filePath))
            {
                var line = reader.ReadLine();

                var employeeList = new HashSet<Employee>();
                var sw = new Stopwatch();

                while (!string.IsNullOrWhiteSpace(line))
                {
                    var lineSplit = line.Split("\t");

                    employeeList.Add(
                    new Employee
                    {
                        EmployeeNo = lineSplit[0],
                        FirstName = lineSplit[1],
                        LastName = lineSplit[2],
                        ManagerEmployeeNo = lineSplit[3]
                    }
                    );

                    line = reader.ReadLine();
                }
                
                EmployeePrinter.PrintAllEmployees(employeeList);
            }
            

            Console.ReadLine();
        }
    }
}
