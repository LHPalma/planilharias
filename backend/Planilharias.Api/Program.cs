using Microsoft.EntityFrameworkCore;
using Planilharias.Application.Workbooks;
using Planilharias.Domain.Workbooks.Repositories;
using Planilharias.Infrastructure.Data;
using Planilharias.Infrastructure.Workbooks.Query;
using Planilharias.Infrastructure.Workbooks.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<PlanilhariasDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
        .UseSnakeCaseNamingConvention());

builder.Services.AddScoped<IWorkbookBaseRepository, WorkbookRepository>();
builder.Services.AddScoped<IGetWorkbooksQueryHandler, GetWorkbooksQueryHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseHttpsRedirection();
app.Run();