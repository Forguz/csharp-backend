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
  public class SubtasksController : ControllerBase
  {
    private readonly ISubtaskRepository _subtaskRepository;

    public SubtasksController(ISubtaskRepository SubtaskRepository)
    {
      _subtaskRepository = SubtaskRepository;
    }

    [HttpGet]
    public async Task<IActionResult> FindAll()
    {
      try
      {
        var subtasks = await _subtaskRepository.FindAll(); ;
        return subtasks != null ? Ok(subtasks) : NotFound();
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
        var subtask = await _subtaskRepository.FindById(id); ;
        return subtask != null ? Ok(subtask) : NotFound();
      }
      catch (Exception ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Subtask Subtask)
    {
      if (ModelState.IsValid)
      {
        await _subtaskRepository.Create(Subtask);
        return CreatedAtAction(nameof(FindAll), new { id = Subtask.Id }, Subtask);
      }
      else
      {
        return BadRequest(ModelState);
      }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromQuery] Guid? id, [FromBody] Subtask body)
    {
      if (id != null && body != null)
      {
        Subtask subtask = await _subtaskRepository.FindById((Guid)id);
        subtask.Title = body.Title;
        await _subtaskRepository.Update(subtask);
        return Ok(subtask);
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
        Subtask subtask = await _subtaskRepository.Delete((Guid)id);
        return Ok(subtask);
      }
      else
      {
        return BadRequest(ModelState);
      }
    }
  }
}