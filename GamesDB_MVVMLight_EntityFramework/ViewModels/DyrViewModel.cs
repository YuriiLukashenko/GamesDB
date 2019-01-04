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
    public class DyrViewModel: ViewModelBase
    {
        private readonly IDataService _dataService;
        public static int Con = 1;

        private DateTime _gameDate;
        public DateTime GameDate
        {
            get => _gameDate;
            set
            {
                Set(ref _gameDate, value);
                _dataService.LoadDyrData((item, played, pogony) =>
                {
                    ObservableDyrs = item;
                    IsNotPlayed = played;
                    UW = pogony[0];
                    UA = pogony[1];
                    WU = pogony[2];
                    WA = pogony[3];
                    AU = pogony[4];
                    AW = pogony[5];
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

        private ObservableCollection<Dyr_OnView> _observableDyrs;
        public ObservableCollection<Dyr_OnView> ObservableDyrs
        {
            get => _observableDyrs;
            set => Set(ref _observableDyrs, value);
        }

        private string _uw;
        public string UW
        {
            get => _uw;
            set => Set(ref _uw, value);
        }

        private string _ua;
        public string UA
        {
            get => _ua;
            set => Set(ref _ua, value);
        }

        private string _wu;
        public string WU
        {
            get => _wu;
            set => Set(ref _wu, value);
        }

        private string _wa;
        public string WA
        {
            get => _wa;
            set => Set(ref _wa, value);
        }

        private string _au;
        public string AU
        {
            get => _au;
            set => Set(ref _au, value);
        }

        private string _aw;
        public string AW
        {
            get => _aw;
            set => Set(ref _aw, value);
        }

        public DyrViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetDyrData((item, date, pogony) =>
            {
                GameDate = date;
                ObservableDyrs = item;
                UW = pogony[0];
                UA = pogony[1];
                WU = pogony[2];
                WA = pogony[3];
                AU = pogony[4];
                AW = pogony[5];
            });
        }

        public RelayCommand _setDyr;
        public RelayCommand SetDyr
        {
            get { return _setDyr ?? (_setDyr = new RelayCommand(() => _dataService.SetDyrData((played) => IsNotPlayed = played, ObservableDyrs, GameDate))); }
        }

        public RelayCommand _update;

        public RelayCommand Update
        {
            get { return _update ?? (_update = new RelayCommand(UpdateDyrs)); }
        }

        private void UpdateDyrs()
        {
            var v = ObservableDyrs.First(n => n.Кто == Enums.Whoes.U);
            v.Всего = (Convert.ToInt32(v.Кон1) + Convert.ToInt32(v.Кон2) + Convert.ToInt32(v.Кон3)).ToString();

            v = ObservableDyrs.First(n => n.Кто == Enums.Whoes.W);
            v.Всего = (Convert.ToInt32(v.Кон1) + Convert.ToInt32(v.Кон2) + Convert.ToInt32(v.Кон3)).ToString();

            v = ObservableDyrs.First(n => n.Кто == Enums.Whoes.A);
            v.Всего = (Convert.ToInt32(v.Кон1) + Convert.ToInt32(v.Кон2) + Convert.ToInt32(v.Кон3)).ToString();

            string [] rel = D_relativation(
                Convert.ToInt32(ObservableDyrs[0].Всего),
                Convert.ToInt32(ObservableDyrs[1].Всего),
                Convert.ToInt32(ObservableDyrs[2].Всего)
                );
            for (int i = 0; i < 3; i++)
            {
                ObservableDyrs[i].Место = rel[i];
            }
        }

        private string[] D_relativation(int u, int v, int a)
        {
            string[] fortest = new string[3];
            string maxdex = "u";
            int max = u;
            if (v >= u && v >= a)
            {
                max = v;
                maxdex = "v";
            }
            if (a >= u && a >= v)
            {
                max = a;
                maxdex = "a";
            }
            #region Govnokod_maxdex_U
            if (maxdex == "u")
            {
                fortest[0] = "1";
                if (u == v && u == a)
                {
                    fortest[1] = "1";
                    fortest[2] = "1";
                }
                else if (u == v)
                {
                    fortest[1] = "1";
                    fortest[2] = "2";
                }
                else if (u == a)
                {
                    fortest[1] = "2";
                    fortest[2] = "1";
                }
                else if (v == a)
                {
                    fortest[1] = "2";
                    fortest[2] = "2";
                }
                else if (v > a)
                {
                    fortest[1] = "2";
                    fortest[2] = "3";
                }
                else if (a > v)
                {
                    fortest[1] = "3";
                    fortest[2] = "2";
                }
            }
            #endregion
            #region Govnokod_maxdex_V
            if (maxdex == "v")
            {
                fortest[1] = "1";
                if (v == u && v == a)
                {
                    fortest[0] = "1";
                    fortest[2] = "1";
                }
                else if (v == u)
                {
                    fortest[0] = "1";
                    fortest[2] = "2";
                }
                else if (v == a)
                {
                    fortest[0] = "2";
                    fortest[2] = "1";
                }
                else if (u == a)
                {
                    fortest[0] = "2";
                    fortest[2] = "2";
                }
                else if (u > a)
                {
                    fortest[0] = "2";
                    fortest[2] = "3";
                }
                else if (a > u)
                {
                    fortest[0] = "3";
                    fortest[2] = "2";
                }
            }
            #endregion
            #region Govnokod_maxdex_A
            if (maxdex == "a")
            {
                fortest[2] = "1";
                if (a == u && a == v)
                {
                    fortest[0] = "1";
                    fortest[1] = "1";
                }
                else if (a == u)
                {
                    fortest[0] = "1";
                    fortest[1] = "2";
                }
                else if (a == v)
                {
                    fortest[0] = "2";
                    fortest[1] = "1";
                }
                else if (u == v)
                {
                    fortest[0] = "2";
                    fortest[1] = "2";
                }
                else if (u > v)
                {
                    fortest[0] = "2";
                    fortest[1] = "3";
                }
                else if (v > u)
                {
                    fortest[0] = "3";
                    fortest[1] = "2";
                }
            }

            #endregion
            return fortest;
        }
    }
}
