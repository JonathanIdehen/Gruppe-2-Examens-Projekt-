using System;
using System.Collections.Generic;
using System.Text;

namespace MaxiZoo.Models
{

    public enum Category
    {
        Cleaning,
        Restocking,
        Cashier,
        OrderingProducts
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public enum Status
    {
        NotStarted,
        InProgress,
        Completed,
        Rejected,
        Done

    }

    public class Task
    {

        public int TaskID { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime Deadline { get; set; }

        public Priority Priority { get; set; }
        public Category Category { get; set; }
        public Status Status { get; set; }
        public EmployeeID EmployeeID { get; set; }

        public Employee? AssignedEmployee { get; set; }

    }
}
