using System;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using KanbanTasks.Data;
using KanbanTasks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KanbanTasks.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BoardsController : ControllerBase
  {
    private readonly PostgresContext _context;

    public BoardsController(PostgresContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
      try
      {
        var boards = _context.Boards;
        return Ok(boards);
      }
      catch (Exception ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Board board)
    {
      if (ModelState.IsValid)
      {
        await _context.Boards.AddAsync(board);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = board.BoardId }, board);
      }
      else
      {
        return BadRequest(ModelState);
      }
    }
  }
}