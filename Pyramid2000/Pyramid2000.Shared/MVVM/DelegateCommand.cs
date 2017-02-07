using System;
using System.Windows.Input;

namespace Pyramid2000.MVVM
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action execute, Func<bool> canExecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            _execute = execute;
            _canExecute = canExecute ?? (() => true);
        }

        public bool CanExecute(object p)
        {
            try
            {
                return _canExecute();
            }
            catch
            {
                return false;
            }
        }

        public void Execute(object p)
        {
            if (!CanExecute(p))
            {
                return;
            }
            _execute();            
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;
        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            _execute = execute;
            _canExecute = canExecute ?? (e => true);
        }

        public bool CanExecute(object p)
        {
            try
            {
                var v = (T)Convert.ChangeType(p, typeof(T));
                return _canExecute == null || _canExecute(v);
            }
            catch
            {
                return false;
            }
        }

        public void Execute(object p)
        {
            if (!CanExecute(p))
            {
                return;
            }
            var v = (T)Convert.ChangeType(p, typeof(T));
            _execute(v);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
