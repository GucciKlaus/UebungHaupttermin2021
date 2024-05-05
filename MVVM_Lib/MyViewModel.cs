//public ICommand PatientClick => new RelayCommand<string>(LoadPatient, x => true);

//private void LoadPatient(string obj)
//{
//    if (selectedpatient != null)
//    {
//        list = _context.Patients.Where(x => x.PatientID == selectedpatient.PatientID).Select(x => new PatientViewModel
//        {
//            Firstname = x.PatientFirstName,
//            Lastname = x.PatientLastName,
//            RightEye = x.Tomographies.Where(y => y.Patient_PatientID == x.PatientID)
//            .Select(y => y.IsRightEye).FirstOrDefault(),
//            Average = x.Tomographies.Where(y => y.Patient_PatientID == x.PatientID).Select(y => y.Papilarea).FirstOrDefault(),
//            MinValue = x.Tomographies.Where(y => y.Patient_PatientID == x.PatientID).Select(y => y.Papilarea).FirstOrDefault() / 2,
//            Date = x.Tomographies.Where(y => y.Patient_PatientID == x.PatientID).Select(y => y.TomDate).FirstOrDefault()
//        }
//            ).ToList();
//    }
//}




using DataLayerLib;
using System.Windows.Input;

namespace MVVM_Lib
{
    public class MyViewModel : ObservableObject
    {
        public event EventHandler<TomoEventArgs> TomographieChanged;
        public event EventHandler<TomoEventArgs> TomographieChanged2;
        private DataContext _context;
        
        public MyViewModel Init(DataContext dataContext, EventHandler<TomoEventArgs>eventpeppi,EventHandler<TomoEventArgs>eventpeppi2)
        {
            _context = dataContext;
            Doctors = _context.Doctors.OrderBy(x => x.DoctorLastName).ToList();
            SelectedDoctor = Doctors.First();
            patients = _context.Patients.Where(x => x.DoctorDoctorID == SelectedDoctor.DoctorID).ToList();
            this.TomographieChanged = eventpeppi;
            this.TomographieChanged2 = eventpeppi2;
            return this;
        }

        private List<Doctor> doctors;

        public List<Doctor> Doctors
        {
            get { return doctors; }
            set
            {
                doctors = value;
                RaisePropertyChangedEvent(nameof(Doctors));
            }
        }

        private Doctor selecteddoctor;

        public Doctor SelectedDoctor
        {
            get { return selecteddoctor; }
            set { selecteddoctor = value; RaisePropertyChangedEvent(nameof(SelectedDoctor)); }
        }

        private List<Patient> patients;

        public List<Patient> Patients
        {
            get { return patients; }
            set { patients = value; RaisePropertyChangedEvent(nameof(patients)); }
        }
        private Patient selectedpatient;

        public Patient SelectedPatient
        {
            get { return selectedpatient; }
            set { selectedpatient = value; RaisePropertyChangedEvent(nameof(SelectedPatient));
                List<PatientViewModel> patients = new List<PatientViewModel>();
                List<Tomography> g = _context.Tomographies.Where(x => x.Patient_PatientID == value.PatientID).ToList();
                foreach(Tomography tomography in g)
                {
                    PatientViewModel pVM = new PatientViewModel { Firstname = value.PatientFirstName, Lastname = value.PatientLastName, ID = tomography.TomographyID, Average = tomography.Papilarea, Date = tomography.TomDate, MinValue = tomography.Papilarea * 0.8, RightEye = tomography.IsRightEye,Image = tomography.Image };
                    patients.Add(pVM);
                }
                List = patients;
            }
        }

        private List<PatientViewModel> list;

        public List<PatientViewModel> List
        {
            get { return list; }
            set { list = value; RaisePropertyChangedEvent(nameof(List)); }
        }


        private PatientViewModel selectedtomography;

        public PatientViewModel SelectedTomography
        {
            get { return selectedtomography; }
            set
            {
                if (value != null) {
                selectedtomography = value; RaisePropertyChangedEvent(nameof(SelectedTomography));

                //string name = _context.Patients.Where(x => x.PatientID == value.ID).Select(y => y.PatientFirstName).FirstOrDefault();
                double[] values = new double[7];
                for (int i = 0; i < 7; i++)
                {
                    values[i] = value.Average * i / 5;
                }
                TomoEventArgs args = new TomoEventArgs { Eye = value.RightEye, Namer = $"{value.Firstname} sein {value.Lastname}", papillaray = values, ImageData = value.Image };
                OnTomographieChanged(args);
            }
        }
        }
        

        private void OnTomographieChanged(TomoEventArgs args)
        {
            if(args.Eye == true)
            {
                TomographieChanged?.Invoke(this, args);
            }
            else if (args.Eye== false)
            {
                TomographieChanged2?.Invoke(this, args);
            }
            
        }


    }


}
