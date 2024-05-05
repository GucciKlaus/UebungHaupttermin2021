using DataLayerLib;
using MVVM_Lib;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControl1;

namespace UebungHaupttermin2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event EventHandler<TomoEventArgs> EventHandler;
        public event EventHandler<TomoEventArgs> EventHandler2;

        //private MyViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            Debug.WriteLine("MainWindow constructor called.");
            Debug.WriteLine($"usc1 is {(usc1 != null ? "" : "not ")}null.");
            Debug.WriteLine($"usc2 is {(usc2 != null ? "" : "not ")}null.");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //EventHandler += (usc1 as MyInterface).ValueChangedFromOutside;
            //EventHandler2 += (usc2 as MyInterface).ValueChangedFromOutside;

            
            foreach(UIElement elem in maingrid.Children)
            {
                if(elem is MyInterface)
                {
                    EventHandler += (elem as MyInterface).ValueChangedFromOutside;
                }
            }

            var DB = new DataContext();
            DB.Database.EnsureDeleted();
            DB.Database.EnsureCreated();
            int patientsnr = DB.Patients.Count();
            Title = patientsnr.ToString();
            
            

           
            this.DataContext = new MyViewModel().Init(DB,EventHandler);
        }

        private void MyViewModel_TomographieChanged(object? sender, TomoEventArgs e)
        {
            
        }


        

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}