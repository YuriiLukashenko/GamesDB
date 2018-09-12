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

namespace GamesDB_MVVMLight_EntityFramework.View
{
    /// <summary>
    /// Логика взаимодействия для NewGameView.xaml
    /// </summary>
    public partial class NewGameView : Page
    {
        public NewGameView()
        {
            InitializeComponent();
        }

        private void ValetItem_Selected(object sender, RoutedEventArgs e)
        {
            MyNewGameFrame.Navigate(new Uri("Views/ValetView.xaml", UriKind.Relative));
        }

        private void ThousandItem_OnSelected(object sender, RoutedEventArgs e)
        {
            MyNewGameFrame.Navigate(new Uri("Views/ThousandView.xaml", UriKind.Relative));
        }

        private void MutItem_OnSelected(object sender, RoutedEventArgs e)
        {
            MyNewGameFrame.Navigate(new Uri("Views/MutView.xaml", UriKind.Relative));
        }

        private void NiceItem_OnSelected(object sender, RoutedEventArgs e)
        {
            MyNewGameFrame.Navigate(new Uri("Views/NiceView.xaml", UriKind.Relative));
        }

        private void DyrtItem_OnSelected(object sender, RoutedEventArgs e)
        {
            MyNewGameFrame.Navigate(new Uri("Views/DyrView.xaml", UriKind.Relative));
        }

        private void ResItem_OnSelected(object sender, RoutedEventArgs e)
        {
            MyNewGameFrame.Navigate(new Uri("Views/GameDayView.xaml", UriKind.Relative));
        }
    }
}
