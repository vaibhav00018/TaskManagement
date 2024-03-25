using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using TaskManagementDataAccess;
using TaskManagementService;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<ITaskManagementRepo, TaskManagementRepoImplement>();

builder.Services.AddDbContext<TaskDBContext>(o =>
{
    o.UseSqlServer("Server=DESKTOP-G00D2UI;Database=TaskManagement;Trusted_Connection=SSPI;Integrated Security=True;TrustServerCertificate=True", b => b.MigrationsAssembly("TaskManagement"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
