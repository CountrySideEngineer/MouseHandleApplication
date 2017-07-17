using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace HandleApplication.Command
{
    /// <summary>
    /// Action coordinates with mouse action.
    /// </summary>
    public class MouseCoordinatesAction : TriggerAction<DependencyObject>
    {
        #region
        /// <summary>
        /// Regists "Command" Property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                "Command",
                typeof(ICommand),
                typeof(MouseCoordinatesAction),
                new UIPropertyMetadata(null));
        /// <summary>
        /// Interface of command
        /// </summary>
       public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
 
        /// <summary>
        /// Handle mouse event.
        /// </summary>
        /// <param name="parameter">MouseEventArgs</param>
        protected override void Invoke(object parameter)
        {
            var eventAargs = parameter as MouseEventArgs;
            var element = AssociatedObject as IInputElement;//Get object the trigger attached.
            if ((this.Command == null) || (eventAargs == null) || (element == null)) { return; }
            var Position = eventAargs.GetPosition(element);
            if (Command.CanExecute(Position))
            {
                Command.Execute(Position);
            }
        }
        #endregion
    }
}
