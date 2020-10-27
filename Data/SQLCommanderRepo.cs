using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class SQLCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SQLCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateCommad(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            _context.Add(command);
        }

        public void DeleteCommand(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            _context.Commands.Remove(command);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault((c) => c.Id == id);
        }

        public bool saveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command command)
        {
            //throw new NotImplementedException();
        }
    }
}
