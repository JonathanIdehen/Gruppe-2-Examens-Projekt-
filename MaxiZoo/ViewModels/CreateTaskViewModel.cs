using MaxiZoo.Commands;
using MaxiZoo.Models;
using MaxiZoo.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MaxiZoo.Services;

namespace MaxiZoo.ViewModels
{
    public class CreateTaskViewModel : BaseViewModel
    {
        public bool IsOneTime { get; set; } 

        public Category SelectedCategory { get; set; }
        public Priority SelectedPriority { get; set; }

        public string Title { get; set; } = "";
        public string Description { get; set; } = ""; 
        public DateTime? Deadline { get; set; }

        public ICommand? CreateTaskCommand { get; }

        public CreateTaskViewModel(TaskService taskService)
        {
            CreateTaskCommand = new CreateTaskCommand(this, taskService);
        }

        public Array Categories => Enum.GetValues(typeof(Category));
        public Array Priorities => Enum.GetValues(typeof(Priority));
    }
}
