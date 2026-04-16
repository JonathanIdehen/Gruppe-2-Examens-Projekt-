using System;
using System.Collections.Generic;
using System.Text;

namespace MaxiZoo.Models
{
    public enum Role
    {
        Employee,
        Manager // stands for both chef and souschef
    }
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; } = "";
        public Role Role { get; set; }
    }
}
