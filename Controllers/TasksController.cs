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
  public class TasksController : ControllerBase
  {
    private readonly ITaskRepository _taskRepository;

    public TasksController(ITaskRepository TaskRepository)
    {
      _taskRepository = TaskRepository;
    }

    [HttpGet]
    public async Task<IActionResult> FindAll()
    {
      try
      {
        var tasks = await _taskRepository.FindAll(); ;
        return tasks != null ? Ok(tasks) : NotFound();
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
        var task = await _taskRepository.FindById(id); ;
        return task != null ? Ok(task) : NotFound();
      }
      catch (Exception ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Models.Task Task)
    {
      if (ModelState.IsValid)
      {
        await _taskRepository.Create(Task);
        return CreatedAtAction(nameof(FindAll), new { id = Task.Id }, Task);
      }
      else
      {
        return BadRequest(ModelState);
      }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromQuery] Guid? id, [FromBody] Models.Task body)
    {
      if (id != null && body != null)
      {
        Models.Task Task = await _taskRepository.FindById((Guid)id);
        Task.Title = body.Title;
        await _taskRepository.Update(Task);
        return Ok(Task);
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
        Models.Task Task = await _taskRepository.Delete((Guid)id);
        return Ok(Task);
      }
      else
      {
        return BadRequest(ModelState);
      }
    }
  }
}