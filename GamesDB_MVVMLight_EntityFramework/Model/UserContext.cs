using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB_MVVMLight_EntityFramework.Model
{
    public class UserContext : DbContext
    {
        public UserContext() : base("Connection")
        {

        }
        public DbSet<Valet> Valets { get; set; }
        public DbSet<Thousand> Thousands { get; set; }
        public DbSet<Dyr> Dyrs { get; set; }
        public DbSet<Mut> Muts { get; set; }
        public DbSet<GameDay> GameDays { get; set; }
        public DbSet<Nice> Nices { get; set; }
    }
}
