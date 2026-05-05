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
        private readonly TaskService _taskService;
        private readonly CurrentUserStore _currentUserStore;

        public ICommand NavigateToMyTasksCommand { get; }
        public ICommand NavigateToTaskOverviewCommand { get; }

        public EmployeeHomeViewModel(
            NavigationStore navigationStore,
            NavigationService navigationService,
            TaskService taskService,
            CurrentUserStore currentUserStore,
            EmployeeRepository employeeRepository,
            EmployeeService employeeService)
        {
            _navigationStore = navigationStore;
            _taskService = taskService;
            _currentUserStore = currentUserStore;


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
        }
    }
}
