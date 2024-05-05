//using DataLayerLib;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace UebungHaupttermin2021
//{
//    public class ObservableObject : INotifyPropertyChanged
//    {
//        public event PropertyChangedEventHandler? PropertyChanged;

//        public void RaisePropertyChangedEvent (string propertyName)
//        {
//            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (propertyName));
//        }


//    }

//    public class MyViewModel : ObservableObject
//    {
//        public MyViewModel Init(DataContext dataContext)
//        {
//            var DB = dataContext;
//            Doctors = DB.Doctors.OrderBy(x => x.DoctorLastName).ToList();
//            SelectedDoctor = Doctors.First();
//            patients = DB.Patients.Where(x=>x.DoctorDoctorID == SelectedDoctor.DoctorID).ToList();
//            //list = DB.Patients.Where(x=>x.PatientID == selectedpatient.PatientID).Select(x => new PatientViewModel{Firstname = x.PatientFirstName,
//            //    Lastname = x.PatientLastName,
//            //    RightEye = x.Tomographies.Where(y=>y.Patient_PatientID == x.PatientID)
//            //    .Select(y=>y.IsRightEye).FirstOrDefault(),
//            //     Average = x.Tomographies.Where(y=>y.Patient_PatientID == x.PatientID).Select(y=>y.Papilarea).FirstOrDefault(),
//            //     MinValue = x.Tomographies.Where(y => y.Patient_PatientID == x.PatientID).Select(y => y.Papilarea).FirstOrDefault()/2,
//            //     Date = x.Tomographies.Where(y=>y.Patient_PatientID == x.PatientID).Select(y=>y.TomDate).FirstOrDefault()
//            //}
//            //    ).ToList();
//            return this;
//        }

//        private List<Doctor> doctors;

//        public List<Doctor> Doctors
//        {
//            get { return doctors; }
//            set
//            {
//                doctors = value;
//                RaisePropertyChangedEvent(nameof(Doctors));
//            }
//        }

//        private Doctor selecteddoctor;

//        public Doctor SelectedDoctor
//        {
//            get { return selecteddoctor; }
//            set { selecteddoctor = value; RaisePropertyChangedEvent(nameof(SelectedDoctor)); }
//        }

//        private List<Patient> patients;

//        public List<Patient> Patients
//        {
//            get { return patients; }
//            set { patients = value; RaisePropertyChangedEvent(nameof(patients)); }
//        }
//        private Patient selectedpatient;

//        public Doctor SelectedPatient
//        {
//            get { return selecteddoctor; }
//            set { selecteddoctor = value; RaisePropertyChangedEvent(nameof(SelectedPatient)); }
//        }

//        private List<PatientViewModel> list;

//        public List<PatientViewModel> List
//        {
//            get { return list; }
//            set { list = value; RaisePropertyChangedEvent(nameof(List)); }
//        }


//        private Tomography selectedtomography;

//        public Doctor SelectedTomography
//        {
//            get { return selecteddoctor; }
//            set { selecteddoctor = value; RaisePropertyChangedEvent(nameof(SelectedTomography)); }
//        }

//    }

//    public class PatientViewModel : ObservableObject
//    {
//        public string Firstname { get; set; }
//        public string Lastname { get; set; }
//        public DateTime Date { get; set; }
//        public bool RightEye { get; set; }
//        public double Average { get; set; }
//        public double MinValue { get; set; }
//    }
//}
