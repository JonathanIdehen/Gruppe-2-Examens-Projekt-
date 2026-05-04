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


        public CreateEmployeeViewModel(
    EmployeeService employeeService,
    NavigationStore navigationStore,
    TaskService taskService,
    EmployeeRepository employeeRepository)
        {
            _employeeService = employeeService;
            _navigationStore = navigationStore;
            _taskService = taskService;
            _employeeRepository = employeeRepository;

            CreateEmployeeCommand = new CreateEmployeeCommand(this, employeeService);

            GoBackCommand = new NavigateCommand(
                _navigationStore,
                () => new ManagerHomeViewModel(
                    _navigationStore,
                    _taskService,
                    _employeeRepository,
                    _employeeService));
        }
    }
}
