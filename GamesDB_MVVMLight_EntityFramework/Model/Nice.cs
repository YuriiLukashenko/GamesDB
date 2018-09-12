using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB_MVVMLight_EntityFramework.Model
{
    public class Nice
    {
        public int Id { get; set; }
        public DateTime GameDate { get; set; }
        public string Comment { get; set; }
    }
}
