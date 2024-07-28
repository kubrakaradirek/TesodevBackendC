using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TesodevBackendC.Order.Application.Features.CQRS.Commands.ProductCommands;
using TesodevBackendC.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using TesodevBackendC.Order.Application.Features.CQRS.Handlers.ProductHandlers;
using TesodevBackendC.Order.Application.Features.CQRS.Handlers.ProductOrderDetailHandlers;
using TesodevBackendC.Order.Application.Features.CQRS.Queries.ProductOrderDetailQueries;
using TesodevBackendC.Order.Application.Interfaces;
using TesodevBackendC.Order.Application.Validators.OrderDetailValidators;
using TesodevBackendC.Order.Application.Validators.ProductValidators;
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

builder.Services.AddScoped<GetProductListByOrderDetailIdQueryHandler>();



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

builder.Services.AddFluentValidation(fv =>
{
    fv.RegisterValidatorsFromAssemblyContaining<CreateProductCommandValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<UpdateProductCommandValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<CreateOrderDetailCommandValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<UpdateOrderDetailCommandHadnler>();
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();



