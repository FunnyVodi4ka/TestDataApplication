using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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

namespace test_demo_exam_04.MainPages
{
    /// <summary>
    /// Логика взаимодействия для AddEditUser.xaml
    /// </summary>
    public partial class AddEditUser : Page
    {
        FirstTable currentRow = new FirstTable();
        ValidationClass validation = new ValidationClass();
        string SaveFilename, newImageName;

        public AddEditUser(FirstTable row)
        {
            InitializeComponent();
            try
            {
                SetIDSecond();
                currentRow = row;

                if (currentRow.ID != 0)
                {
                    FindIDSecond();
                    DataContext = currentRow;
                }
            }
            catch
            {
                MessageBox.Show("Critical error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FindIDSecond()
        {
            var row = AppConnect.model0db.SecondTable.FirstOrDefault(x => x.ID == currentRow.IDsecond);
            cbIDSecond.SelectedItem = row.Name;
        }

        private void SetIDSecond()
        {
            cbIDSecond.Items.Add("Choose IDSecond");

            foreach (var item in AppConnect.model0db.SecondTable)
            {
                cbIDSecond.Items.Add(item.Name);
            }

            cbIDSecond.SelectedIndex = 0;
        }

        private bool CheckAllData()
        {
            if (!validation.CheckStringData(tbName.Text))
            {
                MessageBox.Show("Error name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (currentRow.ID != 0 && pbPassword.Password.Length <= 0) { }
            else
            {
                if (!validation.CheckPassword(pbPassword.Password))
                {
                    MessageBox.Show("Error password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
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
            if(!CheckIDSecond())
            {
                MessageBox.Show("Error idSecond", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private bool CheckIDSecond()
        {
            var row = AppConnect.model0db.SecondTable.FirstOrDefault(x => x.Name == cbIDSecond.SelectedItem.ToString());
            if (row != null)
            {
                currentRow.IDsecond = row.ID;
                return true;
            }
            return false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CheckAllData())
            {
                try
                {
                    currentRow.Name = tbName.Text;
                    if (currentRow.ID != 0 && pbPassword.Password.Length <= 0) { }
                    else
                    {
                        currentRow.Password = pbPassword.Password;
                    }
                    currentRow.Email = tbEmail.Text;
                    currentRow.Phone = tbPhone.Text;
                    
                    currentRow.Cost = Int32.Parse(tbCost.Text);
                    currentRow.Date = DateTime.Parse(dpDate.Text);
                    if (SaveFilename != null) {
                        LoadImageInDirectory();
                        currentRow.ImageOfTable = newImageName;
                    }

                    if (currentRow.ID == 0)
                    {
                        AppConnect.model0db.FirstTable.Add(currentRow);
                    }

                    Entities.GetContext().SaveChanges();
                    AppConnect.model0db.SaveChanges();

                    MessageBox.Show("Save is good", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    AppFrame.frameMain.Navigate(new MenuUserList());
                }
                catch
                {
                    MessageBox.Show("Critical error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnLoadImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();

                Random rnd = new Random();
                newImageName = rnd.Next(10000, 100000).ToString() + rnd.Next(10000, 100000).ToString() + ".png";

                SaveFilename = dialog.FileName;
                lbImage.Text = newImageName;
            }
            catch { }
        }

        private void LoadImageInDirectory()
        {
            try
            {
                File.Copy(SaveFilename, System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Resources\\UserImages\\" + newImageName);
            }
            catch
            {
                MessageBox.Show("Load image error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new MenuUserList());
        }
    }
}
