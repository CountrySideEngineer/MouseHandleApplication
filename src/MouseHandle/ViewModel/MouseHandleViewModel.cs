using HandleApplication.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HandleApplication.ViewModel
{
    /// <summary>
    /// MouseHandle application main ViewModel class.
    /// </summary>
    public class MouseHandleViewModel : ViewModelBase
    {
        #region Private fields and constants (in a region)
        /// <summary>
        /// Mouse position, X and Y, in integer.
        /// </summary>
        private int xPos;
        private int yPos;
        #endregion

        #region Constructors and the Finalizer
        public MouseHandleViewModel()
        {
            this.XPos = 0;
            this.YPos = 0;
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Accessor to XPos, X positin of mouse in number, integer.
        /// </summary>
        public int XPos
        {
            get { return this.xPos; }
            set
            {
                this.xPos = value;
                this.RaisePropertyChanged("XPos");
            }
        }

        /// <summary>
        /// Accessor to YPos, Y positin of mouse in number, integer.
        /// </summary>
        public int YPos
        {
            get { return this.yPos; }
            set
            {
                this.yPos = value;
                this.RaisePropertyChanged("YPos");
            }
        }

        /// <summary>
        /// Defines a command, MousePosCommand.
        /// </summary>
        protected ICommand mousePosCommand;
        public ICommand MousePosCommand
        {
            get
            {
                if (this.mousePosCommand == null)
                {
                    this.mousePosCommand =
                        new DelegateCommand<Point>(
                            this.MousePosCommandExecute, 
                            this.CanMousePosMoveCommandExecute);
                }
                return this.mousePosCommand;
            }
        }

        /// <summary>
        /// Body of MousePosCommand.
        /// </summary>
        /// <param name="Pos">Point of mouse cursor on Canvas object.</param>
        public void MousePosCommandExecute(Point Pos)
        {
            this.XPos = Convert.ToInt32(Pos.X);
            this.YPos = Convert.ToInt32(Pos.Y);
        }

        /// <summary>
        /// Returns whether the command can execute or not.
        /// *This function always returns true.
        /// </summary>
        /// <returns>Always returns true.</returns>
        public bool CanMousePosMoveCommandExecute()
        {
            return true;
        }
        #endregion

    }
}
