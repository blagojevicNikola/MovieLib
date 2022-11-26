using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    public abstract class BaseViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); 
        }

    }
}
