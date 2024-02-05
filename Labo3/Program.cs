using BLL.Iterfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsersRepository, UsersRepository>(x => new UsersRepository(builder.Configuration.GetConnectionString("Main")));
builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddScoped<IArticleRepository, ArticleRepository>(x => new ArticleRepository(builder.Configuration.GetConnectionString("Main")));
builder.Services.AddScoped<IArticleService, ArticleService>();

builder.Services.AddScoped<IAgendaRepository, AgendaRepository>(x => new AgendaRepository(builder.Configuration.GetConnectionString("Main")));


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
