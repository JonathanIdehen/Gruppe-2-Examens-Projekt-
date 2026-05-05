using MaxiZoo.Commands;
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

        public EmployeeHomeViewModel(
            NavigationStore navigationStore,
            TaskService taskService,
            CurrentUserStore currentUserStore)
        {
            _navigationStore = navigationStore;
            _taskService = taskService;
            _currentUserStore = currentUserStore;

            NavigateToMyTasksCommand = new NavigateCommand(
                _navigationStore,
                () => new MyTasksViewModel(_taskService, _currentUserStore));
        }
    }
}
