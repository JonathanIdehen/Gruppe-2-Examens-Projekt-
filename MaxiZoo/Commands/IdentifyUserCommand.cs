using MaxiZoo.Models;
using MaxiZoo.Persistence;
using MaxiZoo.Services;
using MaxiZoo.Stores;
using MaxiZoo.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
namespace MaxiZoo.Commands
{
    public class IdentifyUserCommand : CommandBase
    {
        private readonly StartViewModel _startViewModel;
        private readonly UserIdentificationService _userIdentificationService;
        private readonly CurrentUserStore _currentUserStore;
        private readonly NavigationStore _navigationStore;
        private readonly TaskService _taskService;
        private readonly EmployeeRepository _employeeRepository;
        private readonly EmployeeService _employeeService;
        private readonly NavigationService _navigationService;


        public IdentifyUserCommand(
        StartViewModel startViewModel,
        UserIdentificationService userIdentificationService,
        CurrentUserStore currentUserStore,
        NavigationStore navigationStore,
        TaskService taskService,
        EmployeeRepository employeeRepository,
        EmployeeService employeeService,
        NavigationService navigationService)
        {
            _startViewModel = startViewModel;
            _userIdentificationService = userIdentificationService;
            _currentUserStore = currentUserStore;
            _navigationStore = navigationStore;
            _taskService = taskService;
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            if (!int.TryParse(_startViewModel.EmployeeIdInput, out int employeeId))
                return;

            Employee? employee = _userIdentificationService.IdentifyUser(employeeId);
            if (employee == null)
                return;

            _currentUserStore.CurrentUser = employee;

            if (employee.Role == Role.Manager)
            {
                _navigationStore.CurrentViewModel =
                    new ManagerHomeViewModel(
                        _navigationStore, 
                        _navigationService,
                        _taskService, 
                        _employeeRepository, 
                        _employeeService);
            }
            else
            {
                _navigationStore.CurrentViewModel =
                   new EmployeeHomeViewModel(
                      _navigationStore,
                      _navigationService,
                      _taskService,
                      _currentUserStore);
            }
        }
    }
}
