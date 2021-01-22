using System;
using System.Collections.Generic;
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

namespace MLStudy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Main(object sender, EventArgs e)
        {
            Run();
            float[] datas = new float[] { 1f, 1f };
            examML ml1 = new examML();
            lb1.Items.Add(ml1.Calculate(datas));
            ml1.Callback(1);
        }

        public void Run()
        {
            Random rd = new Random();
            float[,] datas = new float[4,2] { { 1f,0f},{ 0f, 1f},{ 1f, 1f }, { 0f, 0f } };
            float[] expect = new float[4] { 1f, 1f, 0f, 0f };
            examML ml = new examML();
            float[] data = new float[2];
            for (int i = 0; i < 5000; i++)
            {
                int rnd = rd.Next(0, 4);
                for(int j = 0; j < 2; j++)
                {
                    data[j] = datas[rnd, j];
                }
                float val = ml.Calculate(data);
                ml.Callback(expect[rnd]);
                lb1.Items.Add(datas[rnd, 0]+","+datas[rnd, 1] +"   "+ val.ToString("0.00") +" EXCEPECT:"+expect[rnd]);
            }

            string s = "";
            for (int i = 0; i < 4; i++)
            {
                int rnd = i;
                for (int j = 0; j < 2; j++)
                {
                    data[j] = datas[rnd, j];
                }
                float val = ml.Calculate(data);
                ml.Callback(expect[rnd]);
                s += ml.Cost+"\n";
                
            }
            MessageBox.Show(s);
        }
    }
}
