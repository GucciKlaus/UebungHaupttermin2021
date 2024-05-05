using MVVM_Lib;
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
using System.IO;
using System.Drawing;
using static System.Net.WebRequestMethods;

namespace UserControl1
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl, MyInterface
    {
        public TomoEventArgs e1 { get; set; }
        public UserControl1()
        {
            InitializeComponent();
        }




        public void ValueChangedFromOutside(object sender, TomoEventArgs e)
        {
            e1 = e;
            DrawCan(e1);
        }

        public static System.Drawing.Image byteArrayToImage(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        public System.Windows.Media.ImageSource ConvertImage(System.Drawing.Image image)
        {
            try
            {
                if (image != null)
                {
                    var bitmap = new System.Windows.Media.Imaging.BitmapImage();
                    bitmap.BeginInit();
                    System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                    image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                    bitmap.StreamSource = memoryStream;
                    bitmap.EndInit();
                    return bitmap;
                }
            }
            catch { }
            return null;
        }

        public void DrawCan(TomoEventArgs e)
        {
            can2.Children.Clear();
            if (e != null)
            {
                lbl.Content = e.Namer;
                can1.Source = ConvertImage(byteArrayToImage(e.ImageData));
                double centerX = can2.ActualWidth / 2;
                double centerY = can2.ActualHeight / 2;
                double radius2 = Math.Min(can2.ActualWidth, can2.ActualHeight) * 3 / 4 / 2;
                Ellipse circle = new Ellipse
                {

                    Height = radius2 * 2,
                    Width = radius2 * 2,
                    Fill = System.Windows.Media.Brushes.Black,
                    Margin = new Thickness(centerX - radius2, centerY - radius2, 0, 0)
                };
                can2.Children.Add(circle);
                int numOfTriangles = 6;
                double radius = Math.Min(circle.Width, circle.Height) / 2;
                double centerX2 = circle.Margin.Left + radius;
                double centerY2 = circle.Margin.Top + radius;

                List<System.Windows.Point> circlePoints = new List<System.Windows.Point>();
                for (int i = 0; i < numOfTriangles; i++)
                {
                    //double angle = i * 2 * Math.PI / numOfTriangles;
                    //double x = centerX2 + radius * Math.Cos(angle);
                    //double y = centerY2 + radius * Math.Sin(angle);
                    double angle_deg = 60 * i - 30;
                    double angle_rad = Math.PI / 180 * angle_deg;
                    double x = centerX2 + radius * Math.Cos(angle_rad);
                    double y = centerY2 + radius * Math.Sin(angle_rad);
                    circlePoints.Add(new System.Windows.Point((int)x, (int)y));
                }

                for (int i = 0; i < numOfTriangles; i++)
                {
                    Polygon triangle = new Polygon
                    {
                        Fill = System.Windows.Media.Brushes.Red,
                        Stroke = System.Windows.Media.Brushes.Black,
                        StrokeThickness = 1,
                        Points = new PointCollection
                    {
                        new System.Windows.Point(centerX2,centerY2),
                        circlePoints[i],
                        circlePoints[(i+1)%numOfTriangles]
                    }
                    };
                    if (e.papillaray[i] < 3)
                    {
                        triangle.Fill = System.Windows.Media.Brushes.Green;
                    }
                    else
                    {
                        triangle.Fill = System.Windows.Media.Brushes.Red;
                    }
                    TextBlock t1 = new TextBlock { TextAlignment = TextAlignment.Left, Text = e.papillaray[i].ToString("N2") };
                    TransformGroup tg = new TransformGroup();
                    tg.Children.Add(new TranslateTransform(
                        (centerX2 + circlePoints[i].X + circlePoints[(i + 1) % numOfTriangles].X)/3 -5,
                        (centerY2 + circlePoints[i].Y + circlePoints[(i + 1) % numOfTriangles].Y)/3));
                    t1.RenderTransform = tg;
                    can2.Children.Add(triangle);
                    can2.Children.Add(t1);
                }
                double radius3 = Math.Min(centerX2, centerY2) / 2;
                double average = e.papillaray.Average();
                Ellipse esmall = new Ellipse
                {
                    Height = radius2 / 2.5,
                    Width = radius2 / 2.5,
                    Margin = new Thickness(centerX - radius2 / 2.5 / 2, centerY - radius2 / 2.5 / 2, 0, 0)
                    , Stroke = System.Windows.Media.Brushes.Black
                };
                if (average > 2)
                {
                    esmall.Fill = System.Windows.Media.Brushes.Green;
                }
                else
                {
                    esmall.Fill = System.Windows.Media.Brushes.Red;
                }
                can2.Children.Add(esmall);
        }
    }

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {

    }

    private void can2_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        DrawCan(e1);
    }
}

}
