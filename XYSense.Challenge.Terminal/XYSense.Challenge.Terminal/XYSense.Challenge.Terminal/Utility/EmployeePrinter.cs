using System;
using System.Collections.Generic;
using System.Linq;
using XYSense.Challenge.Terminal.Domain;

namespace XYSense.Challenge.Terminal.Utility
{
    public static class EmployeePrinter
    {
        /// <summary>
        /// Print the employee details to the console with the specified level of indentation
        /// </summary>
        public static void PrintDetails(int indent, Employee employee) =>
          Console.WriteLine($"{string.Empty.PadLeft(indent * 3, ' ')}{indent} - {employee}");

        internal static void PrintAllEmployees(IEnumerable<Employee> employeeList)
        {
            var currentEmp = employeeList.Where(x => string.IsNullOrWhiteSpace(x.ManagerEmployeeNo)).FirstOrDefault();
            var hierachy = 0;

            PrintDetails(hierachy, currentEmp);
            hierachy++;

            var ceoReports = employeeList.Where(x => x.ManagerEmployeeNo
            .Equals(currentEmp.EmployeeNo, StringComparison.OrdinalIgnoreCase));

            foreach (var report in ceoReports)
            {
                PrintDetails(hierachy, report);
                PrintHieracy(report, employeeList, hierachy);
            }
        }

        private static void PrintHieracy(Employee manager, IEnumerable<Employee> employeeList, int index)
        {
            var reports = employeeList
            .Where(x => x.ManagerEmployeeNo.Equals(manager.EmployeeNo, StringComparison.OrdinalIgnoreCase));
            var hierachy = ++index;

            foreach (var report in reports)
            {
                PrintDetails(hierachy, report);
                PrintHieracy(report, employeeList, hierachy);
            }
        }
    }
}
