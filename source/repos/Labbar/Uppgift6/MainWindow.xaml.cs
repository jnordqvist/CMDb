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

namespace Uppgift6
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

        private void calc(object sender, RoutedEventArgs e){
            string type = (sender as Button).Name;
            double res = 0;
            switch (type){
                case "add":
                    res = Convert.ToDouble(numberOne.Text) + Convert.ToDouble(numberTwo.Text);
                    result.Text = Math.Round(res, 4).ToString();
                    resText.Content ="Summa";
                    break;
                case "sub":
                    res = Convert.ToDouble(numberOne.Text) - Convert.ToDouble(numberTwo.Text);
                    result.Text = Math.Round(res, 4).ToString();
                    resText.Content = "Differens";
                    break;
                case "mult":
                    res = Convert.ToDouble(numberOne.Text) * Convert.ToDouble(numberTwo.Text);
                    result.Text = Math.Round(res, 4).ToString();
                    resText.Content = "Produkt";
                    break;
                case "div":
                    res = Convert.ToDouble(numberOne.Text) / Convert.ToDouble(numberTwo.Text);
                    result.Text = Math.Round(res, 4).ToString();
                    resText.Content = "Kvot";
                    break;
                default:
                    break;
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            result.Clear();
            numberOne.Clear();
            numberTwo.Clear();
        }
    }
}
