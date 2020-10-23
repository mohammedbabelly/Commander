using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAppCommands()
        {
            IEnumerable < Command >commands= new List<Command> 
             {
                new Command { Id = 1, HowTo = "Write a code", Line = "Keyboard", Platform = "Programming" },
                 new Command { Id = 2, HowTo = "Write a code", Line = "Keyboard", Platform = "Programming" },
                 new Command { Id = 3, HowTo = "Write a code", Line = "Keyboard", Platform = "Programming" }
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            Command command = new Command { Id=1,HowTo="Write a code",Line="Keyboard",Platform="Programming"};
            return command;
        }
    }
}
