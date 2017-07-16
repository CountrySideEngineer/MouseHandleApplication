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
        #endregion

    }
}
