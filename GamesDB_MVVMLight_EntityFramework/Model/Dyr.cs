using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB_MVVMLight_EntityFramework.Model
{
    public class Dyr
    {
        public int Id { get; set; }
        public DateTime GameDate { get; set; }
        public int IdCone { get; set; }
        public int U { get; set; }
        public int W { get; set; }
        public int A { get; set; }
        public int UW { get; set; }
        public int UA { get; set; }
        public int WU { get; set; }
        public int WA { get; set; }
        public int AU { get; set; }
        public int AW { get; set; }
    }
}
