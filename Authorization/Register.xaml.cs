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

namespace test_demo_exam_04.Authorization
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        FirstTable currentRow = new FirstTable();
        ValidationClass validation = new ValidationClass();
        public Register()
        {
            InitializeComponent();
        }

        private bool CheckAllData()
        {
            if(!validation.CheckStringData(tbName.Text))
            {
                MessageBox.Show("Error name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!validation.CheckPassword(pbPassword.Password))
            {
                MessageBox.Show("Error password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!validation.CheckEmail(tbEmail.Text))
            {
                MessageBox.Show("Error email", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!validation.CheckPhone(tbPhone.Text))
            {
                MessageBox.Show("Error phone", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!validation.CheckIntData(tbCost.Text))
            {
                MessageBox.Show("Error cost", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!validation.CheckDateOfBirth(dpDate.Text))
            {
                MessageBox.Show("Error date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if(CheckAllData())
            {
                try
                {
                    currentRow.Name = tbName.Text;
                    currentRow.Password = pbPassword.Password;
                    currentRow.Email = tbEmail.Text;
                    currentRow.Phone = tbPhone.Text;
                    var idSecond = AppConnect.model0db.SecondTable.FirstOrDefault(x => x.Name == "Test1");
                    currentRow.IDsecond = idSecond.ID;
                    currentRow.Cost = Int32.Parse(tbCost.Text);
                    currentRow.Date = DateTime.Parse(dpDate.Text);

                    AppConnect.model0db.FirstTable.Add(currentRow);

                    Entities.GetContext().SaveChanges();
                    AppConnect.model0db.SaveChanges();

                    MessageBox.Show("Register is good", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    AppFrame.frameMain.Navigate(new Login());
                }
                catch
                {
                    MessageBox.Show("Critical error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Login());
        }
    }
}
