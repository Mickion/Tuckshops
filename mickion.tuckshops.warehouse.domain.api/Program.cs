
using mickion.tuckshops.shared.application;
using mickion.tuckshops.shared.application.Logger;
using mickion.tuckshops.warehouse.application;
using mickion.tuckshops.warehouse.infrastructure;
using mickion.tuckshops.shared.api.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationLayer();
builder.Services.AddApplicationLogging();
builder.Services.AddApplicationVersioning(1);
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddGlobalExceptionHandler(builder.Configuration);

//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Add common middlewares
app.UseSharedMiddlewares();

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
