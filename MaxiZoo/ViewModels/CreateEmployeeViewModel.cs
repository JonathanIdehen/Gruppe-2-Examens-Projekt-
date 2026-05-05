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
    public class CreateEmployeeViewModel : BaseViewModel
    {
        private readonly EmployeeService _employeeService;
        private readonly TaskService _taskService;
        private readonly EmployeeRepository _employeeRepository;
        private readonly NavigationStore _navigationStore;

        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string EmployeeIdInput { get; set; } = "";

        public Role SelectedRole { get; set; }

        public List<Role> Roles { get; } =
            Enum.GetValues(typeof(Role)).Cast<Role>().ToList();

        public ICommand CreateEmployeeCommand { get; }
        public ICommand GoBackCommand { get; }
        public ICommand NavigateBackCommand { get; }


        public CreateEmployeeViewModel(
               EmployeeService employeeService,
               NavigationService navigationService,
               NavigationStore navigationStore,
               TaskService taskService,
               EmployeeRepository employeeRepository)
        {
            _employeeService = employeeService;
            
            CreateEmployeeCommand = new CreateEmployeeCommand(this, employeeService);

            NavigateBackCommand = new NavigateCommand(
                navigationService,
                () => new ManagerHomeViewModel(
                    navigationStore,
                    navigationService,
                    taskService,
                    employeeRepository,
                    _employeeService));
        }
    }
}
