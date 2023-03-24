using Test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<testdbContext>(opt =>
opt.UseMySql("server=127.0.0.1;database=testdb;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.10.1-mariadb")));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddCors();

builder.Services.AddMvc();

builder.Services.AddControllers();



var app = builder.Build();

app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials()
                    );

app.UseDeveloperExceptionPage();

app.UseRequestLocalization("es-MX");

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});


app.Run();