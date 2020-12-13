using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Maze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void draw_Click(object sender, RoutedEventArgs e)
        {
            canvas1.Children.Add(Drawline());

            /*
            Rectangle exampleRectangle = new Rectangle();
            exampleRectangle.Width = 75;
            exampleRectangle.Height = 75;

            // Create a LinearGradientBrush and use it to
            // paint the rectangle.
            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.5));
            myBrush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
            exampleRectangle.Fill = myBrush;
            exampleRectangle.RenderTransform = new MatrixTransform(new Matrix(2,1,0,1,100,100));
            canvas1.Children.Add(exampleRectangle);
            */
        }



        private Line Drawline()
        {
            Line myLine = new()
            {
                Stroke = System.Windows.Media.Brushes.Black,
                StrokeThickness = 2
            };
            try
            {
                string[] a = point1.Text.Split(',');
                string[] b = point2.Text.Split(',');
                myLine.X1 = Convert.ToInt32(a[0]);
                myLine.Y1 = Convert.ToInt32(a[1]);
                myLine.X2 = Convert.ToInt32(b[0]);
                myLine.Y2 = Convert.ToInt32(b[1]);
            }
            catch
            {
                MessageBox.Show("ERROR!");
            }
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            return myLine;
        }
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            if (canvas1.Children.Count == 0)   return;
            canvas1.Children.RemoveAt(canvas1.Children.Count-1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MazeGenerater maze1 = new MazeGenerater(5);
        }
    }
}
