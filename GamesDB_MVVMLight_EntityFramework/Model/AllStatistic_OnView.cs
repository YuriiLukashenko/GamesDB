using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB_MVVMLight_EntityFramework.Model
{
    public class AllStatistic_OnView
    {
        public Enums.Whoes Кто { get; set; }
        public int Сумма { get; set; }
        public int Сыграно { get; set; }
        public double Результат { get; set; }
    }
}
