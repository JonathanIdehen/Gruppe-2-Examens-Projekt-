using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MaxiZoo.Services;
using MaxiZoo. ViewModels;

namespace MaxiZoo.Commands
{
    public class AssignTaskCommand : ICommand 
    {
        private readonly AssignTaskViewModel _viewModel; // Reference to the ViewModel to access selected tasks and employee
        private readonly TaskService _taskService; // Reference to the TaskService to perform the assignment

        public AssignTaskCommand(AssignTaskViewModel viewModel, TaskService taskService) 
        {
            _viewModel = viewModel;
            _taskService = taskService;
        }
        
        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter)
            {
            return _viewModel.SelectedTasks != null && _viewModel.SelectedEmployee != null;
        }
        public void Execute(object? parameter)
        {
            if (_viewModel.SelectedTasks == null || _viewModel.SelectedEmployee == null)
            {
                _taskService.AssignTaskToEmployee(_viewModel.SelectedTasks, _viewModel.SelectedEmployee);
            }
        }
    }
}
