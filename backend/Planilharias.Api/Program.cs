using Microsoft.EntityFrameworkCore;
using Planilharias.Application.Workbooks;
using Planilharias.Application.Workbooks.Mappers;
using Planilharias.Application.Workbooks.UseCases;
using Planilharias.Domain.Workbooks.Repositories;
using Planilharias.Infrastructure.Data;
using Planilharias.Infrastructure.Workbooks.Query;
using Planilharias.Infrastructure.Workbooks.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PlanilhariasDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
        .UseSnakeCaseNamingConvention());

builder.Services.AddScoped<IWorkbookRepository, WorkbookRepository>();
builder.Services.AddScoped<IGetWorkbooksQueryHandler, GetWorkbooksQueryHandler>();
builder.Services.AddScoped<IGetWorkbooksUseCase, GetWorkbooksUseCase>();
builder.Services.AddScoped<WorkbookMapper>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();