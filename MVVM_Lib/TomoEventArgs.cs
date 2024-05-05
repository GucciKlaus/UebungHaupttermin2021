using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Lib
{
    public class TomoEventArgs:EventArgs
    {
        //public TomoEventArgs(bool eye, string? namer, double[] papillaray, byte[] imageData)
        //{
        //    Eye = eye;
        //    Namer = namer;
        //    this.papillaray = papillaray;
        //    ImageData = imageData;
        //}

        public bool Eye { get; set; }
        public string? Namer { get; set; }
        public double[] papillaray { get; set; }
        public byte[] ImageData { get; set; }

        
    }
}
