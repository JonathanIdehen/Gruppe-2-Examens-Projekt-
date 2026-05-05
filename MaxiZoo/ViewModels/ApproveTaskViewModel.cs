using MaxiZoo.Commands;
using MaxiZoo.Models;
using MaxiZoo.Services;
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

        public ApproveTaskViewModel(TaskService taskService)
        {
            _taskService = taskService;

            TasksForApproval = _taskService.GetTasksForApproval();

            ApproveTaskCommand = new ApproveTaskCommand(this, _taskService, true);
            RejectTaskCommand = new ApproveTaskCommand(this, _taskService, false);
        }

        public void RefreshData()
        {
            TasksForApproval = _taskService.GetTasksForApproval();
            OnPropertyChanged(nameof(TasksForApproval));
        }
    }
}
