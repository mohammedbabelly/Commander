using System;
using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repo;

        public CommandsController(ICommanderRepo repo)
        {
            _repo = repo;
        }
        //private readonly MockCommanderRepo _repo = new MockCommanderRepo();
        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GelAllCommands()
        {
            return Ok(_repo.GetAppCommands());
        }
        //GET api/command/5
        [HttpGet("{id}")]
        public ActionResult <Command> GelCommandById(int id)
        {
            return Ok(_repo.GetCommandById(id));
        }
      
    }
}