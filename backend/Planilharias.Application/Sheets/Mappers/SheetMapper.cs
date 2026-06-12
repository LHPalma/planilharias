using Planilharias.Application.Sheets.DTOs.Response;
using Planilharias.Domain.Sheets.Model;
using Riok.Mapperly.Abstractions;

namespace Planilharias.Application.Sheets.Mappers;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
public partial class SheetMapper
{
    public partial SheetResponse ToResponse(Sheet sheet);

    public partial SheetDetailResponse ToDetailResponse(Sheet sheet);
}