﻿using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        bool saveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);

        void CreateCommad(Command command);

        void UpdateCommand(Command command);

        void DeleteCommand(Command command);
    }
}
