using MaxiZoo.Stores;
using MaxiZoo.ViewModels;
using System;
using System.Windows.Input;

namespace MaxiZoo.Commands
{
    public class NavigateCommand : ICommand
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<BaseViewModel> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<BaseViewModel> createViewModel) 
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}