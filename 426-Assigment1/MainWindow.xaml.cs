using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows;

namespace _426_Assigment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BigInteger n, z, e;
        BigInteger dPrivate;
        string text;
        string cipherText = "";
        int strLength;
        BigInteger[] numArr;
        int num ,m;
        string numS;


        public MainWindow()
        {
            InitializeComponent();
        }

        public bool PrimeChk() //checks if the number is prime or not
        {
            BigInteger p = int.Parse(TextBox1.Text);
            BigInteger q = int.Parse(TextBox2.Text);

            if (p <= 1 || q <= 1) return false;
            if (p == 2 && q == 2) return true;
            if (p == 0 || q == 0) return false;
            int i, j;
            for (i = 3; i <= p - 1; i++)
            {
                if (p % i == 0)
                    return false;
            }
            if (p == i)
                return true;
            return true;

            for (j = 3; j <= q - 1; j++)
            {
                if (q % j == 0)
                    return false;
            }
            if (q == j)
                return true;
            return true;
        }
        public int GetN(int p, int q) //calculates n
        {
            int n = p * q;
            return n;
        }




        private void Calculation_Copy_Click(object sender, RoutedEventArgs e)
        {
            BigInteger ePrime = int.Parse(eTextBox.Text);

            int c = 1;
            for (int i = 0; i < ePrime; i++)
            {
                c = (int)(c * dPrivate % n);
                c = (int)(c % n);
            }


            c = (int)(ePrime % z);
            dPrivate = 1 / c;

            ePublicKey1.Text = ePrime.ToString();
            nPublicKey1.Text = nTextBox.Text;
            dPrivateKey1.Text = dPrivate.ToString();
            nPrivateKey1.Text = nTextBox.Text;
        }



        private void Calculation_Click(object sender, RoutedEventArgs e)
        {
            BigInteger p = int.Parse(TextBox1.Text);
            BigInteger q = int.Parse(TextBox2.Text);
            if (p % 2 != 0)
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

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            enTextBox1.Text = "";
            enTextBox2.Text = "";
            enTextBox3.Text = "";
            enTextBox4.Text = "";
            enTextBox5.Text = "";

        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            Encrypt();
        }

        private void GetValues()
        {
            e = int.Parse(enTextBox1.Text);
            n = int.Parse(enTextBox2.Text);

        }


        private void Encrypt()
        {

            text = enTextBox3.Text.ToString();
            strLength = text.Length;
            e = int.Parse(enTextBox1.Text);
            n = int.Parse(enTextBox2.Text);
            int cipherInt;

            

            List<int> numbers = new List<int>();
            List<string> hex = new List<string>();

            char[] letters = text.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {   
               
                cipherInt = Convert.ToInt32(letters[i]);
                m = cipherInt;
                int c = 1; 
                for ( int k = 0; k < e; k++)
                {
                    c = c * m % (int)n;
                    c = c % (int)n;
                    numbers.Add(c);
                    numS = c.ToString("X4");
                    hex.Add(numS);
                }
                
                foreach (int mynum in numbers)
                {

                    enTextBox4.Text = mynum.ToString();
                    Console.WriteLine(mynum.ToString());
                }

                foreach(string myhex in hex)
                {
                    enTextBox5.Text = myhex.ToString();
                }

                //    foreach(int item in numArr)
                {
                //    numArr[i] += num;
              //      enTextBox4.Text= item.ToString() + ",";
                }
            }
            
        }

        

    }
}
