using Microsoft.EntityFrameworkCore;
using Npgsql;
using Planilharias.Api.ExceptionHandling;
using Planilharias.Application.Sheets.Mappers;
using Planilharias.Application.Sheets.Query;
using Planilharias.Application.Sheets.UseCases;
using Planilharias.Application.Workbooks;
using Planilharias.Application.Workbooks.Command;
using Planilharias.Application.Workbooks.Mappers;
using Planilharias.Application.Workbooks.Query;
using Planilharias.Application.Workbooks.UseCases;
using Planilharias.Domain.Sheets.Repositories;
using Planilharias.Domain.Workbooks.Repositories;
using Planilharias.Infrastructure.Data;
using Planilharias.Infrastructure.Sheets.Repositories;
using Planilharias.Infrastructure.Workbooks.Repositories;

var builder = WebApplication.CreateBuilder(args);

#region Services

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<DomainExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

#endregion


var app = builder.Build();

app.UseExceptionHandler();

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
    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructure(IConfiguration configuration)
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

        public IServiceCollection AddApplication()
        {
            #region Workbooks

            // UseCases
            services.AddScoped<IGetWorkbookByIdUseCase, GetWorkbookByIdUseCase>();
            services.AddScoped<IGetWorkbooksUseCase, GetWorkbooksUseCase>();
            services.AddScoped<ICreateWorkbookUseCase, CreateWorkbookUseCase>();

            // Commands
            services.AddScoped<ICreateWorkbookCommandHandler, CreateWorkbookCommandHandler>();

            // Queries
            services.AddScoped<IGetWorkbookByIdQueryHandler, GetWorkbookByIdQueryHandler>();
            services.AddScoped<IGetWorkbooksQueryHandler, GetWorkbooksQueryHandler>();

            // Mappers
            services.AddScoped<WorkbookMapper>();

            #endregion

            #region Sheets

            // UseCases
            services.AddScoped<IGetSheetsByWorkbookUseCase, GetSheetsByWorkbookUseCase>();
            services.AddScoped<IGetSheetDetailUseCase, GetSheetDetailUseCase>();

            // Queries
            services.AddScoped<IGetSheetsQueryHandler, GetSheetsQueryHandler>();
            services.AddScoped<IGetSheetQueryHandler, GetSheetQueryHandler>();

            // Mappers
            services.AddScoped<SheetMapper>();

            #endregion

            return services;
        }
    }
}