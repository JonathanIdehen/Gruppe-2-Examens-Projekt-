using MaxiZoo.Models;
using MaxiZoo.Services;
using MaxiZoo.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace MaxiZoo.Commands
{
    public class RestoreTaskCommand : ICommand
    {
        private readonly RestoreTaskViewModel _viewModel;
        private readonly TaskService _taskService;

        public RestoreTaskCommand(RestoreTaskViewModel viewModel, TaskService taskService)
        {
            _viewModel = viewModel;
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

            _taskService.RestoreTask(task);
            MessageBox.Show("Opgaven er gendannet.");

            _viewModel.RefreshData();
        }

        public event EventHandler? CanExecuteChanged;
    }
}
