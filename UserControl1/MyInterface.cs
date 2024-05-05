using MVVM_Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControl1
{
    public interface MyInterface
    {
        void ValueChangedFromOutside(object? sender, TomoEventArgs e);
    }
}
