using GenerationService.Models.Dto.Responses;

namespace GenerationService.Business.Interfaces;

public interface IGenerateScoreCommand
{
    Task<ResponseInfo<GetSummaryResponse>> ExecuteAsync(Guid userId, CancellationToken cancellationToken);
}
