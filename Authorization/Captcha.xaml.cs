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
using System.Windows.Shapes;

namespace test_demo_exam_04.Authorization
{
    /// <summary>
    /// Логика взаимодействия для Captcha.xaml
    /// </summary>
    public partial class Captcha : Window
    {
        string rightText;
        public Captcha()
        {
            InitializeComponent();
            ReloadData();
        }

        public void ReloadData()
        {
            rightText = "";
            string arrayChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";
            Random rnd = new Random();
            for(int i = 0; i < 5; i++)
            {
                rightText += arrayChars[rnd.Next(arrayChars.Length)];
            }
            lbCaptcha.Text = rightText;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if(tbCaptcha.Text == rightText)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("No, try again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ReloadData();
            }
        }
    }
}
