using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GamesDB_MVVMLight_EntityFramework.Views;

namespace GamesDB_MVVMLight_EntityFramework.Model
{
    public class DataService : IDataService
    {
        public static int countGames = 0;

        #region Valet:_GET,SET,LOAD

        public void GetValetData(Action<ObservableCollection<Valet_OnView>, DateTime> callback)
        {
            var valetOnViews = NewValets();
            DateTime dt = DateTime.Now;
            callback(valetOnViews, dt);
        }

        public void SetValetData(ObservableCollection<Valet_OnView> valetOnViews, DateTime dt)
        {
            ObservableCollection<Valet> OnValet = ParseOnView_To_Valet(valetOnViews, dt);
            using (var db = new UserContext())
            {
                foreach (Valet valet in OnValet)
                {
                    db.Valets.Add(valet);
                }
                db.SaveChanges();
            }
            MessageBox.Show("Валет сохранен.");
        }

        public void LoadValetData(Action<ObservableCollection<Valet_OnView>> callback, DateTime dt)
        {
            var observableValets = new ObservableCollection<Valet>();
            using (var db = new UserContext())
            {
                var valets = db.Valets;
                foreach (var valet in valets)
                {
                    if (valet.GameDate.Date == dt.Date)
                        observableValets.Add(valet);
                }
            }
            callback(ParseValet_To_OnView(observableValets));
        }

        #endregion


        #region Mut:_GET,SET,LOAD

        public void GetMutData(Action<ObservableCollection<Mut_OnView>, DateTime> callback)
        {
            var mutOnViews = NewMuts();
            DateTime dt = DateTime.Now;
            callback(mutOnViews, dt);
        }

        public void SetMutData(ObservableCollection<Mut_OnView> mutOnViews, DateTime dt)
        {
            ObservableCollection<Mut> OnMut = ParseOnView_To_Mut(mutOnViews, dt);
            using (var db = new UserContext())
            {
                foreach (Mut mut in OnMut)
                {
                    db.Muts.Add(mut);
                }
                db.SaveChanges();
            }

            MessageBox.Show("Муть сохранена.");
        }

        public void LoadMutData(Action<ObservableCollection<Mut_OnView>> callback, DateTime dt)
        {
            ObservableCollection<Mut> observableMuts = new ObservableCollection<Mut>();
            using (var db = new UserContext())
            {
                var muts = db.Muts;
                foreach (var mut in muts)
                {
                    if (mut.GameDate.Date == dt.Date)
                    {
                        observableMuts.Add(mut);
                    }
                }
            }
            callback(ParseMyt_To_OnView(observableMuts));
        }
        #endregion


        #region Nice:_GET,SET,LOAD

        public void GetNiceData(Action<string, DateTime> callback)
        {
            callback("Напишите здесь что-то", DateTime.Today);
        }

        public void SetNiceData(string comment, DateTime dt)
        {
            Nice nice = new Nice
            {
                Comment = comment,
                GameDate = dt
            };
            using (var db = new UserContext())
            {
                db.Nices.Add(nice);
                db.SaveChanges();
            }

            MessageBox.Show("Интересные факты сохранены.");
        }

        public void LoadNiceData(Action<string> callback, DateTime dt)
        {
            string str = String.Empty;
            using (var db = new UserContext())
            {
                var nices = db.Nices;
                foreach (var nice in nices)
                {
                    if (nice.GameDate.Date == dt.Date)
                    {
                        str = nice.Comment;
                    }
                }
            }
            callback(str);
        }
        #endregion


        #region Thousand_GET,SET,LOAD

        public void SetThousandData(ObservableCollection<Thousand_OnView> thousandOnViews, DateTime dt, int Con)
        {

            ObservableCollection<Thousand> OnThousand = ParseOnView_To_Thousand(thousandOnViews, dt, Con);
            using (var db = new UserContext())
            {
                foreach (Thousand thousand in OnThousand)
                {
                    db.Thousands.Add(thousand);
                }
                db.SaveChanges();
            }

            MessageBox.Show("Тысяча сохранена.");
        }

        public void GetThousandData(Action<ObservableCollection<Thousand_OnView>, DateTime> callback)
        {
            var thousandsOnViews = NewThousands();
            DateTime dt = DateTime.Now;
            callback(thousandsOnViews, dt);
        }

        public void LoadThousandData(Action<ObservableCollection<Thousand_OnView>> callback, DateTime dt)
        {
            ObservableCollection<Thousand> observableThousands = new ObservableCollection<Thousand>();
            using (var db = new UserContext())
            {
                var thousands = db.Thousands;
                foreach (var thousand in thousands)
                {
                    if (thousand.GameDate.Date == dt.Date)
                    {
                        observableThousands.Add(thousand);
                    }
                }
            }
            callback(ParseThousand_To_OnView(observableThousands));
        }

        #endregion


        #region Dyr_GET,SET,LOAD

        public void GetDyrData(Action<ObservableCollection<Dyr_OnView>, DateTime, string[]> callback)
        {
            var dyrsOnViews = NewDyrs();
            DateTime dt = DateTime.Now;
            string[] pogony = GetPogonyFromDb();

            callback(dyrsOnViews, dt, pogony);
        }

        public void SetDyrData(ObservableCollection<Dyr_OnView> dyrOnViews, DateTime dt)
        {
            ObservableCollection<Dyr> OnDyr = ParseOnView_To_Dyr(dyrOnViews, dt);
            using (var db = new UserContext())
            {
                foreach (Dyr dyr in OnDyr)
                {
                    db.Dyrs.Add(dyr);
                }
                db.SaveChanges();
            }
            MessageBox.Show("Дурь сохранена.");
        }

        public void LoadDyrData(Action<ObservableCollection<Dyr_OnView>> callback, DateTime dt)
        {
            ObservableCollection<Dyr> observableDyrs = new ObservableCollection<Dyr>();
            using (var db = new UserContext())
            {
                var dyrs = db.Dyrs;
                foreach (var dyr in dyrs)
                {
                    if (dyr.GameDate.Date == dt.Date)
                    {
                        observableDyrs.Add(dyr);
                    }
                }
            }
            callback(ParseDyr_To_OnView(observableDyrs));
        }

        #endregion

        private string[] GetPogonyFromDb()
        {
            string[] pogony = new string[6];
            int[] pered = new int [6];
            for (int i = 0; i < 6; i++) pered[i] = 0;
            using (var db = new UserContext())
            {
                var dyrs = db.Dyrs;
                foreach (var dyr in dyrs)
                {
                    if (dyr.UW == 1) pered[0]++;
                    if (dyr.UA == 1) pered[1]++;
                    if (dyr.WU == 1) pered[2]++;
                    if (dyr.WA == 1) pered[3]++;
                    if (dyr.AU == 1) pered[4]++;
                    if (dyr.AW == 1) pered[5]++;
                }
            }

            for (int i = 0; i < 6; i++)
            {
                switch (pered[i])
                {
                    case 0: pogony[i] = "Пока ничего"; break;
                    case 1: pogony[i] = "Шестерка"; break;
                    case 2: pogony[i] = "Семерка"; break;
                    case 3: pogony[i] = "Восьмерка"; break;
                    case 4: pogony[i] = "Девятка"; break;
                    case 5: pogony[i] = "Десятка"; break;
                    case 6: pogony[i] = "Валет"; break;
                    case 7: pogony[i] = "Дама"; break;
                    case 8: pogony[i] = "Король"; break;
                    case 9: pogony[i] = "Туз"; break;
                    case 10: pogony[i] = "Джокер"; break;
                }
            }

            return pogony;
        }

        #region GameDay:_GET,SET,LOAD

        public void GetGameDayData(Action<ObservableCollection<GameDay_OnView>, DateTime> callback)
        {
            //get from db
            ObservableCollection<GameDay> gameDay = new ObservableCollection<GameDay>();
            Valet valetToday = new Valet();
            Thousand thousandToday = new Thousand();
            Dyr dyrToday = new Dyr();
            Mut mutToday = new Mut();
            DateTime Today = DateTime.Today;
            using (var db = new UserContext())
            {
                var valets = db.Valets;
                foreach (var valet in valets)
                {
                    if (valet.GameDate.Date == DateTime.Today && valet.IdCone == 100)
                    {
                        valetToday = valet;
                        break;
                    }
                }
                var thousands = db.Thousands;
                foreach (var th in thousands)
                {
                    if (th.GameDate.Date == DateTime.Today && th.IdCone == 100)
                    {
                        thousandToday = th;
                        break;
                    }
                }
                var dyrs = db.Dyrs;
                foreach (var dyr in dyrs)
                {
                    if (dyr.GameDate.Date == DateTime.Today && dyr.IdCone == 100)
                    {
                        dyrToday = dyr;
                        break;
                    }
                }
                var muts = db.Muts;
                foreach (var mut in muts)
                {
                    if (mut.GameDate.Date == DateTime.Today && mut.IdCone == 100)
                    {
                        mutToday = mut;
                        break;
                    }
                }

                callback(ParseDb_To_GameDay(Today, valetToday, thousandToday, dyrToday, mutToday), Today);
            }
        }

        public void LoadGameDayData(Action<ObservableCollection<GameDay_OnView>> callback, DateTime dt)
        {
            ObservableCollection<GameDay> gameDay = new ObservableCollection<GameDay>();
            Valet valetToday = new Valet();
            Thousand thousandToday = new Thousand();
            Dyr dyrToday = new Dyr();
            Mut mutToday = new Mut();
            DateTime Today = dt.Date;
            using (var db = new UserContext())
            {
                var valets = db.Valets;
                foreach (var valet in valets)
                {
                    if (valet.GameDate.Date == Today && valet.IdCone == 100)
                    {
                        valetToday = valet;
                        break;
                    }
                }

                var thousands = db.Thousands;
                foreach (var th in thousands)
                {
                    if (th.GameDate.Date == Today && th.IdCone == 100)
                    {
                        thousandToday = th;
                        break;
                    }
                }

                var dyrs = db.Dyrs;
                foreach (var dyr in dyrs)
                {
                    if (dyr.GameDate.Date == Today && dyr.IdCone == 100)
                    {
                        dyrToday = dyr;
                        break;
                    }
                }

                var muts = db.Muts;
                foreach (var mut in muts)
                {
                    if (mut.GameDate.Date == Today && mut.IdCone == 100)
                    {
                        mutToday = mut;
                        break;
                    }
                }
            }
            callback(ParseDb_To_GameDay(Today, valetToday, thousandToday, dyrToday, mutToday));
        }

        public void SetGameDayData(ObservableCollection<GameDay_OnView> gameDayOnViews, DateTime dt)
        {
            ObservableCollection<GameDay> OnGameDay = ParseOnView_To_GameDay(gameDayOnViews, dt);
            using (var db = new UserContext())
            {
                foreach (GameDay gd in OnGameDay)
                {
                    db.GameDays.Add(gd);
                }
                db.SaveChanges();
            }
            MessageBox.Show("Игровой день сохранен.");
        }
        #endregion



        private ObservableCollection<Valet_OnView> ParseValet_To_OnView(ObservableCollection<Valet> valetsDb)
        {
            if (valetsDb == null || valetsDb.Count==0)
            {
                var valetOnViews = NewValets();
                return valetOnViews;
            }
            else
            {
                var valetOnViews = new ObservableCollection<Valet_OnView>
                {
                    new Valet_OnView()
                    {
                        Кто = Enums.Whoes.U,
                        Кон1 = valetsDb.First(n => n.IdCone == 1).U,
                        Кон2 = valetsDb.First(n => n.IdCone == 2).U,
                        Кон3 = valetsDb.First(n => n.IdCone == 3).U,
                        Всего = valetsDb.First(n => n.IdCone == 10).U,
                        Место = valetsDb.First(n => n.IdCone == 100).U
                    },
                    new Valet_OnView()
                    {
                        Кто = Enums.Whoes.W,
                        Кон1 = valetsDb.First(n => n.IdCone == 1).W,
                        Кон2 = valetsDb.First(n => n.IdCone == 2).W,
                        Кон3 = valetsDb.First(n => n.IdCone == 3).W,
                        Всего = valetsDb.First(n => n.IdCone == 10).W,
                        Место = valetsDb.First(n => n.IdCone == 100).W
                    },
                    new Valet_OnView()
                    {
                        Кто = Enums.Whoes.A,
                        Кон1 = valetsDb.First(n => n.IdCone == 1).A,
                        Кон2 = valetsDb.First(n => n.IdCone == 2).A,
                        Кон3 = valetsDb.First(n => n.IdCone == 3).A,
                        Всего = valetsDb.First(n => n.IdCone == 10).A,
                        Место = valetsDb.First(n => n.IdCone == 100).A
                    }
                };
                return valetOnViews;
            }
        }

        private ObservableCollection<Thousand_OnView> ParseThousand_To_OnView(ObservableCollection<Thousand> thousandsDb)
        {
            var thousandOnViews = NewThousands();
            if (thousandsDb == null || thousandsDb.Count == 0)
            {
                return thousandOnViews;
            }
            else
            {
                if (thousandsDb.Count >= 1)
                {
                    if (thousandsDb[0].IdCone == 100)
                    {
                        goto Relativation;
                    }
                    thousandOnViews[0].Кон1 = thousandsDb[0].Whoes == Enums.Whoes.U ? thousandsDb[0].Value.ToString() : "0";
                    thousandOnViews[1].Кон1 = thousandsDb[0].U.ToString();
                    thousandOnViews[2].Кон1 = thousandsDb[0].Umarj;
                    thousandOnViews[3].Кон1 = thousandsDb[0].Ubolt.ToString();
                    thousandOnViews[4].Кон1 = thousandsDb[0].Urosp.ToString();
                    thousandOnViews[5].Кон1 = thousandsDb[0].Whoes == Enums.Whoes.W ? thousandsDb[0].Value.ToString() : "0";
                    thousandOnViews[6].Кон1 = thousandsDb[0].W.ToString();
                    thousandOnViews[7].Кон1 = thousandsDb[0].Wmarj;
                    thousandOnViews[8].Кон1 = thousandsDb[0].Wbolt.ToString();
                    thousandOnViews[9].Кон1 = thousandsDb[0].Wrosp.ToString();
                    thousandOnViews[10].Кон1 = thousandsDb[0].Whoes == Enums.Whoes.A ? thousandsDb[0].Value.ToString() : "0";
                    thousandOnViews[11].Кон1 = thousandsDb[0].A.ToString();
                    thousandOnViews[12].Кон1 = thousandsDb[0].Amarj;
                    thousandOnViews[13].Кон1 = thousandsDb[0].Abolt.ToString();
                    thousandOnViews[14].Кон1 = thousandsDb[0].Arosp.ToString();
                }
                if (thousandsDb.Count >= 2)
                {
                    if (thousandsDb[1].IdCone == 100)
                    {
                        goto Relativation;
                    }
                    thousandOnViews[0].Кон2 = thousandsDb[1].Whoes == Enums.Whoes.U ? thousandsDb[1].Value.ToString() : "0";
                    thousandOnViews[1].Кон2 = thousandsDb[1].U.ToString();
                    thousandOnViews[2].Кон2 = thousandsDb[1].Umarj;
                    thousandOnViews[3].Кон2 = thousandsDb[1].Ubolt.ToString();
                    thousandOnViews[4].Кон2 = thousandsDb[1].Urosp.ToString();
                    thousandOnViews[5].Кон2 = thousandsDb[1].Whoes == Enums.Whoes.W ? thousandsDb[1].Value.ToString() : "0";
                    thousandOnViews[6].Кон2 = thousandsDb[1].W.ToString();
                    thousandOnViews[7].Кон2 = thousandsDb[1].Wmarj;
                    thousandOnViews[8].Кон2 = thousandsDb[1].Wbolt.ToString();
                    thousandOnViews[9].Кон2 = thousandsDb[1].Wrosp.ToString();
                    thousandOnViews[10].Кон2 = thousandsDb[1].Whoes == Enums.Whoes.A ? thousandsDb[1].Value.ToString() : "0";
                    thousandOnViews[11].Кон2 = thousandsDb[1].A.ToString();
                    thousandOnViews[12].Кон2 = thousandsDb[1].Amarj;
                    thousandOnViews[13].Кон2 = thousandsDb[1].Abolt.ToString();
                    thousandOnViews[14].Кон2 = thousandsDb[1].Arosp.ToString();
                }
                if (thousandsDb.Count >= 3)
                {
                    if (thousandsDb[2].IdCone == 100)
                    {
                        goto Relativation;
                    }
                    thousandOnViews[0].Кон3 = thousandsDb[2].Whoes == Enums.Whoes.U ? thousandsDb[2].Value.ToString() : "0";
                    thousandOnViews[1].Кон3 = thousandsDb[2].U.ToString();
                    thousandOnViews[2].Кон3 = thousandsDb[2].Umarj;
                    thousandOnViews[3].Кон3 = thousandsDb[2].Ubolt.ToString();
                    thousandOnViews[4].Кон3 = thousandsDb[2].Urosp.ToString();
                    thousandOnViews[5].Кон3 = thousandsDb[2].Whoes == Enums.Whoes.W ? thousandsDb[2].Value.ToString() : "0";
                    thousandOnViews[6].Кон3 = thousandsDb[2].W.ToString();
                    thousandOnViews[7].Кон3 = thousandsDb[2].Wmarj;
                    thousandOnViews[8].Кон3 = thousandsDb[2].Wbolt.ToString();
                    thousandOnViews[9].Кон3 = thousandsDb[2].Wrosp.ToString();
                    thousandOnViews[10].Кон3 = thousandsDb[2].Whoes == Enums.Whoes.A ? thousandsDb[2].Value.ToString() : "0";
                    thousandOnViews[11].Кон3 = thousandsDb[2].A.ToString();
                    thousandOnViews[12].Кон3 = thousandsDb[2].Amarj;
                    thousandOnViews[13].Кон3 = thousandsDb[2].Abolt.ToString();
                    thousandOnViews[14].Кон3 = thousandsDb[2].Arosp.ToString();
                }
                if (thousandsDb.Count >= 4)
                {
                    if (thousandsDb[3].IdCone == 100)
                    {
                        goto Relativation;
                    }
                    thousandOnViews[0].Кон4 = thousandsDb[3].Whoes == Enums.Whoes.U ? thousandsDb[3].Value.ToString() : "0";
                    thousandOnViews[1].Кон4 = thousandsDb[3].U.ToString();
                    thousandOnViews[2].Кон4 = thousandsDb[3].Umarj;
                    thousandOnViews[3].Кон4 = thousandsDb[3].Ubolt.ToString();
                    thousandOnViews[4].Кон4 = thousandsDb[3].Urosp.ToString();
                    thousandOnViews[5].Кон4 = thousandsDb[3].Whoes == Enums.Whoes.W ? thousandsDb[3].Value.ToString() : "0";
                    thousandOnViews[6].Кон4 = thousandsDb[3].W.ToString();
                    thousandOnViews[7].Кон4 = thousandsDb[3].Wmarj;
                    thousandOnViews[8].Кон4 = thousandsDb[3].Wbolt.ToString();
                    thousandOnViews[9].Кон4 = thousandsDb[3].Wrosp.ToString();
                    thousandOnViews[10].Кон4 = thousandsDb[3].Whoes == Enums.Whoes.A ? thousandsDb[3].Value.ToString() : "0";
                    thousandOnViews[11].Кон4 = thousandsDb[3].A.ToString();
                    thousandOnViews[12].Кон4 = thousandsDb[3].Amarj;
                    thousandOnViews[13].Кон4 = thousandsDb[3].Abolt.ToString();
                    thousandOnViews[14].Кон4 = thousandsDb[3].Arosp.ToString();
                }
                if (thousandsDb.Count >= 5)
                {
                    if (thousandsDb[4].IdCone == 100)
                    {
                        goto Relativation;
                    }
                    thousandOnViews[0].Кон5 = thousandsDb[4].Whoes == Enums.Whoes.U ? thousandsDb[4].Value.ToString() : "0";
                    thousandOnViews[1].Кон5 = thousandsDb[4].U.ToString();
                    thousandOnViews[2].Кон5 = thousandsDb[4].Umarj;
                    thousandOnViews[3].Кон5 = thousandsDb[4].Ubolt.ToString();
                    thousandOnViews[4].Кон5 = thousandsDb[4].Urosp.ToString();
                    thousandOnViews[5].Кон5 = thousandsDb[4].Whoes == Enums.Whoes.W ? thousandsDb[4].Value.ToString() : "0";
                    thousandOnViews[6].Кон5 = thousandsDb[4].W.ToString();
                    thousandOnViews[7].Кон5 = thousandsDb[4].Wmarj;
                    thousandOnViews[8].Кон5 = thousandsDb[4].Wbolt.ToString();
                    thousandOnViews[9].Кон5 = thousandsDb[4].Wrosp.ToString();
                    thousandOnViews[10].Кон5 = thousandsDb[4].Whoes == Enums.Whoes.A ? thousandsDb[4].Value.ToString() : "0";
                    thousandOnViews[11].Кон5 = thousandsDb[4].A.ToString();
                    thousandOnViews[12].Кон5 = thousandsDb[4].Amarj;
                    thousandOnViews[13].Кон5 = thousandsDb[4].Abolt.ToString();
                    thousandOnViews[14].Кон5 = thousandsDb[4].Arosp.ToString();
                }
                if (thousandsDb.Count >= 6)
                {
                    if (thousandsDb[5].IdCone == 100)
                    {
                        goto Relativation;
                    }
                    thousandOnViews[0].Кон6 = thousandsDb[5].Whoes == Enums.Whoes.U ? thousandsDb[5].Value.ToString() : "0";
                    thousandOnViews[1].Кон6 = thousandsDb[5].U.ToString();
                    thousandOnViews[2].Кон6 = thousandsDb[5].Umarj;
                    thousandOnViews[3].Кон6 = thousandsDb[5].Ubolt.ToString();
                    thousandOnViews[4].Кон6 = thousandsDb[5].Urosp.ToString();
                    thousandOnViews[5].Кон6 = thousandsDb[5].Whoes == Enums.Whoes.W ? thousandsDb[5].Value.ToString() : "0";
                    thousandOnViews[6].Кон6 = thousandsDb[5].W.ToString();
                    thousandOnViews[7].Кон6 = thousandsDb[5].Wmarj;
                    thousandOnViews[8].Кон6 = thousandsDb[5].Wbolt.ToString();
                    thousandOnViews[9].Кон6 = thousandsDb[5].Wrosp.ToString();
                    thousandOnViews[10].Кон6 = thousandsDb[5].Whoes == Enums.Whoes.A ? thousandsDb[5].Value.ToString() : "0";
                    thousandOnViews[11].Кон6 = thousandsDb[5].A.ToString();
                    thousandOnViews[12].Кон6 = thousandsDb[5].Amarj;
                    thousandOnViews[13].Кон6 = thousandsDb[5].Abolt.ToString();
                    thousandOnViews[14].Кон6 = thousandsDb[5].Arosp.ToString();
                }
                if (thousandsDb.Count >= 7)
                {
                    if (thousandsDb[6].IdCone == 100)
                    {
                        goto Relativation;
                    }
                    thousandOnViews[0].Кон7 = thousandsDb[6].Whoes == Enums.Whoes.U ? thousandsDb[6].Value.ToString() : "0";
                    thousandOnViews[1].Кон7 = thousandsDb[6].U.ToString();
                    thousandOnViews[2].Кон7 = thousandsDb[6].Umarj;
                    thousandOnViews[3].Кон7 = thousandsDb[6].Ubolt.ToString();
                    thousandOnViews[4].Кон7 = thousandsDb[6].Urosp.ToString();
                    thousandOnViews[5].Кон7 = thousandsDb[6].Whoes == Enums.Whoes.W ? thousandsDb[6].Value.ToString() : "0";
                    thousandOnViews[6].Кон7 = thousandsDb[6].W.ToString();
                    thousandOnViews[7].Кон7 = thousandsDb[6].Wmarj;
                    thousandOnViews[8].Кон7 = thousandsDb[6].Wbolt.ToString();
                    thousandOnViews[9].Кон7 = thousandsDb[6].Wrosp.ToString();
                    thousandOnViews[10].Кон7 = thousandsDb[6].Whoes == Enums.Whoes.A ? thousandsDb[6].Value.ToString() : "0";
                    thousandOnViews[11].Кон7 = thousandsDb[6].A.ToString();
                    thousandOnViews[12].Кон7 = thousandsDb[6].Amarj;
                    thousandOnViews[13].Кон7 = thousandsDb[6].Abolt.ToString();
                    thousandOnViews[14].Кон7 = thousandsDb[6].Arosp.ToString();
                }
                if(thousandsDb.Count >= 8)
                {
                    if (thousandsDb[7].IdCone == 100)
                    {
                        goto Relativation;
                    }
                    thousandOnViews[0].Кон8 = thousandsDb[7].Whoes == Enums.Whoes.U ? thousandsDb[7].Value.ToString() : "0";
                    thousandOnViews[1].Кон8 = thousandsDb[7].U.ToString();
                    thousandOnViews[2].Кон8 = thousandsDb[7].Umarj;
                    thousandOnViews[3].Кон8 = thousandsDb[7].Ubolt.ToString();
                    thousandOnViews[4].Кон8 = thousandsDb[7].Urosp.ToString();
                    thousandOnViews[5].Кон8 = thousandsDb[7].Whoes == Enums.Whoes.W ? thousandsDb[7].Value.ToString() : "0";
                    thousandOnViews[6].Кон8 = thousandsDb[7].W.ToString();
                    thousandOnViews[7].Кон8 = thousandsDb[7].Wmarj;
                    thousandOnViews[8].Кон8 = thousandsDb[7].Wbolt.ToString();
                    thousandOnViews[9].Кон8 = thousandsDb[7].Wrosp.ToString();
                    thousandOnViews[10].Кон8 = thousandsDb[7].Whoes == Enums.Whoes.A ? thousandsDb[7].Value.ToString() : "0";
                    thousandOnViews[11].Кон8 = thousandsDb[7].A.ToString();
                    thousandOnViews[12].Кон8 = thousandsDb[7].Amarj;
                    thousandOnViews[13].Кон8 = thousandsDb[7].Abolt.ToString();
                    thousandOnViews[14].Кон8 = thousandsDb[7].Arosp.ToString();
                }
                if(thousandsDb.Count >= 9)
                {
                    if (thousandsDb[8].IdCone == 100)
                    {
                        goto Relativation;
                    }
                    thousandOnViews[0].Кон9 = thousandsDb[8].Whoes == Enums.Whoes.U ? thousandsDb[8].Value.ToString() : "0";
                    thousandOnViews[1].Кон9 = thousandsDb[8].U.ToString();
                    thousandOnViews[2].Кон9 = thousandsDb[8].Umarj;
                    thousandOnViews[3].Кон9 = thousandsDb[8].Ubolt.ToString();
                    thousandOnViews[4].Кон9 = thousandsDb[8].Urosp.ToString();
                    thousandOnViews[5].Кон9 = thousandsDb[8].Whoes == Enums.Whoes.W ? thousandsDb[8].Value.ToString() : "0";
                    thousandOnViews[6].Кон9 = thousandsDb[8].W.ToString();
                    thousandOnViews[7].Кон9 = thousandsDb[8].Wmarj;
                    thousandOnViews[8].Кон9 = thousandsDb[8].Wbolt.ToString();
                    thousandOnViews[9].Кон9 = thousandsDb[8].Wrosp.ToString();
                    thousandOnViews[10].Кон9 = thousandsDb[8].Whoes == Enums.Whoes.A ? thousandsDb[8].Value.ToString() : "0";
                    thousandOnViews[11].Кон9 = thousandsDb[8].A.ToString();
                    thousandOnViews[12].Кон9 = thousandsDb[8].Amarj;
                    thousandOnViews[13].Кон9 = thousandsDb[8].Abolt.ToString();
                    thousandOnViews[14].Кон9 = thousandsDb[8].Arosp.ToString();
                }
                Relativation:
                thousandOnViews[1].Место = thousandsDb.First(n => n.IdCone == 100).U.ToString();
                thousandOnViews[6].Место = thousandsDb.First(n => n.IdCone == 100).W.ToString();
                thousandOnViews[11].Место = thousandsDb.First(n => n.IdCone == 100).A.ToString();
                return thousandOnViews;
            }
        }

        private ObservableCollection<Dyr_OnView> ParseDyr_To_OnView(ObservableCollection<Dyr> dyrsDb)
        {
            if (dyrsDb == null || dyrsDb.Count == 0)
            {
                var dyrsOnViews = NewDyrs();
                return dyrsOnViews;
            }
            else
            {
                var dyrsOnViews = new ObservableCollection<Dyr_OnView>
                {
                    new Dyr_OnView()
                    {
                        Кто = Enums.Whoes.U,
                        Кон1 = dyrsDb.First(n => n.IdCone == 1).U.ToString(),
                        Кон2 = dyrsDb.First(n => n.IdCone == 2).U.ToString(),
                        Кон3 = dyrsDb.First(n => n.IdCone == 3).U.ToString(),
                        Всего = dyrsDb.First(n => n.IdCone == 10).U.ToString(),
                        Место = dyrsDb.First(n => n.IdCone == 100).U.ToString()
                    },
                    new Dyr_OnView()
                    {
                        Кто = Enums.Whoes.W,
                        Кон1 = dyrsDb.First(n => n.IdCone == 1).W.ToString(),
                        Кон2 = dyrsDb.First(n => n.IdCone == 2).W.ToString(),
                        Кон3 = dyrsDb.First(n => n.IdCone == 3).W.ToString(),
                        Всего = dyrsDb.First(n => n.IdCone == 10).W.ToString(),
                        Место = dyrsDb.First(n => n.IdCone == 100).W.ToString()
                    },
                    new Dyr_OnView()
                    {
                        Кто = Enums.Whoes.A,
                        Кон1 = dyrsDb.First(n => n.IdCone == 1).A.ToString(),
                        Кон2 = dyrsDb.First(n => n.IdCone == 2).A.ToString(),
                        Кон3 = dyrsDb.First(n => n.IdCone == 3).A.ToString(),
                        Всего = dyrsDb.First(n => n.IdCone == 10).A.ToString(),
                        Место = dyrsDb.First(n => n.IdCone == 100).A.ToString()
                    }
                };
                return dyrsOnViews;
            }
        }

        private ObservableCollection<Mut_OnView> ParseMyt_To_OnView(ObservableCollection<Mut> mutsDb)
        {
            if (mutsDb == null || mutsDb.Count == 0)
            {
                var mutsOnViews = NewMuts();
                return mutsOnViews;
            }
            else
            {
                var mutsOnViews = new ObservableCollection<Mut_OnView>
                {
                    new Mut_OnView()
                    {
                        Кто = Enums.Whoes.U,
                        Кон1 = mutsDb.First(n => n.IdCone == 1).U,
                        Кон2 = mutsDb.First(n => n.IdCone == 2).U,
                        Кон3 = mutsDb.First(n => n.IdCone == 3).U,
                        Всего = mutsDb.First(n => n.IdCone == 10).U,
                        Место = mutsDb.First(n => n.IdCone == 100).U
                    },
                    new Mut_OnView()
                    {
                        Кто = Enums.Whoes.W,
                        Кон1 = mutsDb.First(n => n.IdCone == 1).W,
                        Кон2 = mutsDb.First(n => n.IdCone == 2).W,
                        Кон3 = mutsDb.First(n => n.IdCone == 3).W,
                        Всего = mutsDb.First(n => n.IdCone == 10).W,
                        Место = mutsDb.First(n => n.IdCone == 100).W},
                    new Mut_OnView()
                    {
                        Кто = Enums.Whoes.A,
                        Кон1 = mutsDb.First(n => n.IdCone == 1).A,
                        Кон2 = mutsDb.First(n => n.IdCone == 2).A,
                        Кон3 = mutsDb.First(n => n.IdCone == 3).A,
                        Всего = mutsDb.First(n => n.IdCone == 10).A,
                        Место = mutsDb.First(n => n.IdCone == 100).A
                    }
                };
                return mutsOnViews;
            }
        }

        private ObservableCollection<GameDay_OnView> ParseDb_To_GameDay(DateTime Today, Valet valetToday, Thousand thousandToday, Dyr dyrToday, Mut mutToday)
        {
            countGames = 0;
            ObservableCollection<GameDay_OnView> gameDayOnViews = new ObservableCollection<GameDay_OnView>
            {
                new GameDay_OnView() {Кто = Enums.Whoes.U, Всего = 0},
                new GameDay_OnView() {Кто = Enums.Whoes.W, Всего = 0},
                new GameDay_OnView() {Кто = Enums.Whoes.A, Всего = 0},
            };
            if (valetToday.GameDate.Date == Today)
            {
                countGames++;
                gameDayOnViews[0].Всего += valetToday.U;
                gameDayOnViews[1].Всего += valetToday.W;
                gameDayOnViews[2].Всего += valetToday.A;
            }
            if (thousandToday.GameDate.Date == Today)
            {
                countGames++;
                gameDayOnViews[0].Всего += thousandToday.U;
                gameDayOnViews[1].Всего += thousandToday.W;
                gameDayOnViews[2].Всего += thousandToday.A;
            }
            if (dyrToday.GameDate.Date == Today)
            {
                countGames++;
                gameDayOnViews[0].Всего += dyrToday.U;
                gameDayOnViews[1].Всего += dyrToday.W;
                gameDayOnViews[2].Всего += dyrToday.A;
            }
            if (mutToday.GameDate.Date == Today)
            {
                countGames++;
                gameDayOnViews[0].Всего += mutToday.U;
                gameDayOnViews[1].Всего += mutToday.W;
                gameDayOnViews[2].Всего += mutToday.A;
            }

            int[] rel = G_relativation(gameDayOnViews[0].Всего, gameDayOnViews[1].Всего, gameDayOnViews[2].Всего);
            for (int i = 0; i < 3; i++)
            {
                gameDayOnViews[i].Место = rel[i];
            }

            return gameDayOnViews;
        }


        public int[] G_relativation(int u, int v, int a) //супер говнокод для перевода из абсолютного в относительный
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

        #region OnView_To_X_Parsers

        private ObservableCollection<Valet> ParseOnView_To_Valet(ObservableCollection<Valet_OnView> valetOnViews, DateTime dt)
        {
            var valets = new ObservableCollection<Valet>
            {
                new Valet()
                {
                    GameDate = dt,
                    IdCone = 1,
                    U = valetOnViews.First(n => n.Кто == Enums.Whoes.U).Кон1,
                    W = valetOnViews.First(n => n.Кто == Enums.Whoes.W).Кон1,
                    A = valetOnViews.First(n => n.Кто == Enums.Whoes.A).Кон1
                },
                new Valet()
                {
                    GameDate = dt,
                    IdCone = 2,
                    U = valetOnViews.First(n => n.Кто == Enums.Whoes.U).Кон2,
                    W = valetOnViews.First(n => n.Кто == Enums.Whoes.W).Кон2,
                    A = valetOnViews.First(n => n.Кто == Enums.Whoes.A).Кон2
                },
                new Valet()
                {
                    GameDate = dt,
                    IdCone = 3,
                    U = valetOnViews.First(n => n.Кто == Enums.Whoes.U).Кон3,
                    W = valetOnViews.First(n => n.Кто == Enums.Whoes.W).Кон3,
                    A = valetOnViews.First(n => n.Кто == Enums.Whoes.A).Кон3
                },
                new Valet()
                {
                    GameDate = dt,
                    IdCone = 10,
                    U = valetOnViews.First(n => n.Кто == Enums.Whoes.U).Всего,
                    W = valetOnViews.First(n => n.Кто == Enums.Whoes.W).Всего,
                    A = valetOnViews.First(n => n.Кто == Enums.Whoes.A).Всего
                },
                new Valet()
                {
                    GameDate = dt,
                    IdCone = 100,
                    U = valetOnViews.First(n => n.Кто == Enums.Whoes.U).Место,
                    W = valetOnViews.First(n => n.Кто == Enums.Whoes.W).Место,
                    A = valetOnViews.First(n => n.Кто == Enums.Whoes.A).Место
                }
            };
            return valets;
        }

        private ObservableCollection<Mut> ParseOnView_To_Mut(ObservableCollection<Mut_OnView> mutOnViews, DateTime dt)
        {
            var muts = new ObservableCollection<Mut>
            {
                new Mut()
                {
                    GameDate = dt,
                    IdCone = 1,
                    U = mutOnViews.First(n => n.Кто == Enums.Whoes.U).Кон1,
                    W = mutOnViews.First(n => n.Кто == Enums.Whoes.W).Кон1,
                    A = mutOnViews.First(n => n.Кто == Enums.Whoes.A).Кон1
                },
                new Mut()
                {
                    GameDate = dt,
                    IdCone = 2,
                    U = mutOnViews.First(n => n.Кто == Enums.Whoes.U).Кон2,
                    W = mutOnViews.First(n => n.Кто == Enums.Whoes.W).Кон2,
                    A = mutOnViews.First(n => n.Кто == Enums.Whoes.A).Кон2
                },
                new Mut()
                {
                    GameDate = dt,
                    IdCone = 3,
                    U = mutOnViews.First(n => n.Кто == Enums.Whoes.U).Кон3,
                    W = mutOnViews.First(n => n.Кто == Enums.Whoes.W).Кон3,
                    A = mutOnViews.First(n => n.Кто == Enums.Whoes.A).Кон3
                },
                new Mut()
                {
                    GameDate = dt,
                    IdCone = 10,
                    U = mutOnViews.First(n => n.Кто == Enums.Whoes.U).Всего,
                    W = mutOnViews.First(n => n.Кто == Enums.Whoes.W).Всего,
                    A = mutOnViews.First(n => n.Кто == Enums.Whoes.A).Всего
                },
                new Mut()
                {
                    GameDate = dt,
                    IdCone = 100,
                    U = mutOnViews.First(n => n.Кто == Enums.Whoes.U).Место,
                    W = mutOnViews.First(n => n.Кто == Enums.Whoes.W).Место,
                    A = mutOnViews.First(n => n.Кто == Enums.Whoes.A).Место
                }
            };
            return muts;
        }

        private ObservableCollection<Dyr> ParseOnView_To_Dyr(ObservableCollection<Dyr_OnView> dyrOnViews, DateTime dt)
        {
            #region Ostrovok Govnokoda

            int U1 = Convert.ToInt32(dyrOnViews[0].Кон1);
            int W1 = Convert.ToInt32(dyrOnViews[1].Кон1);
            int A1 = Convert.ToInt32(dyrOnViews[2].Кон1);
            int U2 = Convert.ToInt32(dyrOnViews[0].Кон2);
            int W2 = Convert.ToInt32(dyrOnViews[1].Кон2);
            int A2 = Convert.ToInt32(dyrOnViews[2].Кон2);
            int U3 = Convert.ToInt32(dyrOnViews[0].Кон3);
            int W3 = Convert.ToInt32(dyrOnViews[1].Кон3);
            int A3 = Convert.ToInt32(dyrOnViews[2].Кон3);

            int[,] pogony = new int[5, 6];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    pogony[i, j] = 0;
                }
            }

            if (U1 == 4 && W1 == 0) { pogony[0, 0] = 1; }
            if (U1 == 4 && A1 == 0) { pogony[0, 1] = 1; }
            if (W1 == 4 && U1 == 0) { pogony[0, 2] = 1; }
            if (W1 == 4 && A1 == 0) { pogony[0, 3] = 1; }
            if (A1 == 4 && U1 == 0) { pogony[0, 4] = 1; }
            if (A1 == 4 && W1 == 0) { pogony[0, 5] = 1; }

            if (U2 == 4 && W2 == 0) { pogony[1, 0] = 1; }
            if (U2 == 4 && A2 == 0) { pogony[1, 1] = 1; }
            if (W2 == 4 && U2 == 0) { pogony[1, 2] = 1; }
            if (W2 == 4 && A2 == 0) { pogony[1, 3] = 1; }
            if (A2 == 4 && U2 == 0) { pogony[1, 4] = 1; }
            if (A2 == 4 && W2 == 0) { pogony[1, 5] = 1; }

            if (U3 == 4 && W3 == 0) { pogony[2, 0] = 1; }
            if (U3 == 4 && A3 == 0) { pogony[2, 1] = 1; }
            if (W3 == 4 && U3 == 0) { pogony[2, 2] = 1; }
            if (W3 == 4 && A3 == 0) { pogony[2, 3] = 1; }
            if (A3 == 4 && U3 == 0) { pogony[2, 4] = 1; }
            if (A3 == 4 && W3 == 0) { pogony[2, 5] = 1; }

            #endregion

            var dyr = new ObservableCollection<Dyr>()
            {
                new Dyr()
                {
                    GameDate = dt,
                    IdCone = 1,
                    U = U1,
                    W = W1,
                    A = A1,
                    UW = pogony[0,0],
                    UA = pogony[0,1],
                    WU = pogony[0,2],
                    WA = pogony[0,3],
                    AU = pogony[0,4],
                    AW = pogony[0,5]
                },
                new Dyr()
                {
                    GameDate = dt,
                    IdCone = 2,
                    U = U2,
                    W = W2,
                    A = A2,
                    UW = pogony[1,0],
                    UA = pogony[1,1],
                    WU = pogony[1,2],
                    WA = pogony[1,3],
                    AU = pogony[1,4],
                    AW = pogony[1,5]
                },
                new Dyr()
                {
                    GameDate = dt,
                    IdCone = 3,
                    U = U3,
                    W = W3,
                    A = A3,
                    UW = pogony[2,0],
                    UA = pogony[2,1],
                    WU = pogony[2,2],
                    WA = pogony[2,3],
                    AU = pogony[2,4],
                    AW = pogony[2,5]
                },
                new Dyr()
                {
                    GameDate = dt,
                    IdCone = 10,
                    U = Convert.ToInt32(dyrOnViews[0].Всего),
                    W = Convert.ToInt32(dyrOnViews[1].Всего),
                    A = Convert.ToInt32(dyrOnViews[2].Всего),
                    UW = pogony[3,0],
                    UA = pogony[3,1],
                    WU = pogony[3,2],
                    WA = pogony[3,3],
                    AU = pogony[3,4],
                    AW = pogony[3,5]
                },
                new Dyr()
                {
                    GameDate = dt,
                    IdCone = 100,
                    U = Convert.ToInt32(dyrOnViews[0].Место),
                    W = Convert.ToInt32(dyrOnViews[1].Место),
                    A = Convert.ToInt32(dyrOnViews[2].Место),
                    UW = pogony[4,0],
                    UA = pogony[4,1],
                    WU = pogony[4,2],
                    WA = pogony[4,3],
                    AU = pogony[4,4],
                    AW = pogony[4,5]
                }
            };
            return dyr;
        }

        private ObservableCollection<Thousand> ParseOnView_To_Thousand(ObservableCollection<Thousand_OnView> thousandOnViews, DateTime dt, int Con)
        {
            var thousands = new ObservableCollection<Thousand>();
            if (Con >= 1)
            {
                var curThousand1 = new Thousand();
                curThousand1.GameDate = dt;
                curThousand1.IdCone = 1;
                curThousand1.U = Convert.ToInt32(thousandOnViews[1].Кон1 == "" ? "0" : thousandOnViews[1].Кон1);
                curThousand1.W = Convert.ToInt32(thousandOnViews[6].Кон1 == "" ? "0" : thousandOnViews[6].Кон1);
                curThousand1.A = Convert.ToInt32(thousandOnViews[11].Кон1 == "" ? "0" : thousandOnViews[11].Кон1);
                if (thousandOnViews[0].Кон1 != "0")
                {
                    curThousand1.Whoes = Enums.Whoes.U;
                    curThousand1.Value = Convert.ToInt32(thousandOnViews[0].Кон1);
                }
                else if (thousandOnViews[5].Кон1 != "0")
                {
                    curThousand1.Whoes = Enums.Whoes.W;
                    curThousand1.Value = Convert.ToInt32(thousandOnViews[5].Кон1);
                }
                else if (thousandOnViews[10].Кон1 != "0")
                {
                    curThousand1.Whoes = Enums.Whoes.A;
                    curThousand1.Value = Convert.ToInt32(thousandOnViews[10].Кон1);
                }

                curThousand1.Umarj = thousandOnViews[2].Кон1;
                curThousand1.Wmarj = thousandOnViews[7].Кон1;
                curThousand1.Amarj = thousandOnViews[12].Кон1;
                curThousand1.Ubolt = Convert.ToInt32(thousandOnViews[3].Кон1);
                curThousand1.Wbolt = Convert.ToInt32(thousandOnViews[8].Кон1);
                curThousand1.Abolt = Convert.ToInt32(thousandOnViews[13].Кон1);
                curThousand1.Urosp = Convert.ToInt32(thousandOnViews[4].Кон1);
                curThousand1.Wrosp = Convert.ToInt32(thousandOnViews[9].Кон1);
                curThousand1.Arosp = Convert.ToInt32(thousandOnViews[14].Кон1);
                thousands.Add(curThousand1);
            }
            if (Con >= 2)
            {
                var curThousand2 = new Thousand();
                curThousand2.GameDate = dt;
                curThousand2.IdCone = 2;
                curThousand2.U = Convert.ToInt32(thousandOnViews[1].Кон2 == "" ? "0" : thousandOnViews[1].Кон2);
                curThousand2.W = Convert.ToInt32(thousandOnViews[6].Кон2 == "" ? "0" : thousandOnViews[6].Кон2);
                curThousand2.A = Convert.ToInt32(thousandOnViews[11].Кон2 == "" ? "0" : thousandOnViews[11].Кон2);
                if (thousandOnViews[0].Кон2 != "0")
                {
                    curThousand2.Whoes = Enums.Whoes.U;
                    curThousand2.Value = Convert.ToInt32(thousandOnViews[0].Кон2);
                }
                else if (thousandOnViews[5].Кон2 != "0")
                {
                    curThousand2.Whoes = Enums.Whoes.W;
                    curThousand2.Value = Convert.ToInt32(thousandOnViews[5].Кон2);
                }
                else if (thousandOnViews[10].Кон2 != "0")
                {
                    curThousand2.Whoes = Enums.Whoes.A;
                    curThousand2.Value = Convert.ToInt32(thousandOnViews[10].Кон2);
                }

                curThousand2.Umarj = thousandOnViews[2].Кон2;
                curThousand2.Wmarj = thousandOnViews[7].Кон2;
                curThousand2.Amarj = thousandOnViews[12].Кон2;
                curThousand2.Ubolt = Convert.ToInt32(thousandOnViews[3].Кон2);
                curThousand2.Wbolt = Convert.ToInt32(thousandOnViews[8].Кон2);
                curThousand2.Abolt = Convert.ToInt32(thousandOnViews[13].Кон2);
                curThousand2.Urosp = Convert.ToInt32(thousandOnViews[4].Кон2);
                curThousand2.Wrosp = Convert.ToInt32(thousandOnViews[9].Кон2);
                curThousand2.Arosp = Convert.ToInt32(thousandOnViews[14].Кон2);
                thousands.Add(curThousand2);
            }
            if (Con >= 3)
            {
                var curThousand3 = new Thousand();
                curThousand3.GameDate = dt;
                curThousand3.IdCone = 3;
                curThousand3.U = Convert.ToInt32(thousandOnViews[1].Кон3 == "" ? "0" : thousandOnViews[1].Кон3);
                curThousand3.W = Convert.ToInt32(thousandOnViews[6].Кон3 == "" ? "0" : thousandOnViews[6].Кон3);
                curThousand3.A = Convert.ToInt32(thousandOnViews[11].Кон3 == "" ? "0" : thousandOnViews[11].Кон3);
                if (thousandOnViews[0].Кон3 != "0")
                {
                    curThousand3.Whoes = Enums.Whoes.U;
                    curThousand3.Value = Convert.ToInt32(thousandOnViews[0].Кон3);
                }
                else if (thousandOnViews[5].Кон3 != "0")
                {
                    curThousand3.Whoes = Enums.Whoes.W;
                    curThousand3.Value = Convert.ToInt32(thousandOnViews[5].Кон3);
                }
                else if (thousandOnViews[10].Кон3 != "0")
                {
                    curThousand3.Whoes = Enums.Whoes.A;
                    curThousand3.Value = Convert.ToInt32(thousandOnViews[10].Кон3);
                }

                curThousand3.Umarj = thousandOnViews[2].Кон3;
                curThousand3.Wmarj = thousandOnViews[7].Кон3;
                curThousand3.Amarj = thousandOnViews[12].Кон3;
                curThousand3.Ubolt = Convert.ToInt32(thousandOnViews[3].Кон3);
                curThousand3.Wbolt = Convert.ToInt32(thousandOnViews[8].Кон3);
                curThousand3.Abolt = Convert.ToInt32(thousandOnViews[13].Кон3);
                curThousand3.Urosp = Convert.ToInt32(thousandOnViews[4].Кон3);
                curThousand3.Wrosp = Convert.ToInt32(thousandOnViews[9].Кон3);
                curThousand3.Arosp = Convert.ToInt32(thousandOnViews[14].Кон3);
                thousands.Add(curThousand3);
            }
            if (Con >= 4)
            {
                var curThousand4 = new Thousand();
                curThousand4.GameDate = dt;
                curThousand4.IdCone = 4;
                curThousand4.U = Convert.ToInt32(thousandOnViews[1].Кон4 == "" ? "0" : thousandOnViews[1].Кон4);
                curThousand4.W = Convert.ToInt32(thousandOnViews[6].Кон4 == "" ? "0" : thousandOnViews[6].Кон4);
                curThousand4.A = Convert.ToInt32(thousandOnViews[11].Кон4 == "" ? "0" : thousandOnViews[11].Кон4);
                if (thousandOnViews[0].Кон4 != "0")
                {
                    curThousand4.Whoes = Enums.Whoes.U;
                    curThousand4.Value = Convert.ToInt32(thousandOnViews[0].Кон4);
                }
                else if (thousandOnViews[5].Кон4 != "0")
                {
                    curThousand4.Whoes = Enums.Whoes.W;
                    curThousand4.Value = Convert.ToInt32(thousandOnViews[5].Кон4);
                }
                else if (thousandOnViews[10].Кон4 != "0")
                {
                    curThousand4.Whoes = Enums.Whoes.A;
                    curThousand4.Value = Convert.ToInt32(thousandOnViews[10].Кон4);
                }

                curThousand4.Umarj = thousandOnViews[2].Кон4;
                curThousand4.Wmarj = thousandOnViews[7].Кон4;
                curThousand4.Amarj = thousandOnViews[12].Кон4;
                curThousand4.Ubolt = Convert.ToInt32(thousandOnViews[3].Кон4);
                curThousand4.Wbolt = Convert.ToInt32(thousandOnViews[8].Кон4);
                curThousand4.Abolt = Convert.ToInt32(thousandOnViews[13].Кон4);
                curThousand4.Urosp = Convert.ToInt32(thousandOnViews[4].Кон4);
                curThousand4.Wrosp = Convert.ToInt32(thousandOnViews[9].Кон4);
                curThousand4.Arosp = Convert.ToInt32(thousandOnViews[14].Кон4);
                thousands.Add(curThousand4);
            }
            if (Con >= 5)
            {
                var curThousand5 = new Thousand();
                curThousand5.GameDate = dt;
                curThousand5.IdCone = 5;
                curThousand5.U = Convert.ToInt32(thousandOnViews[1].Кон5 == "" ? "0" : thousandOnViews[1].Кон5);
                curThousand5.W = Convert.ToInt32(thousandOnViews[6].Кон5 == "" ? "0" : thousandOnViews[6].Кон5);
                curThousand5.A = Convert.ToInt32(thousandOnViews[11].Кон5 == "" ? "0" : thousandOnViews[11].Кон5);
                if (thousandOnViews[0].Кон5 != "0")
                {
                    curThousand5.Whoes = Enums.Whoes.U;
                    curThousand5.Value = Convert.ToInt32(thousandOnViews[0].Кон5);
                }
                else if (thousandOnViews[5].Кон5 != "0")
                {
                    curThousand5.Whoes = Enums.Whoes.W;
                    curThousand5.Value = Convert.ToInt32(thousandOnViews[5].Кон5);
                }
                else if (thousandOnViews[10].Кон5 != "0")
                {
                    curThousand5.Whoes = Enums.Whoes.A;
                    curThousand5.Value = Convert.ToInt32(thousandOnViews[10].Кон5);
                }

                curThousand5.Umarj = thousandOnViews[2].Кон5;
                curThousand5.Wmarj = thousandOnViews[7].Кон5;
                curThousand5.Amarj = thousandOnViews[12].Кон5;
                curThousand5.Ubolt = Convert.ToInt32(thousandOnViews[3].Кон5);
                curThousand5.Wbolt = Convert.ToInt32(thousandOnViews[8].Кон5);
                curThousand5.Abolt = Convert.ToInt32(thousandOnViews[13].Кон5);
                curThousand5.Urosp = Convert.ToInt32(thousandOnViews[4].Кон5);
                curThousand5.Wrosp = Convert.ToInt32(thousandOnViews[9].Кон5);
                curThousand5.Arosp = Convert.ToInt32(thousandOnViews[14].Кон5);
                thousands.Add(curThousand5);
            }
            if (Con >= 6)
            {
                var curThousand6 = new Thousand();
                curThousand6.GameDate = dt;
                curThousand6.IdCone = 6;
                curThousand6.U = Convert.ToInt32(thousandOnViews[1].Кон6 == "" ? "0" : thousandOnViews[1].Кон6);
                curThousand6.W = Convert.ToInt32(thousandOnViews[6].Кон6 == "" ? "0" : thousandOnViews[6].Кон6);
                curThousand6.A = Convert.ToInt32(thousandOnViews[11].Кон6 == "" ? "0" : thousandOnViews[11].Кон6);
                if (thousandOnViews[0].Кон6 != "0")
                {
                    curThousand6.Whoes = Enums.Whoes.U;
                    curThousand6.Value = Convert.ToInt32(thousandOnViews[0].Кон6);
                }
                else if (thousandOnViews[5].Кон6 != "0")
                {
                    curThousand6.Whoes = Enums.Whoes.W;
                    curThousand6.Value = Convert.ToInt32(thousandOnViews[5].Кон6);
                }
                else if (thousandOnViews[10].Кон6 != "0")
                {
                    curThousand6.Whoes = Enums.Whoes.A;
                    curThousand6.Value = Convert.ToInt32(thousandOnViews[10].Кон6);
                }

                curThousand6.Umarj = thousandOnViews[2].Кон6;
                curThousand6.Wmarj = thousandOnViews[7].Кон6;
                curThousand6.Amarj = thousandOnViews[12].Кон6;
                curThousand6.Ubolt = Convert.ToInt32(thousandOnViews[3].Кон6);
                curThousand6.Wbolt = Convert.ToInt32(thousandOnViews[8].Кон6);
                curThousand6.Abolt = Convert.ToInt32(thousandOnViews[13].Кон6);
                curThousand6.Urosp = Convert.ToInt32(thousandOnViews[4].Кон6);
                curThousand6.Wrosp = Convert.ToInt32(thousandOnViews[9].Кон6);
                curThousand6.Arosp = Convert.ToInt32(thousandOnViews[14].Кон6);
                thousands.Add(curThousand6);
            }
            if (Con >= 7)
            {
                var curThousand7 = new Thousand();
                curThousand7.GameDate = dt;
                curThousand7.IdCone = 7;
                curThousand7.U = Convert.ToInt32(thousandOnViews[1].Кон7 == "" ? "0" : thousandOnViews[1].Кон7);
                curThousand7.W = Convert.ToInt32(thousandOnViews[6].Кон7 == "" ? "0" : thousandOnViews[6].Кон7);
                curThousand7.A = Convert.ToInt32(thousandOnViews[11].Кон7 == "" ? "0" : thousandOnViews[11].Кон7);
                if (thousandOnViews[0].Кон7 != "0")
                {
                    curThousand7.Whoes = Enums.Whoes.U;
                    curThousand7.Value = Convert.ToInt32(thousandOnViews[0].Кон7);
                }
                else if (thousandOnViews[5].Кон7 != "0")
                {
                    curThousand7.Whoes = Enums.Whoes.W;
                    curThousand7.Value = Convert.ToInt32(thousandOnViews[5].Кон7);
                }
                else if (thousandOnViews[10].Кон7 != "0")
                {
                    curThousand7.Whoes = Enums.Whoes.A;
                    curThousand7.Value = Convert.ToInt32(thousandOnViews[10].Кон7);
                }

                curThousand7.Umarj = thousandOnViews[2].Кон7;
                curThousand7.Wmarj = thousandOnViews[7].Кон7;
                curThousand7.Amarj = thousandOnViews[12].Кон7;
                curThousand7.Ubolt = Convert.ToInt32(thousandOnViews[3].Кон7);
                curThousand7.Wbolt = Convert.ToInt32(thousandOnViews[8].Кон7);
                curThousand7.Abolt = Convert.ToInt32(thousandOnViews[13].Кон7);
                curThousand7.Urosp = Convert.ToInt32(thousandOnViews[4].Кон7);
                curThousand7.Wrosp = Convert.ToInt32(thousandOnViews[9].Кон7);
                curThousand7.Arosp = Convert.ToInt32(thousandOnViews[14].Кон7);
                thousands.Add(curThousand7);
            }
            if (Con >= 8)
            {
                var curThousand8 = new Thousand();
                curThousand8.GameDate = dt;
                curThousand8.IdCone = 8;
                curThousand8.U = Convert.ToInt32(thousandOnViews[1].Кон8 == "" ? "0" : thousandOnViews[1].Кон8);
                curThousand8.W = Convert.ToInt32(thousandOnViews[6].Кон8 == "" ? "0" : thousandOnViews[6].Кон8);
                curThousand8.A = Convert.ToInt32(thousandOnViews[11].Кон8 == "" ? "0" : thousandOnViews[11].Кон8);
                if (thousandOnViews[0].Кон8 != "0")
                {
                    curThousand8.Whoes = Enums.Whoes.U;
                    curThousand8.Value = Convert.ToInt32(thousandOnViews[0].Кон8);
                }
                else if (thousandOnViews[5].Кон8 != "0")
                {
                    curThousand8.Whoes = Enums.Whoes.W;
                    curThousand8.Value = Convert.ToInt32(thousandOnViews[5].Кон8);
                }
                else if (thousandOnViews[10].Кон8 != "0")
                {
                    curThousand8.Whoes = Enums.Whoes.A;
                    curThousand8.Value = Convert.ToInt32(thousandOnViews[10].Кон8);
                }

                curThousand8.Umarj = thousandOnViews[2].Кон8;
                curThousand8.Wmarj = thousandOnViews[7].Кон8;
                curThousand8.Amarj = thousandOnViews[12].Кон8;
                curThousand8.Ubolt = Convert.ToInt32(thousandOnViews[3].Кон8);
                curThousand8.Wbolt = Convert.ToInt32(thousandOnViews[8].Кон8);
                curThousand8.Abolt = Convert.ToInt32(thousandOnViews[13].Кон8);
                curThousand8.Urosp = Convert.ToInt32(thousandOnViews[4].Кон8);
                curThousand8.Wrosp = Convert.ToInt32(thousandOnViews[9].Кон8);
                curThousand8.Arosp = Convert.ToInt32(thousandOnViews[14].Кон8);
                thousands.Add(curThousand8);
            }
            if (Con >= 9)
            {
                var curThousand9 = new Thousand();
                curThousand9.GameDate = dt;
                curThousand9.IdCone = 9;
                curThousand9.U = Convert.ToInt32(thousandOnViews[1].Кон9 == "" ? "0" : thousandOnViews[1].Кон9);
                curThousand9.W = Convert.ToInt32(thousandOnViews[6].Кон9 == "" ? "0" : thousandOnViews[6].Кон9);
                curThousand9.A = Convert.ToInt32(thousandOnViews[11].Кон9 == "" ? "0" : thousandOnViews[11].Кон9);
                if (thousandOnViews[0].Кон9 != "0")
                {
                    curThousand9.Whoes = Enums.Whoes.U;
                    curThousand9.Value = Convert.ToInt32(thousandOnViews[0].Кон9);
                }
                else if (thousandOnViews[5].Кон9 != "0")
                {
                    curThousand9.Whoes = Enums.Whoes.W;
                    curThousand9.Value = Convert.ToInt32(thousandOnViews[5].Кон9);
                }
                else if (thousandOnViews[10].Кон9 != "0")
                {
                    curThousand9.Whoes = Enums.Whoes.A;
                    curThousand9.Value = Convert.ToInt32(thousandOnViews[10].Кон9);
                }

                curThousand9.Umarj = thousandOnViews[2].Кон9;
                curThousand9.Wmarj = thousandOnViews[7].Кон9;
                curThousand9.Amarj = thousandOnViews[12].Кон9;
                curThousand9.Ubolt = Convert.ToInt32(thousandOnViews[3].Кон9);
                curThousand9.Wbolt = Convert.ToInt32(thousandOnViews[8].Кон9);
                curThousand9.Abolt = Convert.ToInt32(thousandOnViews[13].Кон9);
                curThousand9.Urosp = Convert.ToInt32(thousandOnViews[4].Кон9);
                curThousand9.Wrosp = Convert.ToInt32(thousandOnViews[9].Кон9);
                curThousand9.Arosp = Convert.ToInt32(thousandOnViews[14].Кон9);
                thousands.Add(curThousand9);
            }
            //last
            var curThousand = new Thousand();
            curThousand.GameDate = dt;
            curThousand.IdCone = 100;
            curThousand.U = Convert.ToInt32(thousandOnViews[1].Место == "" ? "0" : thousandOnViews[1].Место);
            curThousand.W = Convert.ToInt32(thousandOnViews[6].Место == "" ? "0" : thousandOnViews[6].Место);
            curThousand.A = Convert.ToInt32(thousandOnViews[11].Место == "" ? "0" : thousandOnViews[11].Место);
            curThousand.Whoes = Enums.Whoes.None;
            curThousand.Value = 0;
            curThousand.Umarj = ".";
            curThousand.Wmarj = ".";
            curThousand.Amarj = ".";
            curThousand.Ubolt = 0;
            curThousand.Wbolt = 0;
            curThousand.Abolt = 0;
            curThousand.Urosp = 0;
            curThousand.Wrosp = 0;
            curThousand.Arosp = 0;
            thousands.Add(curThousand);
            return thousands;
        }

        private ObservableCollection<GameDay> ParseOnView_To_GameDay(ObservableCollection<GameDay_OnView> gameDayOnViews, DateTime dt)
        {
            var GameDays = new ObservableCollection<GameDay>
            {
                new GameDay()
                {
                    GameDate = dt,
                    CountGames = countGames,
                    Uall = gameDayOnViews[0].Всего,
                    Wall = gameDayOnViews[1].Всего,
                    Aall = gameDayOnViews[2].Всего,
                    Urel = gameDayOnViews[0].Место,
                    Wrel = gameDayOnViews[1].Место,
                    Arel = gameDayOnViews[2].Место,
                }
            };
            return GameDays;
        }

        #endregion

        #region StartNewGame
        private ObservableCollection<Valet_OnView> NewValets()
        {
            var valetOnViews = new ObservableCollection<Valet_OnView>
            {
                new Valet_OnView()
                {
                    Кто = Enums.Whoes.U
                },
                new Valet_OnView()
                {
                    Кто = Enums.Whoes.W
                },
                new Valet_OnView()
                {
                    Кто = Enums.Whoes.A
                },
            };
            return valetOnViews;
        }

        private ObservableCollection<Mut_OnView> NewMuts()
        {
            var mutOnViews = new ObservableCollection<Mut_OnView>
            {
                new Mut_OnView() { Кто = Enums.Whoes.U },
                new Mut_OnView() { Кто = Enums.Whoes.W },
                new Mut_OnView() { Кто = Enums.Whoes.A },
            };
            return mutOnViews;
        }

        private ObservableCollection<Thousand_OnView> NewThousands()
        {
            var thousandOnViews = new ObservableCollection<Thousand_OnView>
            {
                new Thousand_OnView {Тип = "Ставка", Кто = Enums.Whoes.U},
                new Thousand_OnView {Тип = "Результат", Кто = Enums.Whoes.U},
                new Thousand_OnView {Тип = "Марьяжи", Кто = Enums.Whoes.U},
                new Thousand_OnView {Тип = "Болты", Кто = Enums.Whoes.U},
                new Thousand_OnView {Тип = "Росписи", Кто = Enums.Whoes.U},
                new Thousand_OnView {Тип = "Ставка", Кто = Enums.Whoes.W},
                new Thousand_OnView {Тип = "Результат", Кто = Enums.Whoes.W},
                new Thousand_OnView {Тип = "Марьяжи", Кто = Enums.Whoes.W},
                new Thousand_OnView {Тип = "Болты", Кто = Enums.Whoes.W},
                new Thousand_OnView {Тип = "Росписи", Кто = Enums.Whoes.W},
                new Thousand_OnView {Тип = "Ставка", Кто = Enums.Whoes.A},
                new Thousand_OnView {Тип = "Результат", Кто = Enums.Whoes.A},
                new Thousand_OnView {Тип = "Марьяжи", Кто = Enums.Whoes.A},
                new Thousand_OnView {Тип = "Болты", Кто = Enums.Whoes.A},
                new Thousand_OnView {Тип = "Росписи", Кто = Enums.Whoes.A}
            };
            return thousandOnViews;
        }

        private ObservableCollection<Dyr_OnView> NewDyrs()
        {
            var dyrOnViews = new ObservableCollection<Dyr_OnView>()
            {
                new Dyr_OnView() { Кто = Enums.Whoes.U},
                new Dyr_OnView() { Кто = Enums.Whoes.W},
                new Dyr_OnView() { Кто = Enums.Whoes.A}
            };
            return dyrOnViews;
        }

        #endregion
    }
}