using MaxiZoo.Services;
using MaxiZoo.ViewModels;
using System;
using System.Windows.Input;

namespace MaxiZoo.Commands
{
    public class NavigateCommand : ICommand
    {
        private readonly NavigationService _navigationService;
        private readonly Func<BaseViewModel> _createViewModel;

        public NavigateCommand(NavigationService navigationService, Func<BaseViewModel> createViewModel)
        {
            _navigationService = navigationService;
            _createViewModel = createViewModel;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            _navigationService.NavigateTo(_createViewModel());
        }

        public event EventHandler? CanExecuteChanged;
    }
}