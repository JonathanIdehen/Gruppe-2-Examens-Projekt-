using MaxiZoo.Services;
using MaxiZoo.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MaxiZoo.Commands
{
    public class CreateEmployeeCommand : ICommand
    {
        private readonly CreateEmployeeViewModel _viewModel;
        private readonly EmployeeService _employeeService;

        public CreateEmployeeCommand(CreateEmployeeViewModel viewModel, EmployeeService employeeService)
        {
            _viewModel = viewModel;
            _employeeService = employeeService;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (string.IsNullOrWhiteSpace(_viewModel.FirstName) || string.IsNullOrWhiteSpace(_viewModel.LastName))
            {
                MessageBox.Show("Du skal skrive et navn.");
                return;
            }

            if (!int.TryParse(_viewModel.EmployeeIdInput, out int employeeId))
            {
                MessageBox.Show("Bruger ID skal være et tal.");
                return;
            }

            string fullName = _viewModel.FirstName + " " + _viewModel.LastName;

            _employeeService.CreateEmployee(
                fullName,
                employeeId,
                _viewModel.SelectedRole);

            MessageBox.Show("Medarbejderen er oprettet.");

            _viewModel.FirstName = "";
            _viewModel.LastName = "";
            _viewModel.EmployeeIdInput = "";
        }
    }
}
