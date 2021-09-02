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

namespace Uppgift3
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

        public bool IsValidDiscountCode(string code)
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            string season = GetSeason(month);
            code = code.ToUpper();
            string correctCode = $"{season}{year}";
            return CorrectChars(code, correctCode);
        }

        /// <summary>
        /// denna metod skapar jag för att tolka siffran datetime.now.month ger som en årstid
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        private string GetSeason(int month)
        {
            if (0 < month && month < 4 || 10 < month)
            {
                return "VINTER";
            }
            else if (month == 4 || month == 5)
            {
                return "VÅR";
            }
            else if (5 < month && month < 9)
            {
                return "SOMMAR";
            }
            else
                return "HÖST";
        }

        /// <summary>
        /// denna metod skapar jag för att kolla om alla tecken i strängen är rätt
        /// </summary>
        /// <param name="code"></param>
        /// <param name="correctCode"></param>
        /// <returns></returns>
        private bool CorrectChars(string code, string correctCode)
        {
            for(int i = 0; i < correctCode.Length; i++)
            {
                if (code[i] != correctCode[i])
                    return false;
            }
            return true;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValidDiscountCode(txtBoxInput.Text))
                MessageBox.Show("Den där rabattkoden är felaktig. Försök igen.");
        }
    }
}
