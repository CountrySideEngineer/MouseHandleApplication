using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleApplication.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private MouseHandleViewModel mouseHandleVM;
        public MouseHandleViewModel MouseHandleVM
        {
            get
            {
                if (this.mouseHandleVM == null)
                {
                    this.mouseHandleVM = new MouseHandleViewModel();
                }
                return this.mouseHandleVM;
            }
            set
            {
                this.mouseHandleVM = value;
                this.RaisePropertyChanged("MouseHandleVM");
            }
        }
    }
}
