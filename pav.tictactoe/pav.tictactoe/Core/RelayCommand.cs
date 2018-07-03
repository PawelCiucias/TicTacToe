using System;
using System.Windows.Input;

namespace pav.tictactoe.Core
{
    class RelayCommand : ICommand
    {
        Func<object, bool> canExecute;
        Action<object> execute;


        public RelayCommand(Action<object> execute) => this.execute = execute;
        public RelayCommand(Action execute) : this(x => execute.Invoke()) { }


        #region ICommand Implementation

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter = null)
        {
            if (canExecute == null)
                return true;
            return canExecute(parameter);
        }

        public void Execute(object parameter = null)
        {
            if (execute != null)
                execute.Invoke(parameter);
        }
        #endregion
    }
}
