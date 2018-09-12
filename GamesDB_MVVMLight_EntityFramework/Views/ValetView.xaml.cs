using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using GamesDB_MVVMLight_EntityFramework.ViewModels;

namespace GamesDB_MVVMLight_EntityFramework.Views
{
    /// <summary>
    /// Логика взаимодействия для ValetView.xaml
    /// </summary>
    public partial class ValetView : Page
    {
        public ValetView()
        {
            InitializeComponent();
        }

        private void ButtonValet_OnClick(object sender, RoutedEventArgs e)
        {

            var rows = MyDataGrid.DataContext as ValetViewModel;

            var collection = rows.ObservableValets;

        }

        private void Test_OnClick(object sender, RoutedEventArgs e)
        {
            MyDataGrid.Items.Refresh();
        }

    }
}
