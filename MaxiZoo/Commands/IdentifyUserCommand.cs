using MaxiZoo.Models;
using MaxiZoo.Persistence;
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
        private readonly TaskService _taskService;


        public IdentifyUserCommand(
           StartViewModel startViewModel,
           UserIdentificationService userIdentificationService,
           CurrentUserStore currentUserStore,
           NavigationStore navigationStore,
           TaskService taskService)
        {
            _startViewModel = startViewModel;
            _userIdentificationService = userIdentificationService;
            _currentUserStore = currentUserStore;
            _navigationStore = navigationStore;
            _taskService = taskService;
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
                _navigationStore.CurrentViewModel =
                    new ManagerHomeViewModel(_navigationStore, _taskService);
            }
            else
            {
                _navigationStore.CurrentViewModel = new EmployeeHomeViewModel();
            }
        }
    }
}
