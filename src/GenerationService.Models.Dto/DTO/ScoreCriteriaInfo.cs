using GenerationService.Models.Dto.Enum;

namespace GenerationService.Models.Dto.DTO;

public class ScoreCriteriaInfo
{
    public int IDUnderReview { get; set; }
    public ScoreCriteriaType Type { get; set; }
    public int Score { get; set; }
    public required string Description { get; set; }
}
