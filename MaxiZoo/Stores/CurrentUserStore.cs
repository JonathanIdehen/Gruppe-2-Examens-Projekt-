using MaxiZoo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaxiZoo.Stores
{
    public class CurrentUserStore
    {
        public Employee? CurrentUser { get; set; } 
        // Property that holds the currently registered user.
    }
}
