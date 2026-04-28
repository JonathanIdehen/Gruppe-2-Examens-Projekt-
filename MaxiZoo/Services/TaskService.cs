using MaxiZoo.Models;
using MaxiZoo.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using MaxiZoo.Commands;
using MaxiZoo.ViewModels;


namespace MaxiZoo.Services
{
    public class TaskService
    {
        private readonly TaskRepository _taskRepository;

        public TaskService(TaskRepository taskRepository) 
        {
            _taskRepository = taskRepository;
        }

        public void CreateTask(WorkTask task)
        {
            _taskRepository.AddTask(task);
        }

        public List<WorkTask> GetAvailableTasks() {
            return _taskRepository.GetAvailableTasks();
        }

        public void AssignTaskToEmployee(WorkTask task, Employee employee)
        { 
            task.AssignedEmployee = employee;
            task.EmployeeID = employee.EmployeeID;
            if (task.IsOneTime)
            {
                task.IsAvailableForAssignment = false;
            }
            _taskRepository.AssignTaskToEmployee(task);
        }
        
        public List<WorkTask> GetAllTasks()
        {
            return _taskRepository.GetAvailableTasks();
        }
    }
}
