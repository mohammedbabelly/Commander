using Commander.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {

        }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Command>().HasData(
                new Command { Id = 1, HowTo = "howTo1", Platform = "platform1", Line = "myLine1" },
                new Command { Id = 2, HowTo = "howTo2", Platform = "platform2", Line = "myLine2" },
                new Command { Id = 3, HowTo = "howTo3", Platform = "platform3", Line = "myLine3" },
                new Command { Id = 4, HowTo = "howTo4", Platform = "platform4", Line = "myLine4" },
                new Command { Id = 5, HowTo = "howTo5", Platform = "platform5", Line = "myLine5" }
             );
        }
    }
}
