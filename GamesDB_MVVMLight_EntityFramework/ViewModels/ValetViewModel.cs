using GalaSoft.MvvmLight;
using GamesDB_MVVMLight_EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using GalaSoft.MvvmLight.Command;

namespace GamesDB_MVVMLight_EntityFramework.ViewModels
{
    public class ValetViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        private DateTime _gamedate;

        public DateTime GameDate
        {
            get => _gamedate;
            set
            {
                Set(ref _gamedate, value);
                _dataService.LoadValetData((item, played) =>
                {
                    ObservableValets = item;
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

        private ObservableCollection<Valet_OnView> _observableValets;

        public ObservableCollection<Valet_OnView> ObservableValets
        {
            get => _observableValets;
            set => Set(ref _observableValets, value);
        }

        public ValetViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetValetData((item, date) =>
            {
                GameDate = date;
                ObservableValets = item;
            });
        }

        public RelayCommand _setValet;
        
        public RelayCommand SetValet
        {
            get
            {
                return _setValet ??
                       (_setValet = new RelayCommand(() => _dataService.SetValetData((played) => IsNotPlayed = played, ObservableValets, GameDate)));
            }
        }

        public RelayCommand _update;

        public RelayCommand Update
        {
            get { return _update ?? (_update = new RelayCommand(UpdateValets)); }
        }

        public void UpdateValets()
        {
            var v = ObservableValets.First(n => n.Кто == Enums.Whoes.U);
            v.Всего = v.Кон1 + v.Кон2 + v.Кон3;

            v = ObservableValets.First(n => n.Кто == Enums.Whoes.W);
            v.Всего = v.Кон1 + v.Кон2 + v.Кон3;

            v = ObservableValets.First(n => n.Кто == Enums.Whoes.A);
            v.Всего = v.Кон1 + v.Кон2 + v.Кон3;

            int[] rel = V_relativation(ObservableValets[0].Всего, ObservableValets[1].Всего, ObservableValets[2].Всего);
            for (int i = 0; i < 3; i++)
            {
                ObservableValets[i].Место = rel[i];
            }
        }

        public int[] V_relativation(int u, int v, int a) //супер говнокод для перевода из абсолютного в относительный
        {
            int[] fortest = new int[3];
            string mindex = "u";
            int min = u;
            if (v <= u && v <= a)
            {
                min = v;
                mindex = "v";
            }

            if (a <= u && a <= v)
            {
                min = a;
                mindex = "a";
            }

            int U = 0, W = 0, A = 0;

            #region Govnokod_mindex_U

            if (mindex == "u")
            {
                U = 1;
                if (u == v && u == a)
                {
                    W = 1;
                    A = 1;
                }
                else if (u == v)
                {
                    W = 1;
                    A = 2;
                }
                else if (u == a)
                {
                    W = 2;
                    A = 1;
                }
                else if (v == a)
                {
                    W = 2;
                    A = 2;
                }
                else if (v < a)
                {
                    W = 2;
                    A = 3;
                }
                else if (a < v)
                {
                    W = 3;
                    A = 2;
                }
            }

            #endregion
            #region Govnokod_mindex_V

            if (mindex == "v")
            {
                W = 1;
                if (v == u && v == a)
                {
                    U = 1;
                    A = 1;
                }
                else if (v == u)
                {
                    U = 1;
                    A = 2;
                }
                else if (v == a)
                {
                    U = 2;
                    A = 1;
                }
                else if (u == a)
                {
                    U = 2;
                    A = 2;
                }
                else if (u < a)
                {
                    U = 2;
                    A = 3;
                }
                else if (a < u)
                {
                    U = 3;
                    A = 2;
                }
            }

            #endregion
            #region Govnokod_mindex_A

            if (mindex == "a")
            {
                A = 1;
                if (a == u && a == v)
                {
                    U = 1;
                    W = 1;
                }
                else if (a == u)
                {
                    U = 1;
                    W = 2;
                }
                else if (a == v)
                {
                    U = 2;
                    W = 1;
                }
                else if (u == v)
                {
                    U = 2;
                    W = 2;
                }
                else if (u < v)
                {
                    U = 2;
                    W = 3;
                }
                else if (v < u)
                {
                    U = 3;
                    W = 2;
                }
            }

            #endregion

            fortest[0] = U;
            fortest[1] = W;
            fortest[2] = A;
            return fortest;
        }
    }
}
