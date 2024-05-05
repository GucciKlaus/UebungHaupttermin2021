using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerLib
{
    public partial class Patient
    {
        public int PatientID { get; set; }
        public string? PatientFirstName { get; set;}
        public string? PatientLastName {  get; set; }
        public DateTime BirthDate { get; set; }

        public int DoctorDoctorID {  get; set; }
        public Doctor? Doctor { get; set; }

        public List<Tomography> Tomographies { get; set; } = new List<Tomography>();

    }

    public partial class Patient
    {
        public override string ToString()
        {
            return $"{PatientFirstName} {PatientLastName}";
        }
    }
}
