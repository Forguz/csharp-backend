using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
  public void ConfigureServices(IServiceCollection services)
  {
    // Configuração dos serviços do ASP.NET Core
    services.AddControllers();
  }

  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    // Configuração do pipeline de requisição do ASP.NET Core
    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
    }

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllers();
      // Adicione outros endpoints conforme necessário
    });
  }
}