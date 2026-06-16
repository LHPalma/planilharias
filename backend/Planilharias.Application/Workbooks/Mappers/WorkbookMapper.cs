using Planilharias.Application.Workbooks.DTOs.Responses;
using Planilharias.Domain.Workbooks.Model;
using Riok.Mapperly.Abstractions;

namespace Planilharias.Application.Workbooks.Mappers;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
public partial class WorkbookMapper
{
    public partial WorkbookResponse ToResponse(Workbook workbook);
}