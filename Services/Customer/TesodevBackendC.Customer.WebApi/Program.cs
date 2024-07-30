using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;
using TesodevBackendC.Customer.WebApi.Business.Abstract;
using TesodevBackendC.Customer.WebApi.Business.Concrete;
using TesodevBackendC.Customer.WebApi.DataAccess.Abstract;
using TesodevBackendC.Customer.WebApi.DataAccess.Concrete;
using TesodevBackendC.Customer.WebApi.DataAccess.EntityFramework;
using TesodevBackendC.Customer.WebApi.Validators.AddressValidator;

var builder = WebApplication.CreateBuilder(args);


//Add DbContext configuration
builder.Services.AddDbContext<CustomerDbContext>();

//AutoMapper configuration
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//Address configurations
builder.Services.AddScoped<IAddressService, AddressManager>();
builder.Services.AddScoped<IAddressDal, EfAddressDal>();

//Customers configurations
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();

//CORS policy configuration
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

//FluentValidation configuration
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Enabling CORS policy configuration
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();