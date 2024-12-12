﻿using GenerationService.Models.Dto.DTO;

namespace GenerationService.PromptHelpers.Interfaces;

/// <summary>
/// Interface for converting the received prompt into a model
/// </summary>
public interface IPromptParser
{
    public GetSummaryResponse ParseMainSummary(string summary);
}
