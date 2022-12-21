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
using test_demo_exam_04.ApplicationData;
using test_demo_exam_04.MainPages;

namespace test_demo_exam_04.Authorization
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        public static bool CheckUser(string login, string password)
        {
            var user = Entities.GetContext().FirstTable.FirstOrDefault(x => x.Name == login && x.Password == password);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = AppConnect.model0db.FirstTable.FirstOrDefault(x => x.Name == tbName.Text && x.Password == pbPassword.Password);
                if(user != null)
                {
                    SelectedUser.user = user;
                    AppFrame.frameMain.Navigate(new MenuUserList());
                }
                else
                {
                    MessageBox.Show("User not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Captcha captcha = new Captcha();
                    captcha.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Critical error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Register());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SelectedUser.user = null;
        }
    }
}
