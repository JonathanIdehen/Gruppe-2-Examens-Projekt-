using MaxiZoo.Models; 
using MaxiZoo.Persistence; 
using MaxiZoo.ViewModels;
using System;
using System.Windows.Input;
using MaxiZoo.Services;

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
            if (_viewModel.Deadline == null)
                return;

            WorkTask task = new WorkTask
            {
                Title = _viewModel.Title,
                Description = _viewModel.Description,
                Deadline = _viewModel.Deadline.Value,
                Category = _viewModel.SelectedCategory,
                Priority = _viewModel.SelectedPriority,
                Status = Status.NotStarted,
                IsOneTime = _viewModel.IsOneTime,
                IsAvailableForAssignment = true // skal ligge is service
            };

            _taskService.CreateTask(task);

            _viewModel.Title = "";
            _viewModel.Description = "";
            _viewModel.Deadline = null;
        }
    }
}