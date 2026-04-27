using MaxiZoo.Models;
using WorkTask = MaxiZoo.Models.WorkTask;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaxiZoo.Persistence
{
    public class TaskRepository
    {
        private readonly List<WorkTask> _tasks = new ();
        
        public void AddTask(WorkTask task)
        {
            _tasks.Add(task);
        }
        public List<WorkTask> GetAvailableTasks()
        {
            return _tasks.Where(task => task.IsAvailableForAssignment).ToList();
        }
        public void AssignTaskToEmployee(WorkTask task)
        {
          WorkTask? taskToUpdate = _tasks.FirstOrDefault(t => t.TaskID == task.TaskID);
            if (taskToUpdate == null) return;
            taskToUpdate.EmployeeID = task.EmployeeID;
            taskToUpdate.AssignedEmployee = task.AssignedEmployee;
            taskToUpdate.IsAvailableForAssignment = task.IsAvailableForAssignment;
        }

    }
}
