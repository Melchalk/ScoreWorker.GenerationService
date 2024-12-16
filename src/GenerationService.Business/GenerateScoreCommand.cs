using GenerationService.Business.Interfaces;
using GenerationService.Models.Dto.Responses;

namespace GenerationService.Business;

public class GenerateScoreCommand : IGenerateScoreCommand
{
    public Task<ResponseInfo<GetSummaryResponse>> ExecuteAsync(
        Guid userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
