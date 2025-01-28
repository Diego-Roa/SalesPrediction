using Microsoft.EntityFrameworkCore;
using Sales.DataAccess.Data;
using Sales.Services.Mapping;
using Sales.Services.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));



// Add services to the container.
builder.Services.AddScoped<DbContext, ApplicationDbContext>();
builder.Services.AddScoped(typeof(UnitOfWork));
builder.Services.AddTransient<EmployeesService>();
builder.Services.AddTransient<ShippersService>();
builder.Services.AddTransient<ProductsService>();
builder.Services.AddTransient<OrdersService>();
builder.Services.AddTransient<CustomersService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add controllers
builder.Services.AddControllers();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("DefaultCorsPolicy");
app.UseRouting();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
