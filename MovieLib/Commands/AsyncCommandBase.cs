using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieLib
{
    public abstract class AsyncCommandBase : ICommand
    {
        private readonly Action<Exception> _onException;
        private bool _isExecuting;
        public event EventHandler? CanExecuteChanged;

        public bool IsExecuting { get { return _isExecuting; } set { _isExecuting = value; CanExecuteChanged?.Invoke(this, new EventArgs()); } }
        public bool CanExecute(object? parameter)
        {
            return !IsExecuting;
        }

        public AsyncCommandBase(Action<Exception> onException)
        {
            _onException = onException;
        }

        public async void Execute(object? parameter)
        {
            IsExecuting = true;
            try
            {
                await ExecuteAsync(parameter);
            }
            catch(Exception ex)
            {
                _onException.Invoke(ex);
            }
            IsExecuting = false;
        }

        abstract protected Task ExecuteAsync(object? parameter);
    }
}
