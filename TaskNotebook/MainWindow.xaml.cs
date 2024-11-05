using System.Windows;

namespace TaskNotebook
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(); // Устанавливаем DataContext
        }

        private void TaskList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Обновляем состояние команды DeleteTaskCommand
            if (DataContext is MainViewModel viewModel)
            {
                viewModel.RaiseCanExecuteChanged();
            }
        }
    }
}
