using Microsoft.EntityFrameworkCore;
using Npgsql;
using Planilharias.Application.Sheets.Mappers;
using Planilharias.Application.Sheets.Query;
using Planilharias.Application.Sheets.UseCases;
using Planilharias.Application.Workbooks;
using Planilharias.Application.Workbooks.Mappers;
using Planilharias.Application.Workbooks.Query;
using Planilharias.Application.Workbooks.UseCases;
using Planilharias.Domain.Sheets.Repositories;
using Planilharias.Domain.Workbooks.Repositories;
using Planilharias.Infrastructure.Data;
using Planilharias.Infrastructure.Sheets.Repositories;
using Planilharias.Infrastructure.Workbooks.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

#region Services

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

#endregion


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

internal static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        var dataSource = new NpgsqlDataSourceBuilder(configuration.GetConnectionString("Default"))
            .EnableDynamicJson()
            .Build();

        services.AddDbContext<PlanilhariasDbContext>(options =>
            options.UseNpgsql(dataSource)
                .UseSnakeCaseNamingConvention());

        services.AddScoped<IWorkbookRepository, WorkbookRepository>();
        services.AddScoped<ISheetRepository, SheetRepository>();

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        #region Workbooks

        services.AddScoped<IGetWorkbooksUseCase, GetWorkbooksUseCase>();
        services.AddScoped<IGetWorkbooksQueryHandler, GetWorkbooksQueryHandler>();
        services.AddScoped<WorkbookMapper>();

        #endregion

        #region Sheets

        services.AddScoped<IGetSheetsByWorkbookUseCase, GetSheetsByWorkbookUseCase>();
        services.AddScoped<IGetSheetDetailUseCase, GetSheetDetailUseCase>();
        services.AddScoped<IGetSheetsQueryHandler, GetSheetsQueryHandler>();
        services.AddScoped<IGetSheetQueryHandler, GetSheetQueryHandler>();
        services.AddScoped<SheetMapper>();

        #endregion

        return services;
    }
}