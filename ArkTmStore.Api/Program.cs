using ArkTmStore.Api.BdContext;
using Microsoft.EntityFrameworkCore;
using ArkTmStore.Api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        options.UseSqlServer("Data Source=192.168.1.16,1433;Initial Catalog=ArkTmStore; User=demos; Password=123456");
        // 
    }
);
builder.Services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
builder.Services.AddScoped(typeof(IProductoRepository), typeof(ProductoRepository));
builder.Services.AddScoped(typeof(IBrandRepository), typeof(BrandRepository));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsRule", rule =>
    {
        rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsRule");

app.UseAuthorization();

app.MapControllers();

app.Run();

