using MaxiZoo.Services;
using MaxiZoo. ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

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
       
        public bool CanExecute(object? parameter)
        {
            return _viewModel.SelectedTask != null &&
                   _viewModel.SelectedEmployee != null;
        }

        public void Execute(object? parameter)
        {
            if (_viewModel.SelectedTask == null || _viewModel.SelectedEmployee == null)
            {
                MessageBox.Show("Vælg både en opgave og en medarbejder.");
                return;
            }

                _taskService.AssignTaskToEmployee(
                _viewModel.SelectedTask!,
                _viewModel.SelectedEmployee!); 

            MessageBox.Show("Opgaven er tildelt.");
            _viewModel.RefreshData();
        }

        public event EventHandler? CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
