using MaxiZoo.Models; 
using MaxiZoo.Persistence; 
using MaxiZoo.Services;
using MaxiZoo.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace MaxiZoo.Commands
{
    public class CreateTaskCommand : ICommand
    {
        private readonly CreateTaskViewModel _viewModel;
        private readonly TaskService _taskService;

        public CreateTaskCommand(CreateTaskViewModel vm, TaskService taskService)
        {
            _viewModel = vm;
            _taskService = taskService;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true; // du kan senere validere input her
        }

        public void Execute(object? parameter)
        {
            if (string.IsNullOrWhiteSpace(_viewModel.Title))
            {
                MessageBox.Show("Du skal skrive en titel.");
                return;
            }

            if (_viewModel.Deadline == null)
            {
                MessageBox.Show("Du skal vælge en deadline.");
                return;
            }

            _taskService.CreateTask(
     _viewModel.Title,
     _viewModel.Description,
     _viewModel.Deadline.Value,
     _viewModel.SelectedCategory,
     _viewModel.SelectedPriority,
     _viewModel.IsOneTime
 );


            _viewModel.Title = "";
            _viewModel.Description = "";
            _viewModel.Deadline = null;
        }
    }
}