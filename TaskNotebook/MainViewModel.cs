using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace TaskNotebook
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TaskModel> Tasks { get; set; }
        public ICommand AddTaskCommand { get; set; }
        public ICommand DeleteTaskCommand { get; set; }

        private string? _taskInput;
        public string? TaskInput
        {
            get { return _taskInput; }
            set
            {
                _taskInput = value;
                OnPropertyChanged(nameof(TaskInput));
            }
        }

        private TaskModel? _selectedTask;
        public TaskModel? SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
                RaiseCanExecuteChanged(); // Обновляем состояние команды при изменении выбора
            }
        }

        public MainViewModel()
        {
            Tasks = new ObservableCollection<TaskModel>();
            AddTaskCommand = new RelayCommand(AddTask);
            DeleteTaskCommand = new RelayCommand(DeleteTask, CanDeleteTask);
        }

        private void AddTask()
        {
            if (!string.IsNullOrWhiteSpace(TaskInput))
            {
                Tasks.Add(new TaskModel(TaskInput));
                TaskInput = string.Empty; // Очищаем поле ввода
            }
            else
            {
                MessageBox.Show("Введите задачу перед добавлением.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteTask()
        {
            if (SelectedTask != null)
            {
                Tasks.Remove(SelectedTask);
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private bool CanDeleteTask()
        {
            return SelectedTask != null; // Проверяем, есть ли выбранная задача для удаления
        }

        public void RaiseCanExecuteChanged()
        {
            (DeleteTaskCommand as RelayCommand)?.RaiseCanExecuteChanged();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
