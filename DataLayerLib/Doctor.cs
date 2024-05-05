
namespace DataLayerLib
{
    public partial class Doctor
    {
        public int DoctorID {  get; set; }
        public string? DoctorTitel { get; set; }
        public string? DoctorFirstName { get; set;}
        public string? DoctorLastName { get; set;}
        public DateTime DocterBirthDate { get; set;}


        public List<Patient> Patients { get; set; } = new List<Patient>();
    }

    public partial class Doctor
    {
        public override string ToString()
        {
            return $"{DoctorTitel} {DoctorFirstName} {DoctorLastName}";
        }
    }

}
