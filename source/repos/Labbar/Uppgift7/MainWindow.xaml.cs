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

namespace Uppgift7
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

        private void calc_Click(object sender, RoutedEventArgs e)
        {
            int numerator = Convert.ToInt32(numberOne.Text);
            int denominator = Convert.ToInt32(numberTwo.Text);
            result.Text = Convert.ToString(numerator / denominator);
            remainder.Text = Convert.ToString(numerator % denominator);
        }
    }
}
