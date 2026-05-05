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

        public void CreateTask
        (
            string title,
            string description,
            DateTime deadline,
            Category category,
            Priority priority,
            bool isOneTime)
        {
            
        WorkTask task = new WorkTask
        {
            Title = title,
            Description = description,
            Deadline = deadline,
            Category = category,
            Priority = priority,
            Status = Status.NotStarted,
            IsOneTime = isOneTime,
            IsAvailableForAssignment = true
        };

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

        public List<WorkTask> GetTasksByEmployee(int employeeId)
        {
            return _taskRepository.GetTasksByEmployee(employeeId);
        }

        public void UpdateTaskStatus(WorkTask task)
        {
            _taskRepository.UpdateTaskStatus(task);
        }

        public List<WorkTask> GetTasksForApproval()
        {
            return _taskRepository.GetTasksForApproval();
        }

        public void ApproveTask(WorkTask task)
        {
            task.Status = Status.Done;
            _taskRepository.UpdateTaskStatus(task);
        }

        public void RejectTask(WorkTask task)
        {
            task.Status = Status.NotApproved;
            _taskRepository.UpdateTaskStatus(task);
        }
    }
}
