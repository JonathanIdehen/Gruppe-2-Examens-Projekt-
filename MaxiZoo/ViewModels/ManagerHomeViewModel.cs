using MaxiZoo.Commands;
using MaxiZoo.Services;
using MaxiZoo.Stores;
using System.Windows.Input;

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

            NavigateToCreateTaskCommand = new NavigateCommand(
                _navigationStore,
                () => new CreateTaskViewModel(_taskService));
        }
    }
}