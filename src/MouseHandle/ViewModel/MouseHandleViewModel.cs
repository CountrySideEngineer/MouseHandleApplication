using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleApplication.ViewModel
{
    /// <summary>
    /// MouseHandle application main ViewModel class.
    /// </summary>
    public class MouseHandleViewModel : ViewModelBase
    {
        #region Private fields and constants (in a region)
        /// <summary>
        /// Mouse position, X and Y, in string.
        /// </summary>
        private string xPosStr;
        private string yPosStr;

        /// <summary>
        /// Mouse position, X and Y, in integer.
        /// </summary>
        private int xPos;
        private int yPos;
        #endregion

        #region Constructors and the Finalizer
        public MouseHandleViewModel()
        {
            this.XPosStr = "0";
            this.YPosStr = "0";
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Accessor to XPosStr, X positin of mouse in string.
        /// </summary>
        public string XPosStr
        {
            get { return this.xPosStr; }
            private set
            {
                this.xPosStr = value;
                this.RaisePropertyChanged("XPosStr");
            }
        }

        /// <summary>
        /// Accessor to YPosStr, Y positin of mouse in string.
        /// </summary>
        public string YPosStr
        {
            get { return this.yPosStr; }
            private set
            {
                this.yPosStr = value;
                this.RaisePropertyChanged("YPosStr");
            }
        }

        /// <summary>
        /// Accessor to XPos, X positin of mouse in number, integer.
        /// </summary>
        public int XPos
        {
            get { return this.xPos; }
            set
            {
                this.xPos = value;
                this.XPosStr = Convert.ToString(value);
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
                this.yPosStr = Convert.ToString(value);
                this.RaisePropertyChanged("YPos");
            }
        }
        #endregion

    }
}
