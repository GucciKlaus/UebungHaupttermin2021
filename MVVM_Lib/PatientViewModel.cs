using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Lib
{
    public class PatientViewModel:ObservableObject
    {
            public int ID { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public DateTime Date { get; set; }
            public bool RightEye { get; set; }
            public double Average { get; set; }
            public double MinValue { get; set; }
            public byte[] Image { get; set; }
    }
}
