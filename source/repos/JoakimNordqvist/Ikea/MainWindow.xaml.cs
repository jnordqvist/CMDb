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

namespace Ikea
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ShoppingCart cart;
        public MainWindow()
        {
            InitializeComponent();
            cart = new ShoppingCart();
            RefreshUI();
        }

        private void RefreshUI()
        {
            lblTotal.Content = $"{cart.GetTotalCost():C}";
            lstBoxCart.ItemsSource = null;
            lstBoxCart.ItemsSource = cart.Products;
        }

        private void btnGetDimensions_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Ditt inköp kräver ett lastutrymme som minst är {cart.GetMaxLength()} cm långt, {cart.GetMaxWidth()} cm brett och {cart.GetTotalHeight()} cm högt.");
        }

        private void btnBuyBilly_Click(object sender, RoutedEventArgs e)
        {
            cart.AddToCart("002.638.50");
            RefreshUI();
        }

        private void btnButHenriksdal_Click(object sender, RoutedEventArgs e)
        {
            cart.AddToCart("303.610.38");
            RefreshUI();
        }

        private void btnBuySofie_Click(object sender, RoutedEventArgs e)
        {
            cart.AddToCart("404.403.42");
            RefreshUI();
        }
    }
}
