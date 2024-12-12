using GenerationService.Models.Dto.DTO;
using GenerationService.Models.Dto.Enum;

namespace GenerationService.PromptHelpers.Interfaces;

/// <summary>
/// Interface for creating, processing and sending a prompt
/// </summary>
public interface IPromptHandler
{
    public Task<string> GetSummary(PromptType promptType, List<ReviewInfo> reviews, CancellationToken cancellationToken);
}
