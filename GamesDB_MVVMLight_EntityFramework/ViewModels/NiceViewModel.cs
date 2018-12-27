using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GamesDB_MVVMLight_EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB_MVVMLight_EntityFramework.ViewModels
{
    public class NiceViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        private DateTime _gamedate;
        public DateTime GameDate
        {
            get => _gamedate;
            set
            {
                Set(ref _gamedate, value);
                _dataService.LoadNiceData((item, played) =>
                {
                    Comment = item;
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

        private string _comment;
        public string Comment
        {
            get => _comment;
            set => Set(ref _comment, value);
        }

        public RelayCommand _setNice;

        public RelayCommand SetNice
        {
            get
            {
                return _setNice ??
                       (_setNice = new RelayCommand(() => _dataService.SetNiceData((played)=> IsNotPlayed = played, Comment, GameDate)));
            }
        }

        public NiceViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetNiceData((item, date) =>
            {
                GameDate = date;
                Comment = item;
            });
        }
    }
}
