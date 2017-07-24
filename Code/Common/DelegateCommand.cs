using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Common
{
    public class DelegateCommand<T> : DelegateCommandBase
    {
        public DelegateCommand(Action<T> executeMethod)
            : this(executeMethod, (o) => true)
        {
        }

        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
            : base((o) => executeMethod((T)o), (o) => canExecuteMethod((T)o))
        {

        }

        public void Execute(T parameter)
        {
            base.Execute(parameter);
        }

        public bool CanExecute(T parameter)
        {
            return base.CanExecute(parameter);
        }
    }

    public class DelegateCommand : DelegateCommandBase
    {
        public DelegateCommand(Action action)
            : base((o) => { action(); }, (o) => true)
        {
        }

        public void Execute(object parameter)
        {
            base.Execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }
    }

    public abstract class DelegateCommandBase : ICommand
    {
        private readonly Action<object> executeMethod;
        private readonly Func<object, bool> canExecuteMethod;

        protected DelegateCommandBase(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute(parameter);
        }

        void ICommand.Execute(object parameter)
        {
            Execute(parameter);
        }

        protected void Execute(object parameter)
        {
            executeMethod(parameter);
        }

        protected bool CanExecute(object parameter)
        {
            return canExecuteMethod(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
}
