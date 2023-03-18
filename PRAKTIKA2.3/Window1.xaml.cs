using PRAKTIKA2._3.Praktik2DataSet2TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace PRAKTIKA2._3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ordersTableAdapter ordersAdapter = new ordersTableAdapter();
        usersTableAdapter usersAdapter = new usersTableAdapter();
        public Window1()
        {
            InitializeComponent();
            OrdersDG.ItemsSource = usersAdapter.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            usersAdapter.InsertQuery(TEXT1.Text, TEXT2.Text);
            OrdersDG.ItemsSource = usersAdapter.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object del = (OrdersDG.SelectedItem as DataRowView).Row[0];
            usersAdapter.DeleteQuery(Convert.ToInt32(del));

            OrdersDG.ItemsSource = usersAdapter.GetData();
        }
    }
}
