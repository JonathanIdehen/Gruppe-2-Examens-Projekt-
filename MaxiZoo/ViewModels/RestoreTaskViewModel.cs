using MaxiZoo.Commands;
using MaxiZoo.Models;
using MaxiZoo.Persistence;
using MaxiZoo.Services;
using MaxiZoo.Stores;
using System.Collections.Generic;
using System.Windows.Input;

namespace MaxiZoo.ViewModels
{
    public class RestoreTaskViewModel : BaseViewModel
    {
        private readonly TaskService _taskService;

        private List<WorkTask> _rejectedTasks = new();
        public List<WorkTask> RejectedTasks
        {
            get => _rejectedTasks;
            set
            {
                _rejectedTasks = value;
                OnPropertyChanged();
            }
        }

        public ICommand RestoreTaskCommand { get; }
        public ICommand NavigateBackCommand { get; }

        public RestoreTaskViewModel(
            TaskService taskService,
            NavigationService navigationService,
            NavigationStore navigationStore,
            EmployeeRepository employeeRepository,
            EmployeeService employeeService)
        {
            _taskService = taskService;
            RestoreTaskCommand = new RestoreTaskCommand(this, _taskService);

            NavigateBackCommand = new NavigateCommand(
                navigationService,
                () => new ManagerHomeViewModel(
                    navigationStore,
                    navigationService,
                    taskService,
                    employeeRepository,
                    employeeService));

            RefreshData();
        }

        public void RefreshData()
        {
            RejectedTasks = _taskService.GetRejectedTasks();
        }
    }
}
