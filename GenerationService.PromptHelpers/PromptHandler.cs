﻿using GenerationService.Models.Dto.DTO;
using GenerationService.Models.Dto.Enum;
using GenerationService.PromptHelpers.Interfaces;
using GenerationService.RefitApi;
using Refit;
using System.Text;

namespace GenerationService.PromptHelpers;

public class PromptHandler : IPromptHandler
{
    public async Task<string> GetSummary(
        PromptType promptType,
        List<ReviewInfo> reviews,
        CancellationToken cancellationToken)
    {
        var filePath = PromptPathContainer.SwitchPromptPath(promptType);

        var prompt = await PreparePrompt(filePath, reviews, cancellationToken);

        return await EvaluateReviewsWithLLM(prompt, cancellationToken);
    }

    #region Private

    private async Task<string> PreparePrompt(
        string filePrompt, List<ReviewInfo> reviews, CancellationToken cancellationToken)
    {
        StringBuilder builder = new();

        for (int i = 1; i <= reviews.Count; i++)
            builder.AppendLine($"Review {i}:\n{reviews[i - 1].Review}");

        string samplePrompt = (await File.ReadAllTextAsync(filePrompt, cancellationToken))
            .Replace("\\n", "\n");

        return string.Format(samplePrompt, builder.ToString());
    }

    private async Task<string> EvaluateReviewsWithLLM(
        string prompt, CancellationToken cancellationToken)
    {
        var apiService = RestService.For<ILamaControllerApi>(ILamaControllerApi.VkScoreWorkerApi);

        var request = new GenerateScoreRequest()
        {
            Prompt = prompt,
            ApplyChatTemplate = true,
            SystemPrompt = "You are a helpful assistant of an HR speacialist that rates employees of the company they work at.",
            N = 1,
            Temperature = 0.3
        };

        return await apiService.GenerateScore(request);
    }

    #endregion
}
