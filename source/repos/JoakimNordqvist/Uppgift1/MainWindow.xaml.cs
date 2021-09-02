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

namespace Uppgift1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double total = 0.0;
        public MainWindow()
        {
            InitializeComponent();
            lblTotal.Content = $"{total:C}";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            total += Convert.ToDouble(txtBoxInput.Text);
            lblTotal.Content = $"{total:C}";
            txtBoxInput.Text = "";
        }

        private void btnSub_Click(object sender, RoutedEventArgs e)
        {
            total -= Convert.ToDouble(txtBoxInput.Text);
            lblTotal.Content = $"{total:C}";
            txtBoxInput.Text = "";
        }
    }
}
