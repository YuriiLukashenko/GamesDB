using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GamesDB_MVVMLight_EntityFramework.Model;

namespace GamesDB_MVVMLight_EntityFramework.ViewModels
{
    public class StatisticPageViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        public StatisticPageViewModel(IDataService dataService)
        {
            _dataService = dataService;
            FromDate = DateTime.Today;
            ToDate = DateTime.Today;
        }

        private ObservableCollection<AllStatistic_OnView> _observableAbsolute;

        public ObservableCollection<AllStatistic_OnView> ObservableAbsolute
        {
            get => _observableAbsolute;
            set => Set(ref _observableAbsolute, value);
        }

        private ObservableCollection<AllStatistic_OnView> _observableRelative;

        public ObservableCollection<AllStatistic_OnView> ObservableRelative
        {
            get => _observableRelative;
            set => Set(ref _observableRelative, value);
        }

        private DateTime _fromDate;
        public DateTime FromDate
        {
            get => _fromDate;
            set => Set(ref _fromDate, value);
        }

        private DateTime _toDate;
        public DateTime ToDate
        {
            get => _toDate;
            set => Set(ref _toDate, value);
        }

        private RelayCommand _getStatisticInIntervalCommand;

        public RelayCommand GetStatisticInIntervalCommand
        {
            get
            {
                return _getStatisticInIntervalCommand ??
                       (_getStatisticInIntervalCommand = new RelayCommand(() => GetStatistic(FromDate, ToDate)));
            }
        }

        void GetStatistic(DateTime FromDate, DateTime ToDate)
        {
            _dataService.GetAbsoluteValues((item) => ObservableAbsolute = item, FromDate, ToDate);
            _dataService.GetRelativeValues((item) => ObservableRelative = item, FromDate, ToDate);
        }
    }
}