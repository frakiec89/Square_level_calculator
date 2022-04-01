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

namespace Square_level_calculator
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

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(tbA.Text))
            { MessageBox.Show("введите A"); return; }

            if (string.IsNullOrEmpty(tbB.Text))
            { MessageBox.Show("введите B"); return; }

            if (string.IsNullOrEmpty(tbC.Text))
            { MessageBox.Show("введите C"); return; }
            double[] a_b_c;
            try
            {
                a_b_c = Geta_b_c();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); return;
            }


            var d = GetDiscriminant(a_b_c[0], a_b_c[1], a_b_c[2]);

            if(d <0)
            {
                lbRez.Content = $"Ответ - дискриминант отрицательный ( {d})  -  корней нет";
                return;
            }
       
            if(d==0)
            {
                var x = (a_b_c[1] * -(double) 1) / (double)2 * a_b_c[0];
                lbRez.Content = $"Ответ - дискриминант равен нулю -  корень один {x}";
                return;
            }

            if (d > 0)
            {
                var x = (a_b_c[1] * -(double)1) + Math.Sqrt(d) / (double)2 * a_b_c[0];
                var y = (a_b_c[1] * -(double)1) - Math.Sqrt(d) / (double)2 * a_b_c[0];

                lbRez.Content = $"Ответ - корень x1 =  {x}" +
                    $"\n" +
                    $"Ответ - корень x2 =  {y}";
                return;
            }
        }

        private double GetDiscriminant(double a, double b, double c)
        {
            return Math.Pow(b, 2) - (double)4 * a * c;
        }

        private double[] Geta_b_c()
        {
            var a = new double[3];
            try
            {
                a[0] = Convert.ToDouble(tbA.Text);
            }
            catch 
            {
                throw new Exception("Ошибка в параметре, А не число!");
            }

            try
            {
                a[1] = Convert.ToDouble(tbB.Text);
            }
            catch
            {
                throw new Exception("Ошибка в параметре, B не число!");
            }

            try
            {
                a[2] = Convert.ToDouble(tbC.Text);
            }
            catch
            {
                throw new Exception("Ошибка в параметре, С не число!");
            }
            return  a;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            tbA.Clear();
            tbB.Clear();
            tbC.Clear();    
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if( MessageBox.Show("Вы уверены?", "Выход из программы" , MessageBoxButton.YesNo ) == MessageBoxResult.Yes )
            {
               this.Close();
            }
        }
    }
}
