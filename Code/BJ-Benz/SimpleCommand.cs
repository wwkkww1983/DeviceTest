using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BJ_Benz
{
    class SimpleCommand : ICommand
    {
        private Action<string> execute;
        public SimpleCommand(Action<string> execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
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

        public void Execute(object parameter)
        {
            if(execute != null)
            {
                execute(parameter.ToString());
            }
        }
    }
}
