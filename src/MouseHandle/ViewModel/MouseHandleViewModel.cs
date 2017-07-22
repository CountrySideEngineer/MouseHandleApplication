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

        private bool isPush;
        private bool onCursor;
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

        public bool IsPush
        {
            get { return this.isPush; }
            set
            {
                this.isPush = value;
                this.RaisePropertyChanged("IsPush");

                this.PushState = (value == true) ? "TRUE" : "FALSE";
            }
        }

        public bool OnCursor
        {
            get { return this.onCursor; }
            set
            {
                this.onCursor = value;
                this.RaisePropertyChanged("OnCursor");

                this.CursorState = (value == true) ? "TRUE" : "FALSE";
            }
        }

        public string PushState { get; private set; }
        public string CursorState { get; private set; }

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
                            this.MousePosCommandExecute, null);
                }
                return this.mousePosCommand;
            }
        }

        /// <summary>
        /// Defines a command MouseLeftPushCommand.
        /// </summary>
        protected ICommand mouseLeftButtonPushCommand;
        public ICommand MouseLeftButtonPushCommand
        {
            get
            {
                if (mouseLeftButtonPushCommand == null)
                {
                    this.mouseLeftButtonPushCommand =
                        new DelegateCommand<Point>(this.MouseLeftButtonPushCommandExecute, null);
                }
                return this.mouseLeftButtonPushCommand;
            }
        }

        /// <summary>
        /// Defines a command MouseLeft
        /// </summary>
        protected ICommand mouseLeftButtonReleaseCommand;
        public ICommand MouseLeftButtonReleaseCommand
        {
            get
            {
                if (mouseLeftButtonReleaseCommand == null)
                {
                    this.mouseLeftButtonReleaseCommand =
                        new DelegateCommand<Point>(this.MouseLeftButtonReleaseCommandExecute, null);
                }
                return this.mouseLeftButtonReleaseCommand;
            }
        }

        protected ICommand mouseCursorOnCommand;
        public ICommand MouseCursorOnCommand
        {
            get
            {
                if (this.mouseCursorOnCommand == null)
                {
                    this.mouseCursorOnCommand =
                        new DelegateCommand<Point>(this.MouseCursorOnCommandExecute, null);
                }
                return this.mouseCursorOnCommand;
            }
        }


        /// <summary>
        /// Defines a command Mouse
        /// </summary>
        protected ICommand mouseCursorOffCommand;
        public ICommand MouseCursorOffCommand
        {
            get
            {
                if (this.mouseCursorOffCommand == null) {
                    this.mouseCursorOffCommand =
                        new DelegateCommand<Point>(this.MouseCursorOffCommandExecute, null);
                }
                return this.mouseCursorOffCommand;
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

        public void MouseLeftButtonPushCommandExecute(Point Pos) { this.IsPush = true; }
        public void MouseLeftButtonReleaseCommandExecute(Point Pos) { this.IsPush = false; }
        public void MouseCursorOffCommandExecute(Point Pos)
        {
            this.IsPush = false;
            this.OnCursor = false;
        }
        public void MouseCursorOnCommandExecute(Point Pos) { this.OnCursor = true; }

        /// <summary>
        /// Returns whether the command can execute or not.
        /// *This function always returns true.
        /// </summary>
        /// <returns>Always returns true.</returns>
        public bool CanMousePosMoveCommandExecute() { return true; }
        #endregion

    }
}
