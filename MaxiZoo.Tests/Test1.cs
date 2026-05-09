using MaxiZoo.Models;
using MaxiZoo.Persistence;
using MaxiZoo.Services;
using MaxiZoo.Stores;

namespace MaxiZoo.Tests
{
    [TestClass]
    public class TaskServiceTests
    {
        private TaskService _taskService;

        [TestInitialize]
        public void TestInitialize()
        {
            TaskStore taskStore = new TaskStore();
            TaskRepository taskRepository = new TaskRepository(taskStore);

            _taskService = new TaskService(taskRepository);
        }

        [TestMethod]
        public void TestCreateTaskCheckCount()
        {
            // Arrange
            int before = _taskService.GetAllTasks().Count;

            WorkTask task = new WorkTask
            {
                Title = "Vask gulv",
                Description = "Vask gulvet og skrub kanter",
                IsOneTime = true
            };

            // Act
            _taskService.CreateTask(
            task.Title,
            task.Description,
            DateTime.Now,
            Category.Cleaning,
            Priority.Mellem,
            task.IsOneTime);

            int after = _taskService.GetAllTasks().Count;

            // Assert
            Assert.IsTrue(after > before);
        }

        [TestMethod]
        public void TestCreateTaskCheckTitle()
        {
            // Arrange
            WorkTask task = new WorkTask
            {
                Title = "Bestil kattemad",
                Description = "Bestil kattemad hjem, og bestil lidt ekstra Whiskas",
                IsOneTime = true
            };

            // Act
            _taskService.CreateTask(
             task.Title,
             task.Description,
             DateTime.Now,
             Category.Cleaning,
             Priority.Mellem,
             task.IsOneTime);

            WorkTask lastTask =
                _taskService.GetAllTasks().Last();

            // Assert
            Assert.AreEqual("Bestil kattemad", lastTask.Title);
        }
    }
}
