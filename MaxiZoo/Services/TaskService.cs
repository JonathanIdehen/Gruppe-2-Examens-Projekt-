using MaxiZoo.Models;
using MaxiZoo.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
