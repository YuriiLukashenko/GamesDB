using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GamesDB_MVVMLight_EntityFramework.Model
{
    public interface IDataService
    {
        void GetValetData(Action<ObservableCollection<Valet_OnView>, DateTime> callback);
        void SetValetData(ObservableCollection<Valet_OnView> valetOnViews, DateTime dt);
        void LoadValetData(Action<ObservableCollection<Valet_OnView>> callback, DateTime dt);


        void GetThousandData(Action<ObservableCollection<Thousand_OnView>, DateTime> callback);
        void SetThousandData(ObservableCollection<Thousand_OnView> thousandOnViews, DateTime dt, int Con);
        void LoadThousandData(Action<ObservableCollection<Thousand_OnView>> callback, DateTime dt);


        void GetDyrData(Action<ObservableCollection<Dyr_OnView>, DateTime, string[]> callback);
        void SetDyrData(ObservableCollection<Dyr_OnView> dyrOnViews, DateTime dt);
        void LoadDyrData(Action<ObservableCollection<Dyr_OnView>> callback, DateTime dt);


        void GetMutData(Action<ObservableCollection<Mut_OnView>, DateTime> callback);
        void SetMutData(ObservableCollection<Mut_OnView> mutOnViews, DateTime dt);
        void LoadMutData(Action<ObservableCollection<Mut_OnView>> callback, DateTime dt);
        

        void GetGameDayData(Action<ObservableCollection<GameDay_OnView>, DateTime> callback);
        void SetGameDayData(ObservableCollection<GameDay_OnView> gameDayOnViews, DateTime dt);
        void LoadGameDayData(Action<ObservableCollection<GameDay_OnView>> callback, DateTime dt);


        void GetNiceData(Action<string, DateTime> callback);
        void SetNiceData(string comment, DateTime dt);
        void LoadNiceData(Action<string> callback, DateTime dt);
    }
}