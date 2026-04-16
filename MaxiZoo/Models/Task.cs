using System;
using System.Collections.Generic;
using System.Text;

namespace MaxiZoo.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime Deadline { get; set; }

        public Priority Priority { get; set; }
        public Category Category { get; set; }
        public Status Status { get; set; }

        public Employee? AssignedEmployee { get; set; }

    }
}
