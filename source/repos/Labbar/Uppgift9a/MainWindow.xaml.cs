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

namespace Uppgift9a
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

        private void check_Click(object sender, RoutedEventArgs e)
        {
            int userAge = Convert.ToInt32(age.Text);
            if(userAge > 14)
            {
                result.Content = "Hej " + name.Text + ", du är " + userAge + " år gammal och får se alla filmer";
            }
            else if((userAge > 10) && (userAge <= 14))
            {
                result.Content = "Hej " + name.Text + ", du är " + userAge + " år gammal och får se filmer med åldersgräns upp till 11 år";
            }
            else if ((userAge > 6) && (userAge <= 10))
            {
                result.Content = "Hej " + name.Text + ", du är " + userAge + " år gammal och får se filmer med åldersgräns upp till 7 år";
            }
            else
            {
                result.Content = "Hej " + name.Text + ", du är " + userAge + " år gammal och får se barntillåten film";
            }
        }
    }
}
