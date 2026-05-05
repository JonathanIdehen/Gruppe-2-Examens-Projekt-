using MaxiZoo.Commands;
using MaxiZoo.Models;
using MaxiZoo.Persistence;
using MaxiZoo.Services;
using MaxiZoo.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;


namespace MaxiZoo.ViewModels
{
    public class CreateTaskViewModel : BaseViewModel
    {
        public bool IsOneTime { get; set; } 

        public Category SelectedCategory { get; set; }
        public Priority SelectedPriority { get; set; }

        private string _title = "";
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private string _description = "";
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private DateTime? _deadline;
        public DateTime? Deadline
        {
            get => _deadline;
            set
            {
                _deadline = value;
                OnPropertyChanged();
            }
        }
        public ICommand CreateTaskCommand { get; }
        public ICommand NavigateBackCommand { get; }

        public CreateTaskViewModel(
               NavigationService navigationService,
               TaskService taskService,
               NavigationStore navigationStore,
               EmployeeRepository employeeRepository,
               EmployeeService employeeService)
        {
            CreateTaskCommand = new CreateTaskCommand(this, taskService);

            NavigateBackCommand = new NavigateCommand(
                navigationService,
                () => new ManagerHomeViewModel(
                    navigationStore,
                    navigationService,
                    taskService,
                    employeeRepository,
                    employeeService));
        }

        public Array Categories => Enum.GetValues(typeof(Category));
        public Array Priorities => Enum.GetValues(typeof(Priority));



    }
}
