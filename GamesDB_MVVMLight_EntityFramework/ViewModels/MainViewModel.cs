using GalaSoft.MvvmLight;
using GamesDB_MVVMLight_EntityFramework.Model;

namespace GamesDB_MVVMLight_EntityFramework.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        public string WelcomeTitle
        {
            get => _welcomeTitle;
            set => Set(ref _welcomeTitle, value);
        }

        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;            
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}