using System;
using System.Net;
using KanbanTasks.Models;
using Microsoft.AspNetCore.Mvc;
using KanbanTasks.Contracts;
using System.Threading.Tasks;

namespace KanbanTasks.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BoardsController : ControllerBase
  {
    private readonly IBoardRepository _boardRepository;

    public BoardsController(IBoardRepository boardRepository)
    {
      _boardRepository = boardRepository;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
      try
      {
        var boards = await _boardRepository.FindAll(); ;
        return Ok(boards);
      }
      catch (Exception ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Board board)
    {
      if (ModelState.IsValid)
      {
        await _boardRepository.Create(board);
        return CreatedAtAction(nameof(List), new { id = board.BoardId }, board);
      }
      else
      {
        return BadRequest(ModelState);
      }
    }

    public class PutBody
    {
      public string Title { get; set; }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromQuery] Guid? id, [FromBody] PutBody body)
    {
      if (id != null && body != null)
      {
        Board board1 = await _boardRepository.FindById((Guid)id);
        board1.Title = body.Title;
        await _boardRepository.Update(board1);
        return Ok(board1);
      }
      else
      {
        return BadRequest(ModelState);
      }
    }
  }
}