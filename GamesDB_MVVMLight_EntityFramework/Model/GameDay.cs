using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB_MVVMLight_EntityFramework.Model
{
    public class GameDay
    {
        public int Id { get; set; }
        public DateTime GameDate { get; set; }
        public int CountGames { get; set; }
        public int Uall { get; set; }
        public int Wall { get; set; }
        public int Aall { get; set; }
        public int Urel { get; set; }
        public int Wrel { get; set; }
        public int Arel { get; set; }
    }
}
