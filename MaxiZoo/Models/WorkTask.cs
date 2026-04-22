using System;
using System.Collections.Generic;
using System.Text;

namespace MaxiZoo.Models
{

    public enum Category
    {
        Cleaning,
        Restockning,
        Cashier,
        OrderingProducts,
        
    }

    public enum Priority
    {
        Lav,
        Mellem,
        Høj
    }

    public enum Status
    {
        NotStarted,
        InProgress,
        Done,
        NotApproved,
        Completed
    }

    public class WorkTask
    {

        public int TaskID { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime Deadline { get; set; }

        public Priority Priority { get; set; }
        public Category Category { get; set; }
        public Status Status { get; set; }

        public bool IsOneTime { get; set; }
        public bool IsAvailableForAssignment { get; set; } = true;

        public int? EmployeeID { get; set; } // Foreign key to Employee
        public Employee? AssignedEmployee { get; set; } // Navigation/reference property to Employee

    }
}
