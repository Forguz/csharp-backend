using Microsoft.AspNetCore.Mvc;

namespace KanbanTasks.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BoardsController : ControllerBase
  {
    [HttpGet]
    public IActionResult Get()
    {
      // Implemente a lógica para retornar uma resposta para a requisição GET
      return Ok("Hello, Web API!");
    }
  }
}