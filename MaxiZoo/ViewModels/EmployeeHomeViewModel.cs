using MaxiZoo.Commands;
using MaxiZoo.Persistence;
using MaxiZoo.Services;
using MaxiZoo.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MaxiZoo.ViewModels
{
    public class EmployeeHomeViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly NavigationService _navigationService;
        private readonly TaskService _taskService;
        private readonly CurrentUserStore _currentUserStore;
        private readonly EmployeeRepository _employeeRepository;
        private readonly EmployeeService _employeeService;

        public ICommand NavigateToMyTasksCommand { get; }
        public ICommand NavigateToTaskOverviewCommand { get; }
        public ICommand NavigateBackCommand { get; }

        public EmployeeHomeViewModel(
            NavigationStore navigationStore,
            NavigationService navigationService,
            TaskService taskService,
            CurrentUserStore currentUserStore,
            EmployeeRepository employeeRepository,
            EmployeeService employeeService)
        {
            _navigationStore = navigationStore;
            _navigationService = navigationService;
            _taskService = taskService;
            _currentUserStore = currentUserStore;
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;


            NavigateToMyTasksCommand = new NavigateCommand(
                navigationService,
                () => new MyTasksViewModel(
                    taskService,
                    currentUserStore,
                    navigationService,
                    navigationStore,
                    employeeRepository,
                    employeeService));

            NavigateToTaskOverviewCommand = new NavigateCommand(
                navigationService,
                () => new TaskOverviewViewModel(
                   taskService,
                   navigationService,
                   () => new EmployeeHomeViewModel(
                      navigationStore,
                      navigationService,
                      taskService,
                      currentUserStore,
                      employeeRepository,
                      employeeService)));

            NavigateBackCommand = new NavigateCommand(
                _navigationService,
                () => new StartViewModel(
                new UserIdentificationService(_employeeRepository),
                      _currentUserStore,
                      _navigationStore,
                      _taskService,
                      _employeeRepository,
                      _employeeService,
                      _navigationService));
        }
    }
}
