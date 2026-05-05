using MaxiZoo.Commands;
using MaxiZoo.Models;
using MaxiZoo.Persistence;
using MaxiZoo.Services;
using MaxiZoo.Stores;
using System.Collections.Generic;
using System.Windows.Input;

namespace MaxiZoo.ViewModels
{
    public class ApproveTaskViewModel : BaseViewModel
    {
        private readonly TaskService _taskService;

        public List<WorkTask> TasksForApproval { get; set; }

        public ICommand ApproveTaskCommand { get; }
        public ICommand RejectTaskCommand { get; }
        public ICommand NavigateBackCommand { get; }


        public ApproveTaskViewModel(
            TaskService taskService,
            NavigationService navigationService,
            NavigationStore navigationStore,
            EmployeeRepository employeeRepository,
            EmployeeService employeeService)
        {
            _taskService = taskService;

            TasksForApproval = _taskService.GetTasksForApproval();

            ApproveTaskCommand = new ApproveTaskCommand(this, _taskService, true);
            RejectTaskCommand = new ApproveTaskCommand(this, _taskService, false);

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
            TasksForApproval = _taskService.GetTasksForApproval();
            OnPropertyChanged(nameof(TasksForApproval));
        }
    }
}
