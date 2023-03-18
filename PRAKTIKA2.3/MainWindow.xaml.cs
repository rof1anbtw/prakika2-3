using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PRAKTIKA2._3.Praktik2DataSet2TableAdapters;

namespace PRAKTIKA2._3
{
   
    public partial class MainWindow : Window
    {
        ordersTableAdapter ordersAdapter = new ordersTableAdapter();
        usersTableAdapter usersAdapter = new usersTableAdapter();   
        int ID = 0;
        public MainWindow()
        {
            InitializeComponent();
            OrdersDG.ItemsSource = ordersAdapter.GetData();
            ComboBox.ItemsSource = usersAdapter.GetData();
            ComboBox.DisplayMemberPath = "id";
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = (ComboBox.SelectedItem as DataRowView).Row[0];
            ID = (int)cell;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ordersAdapter.InsertQuery(ID, TEXT1.Text, TEXT2.Text);

            OrdersDG.ItemsSource = ordersAdapter.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object del = (OrdersDG.SelectedItem as DataRowView).Row[0];
            ordersAdapter.DeleteQuery(Convert.ToInt32(del));

            OrdersDG.ItemsSource = ordersAdapter.GetData();
        }
    }
}
