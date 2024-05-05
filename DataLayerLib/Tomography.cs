using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerLib
{
    public class Tomography
    {
        public int TomographyID { get; set; }
        public bool IsRightEye { get; set; }
        public DateTime TomDate { get; set; }
        public double Papilarea { get; set; }
        public byte[]? Image { get; set; }
        public int Patient_PatientID {  get; set; }
        public Patient? Patient { get; set; }
    }
}
