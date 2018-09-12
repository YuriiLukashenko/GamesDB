using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace GamesDB_MVVMLight_EntityFramework
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }
    }
}
