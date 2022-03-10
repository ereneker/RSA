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
        BigInteger n, z, e,d;
        BigInteger dPrivate;
        String text,text2;
        string cipherText = "";

        int strLength;
        BigInteger[] numArr;
        int num ,m, decNum;
        string hex;
        int count = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

       
        public int calculateD(int z, int ePrime)
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


        public bool CheckPrimeNum() //checks if the number is prime or not
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
        public int calculateN(int p, int q) //calculates n
        {
            int n = p * q;
            return n;
        }




        private void Calculation_Copy_Click(object sender, RoutedEventArgs e)
        {
            BigInteger ePrime = int.Parse(eTextBox.Text);

            int c = 1;
    
            ePublicKey1.Text = ePrime.ToString();
            nPublicKey1.Text = nTextBox.Text;
            dPrivateKey1.Text = calculateD((int)z, (int)ePrime).ToString();
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

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            Decrypt();
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

            

          

           // char[] letters = text.ToCharArray();

            String letters = enTextBox3.Text;
            for (int i = 0; i < letters.Length; i++)
            {

                cipherInt = Convert.ToInt32(letters[i]);
                m = (int)BigInteger.ModPow(cipherInt, e, n);
                
               
                if (i == letters.Length - 1)
                {
                    enTextBox4.Text += m.ToString();
                    enTextBox5.Text += m.ToString("X4");
                }
                else
                {
                    enTextBox4.Text += m.ToString() + " ,";
                    enTextBox5.Text += m.ToString("X4");
                }

                    
              

            }




            /* for (int i = 0; i < letters.Length; i++)
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
             }*/

        }

        private void Decrypt()
        {
            text2 = enTextBox3_Copy.Text.ToString();
            d = int.Parse(enTextBox1_Copy.Text);
            n = int.Parse(enTextBox1_Copy1.Text);


            char[] letters = text2.ToCharArray();

            for (int i = 0; i <= text2.Length; i++)
            {
                count++;                        //039002B90247042901050273003502BF022002B9039C03EB02B9
                if (count == 4)
                {
                    hex += Convert.ToChar(text2[i - 1]);
                    int num = Convert.ToInt32(hex, 16);

                    count = 0;
                    decNum = (int)BigInteger.ModPow(num, Convert.ToInt32(d), Convert.ToInt32(n));
                    cipherText += Convert.ToChar(decNum);
                    if(i== letters.Length)
                    {
                        enTextBox3_Copy1.Text += num.ToString();
                    }
                    else
                    {
                        enTextBox3_Copy1.Text += num.ToString() + ",";
                        enTextBox3_Copy2.Text += cipherText;
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
