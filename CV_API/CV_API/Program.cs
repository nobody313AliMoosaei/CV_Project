using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Config Sql Server
#region SqlServer
builder.Services.AddDbContext<DataLayer.DataBase.Database>(option =>
{
    option.UseSqlServer(builder
        .Configuration.GetConnectionString("ConnectionSQL"));
});
#endregion
#region Identity Service
builder.Services.AddIdentity<IdentityUser,IdentityRole>()
    .AddEntityFrameworkStores<DataLayer.DataBase.Database>()
    .AddDefaultTokenProviders();
#endregion

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
