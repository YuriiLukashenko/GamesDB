using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GamesDB_MVVMLight_EntityFramework.Model;

namespace GamesDB_MVVMLight_EntityFramework.ViewModels
{
    public class MutViewModel: ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly IDataService _dataService;

       public static int Con = 1;

        private DateTime _gamedate;
        public DateTime GameDate
        {
            get => _gamedate;
            set
            {
                _gamedate = value;
                RaisePropertyChanged("GameDate");
            }
        }

        private string _umut;
        public string Umut
        {
            get => _umut;
            set
            {
                _umut = value;
                RaisePropertyChanged("Umut");
            } 
        }

        private string _wmut;
        public string Wmut
        {
            get => _wmut;
            set
            {
                _wmut = value;
                RaisePropertyChanged("Wmut");
            }
        }

        private string _amut;
        public string Amut
        {
            get => _amut;
            set
            {
                _amut = value;
                RaisePropertyChanged("Amut");
            }
        }

        private ObservableCollection<Mut_OnView> _observableMuts;

        public ObservableCollection<Mut_OnView> ObservableMuts
        {
            get => _observableMuts;
            set
            {
                _observableMuts = value;
                RaisePropertyChanged("ObservableMuts");
            }
        }

        public RelayCommand _update;

        public RelayCommand Update
        {
            get { return _update ?? (_update = new RelayCommand(UpdateMuts)); }
        }

        public void UpdateMuts()
        {
            int Ures = 0;
            string [] Usplit = Umut.Split('+');
            foreach (string s in Usplit)
            {
                Ures += Convert.ToInt32(s);
            }

            int Wres = 0;
            string[] Wsplit = Wmut.Split('+');
            foreach (string s in Wsplit)
            {
                Wres += Convert.ToInt32(s);
            }

            int Ares = 0;
            string[] Asplit = Amut.Split('+');
            foreach (string s in Asplit)
            {
                Ares += Convert.ToInt32(s);
            }

            if (Con == 1)
            {
                ObservableMuts.First(n => n.Кто == Enums.Whoes.U).Кон1 = Ures;
                ObservableMuts.First(n => n.Кто == Enums.Whoes.W).Кон1 = Wres;
                ObservableMuts.First(n => n.Кто == Enums.Whoes.A).Кон1 = Ares;
                Umut = "";
                Wmut = "";
                Amut = "";
            }
            else if (Con == 2)
            {
                ObservableMuts.First(n => n.Кто == Enums.Whoes.U).Кон2 = Ures;
                ObservableMuts.First(n => n.Кто == Enums.Whoes.W).Кон2 = Wres;
                ObservableMuts.First(n => n.Кто == Enums.Whoes.A).Кон2 = Ares;
                Umut = "";
                Wmut = "";
                Amut = "";
            }
            else if (Con == 3)
            {
                ObservableMuts.First(n => n.Кто == Enums.Whoes.U).Кон3 = Ures;
                ObservableMuts.First(n => n.Кто == Enums.Whoes.W).Кон3 = Wres;
                ObservableMuts.First(n => n.Кто == Enums.Whoes.A).Кон3 = Ares;         
                Umut = "";
                Wmut = "";
                Amut = "";
            }
            Con++;
        }

        public RelayCommand _finish;

        public RelayCommand Finish
        {
            get { return _finish ?? (_finish = new RelayCommand(FinishMuts)); }
        }

        private void FinishMuts()
        {
            var v = ObservableMuts.First(n => n.Кто == Enums.Whoes.U);
            v.Всего = v.Кон1 + v.Кон2 + v.Кон3;

            v = ObservableMuts.First(n => n.Кто == Enums.Whoes.W);
            v.Всего = v.Кон1 + v.Кон2 + v.Кон3;

            v = ObservableMuts.First(n => n.Кто == Enums.Whoes.A);
            v.Всего = v.Кон1 + v.Кон2 + v.Кон3;

            int[] rel = M_relativation(ObservableMuts[0].Всего, ObservableMuts[1].Всего, ObservableMuts[2].Всего);
            for (int i = 0; i < 3; i++)
            {
                ObservableMuts[i].Место = rel[i];
            }
        }


        public int[] M_relativation(int u, int v, int a) //супер говнокод для перевода из абсолютного в относительный
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


        public RelayCommand _setMut;

        public RelayCommand SetMut
        {
            get
            {
                return _setMut ??
                       (_setMut = new RelayCommand(() => _dataService.SetMutData(ObservableMuts, GameDate)));
            }
        }


        public MutViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetMutData((item, date) =>
            {
                GameDate = date;
                ObservableMuts = item;
            });
        }
    }
}
