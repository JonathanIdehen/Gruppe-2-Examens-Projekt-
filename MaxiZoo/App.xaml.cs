using System.Windows;
using MaxiZoo.Persistence;
using MaxiZoo.Services;
using MaxiZoo.Stores;
using MaxiZoo.ViewModels;
using MaxiZoo.Views;

namespace MaxiZoo
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            TaskRepository taskRepository = new TaskRepository();
            TaskService taskService = new TaskService(taskRepository);
            CurrentUserStore currentUserStore = new CurrentUserStore();
            NavigationStore navigationStore = new NavigationStore();

            UserIdentificationService userIdentificationService =
                new UserIdentificationService(employeeRepository);

            navigationStore.CurrentViewModel =
    new StartViewModel(
        userIdentificationService,
        currentUserStore,
        navigationStore,
        taskService,
        employeeRepository);

            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(navigationStore);
            MainWindow mainWindow = new MainWindow
            {
                DataContext = mainWindowViewModel
            };

            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
