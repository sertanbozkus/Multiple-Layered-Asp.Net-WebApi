using BilgeCinema.Business.Managers;
using BilgeCinema.Business.Services;
using BilgeCinema.Data.Context;
using BilgeCinema.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // controller kullanýlacak

builder.Services.AddEndpointsApiExplorer(); // api projesi

builder.Services.AddDbContext<BilgeCinemaContext>(options => options.UseInMemoryDatabase("BilgeCinemaDb"));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IMovieService, MovieManager>();

builder.Services.AddSwaggerGen();
//Swashbuckle.AspNetCore unutma.


var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // http protokolleri eklendi.
app.UseAuthorization();  // her zaman ekle.
app.MapControllers();

app.Run();
