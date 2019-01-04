using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace GamesDB_MVVMLight_EntityFramework.Model
{
    public interface IDataService
    {
        void GetValetData(Action<ObservableCollection<Valet_OnView>, DateTime> callback);
        void SetValetData(Action<bool> callback, ObservableCollection<Valet_OnView> valetOnViews, DateTime dt);
        void LoadValetData(Action<ObservableCollection<Valet_OnView>, bool> callback, DateTime dt);


        void GetThousandData(Action<ObservableCollection<Thousand_OnView>, DateTime> callback);
        void SetThousandData(Action<bool> callback, ObservableCollection<Thousand_OnView> thousandOnViews, DateTime dt, int Con);
        void LoadThousandData(Action<ObservableCollection<Thousand_OnView>, bool> callback, DateTime dt);
        ObservableCollection<Thousand_OnView> NewThousands();

        void GetDyrData(Action<ObservableCollection<Dyr_OnView>, DateTime, string[]> callback);
        void SetDyrData(Action<bool> callback, ObservableCollection<Dyr_OnView> dyrOnViews, DateTime dt);
        void LoadDyrData(Action<ObservableCollection<Dyr_OnView>, bool> callback, DateTime dt);


        void GetMutData(Action<ObservableCollection<Mut_OnView>, DateTime> callback);
        void SetMutData(Action<bool> callback, ObservableCollection<Mut_OnView> mutOnViews, DateTime dt);
        void LoadMutData(Action<ObservableCollection<Mut_OnView>, bool> callback, DateTime dt);
        ObservableCollection<Mut_OnView> NewMuts();
        

        void GetGameDayData(Action<ObservableCollection<GameDay_OnView>, DateTime> callback);
        void SetGameDayData(Action<bool> callback, ObservableCollection<GameDay_OnView> gameDayOnViews, DateTime dt);
        void LoadGameDayData(Action<ObservableCollection<GameDay_OnView>, bool> callback, DateTime dt);


        void GetNiceData(Action<string, DateTime> callback);
        void SetNiceData(Action<bool> callback, string comment, DateTime dt);
        void LoadNiceData(Action<string, bool> callback, DateTime dt);

        void GetAbsoluteValues(Action<ObservableCollection<AllStatistic_OnView>> callback, DateTime from, DateTime to);
        void GetRelativeValues(Action<ObservableCollection<AllStatistic_OnView>> callback, DateTime from, DateTime to);
    }
}