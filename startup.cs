using KanbanTasks.Contracts;
using KanbanTasks.Data;
using KanbanTasks.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KanbanTasks
{
  public class Startup
  {
    public static void ConfigureServices(IServiceCollection services)
    {
      // Configuração dos serviços do ASP.NET Core
      services.AddCors(options =>
      {
        options.AddPolicy("AllowCors",
            builder =>
            {
              builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
      });
      services.AddDbContext<PostgresContext>();
      services.AddScoped<IBoardRepository, BoardRepository>();
      services.AddScoped<IColumnRepository, ColumnRepository>();
      services.AddScoped<ITaskRepository, TaskRepository>();
      services.AddScoped<ISubtaskRepository, SubtaskRepository>();
      services.AddControllers();
    }

    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      // Configuração do pipeline de requisição do ASP.NET Core
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();
      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        // Adicione outros endpoints conforme necessário
      });
    }
  }
}