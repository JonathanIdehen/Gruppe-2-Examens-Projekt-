using MaxiZoo.Commands;
using MaxiZoo.Models;
using MaxiZoo.Persistence;
using MaxiZoo.Services;
using MaxiZoo.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MaxiZoo.ViewModels
{
    public class AssignTaskViewModel : BaseViewModel
    {
        private readonly TaskService _taskService; 
        private readonly EmployeeRepository _employeeRepository;

        public List<WorkTask> AvailableTasks { get; set; }
        public List<Employee> Employees { get; set; }

        private WorkTask? _selectedTask;
        public WorkTask? SelectedTask
        {
            get => _selectedTask;
            set
            {
                _selectedTask = value;
                OnPropertyChanged();
                AssignTaskCommand.RaiseCanExecuteChanged();
            }
        }

        private Employee? _selectedEmployee;
        public Employee? SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
                AssignTaskCommand.RaiseCanExecuteChanged();
            }
        }
        public void RefreshTasks()
        {
            AvailableTasks = _taskService.GetAvailableTasks();
            OnPropertyChanged(nameof(AvailableTasks));
        }
        
        public void RefreshData()
        {
            AvailableTasks = _taskService.GetAvailableTasks();
            Employees = _employeeRepository.GetAllEmployees();

            OnPropertyChanged(nameof(AvailableTasks));
            OnPropertyChanged(nameof(Employees));

            SelectedTask = null;
            SelectedEmployee = null;
        }


        public AssignTaskCommand AssignTaskCommand { get; }
        public AssignTaskViewModel(TaskService taskService, EmployeeRepository employeeRepository) 
        {
            _taskService = taskService;
            _employeeRepository = employeeRepository;
            AvailableTasks = _taskService.GetAvailableTasks();
            Employees = _employeeRepository.GetAllEmployees();
            MessageBox.Show("Opgaver i AssignTaskViewModel: " + AvailableTasks.Count);

            AssignTaskCommand = new AssignTaskCommand(this, _taskService);
        }
       
        
    }
}
