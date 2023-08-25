using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BikeFactory2.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("BikesCN")!;
connectionString = connectionString.Replace("{APP_DATA_PATH}", builder.Environment.ContentRootPath + "App_Data");

builder.Services.AddDbContext<BikeFactoryContext>(options => {
    options.UseSqlServer(connectionString);
});

builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<BikeFactoryContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
