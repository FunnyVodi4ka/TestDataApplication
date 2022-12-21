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
using test_demo_exam_04.Authorization;

namespace test_demo_exam_04
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                AppConnect.model0db = new Entities();
                AppFrame.frameMain = frmMain;

                frmMain.Navigate(new Login());
            }
            catch
            {
                MessageBox.Show("Critical error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            SelectedUser.user = null;
            frmMain.Navigate(new Login());
        }
    }
}
