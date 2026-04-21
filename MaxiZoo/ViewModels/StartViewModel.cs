using MaxiZoo.Commands;
using MaxiZoo.Services;
using MaxiZoo.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

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
            NavigationStore navigationStore)
        {
            IdentifyUserCommand = new IdentifyUserCommand(
                this,
                userIdentificationService,
                currentUserStore,
                navigationStore);
        }
    }
}
