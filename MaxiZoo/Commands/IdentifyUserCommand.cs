using MaxiZoo.Models;
using MaxiZoo.Services;
using MaxiZoo.Stores;
using MaxiZoo.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
namespace MaxiZoo.Commands
{
    public class IdentifyUserCommand : CommandBase
    {
        private readonly StartViewModel _startViewModel;
        private readonly UserIdentificationService _userIdentificationService;
        private readonly CurrentUserStore _currentUserStore;
        private readonly NavigationStore _navigationStore;
        public IdentifyUserCommand(
            StartViewModel startViewModel,
            UserIdentificationService userIdentificationService,
            CurrentUserStore currentUserStore,
            NavigationStore navigationStore)
        {
            _startViewModel = startViewModel;
            _userIdentificationService = userIdentificationService;
            _currentUserStore = currentUserStore;
            _navigationStore = navigationStore;
        }
        public override void Execute(object? parameter)
        {
            if (!int.TryParse(_startViewModel.EmployeeIdInput, out int employeeId))
                return;
            Employee? employee = _userIdentificationService.IdentifyUser(employeeId);
            if (employee == null)
                return;
            _currentUserStore.CurrentUser = employee;
            if (employee.Role == Role.Manager)
            {
                _navigationStore.CurrentViewModel = new ManagerHomeViewModel();
            }
            else
            {
                _navigationStore.CurrentViewModel = new EmployeeHomeViewModel();
            }
        }
    }
}
