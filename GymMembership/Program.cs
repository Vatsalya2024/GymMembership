using GymMembership.Context;
using GymMembership.Interface;
using GymMembership.Models;
using GymMembership.Repositories;
using GymMembership.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", opts =>
    {
        opts.WithOrigins("http://localhost:3000", "null").AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
    });
});
// Startup.cs or Program.cs
builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IRepository<int,User>,UserRepository>();
builder.Services.AddScoped<IRepository<int,Member>,MemberRepository>();

//builder.Services.AddScoped<IMemberService,MemberService>();
builder.Services.AddScoped<IMemberService, MemberService>();

builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("ReactPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();

