using MaxiZoo.Services;
using MaxiZoo.ViewModels;
using System;
using System.Windows.Input;

namespace MaxiZoo.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigationService;
        private readonly Func<BaseViewModel> _createViewModel;

        public NavigateCommand(NavigationService navigationService, Func<BaseViewModel> createViewModel)
        {
            _navigationService = navigationService;
            _createViewModel = createViewModel;
        }

        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            _navigationService.NavigateTo(_createViewModel());
        }

       
    }
}