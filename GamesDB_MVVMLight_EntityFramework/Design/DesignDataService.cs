using System;
using GamesDB_MVVMLight_EntityFramework.Model;
using System.Collections.ObjectModel;

namespace GamesDB_MVVMLight_EntityFramework.Design
{
    public class DesignDataService : IDataService
    {
        public void GetValetData(Action<ObservableCollection<Valet_OnView>, DateTime> callback) { }
        public void SetValetData(ObservableCollection<Valet_OnView> valetOnViews, DateTime dt) { }
        public void LoadValetData(Action<ObservableCollection<Valet_OnView>> callback, DateTime dt) { }


        public void GetThousandData(Action<ObservableCollection<Thousand_OnView>, DateTime> callback) { }
        public void SetThousandData(ObservableCollection<Thousand_OnView> thousandOnViews, DateTime dt, int Con) { }
        public void LoadThousandData(Action<ObservableCollection<Thousand_OnView>> callback, DateTime dt) { }


        public void GetDyrData(Action<ObservableCollection<Dyr_OnView>, DateTime, string[]> callback) { }
        public void SetDyrData(ObservableCollection<Dyr_OnView> dyrOnViews, DateTime dt) { }
        public void LoadDyrData(Action<ObservableCollection<Dyr_OnView>> callback, DateTime dt) { }


        public void GetMutData(Action<ObservableCollection<Mut_OnView>, DateTime> callback) { }
        public void SetMutData(ObservableCollection<Mut_OnView> mutOnViews, DateTime dt) { }
        public void LoadMutData(Action<ObservableCollection<Mut_OnView>> callback, DateTime dt) { }


        public void GetGameDayData(Action<ObservableCollection<GameDay_OnView>, DateTime> callback) { }
        public void SetGameDayData(ObservableCollection<GameDay_OnView> gameDayOnViews, DateTime dt) { }
        public void LoadGameDayData(Action<ObservableCollection<GameDay_OnView>> callback, DateTime dt) { }


        public void GetNiceData(Action<string, DateTime> callback) { }
        public void SetNiceData(string comment, DateTime dt) { }
        public void LoadNiceData(Action<string> callback, DateTime dt) { }
    }
}