using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GamesDB_MVVMLight_EntityFramework.Model;

namespace GamesDB_MVVMLight_EntityFramework.ViewModels
{
    public class ThousandViewModel: ViewModelBase
    {
        private readonly IDataService _dataService;
        public static int Con = 0;

        private DateTime _gameDate;
        public DateTime GameDate
        {
            get => _gameDate;
            set
            {
                Set(ref _gameDate, value);
                _dataService.LoadThousandData((item, played) =>
                {
                    ObservableThousands = item;
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

        private ObservableCollection<Thousand_OnView> _observableThousands;
        public ObservableCollection<Thousand_OnView> ObservableThousands
        {
            get => _observableThousands;
            set => Set(ref _observableThousands, value);
        }

        private RelayCommand _setThousand;
        public RelayCommand SetThousand
        {
            get
            {
                return _setThousand ?? (_setThousand = new RelayCommand(() => 
                           _dataService.SetThousandData(
                               (played) => IsNotPlayed = played,
                               ObservableThousands,
                               GameDate,
                               Con)));
            }
        }

        public ThousandViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetThousandData((item, date) =>
            {
                GameDate = date;
                ObservableThousands = item;
            });
            U_bolt_count = 0;
            U_bolt_color = new SolidColorBrush(Colors.GreenYellow);
            U_rosp_count = 0;
            U_rosp_color = new SolidColorBrush(Colors.GreenYellow);

            W_bolt_count = 0;
            W_bolt_color = new SolidColorBrush(Colors.GreenYellow);
            W_rosp_count = 0;
            W_rosp_color = new SolidColorBrush(Colors.GreenYellow);

            A_bolt_count = 0;
            A_bolt_color = new SolidColorBrush(Colors.GreenYellow);
            A_rosp_count = 0;
            A_rosp_color = new SolidColorBrush(Colors.GreenYellow);
        }

        #region Uprops

        private string _u_stav;
        public string Ustav
        {
            get => _u_stav;
            set => Set(ref _u_stav, value);
        }

        private string _u_res;
        public string Ures
        {
            get => _u_res;
            set => Set(ref _u_res, value);
        }

        private bool _is_ua;
        public bool Is_ua
        {
            get => _is_ua;
            set => Set(ref _is_ua, value);
        }

        private bool _is_uh;
        public bool Is_uh
        {
            get => _is_uh;
            set => Set(ref _is_uh, value);
        }

        private bool _is_ud;
        public bool Is_ud
        {
            get => _is_ud;
            set => Set(ref _is_ud, value);
        }

        private bool _is_uc;
        public bool Is_uc
        {
            get => _is_uc;
            set => Set(ref _is_uc, value);
        }

        private bool _is_us;
        public bool Is_us
        {
            get => _is_us;
            set => Set(ref _is_us, value);
        }

        private string _u_full;
        public string U_full
        {
            get => _u_full;
            set => Set(ref _u_full, value);
        }
        #endregion Uprops

        #region U болт
        private int _u_bolt_count;
        public int U_bolt_count
        {
            get => _u_bolt_count;
            set => Set(ref _u_bolt_count, value);
        }

        private SolidColorBrush _u_bolt_color;
        public SolidColorBrush U_bolt_color
        {
            get => _u_bolt_color;
            set => Set(ref _u_bolt_color, value);
        }

        private RelayCommand _u_bolt_inc;

        public RelayCommand U_bolt_inc
        {
            get
            {
                return _u_bolt_inc ?? (_u_bolt_inc = new RelayCommand(() => UBoltInc()));
            }
        }
        private void UBoltInc()
        {
            U_bolt_count++;
            if (U_bolt_count % 2 == 0)
            {
                U_bolt_color = new SolidColorBrush(Colors.GreenYellow);
                Ures = (Convert.ToInt32(Ures) - 100).ToString();
            }
            else
            {
                U_bolt_color = new SolidColorBrush(Colors.OrangeRed);
            }
        }

        #endregion Uболт

        #region U роспись
        //U-роспись
        private int _u_rosp_count;
        public int U_rosp_count
        {
            get => _u_rosp_count;
            set => Set(ref _u_rosp_count, value);
        }

        private SolidColorBrush _u_rosp_color;
        public SolidColorBrush U_rosp_color
        {
            get => _u_rosp_color;
            set => Set(ref _u_rosp_color, value);
        }

        private RelayCommand _u_rosp_inc;

        public RelayCommand U_rosp_inc
        {
            get
            {
                return _u_rosp_inc ?? (_u_rosp_inc = new RelayCommand(() => URospInc()));
            }
        }

        private void URospInc()
        {
            U_rosp_count++;
            if (U_rosp_count % 2 == 0)
            {
                U_rosp_color = new SolidColorBrush(Colors.GreenYellow);
                Ures = (Convert.ToInt32(Ures) - 100).ToString();
            }
            else
            {
                U_rosp_color = new SolidColorBrush(Colors.OrangeRed);
            }
        }

        #endregion


        #region Wprops

        private string _w_stav;
        public string Wstav
        {
            get => _w_stav;
            set => Set(ref _w_stav, value);
        }

        private string _w_res;
        public string Wres
        {
            get => _w_res;
            set => Set(ref _w_res, value);
        }

        private bool _is_wa;
        public bool Is_wa
        {
            get => _is_wa;
            set => Set(ref _is_wa, value);
        }

        private bool _is_wh;
        public bool Is_wh
        {
            get => _is_wh;
            set => Set(ref _is_wh, value);
        }

        private bool _is_wd;
        public bool Is_wd
        {
            get => _is_wd;
            set => Set(ref _is_wd, value);
        }

        private bool _is_wc;
        public bool Is_wc
        {
            get => _is_wc;
            set => Set(ref _is_wc, value);
        }

        private bool _is_ws;
        public bool Is_ws
        {
            get => _is_ws;
            set => Set(ref _is_ws, value);
        }

        private string _w_full;
        public string W_full
        {
            get => _w_full;
            set => Set(ref _w_full, value);
        }

        #endregion

        #region W болт
        private int _w_bolt_count;
        public int W_bolt_count
        {
            get => _w_bolt_count;
            set => Set(ref _w_bolt_count, value);
        }

        private SolidColorBrush _w_bolt_color;
        public SolidColorBrush W_bolt_color
        {
            get => _w_bolt_color;
            set => Set(ref _w_bolt_color, value);
        }

        private RelayCommand _w_bolt_inc;

        public RelayCommand W_bolt_inc
        {
            get
            {
                return _w_bolt_inc ?? (_w_bolt_inc = new RelayCommand(() => WBoltInc()));
            }
        }
        private void WBoltInc()
        {
            W_bolt_count++;
            if (W_bolt_count % 2 == 0)
            {
                W_bolt_color = new SolidColorBrush(Colors.GreenYellow);
                Wres = (Convert.ToInt32(Wres) - 100).ToString();
            }
            else
            {
                W_bolt_color = new SolidColorBrush(Colors.OrangeRed);
            }
        }

        #endregion

        #region W роспись
        //U-роспись
        private int _w_rosp_count;
        public int W_rosp_count
        {
            get => _w_rosp_count;
            set => Set(ref _w_rosp_count, value);
        }

        private SolidColorBrush _w_rosp_color;
        public SolidColorBrush W_rosp_color
        {
            get => _w_rosp_color;
            set => Set(ref _w_rosp_color, value);
        }

        private RelayCommand _w_rosp_inc;

        public RelayCommand W_rosp_inc
        {
            get
            {
                return _w_rosp_inc ?? (_w_rosp_inc = new RelayCommand(() => WRospInc()));
            }
        }

        private void WRospInc()
        {
            W_rosp_count++;
            if (W_rosp_count % 2 == 0)
            {
                W_rosp_color = new SolidColorBrush(Colors.GreenYellow);
                Wres = (Convert.ToInt32(Wres) - 100).ToString();
            }
            else
            {
                W_rosp_color = new SolidColorBrush(Colors.OrangeRed);
            }
        }

        #endregion


        #region Aprops

        private string _a_stav;
        public string Astav
        {
            get => _a_stav;
            set => Set(ref _a_stav, value);
        }

        private string _a_res;
        public string Ares
        {
            get => _a_res;
            set => Set(ref _a_res, value);
        }

        private bool _is_aa;
        public bool Is_aa
        {
            get => _is_aa;
            set => Set(ref _is_aa, value);
        }

        private bool _is_ah;
        public bool Is_ah
        {
            get => _is_ah;
            set => Set(ref _is_ah, value);
        }

        private bool _is_ad;
        public bool Is_ad
        {
            get => _is_ad;
            set => Set(ref _is_ad, value);
        }

        private bool _is_ac;
        public bool Is_ac
        {
            get => _is_ac;
            set => Set(ref _is_ac, value);
        }

        private bool _is_as;
        public bool Is_as
        {
            get => _is_as;
            set => Set(ref _is_as, value);
        }

        private string _a_full;
        public string A_full
        {
            get => _a_full;
            set => Set(ref _a_full, value);
        }

        #endregion

        #region A болт
        private int _a_bolt_count;
        public int A_bolt_count
        {
            get => _a_bolt_count;
            set => Set(ref _a_bolt_count, value);
        }

        private SolidColorBrush _a_bolt_color;
        public SolidColorBrush A_bolt_color
        {
            get => _a_bolt_color;
            set => Set(ref _a_bolt_color, value);
        }

        private RelayCommand _a_bolt_inc;

        public RelayCommand A_bolt_inc
        {
            get
            {
                return _a_bolt_inc ?? (_a_bolt_inc = new RelayCommand(() => ABoltInc()));
            }
        }
        private void ABoltInc()
        {
            A_bolt_count++;
            if (A_bolt_count % 2 == 0)
            {
                A_bolt_color = new SolidColorBrush(Colors.GreenYellow);
                Ares = (Convert.ToInt32(Ares) - 100).ToString();
            }
            else
            {
                A_bolt_color = new SolidColorBrush(Colors.OrangeRed);
            }
        }

        #endregion

        #region A роспись
        //U-роспись
        private int _a_rosp_count;
        public int A_rosp_count
        {
            get => _a_rosp_count;
            set => Set(ref _a_rosp_count, value);
        }

        private SolidColorBrush _a_rosp_color;
        public SolidColorBrush A_rosp_color
        {
            get => _a_rosp_color;
            set => Set(ref _a_rosp_color, value);
        }

        private RelayCommand _a_rosp_inc;

        public RelayCommand A_rosp_inc
        {
            get
            {
                return _a_rosp_inc ?? (_a_rosp_inc = new RelayCommand(() => ARospInc()));
            }
        }

        private void ARospInc()
        {
            A_rosp_count++;
            if (A_rosp_count % 2 == 0)
            {
                A_rosp_color = new SolidColorBrush(Colors.GreenYellow);
                Ares = (Convert.ToInt32(Ares) - 100).ToString();
            }
            else
            {
                A_rosp_color = new SolidColorBrush(Colors.OrangeRed);
            }
        }

        #endregion

        private void ClearAll()
        {
            Ustav = "";
            Ures = "";
            Wstav = "";
            Wres = "";
            Astav = "";
            Ares = "";
            Is_ua = false;
            Is_uh = false;
            Is_ud = false;
            Is_uc = false;
            Is_us = false;
            Is_wa = false;
            Is_wh = false;
            Is_wd = false;
            Is_wc = false;
            Is_ws = false;
            Is_aa = false;
            Is_ah = false;
            Is_ad = false;
            Is_ac = false;
            Is_as = false;
        }

        private string UGetMarjStr()
        {
            string res="";
            if (Is_ua) res += "A,";
            if (Is_uh) res += "H,";
            if (Is_ud) res += "D,";
            if (Is_uc) res += "C,";
            if (Is_us) res += "S";
            res += ".";
            return res;
        }

        private string WGetMarjStr()
        {
            string res = "";
            if (Is_wa) res += "A,";
            if (Is_wh) res += "H,";
            if (Is_wd) res += "D,";
            if (Is_wc) res += "C,";
            if (Is_ws) res += "S";
            res += ".";
            return res;
        }

        private string AGetMarjStr()
        {
            string res = "";
            if (Is_aa) res += "A,";
            if (Is_ah) res += "H,";
            if (Is_ad) res += "D,";
            if (Is_ac) res += "C,";
            if (Is_as) res += "S";
            res += ".";
            return res;
        }

        public RelayCommand _update;

        public RelayCommand Update
        {
            get { return _update ?? (_update = new RelayCommand(UpdateThousands)); }
        }

        public void UpdateThousands()
        {
            ++Con;

            if (String.IsNullOrEmpty(Ustav)) Ustav = "0";
            if (String.IsNullOrEmpty(Wstav)) Wstav = "0";
            if (String.IsNullOrEmpty(Astav)) Astav = "0";
            if (String.IsNullOrEmpty(Ures)) Ures = "0";
            if (String.IsNullOrEmpty(Wres)) Wres = "0";
            if (String.IsNullOrEmpty(Ares)) Ares = "0";

            switch (Con)
            {
                case 1:
                    U_full = Ures;
                    W_full = Wres;
                    A_full = Ares;
                    #region Вынужденный говнокод Кон1
                    ObservableThousands[0].Кон1 = Ustav;
                    ObservableThousands[1].Кон1 = U_full;
                    ObservableThousands[2].Кон1 = UGetMarjStr();
                    ObservableThousands[3].Кон1 = U_bolt_count.ToString();
                    ObservableThousands[4].Кон1 = U_rosp_count.ToString();
                    ObservableThousands[5].Кон1 = Wstav;
                    ObservableThousands[6].Кон1 = W_full;
                    ObservableThousands[7].Кон1 = WGetMarjStr();
                    ObservableThousands[8].Кон1 = W_bolt_count.ToString();
                    ObservableThousands[9].Кон1 = W_rosp_count.ToString();
                    ObservableThousands[10].Кон1 = Astav;
                    ObservableThousands[11].Кон1 = A_full;
                    ObservableThousands[12].Кон1 = AGetMarjStr();
                    ObservableThousands[13].Кон1 = A_bolt_count.ToString();
                    ObservableThousands[14].Кон1 = A_rosp_count.ToString();
                    #endregion
                    ClearAll();
                    break;
                case 2:
                    U_full = (Convert.ToInt32(Ures) + Convert.ToInt32(ObservableThousands[1].Кон1)).ToString();
                    W_full = (Convert.ToInt32(Wres) + Convert.ToInt32(ObservableThousands[6].Кон1)).ToString();
                    A_full = (Convert.ToInt32(Ares) + Convert.ToInt32(ObservableThousands[11].Кон1)).ToString();
                    if (Convert.ToInt32(U_full) == 555) { U_full = "0"; }
                    if (Convert.ToInt32(W_full) == 555) { W_full = "0"; }
                    if (Convert.ToInt32(A_full) == 555) { A_full = "0"; }
                    #region Вынужденный говнокод Кон2
                    ObservableThousands[0].Кон2 = Ustav;
                    ObservableThousands[1].Кон2 = U_full;
                    ObservableThousands[2].Кон2 = UGetMarjStr();
                    ObservableThousands[3].Кон2 = U_bolt_count.ToString();
                    ObservableThousands[4].Кон2 = U_rosp_count.ToString();
                    ObservableThousands[5].Кон2 = Wstav;
                    ObservableThousands[6].Кон2 = W_full;
                    ObservableThousands[7].Кон2 = WGetMarjStr();
                    ObservableThousands[8].Кон2 = W_bolt_count.ToString();
                    ObservableThousands[9].Кон2 = W_rosp_count.ToString();
                    ObservableThousands[10].Кон2 = Astav;
                    ObservableThousands[11].Кон2 = A_full;
                    ObservableThousands[12].Кон2 = AGetMarjStr();
                    ObservableThousands[13].Кон2 = A_bolt_count.ToString();
                    ObservableThousands[14].Кон2 = A_rosp_count.ToString();
                    #endregion
                    ClearAll();
                    break;
                case 3:
                    U_full = (Convert.ToInt32(Ures) + Convert.ToInt32(ObservableThousands[1].Кон2)).ToString();
                    W_full = (Convert.ToInt32(Wres) + Convert.ToInt32(ObservableThousands[6].Кон2)).ToString();
                    A_full = (Convert.ToInt32(Ares) + Convert.ToInt32(ObservableThousands[11].Кон2)).ToString();
                    if (Convert.ToInt32(U_full) == 555) { U_full = "0"; }
                    if (Convert.ToInt32(W_full) == 555) { W_full = "0"; }
                    if (Convert.ToInt32(A_full) == 555) { A_full = "0"; }
                    #region Вынужденный говнокод Кон3
                    ObservableThousands[0].Кон3 = Ustav;
                    ObservableThousands[1].Кон3 = U_full;
                    ObservableThousands[2].Кон3 = UGetMarjStr();
                    ObservableThousands[3].Кон3 = U_bolt_count.ToString();
                    ObservableThousands[4].Кон3 = U_rosp_count.ToString();
                    ObservableThousands[5].Кон3 = Wstav;
                    ObservableThousands[6].Кон3 = W_full;
                    ObservableThousands[7].Кон3 = WGetMarjStr();
                    ObservableThousands[8].Кон3 = W_bolt_count.ToString();
                    ObservableThousands[9].Кон3 = W_rosp_count.ToString();
                    ObservableThousands[10].Кон3 = Astav;
                    ObservableThousands[11].Кон3 = A_full;
                    ObservableThousands[12].Кон3 = AGetMarjStr();
                    ObservableThousands[13].Кон3 = A_bolt_count.ToString();
                    ObservableThousands[14].Кон3 = A_rosp_count.ToString();
                    #endregion
                    ClearAll();
                    break;
                case 4:
                    U_full = (Convert.ToInt32(Ures) + Convert.ToInt32(ObservableThousands[1].Кон3)).ToString();
                    W_full = (Convert.ToInt32(Wres) + Convert.ToInt32(ObservableThousands[6].Кон3)).ToString();
                    A_full = (Convert.ToInt32(Ares) + Convert.ToInt32(ObservableThousands[11].Кон3)).ToString();
                    if (Convert.ToInt32(U_full) == 555) { U_full = "0"; }
                    if (Convert.ToInt32(W_full) == 555) { W_full = "0"; }
                    if (Convert.ToInt32(A_full) == 555) { A_full = "0"; }
                    #region Вынужденный говнокод Кон4
                    ObservableThousands[0].Кон4 = Ustav;
                    ObservableThousands[1].Кон4 = U_full;
                    ObservableThousands[2].Кон4 = UGetMarjStr();
                    ObservableThousands[3].Кон4 = U_bolt_count.ToString();
                    ObservableThousands[4].Кон4 = U_rosp_count.ToString();
                    ObservableThousands[5].Кон4 = Wstav;
                    ObservableThousands[6].Кон4 = W_full;
                    ObservableThousands[7].Кон4 = WGetMarjStr();
                    ObservableThousands[8].Кон4 = W_bolt_count.ToString();
                    ObservableThousands[9].Кон4 = W_rosp_count.ToString();
                    ObservableThousands[10].Кон4 = Astav;
                    ObservableThousands[11].Кон4 = A_full;
                    ObservableThousands[12].Кон4 = AGetMarjStr();
                    ObservableThousands[13].Кон4 = A_bolt_count.ToString();
                    ObservableThousands[14].Кон4 = A_rosp_count.ToString();
                    #endregion
                    ClearAll();
                    break;
                case 5:
                    U_full = (Convert.ToInt32(Ures) + Convert.ToInt32(ObservableThousands[1].Кон4)).ToString();
                    W_full = (Convert.ToInt32(Wres) + Convert.ToInt32(ObservableThousands[6].Кон4)).ToString();
                    A_full = (Convert.ToInt32(Ares) + Convert.ToInt32(ObservableThousands[11].Кон4)).ToString();
                    if (Convert.ToInt32(U_full) == 555) { U_full = "0"; }
                    if (Convert.ToInt32(W_full) == 555) { W_full = "0"; }
                    if (Convert.ToInt32(A_full) == 555) { A_full = "0"; }
                    #region Вынужденный говнокод Кон5
                    ObservableThousands[0].Кон5 = Ustav;
                    ObservableThousands[1].Кон5 = U_full;
                    ObservableThousands[2].Кон5 = UGetMarjStr();
                    ObservableThousands[3].Кон5 = U_bolt_count.ToString();
                    ObservableThousands[4].Кон5 = U_rosp_count.ToString();
                    ObservableThousands[5].Кон5 = Wstav;
                    ObservableThousands[6].Кон5 = W_full;
                    ObservableThousands[7].Кон5 = WGetMarjStr();
                    ObservableThousands[8].Кон5 = W_bolt_count.ToString();
                    ObservableThousands[9].Кон5 = W_rosp_count.ToString();
                    ObservableThousands[10].Кон5 = Astav;
                    ObservableThousands[11].Кон5 = A_full;
                    ObservableThousands[12].Кон5 = AGetMarjStr();
                    ObservableThousands[13].Кон5 = A_bolt_count.ToString();
                    ObservableThousands[14].Кон5 = A_rosp_count.ToString();
                    #endregion
                    ClearAll();
                    break;
                case 6:
                    U_full = (Convert.ToInt32(Ures) + Convert.ToInt32(ObservableThousands[1].Кон5)).ToString();
                    W_full = (Convert.ToInt32(Wres) + Convert.ToInt32(ObservableThousands[6].Кон5)).ToString();
                    A_full = (Convert.ToInt32(Ares) + Convert.ToInt32(ObservableThousands[11].Кон5)).ToString();
                    if (Convert.ToInt32(U_full) == 555) { U_full = "0"; }
                    if (Convert.ToInt32(W_full) == 555) { W_full = "0"; }
                    if (Convert.ToInt32(A_full) == 555) { A_full = "0"; }
                    #region Вынужденный говнокод Кон6
                    ObservableThousands[0].Кон6 = Ustav;
                    ObservableThousands[1].Кон6 = U_full;
                    ObservableThousands[2].Кон6 = UGetMarjStr();
                    ObservableThousands[3].Кон6 = U_bolt_count.ToString();
                    ObservableThousands[4].Кон6 = U_rosp_count.ToString();
                    ObservableThousands[5].Кон6 = Wstav;
                    ObservableThousands[6].Кон6 = W_full;
                    ObservableThousands[7].Кон6 = WGetMarjStr();
                    ObservableThousands[8].Кон6 = W_bolt_count.ToString();
                    ObservableThousands[9].Кон6 = W_rosp_count.ToString();
                    ObservableThousands[10].Кон6 = Astav;
                    ObservableThousands[11].Кон6 = A_full;
                    ObservableThousands[12].Кон6 = AGetMarjStr();
                    ObservableThousands[13].Кон6 = A_bolt_count.ToString();
                    ObservableThousands[14].Кон6 = A_rosp_count.ToString();
                    #endregion
                    ClearAll();
                    break;
                case 7:
                    U_full = (Convert.ToInt32(Ures) + Convert.ToInt32(ObservableThousands[1].Кон6)).ToString();
                    W_full = (Convert.ToInt32(Wres) + Convert.ToInt32(ObservableThousands[6].Кон6)).ToString();
                    A_full = (Convert.ToInt32(Ares) + Convert.ToInt32(ObservableThousands[11].Кон6)).ToString();
                    if (Convert.ToInt32(U_full) == 555) { U_full = "0"; }
                    if (Convert.ToInt32(W_full) == 555) { W_full = "0"; }
                    if (Convert.ToInt32(A_full) == 555) { A_full = "0"; }
                    #region Вынужденный говнокод Кон7
                    ObservableThousands[0].Кон7 = Ustav;
                    ObservableThousands[1].Кон7 = U_full;
                    ObservableThousands[2].Кон7 = UGetMarjStr();
                    ObservableThousands[3].Кон7 = U_bolt_count.ToString();
                    ObservableThousands[4].Кон7 = U_rosp_count.ToString();
                    ObservableThousands[5].Кон7 = Wstav;
                    ObservableThousands[6].Кон7 = W_full;
                    ObservableThousands[7].Кон7 = WGetMarjStr();
                    ObservableThousands[8].Кон7 = W_bolt_count.ToString();
                    ObservableThousands[9].Кон7 = W_rosp_count.ToString();
                    ObservableThousands[10].Кон7 = Astav;
                    ObservableThousands[11].Кон7 = A_full;
                    ObservableThousands[12].Кон7 = AGetMarjStr();
                    ObservableThousands[13].Кон7 = A_bolt_count.ToString();
                    ObservableThousands[14].Кон7 = A_rosp_count.ToString();
                    #endregion
                    ClearAll();
                    break;
                case 8:
                    U_full = (Convert.ToInt32(Ures) + Convert.ToInt32(ObservableThousands[1].Кон7)).ToString();
                    W_full = (Convert.ToInt32(Wres) + Convert.ToInt32(ObservableThousands[6].Кон7)).ToString();
                    A_full = (Convert.ToInt32(Ares) + Convert.ToInt32(ObservableThousands[11].Кон7)).ToString();
                    if (Convert.ToInt32(U_full) == 555) { U_full = "0"; }
                    if (Convert.ToInt32(W_full) == 555) { W_full = "0"; }
                    if (Convert.ToInt32(A_full) == 555) { A_full = "0"; }
                    #region Вынужденный говнокод Кон8
                    ObservableThousands[0].Кон8 = Ustav;
                    ObservableThousands[1].Кон8 = U_full;
                    ObservableThousands[2].Кон8 = UGetMarjStr();
                    ObservableThousands[3].Кон8 = U_bolt_count.ToString();
                    ObservableThousands[4].Кон8 = U_rosp_count.ToString();
                    ObservableThousands[5].Кон8 = Wstav;
                    ObservableThousands[6].Кон8 = W_full;
                    ObservableThousands[7].Кон8 = WGetMarjStr();
                    ObservableThousands[8].Кон8 = W_bolt_count.ToString();
                    ObservableThousands[9].Кон8 = W_rosp_count.ToString();
                    ObservableThousands[10].Кон8 = Astav;
                    ObservableThousands[11].Кон8 = A_full;
                    ObservableThousands[12].Кон8 = AGetMarjStr();
                    ObservableThousands[13].Кон8 = A_bolt_count.ToString();
                    ObservableThousands[14].Кон8 = A_rosp_count.ToString();
                    #endregion
                    ClearAll();
                    break;
                case 9:
                    U_full = (Convert.ToInt32(Ures) + Convert.ToInt32(ObservableThousands[1].Кон8)).ToString();
                    W_full = (Convert.ToInt32(Wres) + Convert.ToInt32(ObservableThousands[6].Кон8)).ToString();
                    A_full = (Convert.ToInt32(Ares) + Convert.ToInt32(ObservableThousands[11].Кон8)).ToString();
                    if (Convert.ToInt32(U_full) == 555) { U_full = "0"; }
                    if (Convert.ToInt32(W_full) == 555) { W_full = "0"; }
                    if (Convert.ToInt32(A_full) == 555) { A_full = "0"; }
                    #region Вынужденный говнокод Кон9
                    ObservableThousands[0].Кон9 = Ustav;
                    ObservableThousands[1].Кон9 = U_full;
                    ObservableThousands[2].Кон9 = UGetMarjStr();
                    ObservableThousands[3].Кон9 = U_bolt_count.ToString();
                    ObservableThousands[4].Кон9 = U_rosp_count.ToString();
                    ObservableThousands[5].Кон9 = Wstav;
                    ObservableThousands[6].Кон9 = W_full;
                    ObservableThousands[7].Кон9 = WGetMarjStr();
                    ObservableThousands[8].Кон9 = W_bolt_count.ToString();
                    ObservableThousands[9].Кон9 = W_rosp_count.ToString();
                    ObservableThousands[10].Кон9 = Astav;
                    ObservableThousands[11].Кон9 = A_full;
                    ObservableThousands[12].Кон9 = AGetMarjStr();
                    ObservableThousands[13].Кон9 = A_bolt_count.ToString();
                    ObservableThousands[14].Кон9 = A_rosp_count.ToString();
                    #endregion
                    ClearAll();
                    break;
            }
        }


        public RelayCommand _finish;
        public RelayCommand Finish
        {
            get { return _finish ?? (_finish = new RelayCommand(FinishThousands)); }
        }

        public void FinishThousands()
        {
            //TODO: copy Govnokod from previous project (max => max) => U_full, W_full, A_full

            string[] rel = T_relativation(
                Convert.ToInt32(U_full),
                Convert.ToInt32(W_full),
                Convert.ToInt32(A_full)
                );
            #region Вынужденный говнокод Место
            ObservableThousands[0].Место = "";
            ObservableThousands[1].Место = rel[0];
            ObservableThousands[2].Место = "";
            ObservableThousands[3].Место = "";
            ObservableThousands[4].Место = "";
            ObservableThousands[5].Место = "";
            ObservableThousands[6].Место = rel[1];
            ObservableThousands[7].Место = "";
            ObservableThousands[8].Место = "";
            ObservableThousands[9].Место = "";
            ObservableThousands[10].Место = "";
            ObservableThousands[11].Место = rel[2];
            ObservableThousands[12].Место = "";
            ObservableThousands[13].Место = "";
            ObservableThousands[14].Место = "";
            #endregion
            ClearAll();
        }

        private RelayCommand _clean;

        public RelayCommand Clean
        {
            get { return _clean ?? (_clean = new RelayCommand(CleanAllToNewGame)); }
        }

        public void CleanAllToNewGame()
        {
            ClearAll();
            U_full = "";
            W_full = "";
            A_full = "";

            Con = 0;
            ObservableThousands.Clear();
            ObservableThousands = _dataService.NewThousands();
            U_bolt_count = 0;
            U_bolt_color = new SolidColorBrush(Colors.GreenYellow);
            U_rosp_count = 0;
            U_rosp_color = new SolidColorBrush(Colors.GreenYellow);

            W_bolt_count = 0;
            W_bolt_color = new SolidColorBrush(Colors.GreenYellow);
            W_rosp_count = 0;
            W_rosp_color = new SolidColorBrush(Colors.GreenYellow);

            A_bolt_count = 0;
            A_bolt_color = new SolidColorBrush(Colors.GreenYellow);
            A_rosp_count = 0;
            A_rosp_color = new SolidColorBrush(Colors.GreenYellow);
        }

        private string[] T_relativation(int u, int v, int a)
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
