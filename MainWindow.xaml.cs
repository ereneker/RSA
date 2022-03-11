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
        int strLength;
        BigInteger[] numArr;
        int num, m;
        string numS;


        public MainWindow()
        {
            InitializeComponent();
        }

        public bool PrimeNumberCheck() //checks if the number is prime or not
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
        public int GetN(int p, int q)
        {
            int n = p * q;
            return n;
        }
        BigInteger aCalculate;
        public int dCalculate(int z, int ePrime)
        {
          
            for (int i = 0; i < z; i++)
            {
                if (((z * i + 1) % ePrime) == 0)
                {
                    return (((z * i) + 1) / ePrime);
                    
                }
            }
            return 0;
        }


        private void Calculation_Copy_Click(object sender, RoutedEventArgs e)
        {
            

            int c = 1;
            //for (int i = 0; i < z; i++)
            //{
            //    if (((z * i + 1) % ePrime) == 0)
            //    {
            //        aCalculate = (((z * i) + 1) / ePrime);
            //    }
            //}
            

            BigInteger ePrime = int.Parse(eTextBox.Text);


            ePublicKey1.Text = ePrime.ToString();
            nPublicKey1.Text = nTextBox.Text;
            dPrivateKey1.Text =dCalculate((int)z, (int)ePrime).ToString();
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
            IfEIsNull(int.Parse(nTextBox.Text), int.Parse(zTextBox.Text));
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
            System.Environment.Exit(0);
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            Encrypt();
        }

        private void GetKeyValues()
        {
            e = int.Parse(enTextBox1.Text);
            n = int.Parse(enTextBox2.Text);

        }
        private int IfEIsNull(int n, int z)
        {
            Random random = new Random();
            int ePrime;
            while (true)
            {
                ePrime=random.Next(n);
                if (z % ePrime > 0 || z % ePrime < 0)
                {
                    if(PrimeNumberCheck())
                        return ePrime;
                }
            }

        }

        private void Encrypt()
        {

            String text = enTextBox3.Text.ToString();
            strLength = text.Length;
            GetKeyValues();
            int cipherInt;



            int numbers;
            List<string> hex = new List<string>();

            String letters = enTextBox3.Text;
            for (int i = 0; i < letters.Length; i++)
            {

                cipherInt = Convert.ToInt32(letters[i]);
                m = (int)BigInteger.ModPow(cipherInt, e, n);
                int c = 1;
                
                    numS = c.ToString("X4");
                    hex.Add(numS);
                    if (i == letters.Length - 1)
                    {
                        enTextBox4.Text += m.ToString();
                        enTextBox5.Text += m.ToString("X4");
                    }else
                    {
                        enTextBox4.Text += m.ToString()+" ,";
                        enTextBox5.Text+=m.ToString("X4");

                    }
                
                
                //for (int j = 0; j < numbers.Count; j++)
                //{
                //    enTextBox4.Text += numbers[j].ToString();
                //}
               
                //foreach (int mynum in numbers)
                //{

                //    enTextBox4.Text = mynum.ToString();
                //    Console.WriteLine(mynum.ToString());
                //}

                //foreach (string myhex in hex)
                //{
                //    enTextBox5.Text = myhex.ToString();
                //}

                //    foreach(int item in numArr)
                //{
                    //    numArr[i] += num;
                    //      enTextBox4.Text= item.ToString() + ",";
                //}
            }
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            Decrypt();
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            enTextBox1.Text = ePublicKey1.Text;
            enTextBox2.Text = nPublicKey1.Text;
        }

        private void Calculation_Copy2_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Calculation_Copy1_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            nTextBox.Text = "";
            zTextBox.Text = "";
            eTextBox.Text = "";
            ePublicKey1.Text = "";
            nPublicKey1.Text = "";
            dPrivateKey1.Text = "";
            nPrivateKey1.Text = "";
        }

        private void clearButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            enTextBox1_Copy.Text = "";
            enTextBox1_Copy1.Text = "";
            enTextBox3_Copy.Text = "";
            enTextBox3_Copy1.Text = "";
            enTextBox3_Copy2.Text = "";

        }

        private void exitButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void copyButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            enTextBox1_Copy.Text = dPrivateKey1.Text;
            enTextBox1_Copy1.Text = nPrivateKey1.Text;
        }

        int decNum;
        
        BigInteger d;

        private void Decrypt()
        {
            String text2 = enTextBox3_Copy.Text;
            String cipherText = "";
            string hex = "";


            int count = 0;
            char[] letters = text2.ToCharArray();

            for (int i = 0; i <= text2.Length; i++)
            {
                count++;                        //039002B90247042901050273003502BF022002B9039C03EB02B9
                if (count == 4)
                {
                    hex += Convert.ToChar(text2[i - 1]);
                    int num = Convert.ToInt32(hex, 16);

                    count = 0;
                    decNum = (int)BigInteger.ModPow(num, Convert.ToInt32(enTextBox1.Text), Convert.ToInt32(enTextBox1_Copy1.Text));
                    cipherText += Convert.ToChar(decNum);
                    if (i == text2.Length)
                    {
                        enTextBox3_Copy1.Text += num.ToString();
                    }
                    else
                    {
                        enTextBox3_Copy1.Text += num.ToString() + ",";
                        enTextBox3_Copy2.Text = cipherText;
                        hex = "";
                    }
                }
                else
                {
                    hex += Convert.ToChar(text2[i - 1]);
                }

            }
        }

    }
}