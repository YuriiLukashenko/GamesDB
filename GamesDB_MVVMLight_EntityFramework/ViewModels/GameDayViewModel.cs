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
    public class GameDayViewModel: ViewModelBase
    {
        private readonly IDataService _dataService;

        private DateTime _gameDate;
        public DateTime GameDate
        {
            get => _gameDate;
            set
            {
                Set(ref _gameDate, value);
                _dataService.LoadGameDayData((item, played) =>
                {
                    ObservableGameDay = item;
                    IsNotPlayed = played;
                }, GameDate);
            } 
        }

        private bool _isNotPlayed;
        public bool IsNotPlayed
        {
            get => _isNotPlayed;
            set
            {
                Set(ref _isNotPlayed, value);
            }
        }

        private ObservableCollection<GameDay_OnView> _observableGameDay;
        public ObservableCollection<GameDay_OnView> ObservableGameDay
        {
            get => _observableGameDay;
            set => Set(ref _observableGameDay, value);               
        }

        public GameDayViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetGameDayData((item, date) =>
            {
                GameDate = date;
                ObservableGameDay = item;
            });
        }

        public RelayCommand _setGameDay;

        public RelayCommand SetGameDay
        {
            get
            {
                return _setGameDay ??
                       (_setGameDay = new RelayCommand(() => _dataService.SetGameDayData((played)=>IsNotPlayed = played, ObservableGameDay, GameDate)));
            }
        }

        private RelayCommand _loadGameData;

        public RelayCommand LoadGameData
        {
            get
            {
                return _loadGameData ??
                       (_loadGameData = new RelayCommand(() => _dataService.LoadGameDayData((item, played) =>
                           {
                               ObservableGameDay = item;
                               IsNotPlayed = played;
                           }, GameDate)));
            }
        }
    }
}
