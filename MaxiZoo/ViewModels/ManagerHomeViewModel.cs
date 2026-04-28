using MaxiZoo.Commands;
using MaxiZoo.Persistence;
using MaxiZoo.Services;
using MaxiZoo.Stores;
using System.Windows.Input;

namespace MaxiZoo.ViewModels
{
    public class ManagerHomeViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly TaskService _taskService;
        private readonly EmployeeRepository _employeeRepository;

        public ICommand NavigateToCreateTaskCommand { get; }
        public ICommand NavigateToAssignTaskCommand { get; }

        public ManagerHomeViewModel(NavigationStore navigationStore, TaskService taskService, EmployeeRepository employeeRepository)
        {
            _navigationStore = navigationStore;
            _taskService = taskService;
            _employeeRepository = employeeRepository;

            NavigateToCreateTaskCommand = new NavigateCommand(
                _navigationStore,
                () => new CreateTaskViewModel(_taskService));
            NavigateToAssignTaskCommand = new NavigateCommand(
                _navigationStore,
                () =>
                {
                    var vm = new AssignTaskViewModel(_taskService, _employeeRepository);
                    vm.RefreshTasks(); 
                    return vm;
                });
        }
    }
}