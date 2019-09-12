using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using micmdapp.Models;
using Microsoft.EntityFrameworkCore;

namespace micmdapp.Controllers
{
    
    [Route("api/[Controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandContext _context;
        
        public CommandsController(CommandContext context) {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> Get()
        {
            //  return new string[] { "this", "fake", "datas" };
            return _context.CommandItems;
        }

         //GET: api/commands/n
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandItem(int id)
        {
            var commandItem = _context.CommandItems.Find(id);
           if (commandItem == null)
            {
                        return NotFound();
            }
             return commandItem;
        }

         //POST: api/commands
        [HttpPost]
        public ActionResult<Command> PostCommandItem(Command command)
        {
            _context.CommandItems.Add(command);
            _context.SaveChanges();
            return CreatedAtAction("GetCommandItem", new Command{Id = command.Id}, command);
        }

         //PUT:      api/commands/n
        [HttpPut("{id}")]
        public ActionResult PutCommandItem(int id, Command command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            _context.Entry(command).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        //DELETE:   api/commands/n
        [HttpDelete("{id}")]
        public ActionResult<Command> DeleteCommandItem(int id)
        {
            var commandItem = _context.CommandItems.Find(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            _context.CommandItems.Remove(commandItem);
            _context.SaveChanges();
            return commandItem;

        }
        

    }
}