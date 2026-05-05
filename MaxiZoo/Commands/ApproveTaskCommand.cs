using MaxiZoo.Models;
using MaxiZoo.Services;
using MaxiZoo.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace MaxiZoo.Commands
{
    public class ApproveTaskCommand : ICommand
    {
        private readonly ApproveTaskViewModel _viewModel;
        private readonly TaskService _taskService;
        private readonly bool _approve;

        public ApproveTaskCommand(ApproveTaskViewModel viewModel, TaskService taskService, bool approve)
        {
            _viewModel = viewModel;
            _taskService = taskService;
            _approve = approve;
        }

        public bool CanExecute(object? parameter)
        {
            return parameter is WorkTask;
        }

        public void Execute(object? parameter)
        {
            if (parameter is not WorkTask task)
                return;

            if (_approve)
            {
                _taskService.ApproveTask(task);
                MessageBox.Show("Opgaven er godkendt.");
            }
            else
            {
                _taskService.RejectTask(task);
                MessageBox.Show("Opgaven er ikke godkendt.");
            }

            _viewModel.RefreshData();
        }

        public event EventHandler? CanExecuteChanged;
    }
}
