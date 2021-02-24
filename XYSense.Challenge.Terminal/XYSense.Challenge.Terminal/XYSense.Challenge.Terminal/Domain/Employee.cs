using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYSense.Challenge.Terminal.Domain
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeNo { get; set; }
        public string ManagerEmployeeNo { get; set; }

        public override string ToString()
        {
            return $"[{EmployeeNo}] {FirstName} {LastName} - Reports To [{ManagerEmployeeNo}]";
        }
    }
}
