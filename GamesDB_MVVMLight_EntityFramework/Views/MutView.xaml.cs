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

namespace GamesDB_MVVMLight_EntityFramework.Views
{
    /// <summary>
    /// Interaction logic for MutView.xaml
    /// </summary>
    public partial class MutView : Page
    {
        public MutView()
        {
            InitializeComponent();
        }

        private void Test_OnClick(object sender, RoutedEventArgs e)
        {
            MyDataGrid.Items.Refresh();
            Umut.Text = "";
            Wmut.Text = "";
            Amut.Text = "";
        }

    }
}
