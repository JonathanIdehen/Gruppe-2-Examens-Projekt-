using System;
using System.Collections.Generic;
using System.Text;

namespace MaxiZoo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public Role Role { get; set; }
    }
}
