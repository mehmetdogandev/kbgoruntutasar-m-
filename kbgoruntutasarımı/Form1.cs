using System;
using System.Windows.Forms;

namespace kbgoruntutasarımı
{
    public partial class Form1 : Form
    {
        private Random[] randoms;
        private double[] lowerBounds;
        private double[] upperBounds;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 800; // 800 milisaniyede bir çalışacak
            timer1.Tick += timer1_Tick;

            // Rastgele nesneler ve sınırları başlat
            randoms = new Random[10];
            lowerBounds = new double[10];
            upperBounds = new double[10];

            for (int i = 0; i < randoms.Length; i++)
            {
                randoms[i] = new Random(Guid.NewGuid().GetHashCode()); // Farklı tohumlar
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Her label için rastgele veriler üret
            label1.Text = GenerateRandomValue(0).ToString("0.###");
            label4.Text = GenerateRandomValue(1).ToString("0.###");
            label5.Text = GenerateRandomValue(2).ToString("0.###");
            label6.Text = GenerateRandomValue(3).ToString("0.###");
            label7.Text = GenerateRandomValue(4).ToString("0.###");
            label8.Text = GenerateRandomValue(5).ToString("0.###");
            label9.Text = GenerateRandomValue(6).ToString("0.###");
            label10.Text = GenerateRandomValue(7).ToString("0.###");
            // Diğer etiketlere benzer şekilde atanabilir
        }

        private double GenerateRandomValue(int index)
        {
            return randoms[index].NextDouble() * (upperBounds[index] - lowerBounds[index]) + lowerBounds[index];
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            double degisken;

            if (double.TryParse(textBox3.Text, out degisken))
            {
                // TextBox'a girilen değeri al
                if (double.TryParse(textBox1.Text, out double inputValue))
                {
                    // Her label için alt ve üst değerleri belirle
                    for (int i = 0; i < lowerBounds.Length; i++)
                    {
                        lowerBounds[i] = inputValue - degisken;
                        upperBounds[i] = inputValue + degisken;
                    }

                    // Timer'ı başlat
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir sayı girin.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir sayı girin.");
            }
        }






    }
}

