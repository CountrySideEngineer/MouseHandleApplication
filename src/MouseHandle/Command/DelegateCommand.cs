using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HandleApplication.Command
{
    /// <summary>
    /// Command class to notice command from View to ViewModel class.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        #region Private fields and constants
        private readonly Action execute;
        private readonly Action<object> executeObj;
        private readonly Func<bool> canExecute;
        #endregion
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute
        /// in its current state.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data
        /// to be passed, this object can be set to null.
        /// </param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (this.execute != null)
            {
                this.execute();
            }
            else
            {
                this.executeObj(parameter);
            }
        }

        #region Constructors and the Finalizer
        public DelegateCommand(Action<object> executeObj, Func<bool> canExecute)
        {
            if (executeObj == null)
            {
                throw new ArgumentNullException("executeObj");
            }
            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }
            this.executeObj = executeObj;
            this.canExecute = canExecute;
        }
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("executeObj");
            }
            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }
            this.execute = execute;
            this.canExecute = canExecute;
        }
        #endregion
    }

    public class DelegateCommand<T> : ICommand
    {
        #region Private fields and constants
        private readonly Action<T> execute;
        private readonly Func<bool> canExecute;
        #endregion
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute
        /// in its current state.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data
        /// to be passed, this object can be set to null.
        /// </param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            this.execute((T)parameter);
        }

        #region Constructors and the Finalizer
        public DelegateCommand(Action<T> execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        #endregion
    }
}
