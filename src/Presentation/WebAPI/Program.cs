using Application;
using Application.Features.Brands.Commands.CreateBrand;
using FluentValidation.AspNetCore;
using Infrastructure.Filters;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>()).AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateBrandCommandValidator>()).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();