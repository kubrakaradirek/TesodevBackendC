using TesodevBackendC.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using TesodevBackendC.Order.Application.Features.CQRS.Handlers.ProductHandlers;
using TesodevBackendC.Order.Application.Interfaces;
using TesodevBackendC.Order.Persistence.Context;
using TesodevBackendC.Order.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddDbContext<OrderDbContext>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<DeleteOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHadnler>();

builder.Services.AddScoped<GetProductByIdQueryHandler>();
builder.Services.AddScoped<GetProductQueryHandler>();
builder.Services.AddScoped<CreateProductCommandHandler>();
builder.Services.AddScoped<DeleteProductCommandHandler>();
builder.Services.AddScoped<UpdateProductCommandHandler>();

builder.Services.AddScoped<ChangeOrderStatusToFalseCommandHandler>();
builder.Services.AddScoped<ChangeOrderStatusToTrueCommandHandler>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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