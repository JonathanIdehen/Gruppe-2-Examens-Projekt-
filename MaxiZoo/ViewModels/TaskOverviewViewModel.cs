using MaxiZoo.Commands;
using MaxiZoo.Models;
using MaxiZoo.Persistence;
using MaxiZoo.Services;
using MaxiZoo.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MaxiZoo.ViewModels
{
    public class TaskOverviewViewModel : BaseViewModel
    {
        private readonly TaskService _taskService;

        public List<WorkTask> AllTasks { get; set; }
        public List<WorkTask> FilteredTasks { get; set; }

        public Array Statuses => Enum.GetValues(typeof(Status));
        public Array Categories => Enum.GetValues(typeof(Category));

        private Status? _selectedStatus;
        public Status? SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
                ApplyFilter();
                OnPropertyChanged();
            }
        }

        private Category? _selectedCategory;
        public Category? SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                ApplyFilter();
                OnPropertyChanged();
            }
        }

        public ICommand NavigateBackCommand { get; }

        public TaskOverviewViewModel(
            TaskService taskService,
            NavigationService navigationService,
            Func<BaseViewModel> createBackViewModel)
        {
            _taskService = taskService;

            AllTasks = _taskService.GetAllTasks();
            FilteredTasks = AllTasks;

            NavigateBackCommand = new NavigateCommand(
                navigationService,
                createBackViewModel);
        }

        private void ApplyFilter()
        {
            IEnumerable<WorkTask> tasks = AllTasks;

            if (SelectedStatus != null)
                tasks = tasks.Where(t => t.Status == SelectedStatus);

            if (SelectedCategory != null)
                tasks = tasks.Where(t => t.Category == SelectedCategory);

            FilteredTasks = tasks.ToList();
            OnPropertyChanged(nameof(FilteredTasks));
        }
    }
}