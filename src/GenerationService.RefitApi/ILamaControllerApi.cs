using GenerationService.Models.Dto.DTO;
using Refit;

namespace GenerationService.RefitApi;

/// <summary>
/// Interface for interacting with the generation API
/// </summary>
public interface ILamaControllerApi
{
    public const string LamaApi = "";

    [Post("/generate")]
    public Task<string> GenerateScore([Body] GenerateLamaRequest request);
}