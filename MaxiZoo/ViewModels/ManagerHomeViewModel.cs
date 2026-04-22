using System.Windows.Input;
using MaxiZoo.Commands;
using MaxiZoo.Services;
using MaxiZoo.Stores;

namespace MaxiZoo.ViewModels
{
    public class ManagerHomeViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly TaskService _taskService;

        public ICommand NavigateToCreateTaskCommand { get; }

        public ManagerHomeViewModel(NavigationStore navigationStore, TaskService taskService)
        {
            _navigationStore = navigationStore;
            _taskService = taskService;

            NavigateToCreateTaskCommand = new RelayCommand(
                _ => _navigationStore.CurrentViewModel = new CreateTaskViewModel(_taskService));
        }
    }
}
