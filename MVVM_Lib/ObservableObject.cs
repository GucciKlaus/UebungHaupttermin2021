using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Lib
{
        public class ObservableObject : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler? PropertyChanged;

            public void RaisePropertyChangedEvent(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }


        }
}
