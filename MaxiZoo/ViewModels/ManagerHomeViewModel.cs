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
        private readonly NavigationService _navigationService;

        public ICommand NavigateToCreateTaskCommand { get; }
        public ICommand NavigateToAssignTaskCommand { get; }
        public ICommand NavigateToCreateEmployeeCommand { get; }
        public ICommand NavigateToApproveTaskCommand { get; }
        public ICommand NavigateToRestoreTaskCommand { get; }

        public ManagerHomeViewModel(
            NavigationStore navigationStore,
            NavigationService navigationService,
            TaskService taskService, 
            EmployeeRepository employeeRepository, 
            EmployeeService employeeService)
        {
            _navigationStore = navigationStore;
            _navigationService = navigationService;
            _taskService = taskService;
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;

            NavigateToCreateTaskCommand = new NavigateCommand(
                _navigationService,
                () => new CreateTaskViewModel(
                    _navigationService,
                    _taskService,
                    _navigationStore,
                    _employeeRepository,
                    _employeeService));

            NavigateToAssignTaskCommand = new NavigateCommand(
                   _navigationService,
                   () =>
                   {
                      var vm = new AssignTaskViewModel(
                          _taskService,
                          _employeeRepository,
                          _navigationService,
                          _navigationStore,
                          _employeeService);

        vm.RefreshData();
        return vm;
    });

            NavigateToCreateEmployeeCommand = new NavigateCommand(
               _navigationService,
               () => new CreateEmployeeViewModel(
                   _employeeService, 
                   _navigationService,
                   _navigationStore,                 
                   _taskService, 
                   _employeeRepository));
            
            NavigateToApproveTaskCommand = new NavigateCommand(
               _navigationService,
               () => new ApproveTaskViewModel(
                   _taskService,
                   _navigationService,
                   _navigationStore,
                   _employeeRepository,
                   _employeeService));

            NavigateToRestoreTaskCommand = new NavigateCommand(
               _navigationService,
               () => new RestoreTaskViewModel(
                   _taskService,
                   _navigationService,
                   _navigationStore,
                   _employeeRepository,
                   _employeeService));
        }

    }
}