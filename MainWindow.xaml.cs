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
using System.Numerics;
using System.Text.RegularExpressions;

namespace _426_Assigment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BigInteger   n, z;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculation_Copy_Click(object sender, RoutedEventArgs e)
        {
            BigInteger ePrime = int.Parse(eTextBox.Text);
            var d = ePrime % z;
            BigInteger dPrivate = 1 / d;

            ePublicKey1.Text = ePrime.ToString();
            nPublicKey1.Text = nTextBox.Text;
            dPrivateKey1.Text = dPrivate.ToString();
            nPrivateKey1.Text = nTextBox.Text;
        }

        private void Calculation_Click(object sender, RoutedEventArgs e)
        {
            BigInteger p = int.Parse(TextBox1.Text);
            BigInteger q = int.Parse(TextBox2.Text);
            if (p%2!=0)
            {
                n = p * q;
                z = (p - 1) * (q - 1);
            }
            else
            {
                return;
            }
            
            nTextBox.Text = n.ToString();
            zTextBox.Text = z.ToString();
            
        }
    }
}
