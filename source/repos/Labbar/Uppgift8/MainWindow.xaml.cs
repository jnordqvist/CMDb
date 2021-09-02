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

namespace Uppgift8
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

        private void RadioButton_Checked_add(object sender, RoutedEventArgs e)
        {
            result.Text = Convert.ToString(Convert.ToDouble(numberOne.Text) + Convert.ToDouble(numberTwo.Text));
        }

        private void RadioButton_Checked_sub(object sender, RoutedEventArgs e)
        {
            result.Text = Convert.ToString(Convert.ToDouble(numberOne.Text) - Convert.ToDouble(numberTwo.Text));

        }
        private void RadioButton_Checked_mult(object sender, RoutedEventArgs e)
        {
            result.Text = Convert.ToString(Convert.ToDouble(numberOne.Text) * Convert.ToDouble(numberTwo.Text));

        }
        private void RadioButton_Checked_div(object sender, RoutedEventArgs e)
        {
            result.Text = Convert.ToString(Convert.ToDouble(numberOne.Text) / Convert.ToDouble(numberTwo.Text));

        }
    }
}
