using System;
using GamesDB_MVVMLight_EntityFramework.Model;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace GamesDB_MVVMLight_EntityFramework.Design
{
    public class DesignDataService : IDataService
    {
        public void GetValetData(Action<ObservableCollection<Valet_OnView>, DateTime> callback) { }
        public void SetValetData(Action<bool>callback, ObservableCollection<Valet_OnView> valetOnViews, DateTime dt) { }
        public void LoadValetData(Action<ObservableCollection<Valet_OnView>, bool> callback, DateTime dt) { }
        public bool IsValetExist(DateTime dt) { return true; }


        public void GetThousandData(Action<ObservableCollection<Thousand_OnView>, DateTime> callback) { }
        public void SetThousandData(Action<bool> callback, ObservableCollection<Thousand_OnView> thousandOnViews, DateTime dt, int Con) { }
        public void LoadThousandData(Action<ObservableCollection<Thousand_OnView>, bool> callback, DateTime dt) { }
        public ObservableCollection<Thousand_OnView> NewThousands()
        {
            return null;
        }

        public void GetDyrData(Action<ObservableCollection<Dyr_OnView>, DateTime, string[]> callback) { }
        public void SetDyrData(Action<bool> callback, ObservableCollection<Dyr_OnView> dyrOnViews, DateTime dt) { }
        public void LoadDyrData(Action<ObservableCollection<Dyr_OnView>, bool> callback, DateTime dt) { }


        public void GetMutData(Action<ObservableCollection<Mut_OnView>, DateTime> callback) { }
        public void SetMutData(Action<bool> callback, ObservableCollection<Mut_OnView> mutOnViews, DateTime dt) { }
        public void LoadMutData(Action<ObservableCollection<Mut_OnView>, bool> callback, DateTime dt) { }

        public ObservableCollection<Mut_OnView> NewMuts()
        {
            return null;
        }

        public void GetGameDayData(Action<ObservableCollection<GameDay_OnView>, DateTime> callback) { }
        public void SetGameDayData(Action<bool> callback, ObservableCollection<GameDay_OnView> gameDayOnViews, DateTime dt) { }
        public void LoadGameDayData(Action<ObservableCollection<GameDay_OnView>,bool> callback, DateTime dt) { }


        public void GetNiceData(Action<string, DateTime> callback) { }
        public void SetNiceData(Action<bool> callback, string comment, DateTime dt) { }
        public void LoadNiceData(Action<string, bool> callback, DateTime dt) { }

        public void GetAbsoluteValues(Action<ObservableCollection<AllStatistic_OnView>> callback, DateTime from, DateTime to) { }
        public void GetRelativeValues(Action<ObservableCollection<AllStatistic_OnView>> callback, DateTime from, DateTime to) { }
    }
}