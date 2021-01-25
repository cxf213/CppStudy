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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using MLStudy.Model;
using MLStudy.Libs;
using MLStudy.Layers;
using System.Windows.Media;

namespace MLStudy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int sumTimes = 0;
        int dimensions = 2;
        int N = 4;
        List<float[]> datas;
        List<float> expect;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Main(object sender, EventArgs e)
        {
            string s = "";
            LinearLayer l1 = new LinearLayer(2,1);
            float[] res=l1.Forward(new float[2] { 0.69f, 0.75f });

            float[] resback = l1.BackPropa(new float[1] { -0.02f});
            resback = Networks.ListMulAdds( ActiveFunc.Dsigmoid(new float[2] { 0.69f, 0.75f }),resback);
            foreach(var i in resback)
            {
                s += i + ", ";
            }
            MessageBox.Show(s);


            datas = new List<float[]>();
            expect = new List<float>();

            datas.Add(new float[]{ 0f ,0f });
            expect.Add(0f);
            datas.Add(new float[] { 1f, 0f });
            expect.Add(1f);
            datas.Add(new float[] { 0f, 1f });
            expect.Add(1f);
            datas.Add(new float[] { 1f, 1f });
            expect.Add(0f);
            N = 3;
            flashlistbox();
            flashcanve2();
        }

        public float Run(Models ml, int trainTimes)
        {
            Random rd = new Random();
            float[] data = new float[dimensions];
            for (int i = 0; i < trainTimes; i++)
            {
                int rnd = rd.Next(0, N+1);
                for (int j = 0; j < dimensions; j++)
                {
                    data[j] = datas[rnd][j];
                }
                float val = ml.Calculate(data);
                ml.Callback(expect[rnd]);

            }

            float sum = 0f;
            for (int i = 0; i < N+1; i++)
            {
                int rnd = i;
                for (int j = 0; j < dimensions; j++)
                {
                    data[j] = datas[rnd][j];
                }
                float val = ml.Calculate(data);
                ml.Callback(expect[rnd]);

                sum += (val - expect[rnd])* (val - expect[rnd]);
                //lb1.Items.Add(datas[rnd, 0] + " , " + datas[rnd, 1] + " : " + expect[rnd] + " 输出结果: " + val.ToString("0.00") );
            }
            return sum/2/(N+1);
        }

        public void Draw(Models ml, int resolution)
        {
            Canva1.Children.Clear();
            for (int i = 0; i < resolution; i++)
            {
                for (int j = 0; j < resolution; j++)
                {
                    Rectangle r = new Rectangle
                    {
                        Fill = new SolidColorBrush(Color.FromRgb(
                            (byte)(ml.Calculate(new float[] { i / (float)resolution, j / (float)resolution }) * 256),
                            144,
                            159)),
                        Width = (Canva1.Width / resolution) + 1f,
                        Height = (Canva1.Height / resolution) + 1f
                    };
                    r.SetValue(Canvas.LeftProperty, i * (Canva1.Width / (float)resolution));
                    r.SetValue(Canvas.TopProperty, (resolution-j) * ((Canva1.Height-2) / (float)resolution)-8);

                    Canva1.Children.Add(r);
                }
            }

        }

        examML ml;
        bool isinitiated = false;
        private void reset_Click(object sender, RoutedEventArgs e)
        {
            Canva1.Children.Clear();
            ml = new examML();
            isinitiated = true;
            sumTimes = 0;
            sumTime.Content = "已进行 " + sumTimes + " 次训练";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!isinitiated)
            {
                ml = new examML();
                isinitiated = true;
            }
            ml.LearnRate = Convert.ToSingle(learnRate.Text);

            Stopwatch sw = new Stopwatch(); 
            sw.Start();                     
            sumTimes += Convert.ToInt32(traintime.Text);
            sumTime.Content = "已进行 " + sumTimes + " 次训练";


            c1.Content = "平均损失: " + Run(ml, Convert.ToInt32(traintime.Text)).ToString("0.000");

            sw.Stop();                      
            TimeSpan ts = sw.Elapsed;
            t1.Content = "计算用时: " + ts.TotalMilliseconds.ToString("0.00") + " ms";


            Stopwatch sw2 = new Stopwatch(); 
            sw2.Start();                     
            Draw(ml, Convert.ToInt32(res.Text));
            sw2.Stop();                      
            TimeSpan ts2 = sw2.Elapsed;

            t2.Content = "绘画用时: " + ts2.TotalMilliseconds.ToString("0.00") + " ms";
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            float x=0f, y=0f, exc=0f;
            try
            {
                x = Convert.ToSingle(xval.Text);
                y = Convert.ToSingle(yval.Text);
                exc = Convert.ToSingle(val.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("INVAILED INPUT");
            }
            N++;
            datas.Add(new float[] { x, y });
            expect.Add(exc);
            lb1.Items.Add(N + ". " + x + " , "+y+" : "+exc);
            flashcanve2();
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            int id=0;
            try
            {
                id =
                    Convert.ToInt32(
                    lb1.SelectedItem.ToString().Substring(0, 1));
                lb1.Items.Remove(lb1.SelectedItem);
            }
            catch (Exception) { }
            N--;
            flashlistbox();
            datas.RemoveAt(id);
            expect.RemoveAt(id);
            flashcanve2();
        }
        private void flashlistbox()
        {
            lb1.Items.Clear();
            for(int i = 0; i <= N; i++)
            {
                float x = datas[i][0];
                float y = datas[i][1];
                float exc = expect[i];
                lb1.Items.Add(i + ". " + x + " , " + y + " : " + exc);
            }
        }

        private void flashcanve2()
        {
            Canva2.Children.Clear();
            for (int i = 0; i <= N; i++)
            {
                float x = datas[i][0];
                float y = datas[i][1];
                float exc = expect[i];
                Ellipse el = new Ellipse
                {
                    Fill = new SolidColorBrush(exc<0.5?Colors.Green:Colors.Red),
                    Width = 10,
                    Height = 10
                };
                el.SetValue(LeftProperty,x* Canva1.Width-5);
                el.SetValue(TopProperty, (1-y)* Canva1.Height-5);
                Canva2.Children.Add(el);
            }
        }

    }
}
