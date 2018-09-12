using System.Windows;
using System;
using GamesDB_MVVMLight_EntityFramework.ViewModels;

namespace GamesDB_MVVMLight_EntityFramework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void ButtonMenu1_Click(object sender, RoutedEventArgs e)
        {
            ButtonMenu1.Margin = new Thickness(0, 0, 0, 0);
            ButtonMenu2.Margin = new Thickness(310, 0, 0, 0);
            MyMainFrame.Navigate(new Uri("Views/NewGameView.xaml", UriKind.Relative));
        }
    }
}