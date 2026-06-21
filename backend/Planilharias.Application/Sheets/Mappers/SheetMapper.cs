using Planilharias.Application.Sheets.DTOs.Responses;
using Planilharias.Domain.Sheets.Models;
using Riok.Mapperly.Abstractions;

namespace Planilharias.Application.Sheets.Mappers;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
public partial class SheetMapper
{
    public partial SheetResponse ToResponse(Sheet sheet);

    public partial SheetDetailResponse ToDetailResponse(Sheet sheet);
}