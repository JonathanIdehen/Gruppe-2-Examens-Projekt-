using MaxiZoo.Models;
using MaxiZoo.Stores;
using Microsoft.Data.SqlClient;

namespace MaxiZoo.Persistence
{
    public class TaskRepository
    {
        private readonly TaskStore _taskStore;
        private readonly string _connectionString =
        "Server=localhost\\SQLEXPRESS;Database=MaxiZoo;Trusted_Connection=True;TrustServerCertificate=true;";
        
        public TaskRepository(TaskStore taskStore)
        {
            _taskStore = taskStore;
        }
        public void AddTask(WorkTask task)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"
            INSERT INTO [Task]
            (Title, Description, Deadline, Category, Priority, Status, IsOneTime, IsAvailableForAssignment)
            VALUES
            (@Title, @Description, @Deadline, @Category, @Priority, @Status, @IsOneTime, @IsAvailableForAssignment)";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Title", task.Title);
            command.Parameters.AddWithValue("@Description", task.Description);
            command.Parameters.AddWithValue("@Deadline", task.Deadline);
            command.Parameters.AddWithValue("@Category", (int)task.Category);
            command.Parameters.AddWithValue("@Priority", (int)task.Priority);
            command.Parameters.AddWithValue("@Status", (int)task.Status);
            command.Parameters.AddWithValue("@IsOneTime", task.IsOneTime);
            command.Parameters.AddWithValue("@IsAvailableForAssignment", task.IsAvailableForAssignment);

            command.ExecuteNonQuery();
        }

        public List<WorkTask> GetAvailableTasks()
        {
            List<WorkTask> tasks = new();

            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"
            SELECT TaskID, Title, Description, Deadline, Category, Priority, Status, IsOneTime, IsAvailableForAssignment
            FROM [Task]
            WHERE IsAvailableForAssignment = 1";

            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                tasks.Add(new WorkTask
                {
                    TaskID = (int)reader["TaskID"],
                    Title = reader["Title"].ToString() ?? "",
                    Description = reader["Description"].ToString() ?? "",
                    Deadline = (DateTime)reader["Deadline"],
                    Category = (Category)(int)reader["Category"],
                    Priority = (Priority)(int)reader["Priority"],
                    Status = (Status)(int)reader["Status"],
                    IsOneTime = (bool)reader["IsOneTime"],
                    IsAvailableForAssignment = (bool)reader["IsAvailableForAssignment"]
                });
            }

            return tasks;
        }

        public void AssignTaskToEmployee(WorkTask task)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"
            UPDATE Task
            SET EmployeeID = @EmployeeID,
            IsAvailableForAssignment = @IsAvailableForAssignment
            WHERE TaskID = @TaskID";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EmployeeID", task.EmployeeID);
            command.Parameters.AddWithValue("@IsAvailableForAssignment", task.IsAvailableForAssignment);
            command.Parameters.AddWithValue("@TaskID", task.TaskID);

            command.ExecuteNonQuery();
        }

        public List<WorkTask> GetTasksByEmployee(int employeeId)
        {
            List<WorkTask> tasks = new List<WorkTask>();

            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"
            SELECT TaskID, Title, Description, Deadline, Category, Priority, Status, IsOneTime, IsAvailableForAssignment, EmployeeID
            FROM [Task]
            WHERE EmployeeID = @EmployeeID";

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EmployeeID", employeeId);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                tasks.Add(new WorkTask
                {
                    TaskID = (int)reader["TaskID"],
                    Title = reader["Title"].ToString() ?? "",
                    Description = reader["Description"].ToString() ?? "",
                    Deadline = (DateTime)reader["Deadline"],
                    Category = (Category)(int)reader["Category"],
                    Priority = (Priority)(int)reader["Priority"],
                    Status = (Status)(int)reader["Status"],
                    IsOneTime = (bool)reader["IsOneTime"],
                    IsAvailableForAssignment = (bool)reader["IsAvailableForAssignment"],
                    EmployeeID = reader["EmployeeID"] as int?
                });
            }

            return tasks;
        }

        public void UpdateTaskStatus(WorkTask task)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = "UPDATE [Task] SET Status = @Status WHERE TaskID = @TaskID";

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Status", (int)task.Status);
            command.Parameters.AddWithValue("@TaskID", task.TaskID);

            command.ExecuteNonQuery();
        }

        public List<WorkTask> GetTasksForApproval()
        {
            List<WorkTask> tasks = new List<WorkTask>();

            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"
            SELECT TaskID, Title, Description, Deadline, Category, Priority, Status, IsOneTime, IsAvailableForAssignment, EmployeeID
            FROM [Task]
            WHERE Status = @Status";

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Status", (int)Status.Completed);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                tasks.Add(new WorkTask
                {
                    TaskID = (int)reader["TaskID"],
                    Title = reader["Title"].ToString() ?? "",
                    Description = reader["Description"].ToString() ?? "",
                    Deadline = (DateTime)reader["Deadline"],
                    Category = (Category)(int)reader["Category"],
                    Priority = (Priority)(int)reader["Priority"],
                    Status = (Status)(int)reader["Status"],
                    IsOneTime = (bool)reader["IsOneTime"],
                    IsAvailableForAssignment = (bool)reader["IsAvailableForAssignment"],
                    EmployeeID = reader["EmployeeID"] as int?
                });
            }

            return tasks;
        }

        public List<WorkTask> GetRejectedTasks()
        {
            List<WorkTask> tasks = new();

            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"
            SELECT TaskID, Title, Description, Deadline, Category, Priority, Status, IsOneTime, IsAvailableForAssignment, EmployeeID
            FROM [Task]
            WHERE Status = @Status";

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Status", (int)Status.NotApproved);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                tasks.Add(new WorkTask
                {
                    TaskID = (int)reader["TaskID"],
                    Title = reader["Title"].ToString() ?? "",
                    Description = reader["Description"].ToString() ?? "",
                    Deadline = (DateTime)reader["Deadline"],
                    Category = (Category)(int)reader["Category"],
                    Priority = (Priority)(int)reader["Priority"],
                    Status = (Status)(int)reader["Status"],
                    IsOneTime = (bool)reader["IsOneTime"],
                    IsAvailableForAssignment = (bool)reader["IsAvailableForAssignment"],
                    EmployeeID = reader["EmployeeID"] == DBNull.Value ? null : (int?)reader["EmployeeID"]
                });
            }

            return tasks;
        }

        public void RestoreTask(WorkTask task)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"
            UPDATE [Task]
            SET Status = @Status,
            EmployeeID = NULL,
            IsAvailableForAssignment = 1
            WHERE TaskID = @TaskID";

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Status", (int)Status.NotStarted);
            command.Parameters.AddWithValue("@TaskID", task.TaskID);

            command.ExecuteNonQuery();
        }

        public List<WorkTask> GetAllTasks()
        {
            List<WorkTask> tasks = new();

            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"
            SELECT TaskID, Title, Description, Deadline, Category, Priority, Status,
            IsOneTime, IsAvailableForAssignment, EmployeeID
            FROM [Task]";

            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                tasks.Add(new WorkTask
                {
                    TaskID = (int)reader["TaskID"],
                    Title = reader["Title"].ToString() ?? "",
                    Description = reader["Description"].ToString() ?? "",
                    Deadline = (DateTime)reader["Deadline"],
                    Category = (Category)(int)reader["Category"],
                    Priority = (Priority)(int)reader["Priority"],
                    Status = (Status)(int)reader["Status"],
                    IsOneTime = (bool)reader["IsOneTime"],
                    IsAvailableForAssignment = (bool)reader["IsAvailableForAssignment"],
                    EmployeeID = reader["EmployeeID"] as int?
                });
            }

            return tasks;
        }
    }
}
