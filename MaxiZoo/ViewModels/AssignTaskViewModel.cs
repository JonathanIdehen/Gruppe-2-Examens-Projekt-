using MaxiZoo.Services;
using System;
using MaxiZoo.Persistence;
using System.Collections.Generic;
using System.Text;
using MaxiZoo.Models;
using System.Windows.Input;
using MaxiZoo.Commands;
using MaxiZoo.Stores;

namespace MaxiZoo.ViewModels
{
    public class AssignTaskViewModel : BaseViewModel
    {
        private readonly TaskService _taskService; 
        private readonly EmployeeRepository _employeeRepository; 

        public List <WorkTask> AvailableTasks { get; }
        public List<Employee> Employees { get; }
        
        public WorkTask? SelectedTasks { get; set; }
        public Employee? SelectedEmployee { get; set; }

        public ICommand AssignTaskCommand { get; }
        public AssignTaskViewModel(TaskService taskService, EmployeeRepository employeeRepository)
        {
            _taskService = taskService;
            _employeeRepository = employeeRepository;
            AvailableTasks = _taskService.GetAvailableTasks();
            Employees = _employeeRepository.GetAllEmployees();
            AssignTaskCommand = new AssignTaskCommand(this, _taskService);
        }
    }
}
