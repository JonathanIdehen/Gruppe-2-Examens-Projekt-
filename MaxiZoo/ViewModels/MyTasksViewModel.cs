using MaxiZoo.Commands;
using MaxiZoo.Models;
using MaxiZoo.Services;
using MaxiZoo.Stores;
using System.Collections.Generic;
using System.Windows.Input;
using System;
using System.Linq;

namespace MaxiZoo.ViewModels
{
    public class MyTasksViewModel : BaseViewModel
    {
        private readonly TaskService _taskService;
        private readonly CurrentUserStore _currentUserStore;

        public List<WorkTask> MyTasks { get; set; }

        public List<Status> Statuses { get; } =
            Enum.GetValues(typeof(Status)).Cast<Status>().ToList();

        public ICommand UpdateTaskStatusCommand { get; }
        public ICommand NavigateBackCommand { get; }

        public MyTasksViewModel(
            TaskService taskService, 
            CurrentUserStore currentUserStore,
            NavigationService navigationService,
            NavigationStore navigationStore)
        {
            _taskService = taskService;
            _currentUserStore = currentUserStore;

            MyTasks = _taskService.GetTasksByEmployee(
                _currentUserStore.CurrentUser.EmployeeID);

            NavigateBackCommand = new NavigateCommand(
       navigationService,
       () => new EmployeeHomeViewModel(
           navigationStore,
           navigationService,
           taskService,
           currentUserStore));

            UpdateTaskStatusCommand = new UpdateTaskStatusCommand(_taskService);
        }
    }
}
