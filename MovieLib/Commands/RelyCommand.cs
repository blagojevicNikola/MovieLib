using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieLib
{
    public class RelyCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private Action action;
        private Func<bool>? canExecuteAction;

        public RelyCommand(Action action)
        {
            this.action = action;
        }

        public RelyCommand(Action action1, Func<bool> action2)
        {
            action = action1;
            canExecuteAction = action2;
        }

        public bool CanExecute(object? parameter)
        {
            if(canExecuteAction != null) {
                return canExecuteAction.Invoke();
            }
            return true;
        }

        public void Execute(object? parameter)
        {
            action();
        }
    }
}
