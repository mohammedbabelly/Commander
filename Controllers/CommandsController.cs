using System;
using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.DTOs;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repo;

        public IMapper _mapper { get; }

        public CommandsController(ICommanderRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        //private readonly MockCommanderRepo _repo = new MockCommanderRepo();
        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GelAllCommands()
        {
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(_repo.GetAllCommands()));
        }
        //GET api/command/{id}
        [HttpGet("{id}", Name = "GelCommandById")]
        public ActionResult<CommandReadDto> GelCommandById(int id)
        {
            var commandItem = _repo.GetCommandById(id);

            if (commandItem == null) return NotFound();

            return Ok(_mapper.Map<CommandReadDto>(commandItem));
        }
        //Post api/command/{id}
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandWriteDto command)
        {
            var commandModel = _mapper.Map<Command>(command);

            _repo.CreateCommad(commandModel);
            _repo.saveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            /*if (commandItem == null) return NotFound();*/
            return CreatedAtRoute(nameof(GelCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        //Put api/command/{id}
        [HttpPut("{id}")]
        public ActionResult<CommandReadDto> UpdateCommand(int id, CommandWriteDto commandWriteDto)
        {
            var commandModel = _repo.GetCommandById(id);

            if (commandModel == null) return NotFound();

            _mapper.Map(commandWriteDto, commandModel);//it updated the model in the DbContext

            //_repo.UpdateCommand(commandModel);

            _repo.saveChanges();


            return NoContent();
        }


        //Patch api/command/{id}
        /* [HttpPatch("{id}")]
         public ActionResult<CommandReadDto> PartialUpdateCommand(int id, JsonPatchDocument<CommandWriteDto> patchDoc)
         {
             var commandModel = _repo.GetCommandById(id);

             if (commandModel == null) return NotFound();

             var commandToPatch = _mapper.Map<CommandWriteDto>(commandModel);
             patchDoc.ApplyTo(commandToPatch, ModelState);
             if (!TryValidateModel(commandToPatch)) return ValidationProblem(ModelState);

             _mapper.Map(commandToPatch, commandModel);

             _repo.saveChanges();


             return NoContent();
         }*/

        //Delete api/command/{id}
        [HttpDelete("{id}")]
        public ActionResult<CommandReadDto> DeleteCommand(int id)
        {
            var commandModel = _repo.GetCommandById(id);

            if (commandModel == null) return NotFound();

            _repo.DeleteCommand(commandModel);

            _repo.saveChanges();

            return NoContent();
        }

    }
}