using MaxiZoo.Commands;
using MaxiZoo.Services;
using MaxiZoo.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MaxiZoo.Persistence;
using MaxiZoo.Models;

namespace MaxiZoo.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        private string _employeeIdInput = "";

        public string EmployeeIdInput
        {
            get => _employeeIdInput;
            set
            {
                _employeeIdInput = value;
                OnPropertyChanged();
            }
        }

        public ICommand IdentifyUserCommand { get; }

        public StartViewModel(
    UserIdentificationService userIdentificationService,
    CurrentUserStore currentUserStore,
    NavigationStore navigationStore,
    TaskService taskService,
    EmployeeRepository employeeRepository)
        {
            IdentifyUserCommand = new IdentifyUserCommand(
                this,
                userIdentificationService,
                currentUserStore,
                navigationStore,
                taskService,
                employeeRepository);
        }
    }
}
