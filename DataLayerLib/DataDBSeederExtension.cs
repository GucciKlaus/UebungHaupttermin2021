using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerLib
{
    public static class DataDBSeederExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Console.WriteLine("Besamen");
            Patient p1 = new Patient { PatientID = 1, PatientFirstName = "Gustav", PatientLastName = "Gibs", BirthDate = DateTime.UtcNow, DoctorDoctorID = 1 };
            Patient p2 = new Patient { PatientID = 2, PatientFirstName = "Sepp", PatientLastName = "Gibs", BirthDate = DateTime.UtcNow, DoctorDoctorID = 1 };
            modelBuilder.Entity<Patient>().HasData(p1);
            modelBuilder.Entity<Patient>().HasData(p2);

            Doctor d1 = new Doctor { DoctorID = 1, DoctorFirstName = "Hans", DoctorLastName = "Sorglos", DoctorTitel = "Hausarzt", DocterBirthDate = DateTime.Now};
            Doctor d2 = new Doctor { DoctorID = 2, DoctorFirstName = "Kilian", DoctorLastName = "Sorglos", DoctorTitel = "OA", DocterBirthDate = DateTime.Now };
            modelBuilder.Entity<Doctor>().HasData(d1);
            modelBuilder.Entity<Doctor>().HasData(d2);

            Image image1 = Image.FromFile("C:\\Users\\klaus\\Downloads\\UebungHaupttermin2021\\DataLayerLib\\image.jpg");

            Tomography t1 = new Tomography { Image = byteArrayToImage(image1),IsRightEye = true, Papilarea = 2.21,Patient_PatientID=1,TomographyID=1,TomDate=DateTime.MaxValue};
            Tomography t2 = new Tomography { Image = byteArrayToImage(image1), IsRightEye = false, Papilarea = 4.19, Patient_PatientID = 1, TomographyID = 2, TomDate = DateTime.MaxValue };
            Tomography t3 = new Tomography { Image = byteArrayToImage(image1), IsRightEye = true, Papilarea = 5.21, Patient_PatientID = 2, TomographyID = 3, TomDate = DateTime.MaxValue };
            Tomography t4 = new Tomography { Image = byteArrayToImage(image1), IsRightEye = false, Papilarea = 5.19, Patient_PatientID = 2, TomographyID = 4, TomDate = DateTime.MaxValue };
            Tomography t5 = new Tomography { Image = byteArrayToImage(image1), IsRightEye = true, Papilarea = 6.21, Patient_PatientID = 3, TomographyID = 5, TomDate = DateTime.MaxValue };
            Tomography t6 = new Tomography { Image = byteArrayToImage(image1), IsRightEye = false, Papilarea = 6.19, Patient_PatientID = 4, TomographyID = 6, TomDate = DateTime.MaxValue };
            modelBuilder.Entity<Tomography>().HasData(t1);
            modelBuilder.Entity<Tomography>().HasData(t2);
            modelBuilder.Entity<Tomography>().HasData(t3);
            modelBuilder.Entity<Tomography>().HasData(t4);
            modelBuilder.Entity<Tomography>().HasData(t5);
            modelBuilder.Entity<Tomography>().HasData(t6);
        }


        public static byte[] byteArrayToImage(Image image1)
        {
            MemoryStream ms = new MemoryStream();
            image1.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}
