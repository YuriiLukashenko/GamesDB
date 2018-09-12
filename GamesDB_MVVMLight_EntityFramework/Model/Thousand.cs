using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB_MVVMLight_EntityFramework.Model
{   
    public class Thousand
    {
        public int Id { get; set; }
        public DateTime GameDate { get; set; }
        public int IdCone { get; set; }
        public int U { get; set; }
        public int W { get; set; }
        public int A { get; set; }
        public Enums.Whoes Whoes { get; set; }
        public int Value { get; set; }
        public string Umarj { get; set; }
        public string Wmarj { get; set; }
        public string Amarj { get; set; }
        public int Ubolt { get; set; }
        public int Wbolt { get; set; }
        public int Abolt { get; set; }
        public int Urosp { get; set; }
        public int Wrosp { get; set; }
        public int Arosp { get; set; }
    }
}
