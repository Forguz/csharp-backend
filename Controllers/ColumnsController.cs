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
  public class ColumnsController : ControllerBase
  {
    private readonly IColumnRepository _columnRepository;

    public ColumnsController(IColumnRepository columnRepository)
    {
      _columnRepository = columnRepository;
    }

    [HttpGet]
    public async Task<IActionResult> FindAll()
    {
      try
      {
        var Columns = await _columnRepository.FindAll(); ;
        return Columns != null ? Ok(Columns) : NotFound();
      }
      catch (Exception ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }

    [HttpGet]
    public async Task<IActionResult> FindOne([FromQuery] Guid id)
    {
      try
      {
        var Column = await _columnRepository.FindById(id); ;
        return Column != null ? Ok(Column) : NotFound();
      }
      catch (Exception ex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Column column)
    {
      if (ModelState.IsValid)
      {
        await _columnRepository.Create(column);
        return CreatedAtAction(nameof(FindAll), new { id = column.Id }, column);
      }
      else
      {
        return BadRequest(ModelState);
      }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromQuery] Guid? id, [FromBody] Column body)
    {
      if (id != null && body != null)
      {
        Column column = await _columnRepository.FindById((Guid)id);
        column.Title = body.Title;
        await _columnRepository.Update(column);
        return Ok(column);
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
        Column column = await _columnRepository.Delete((Guid)id);
        return Ok(column);
      }
      else
      {
        return BadRequest(ModelState);
      }
    }
  }
}