using MaxiZoo.Models;
using MaxiZoo.Services;
using System;
using System.Windows;
using System.Windows.Input;

namespace MaxiZoo.Commands
{
    public class UpdateTaskStatusCommand : ICommand
    {
        private readonly TaskService _taskService;

        public UpdateTaskStatusCommand(TaskService taskService)
        {
            _taskService = taskService;
        }

        public bool CanExecute(object? parameter)
        {
            return parameter is WorkTask;
        }

        public void Execute(object? parameter)
        {
            if (parameter is not WorkTask task)
                return;

            _taskService.UpdateTaskStatus(task);

            MessageBox.Show("Status er opdateret.");
        }

        public event EventHandler? CanExecuteChanged;
    }
}
