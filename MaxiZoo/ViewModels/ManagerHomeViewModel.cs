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
        private readonly EmployeeService _employeeService;



        public ICommand NavigateToCreateTaskCommand { get; }
        public ICommand NavigateToAssignTaskCommand { get; }
        public ICommand NavigateToCreateEmployeeCommand { get; }
        public ICommand NavigateToApproveTaskCommand { get; }

        public ManagerHomeViewModel(NavigationStore navigationStore, TaskService taskService, 
            EmployeeRepository employeeRepository, EmployeeService employeeService)
        {
            _navigationStore = navigationStore;
            _taskService = taskService;
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;

            NavigateToCreateTaskCommand = new NavigateCommand(
                _navigationStore,
                () => new CreateTaskViewModel(_taskService));

            NavigateToAssignTaskCommand = new NavigateCommand(
                _navigationStore,
                () =>
                {
                    var vm = new AssignTaskViewModel(_taskService, _employeeRepository);
                    vm.RefreshData(); 
                    return vm;
                });

            NavigateToCreateEmployeeCommand = new NavigateCommand(
               _navigationStore,
               () => new CreateEmployeeViewModel(_employeeService, _navigationStore, _taskService, 
               _employeeRepository));
            
            NavigateToApproveTaskCommand = new NavigateCommand(
               _navigationStore,
               () => new ApproveTaskViewModel(_taskService));
        }

    }
}