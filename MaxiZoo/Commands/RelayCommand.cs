using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
namespace MaxiZoo.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Predicate<object?>? _canExecute;
        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
        // RelayCommand er en implementering af ICommand, som bruges til at binde handlinger i ViewModel til UI-elementer i WPF.
    }
}
