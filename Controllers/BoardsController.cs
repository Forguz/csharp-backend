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
    public async Task<IActionResult> FindAll()
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

    [HttpGet("{id}")]
    public async Task<IActionResult> FindOne(Guid id)
    {
      try
      {
        var board = await _boardRepository.FindById(id);
        return board != null ? Ok(board) : NotFound();
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
        return CreatedAtAction(nameof(FindAll), new { id = board.Id }, board);
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
    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] Guid? id)
    {
      if (id != null)
      {
        Board board = await _boardRepository.Delete((Guid)id);
        return Ok(board);
      }
      else
      {
        return BadRequest(ModelState);
      }
    }
  }
}