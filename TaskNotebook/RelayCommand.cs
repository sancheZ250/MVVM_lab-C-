using System;
using System.Windows.Input;

namespace TaskNotebook
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute; // Добавлено ? для допуска значений null

        public event EventHandler? CanExecuteChanged; // Добавлено ? для допуска значений null

        public RelayCommand(Action execute, Func<bool>? canExecute = null) // Добавлено ? для допуска значений null
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) // Добавлено ? для допуска значений null
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object? parameter) // Добавлено ? для допуска значений null
        {
            _execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
