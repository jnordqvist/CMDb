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

namespace Uppgift2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double total = 300.0;
        public MainWindow()
        {
            InitializeComponent();
            lblTotal.Content = total;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxInput.Text.ToUpper() == "HÖST2020" ||
                txtBoxInput.Text.ToUpper() == "VINTER2020")
            {
                total *= 0.9;
                lblTotal.Content = total;
            }
            else
                MessageBox.Show("Den där rabattkoden är felaktig. Försök igen.");

            
        }
    }
}
