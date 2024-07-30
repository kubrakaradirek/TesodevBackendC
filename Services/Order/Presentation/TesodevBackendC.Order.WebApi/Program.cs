using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TesodevBackendC.Order.Application.Features.CQRS.Commands.ProductCommands;
using TesodevBackendC.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using TesodevBackendC.Order.Application.Features.CQRS.Handlers.OrderLogHandlers;
using TesodevBackendC.Order.Application.Features.CQRS.Handlers.ProductHandlers;
using TesodevBackendC.Order.Application.Features.CQRS.Handlers.ProductOrderDetailHandlers;
using TesodevBackendC.Order.Application.Features.CQRS.Queries.ProductOrderDetailQueries;
using TesodevBackendC.Order.Application.Interfaces;
using TesodevBackendC.Order.Application.Validators.OrderDetailValidators;
using TesodevBackendC.Order.Application.Validators.ProductValidators;
using TesodevBackendC.Order.Domain.Entities;
using TesodevBackendC.Order.Persistence.Context;
using TesodevBackendC.Order.Persistence.Repositories;
using TesodevBackendC.Order.WebApi.OrderConsumer;

var builder = WebApplication.CreateBuilder(args);

//Repositories configuration
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//DbContext configuration
builder.Services.AddDbContext<OrderDbContext>();

//OrderDetail configurations
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<DeleteOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
builder.Services.AddScoped<ChangeOrderStatusToFalseCommandHandler>();
builder.Services.AddScoped<ChangeOrderStatusToTrueCommandHandler>();

//OrderLog configurations
builder.Services.AddScoped<CreateOrderLogCommandHandler>();

//Product configurations
builder.Services.AddScoped<GetProductByIdQueryHandler>();
builder.Services.AddScoped<GetProductQueryHandler>();
builder.Services.AddScoped<CreateProductCommandHandler>();
builder.Services.AddScoped<DeleteProductCommandHandler>();
builder.Services.AddScoped<UpdateProductCommandHandler>();

//ProductOrderDetails configuration
builder.Services.AddScoped<GetProductListByOrderDetailIdQueryHandler>();

//OrderConsumer configuration
builder.Services.AddSingleton<OrderConsumer>();

//Cors Policy configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

//FluentValidation configurations
builder.Services.AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<CreateProductCommandValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<UpdateProductCommandValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<CreateOrderDetailCommandValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<UpdateOrderDetailCommandHandler>();
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Cors configuration
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

//OrderConsumer configuration
var orderConsumer = app.Services.GetRequiredService<OrderConsumer>();
orderConsumer.Start();

app.Run();



