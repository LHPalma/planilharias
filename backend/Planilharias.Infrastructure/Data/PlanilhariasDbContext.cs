using Microsoft.EntityFrameworkCore;
using Planilharias.Domain.Sheets.Models;
using Planilharias.Domain.Workbooks.Models;

namespace Planilharias.Infrastructure.Data;

public class PlanilhariasDbContext(DbContextOptions<PlanilhariasDbContext> options) : DbContext(options)
{
    public DbSet<Workbook> Workbooks => Set<Workbook>();


    public DbSet<Sheet> Sheets => Set<Sheet>();
}