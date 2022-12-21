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

namespace test_demo_exam_04.MainPages
{
    /// <summary>
    /// Логика взаимодействия для MenuUserList.xaml
    /// </summary>
    public partial class MenuUserList : Page
    {
        public MenuUserList()
        {
            InitializeComponent();
            try
            {
                UsersList.ItemsSource = SortFilterRows();
                SetFilter();
                SetSort();
            }
            catch
            {
                MessageBox.Show("Critical error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SetFilter()
        {
            cbFilter.Items.Add("Choose filter");

            foreach(var item in AppConnect.model0db.SecondTable)
            {
                cbFilter.Items.Add(item.Name);
            }

            cbFilter.SelectedIndex = 0;
        }

        private void SetSort()
        {
            cbSort.Items.Add("Choose sort");
            cbSort.Items.Add("Po vozrastaniy");
            cbSort.Items.Add("Po ubivaniy");

            cbSort.SelectedIndex = 0;
        }

        FirstTable[] SortFilterRows()
        {
            List<FirstTable> rows = AppConnect.model0db.FirstTable.ToList();
            var allRows = rows;

            if(tbSearch.Text.Length > 0 )
            {
                rows = rows.Where(x => x.Name.Contains(tbSearch.Text)).ToList();
            }

            if(cbFilter.SelectedIndex > 0)
            {
                var id = AppConnect.model0db.SecondTable.FirstOrDefault(x => x.Name == cbFilter.SelectedItem.ToString());
                rows = rows.Where(x => x.IDsecond == id.ID).ToList();
            }

            switch(cbSort.SelectedIndex)
            {
                case 1:
                    rows = rows.OrderBy(x => x.Name).ToList(); 
                    break;
                case 2:
                    rows = rows.OrderByDescending(x => x.Name).ToList();
                    break;
            }

            if(rows.Count > 0)
            {
                lbCounter.Text = "Show " + rows.Count + " of " + allRows.Count;
            }
            else
            {
                lbCounter.Text = "Not found";
            }

            return rows.ToArray();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UsersList.ItemsSource = SortFilterRows();
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UsersList.ItemsSource = SortFilterRows();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UsersList.ItemsSource = SortFilterRows();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            FirstTable row = new FirstTable();
            AppFrame.frameMain.Navigate(new AddEditUser(row));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(UsersList.SelectedItem != null)
            {
                try
                {
                    if (MessageBox.Show("Are you ready?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var row = UsersList.SelectedItems.Cast<FirstTable>().ToList().ElementAt(0);
                        AppConnect.model0db.FirstTable.Remove(row);
                        AppConnect.model0db.SaveChanges();

                        MessageBox.Show("Delete is good", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        UsersList.ItemsSource = SortFilterRows();
                    }
                }
                catch
                {
                    MessageBox.Show("Delete error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Choose row for delete");
            }
        }

        private void UsersList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FirstTable row = UsersList.SelectedItem as FirstTable;
            NavigationService.Navigate(new AddEditUser(row));
        }
    }
}
