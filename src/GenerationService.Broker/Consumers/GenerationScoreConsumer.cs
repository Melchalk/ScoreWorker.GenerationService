using GenerationService.Business.Interfaces;
using GenerationService.Models.Dto.Requests;
using MassTransit;

namespace GenerationService.Broker.Consumers;

public class GenerationScoreConsumer(IGenerateScoreCommand command) : IConsumer<GenerateScoreRequest>
{
    public async Task Consume(ConsumeContext<GenerateScoreRequest> context)
    {
        var actionResult = await command.ExecuteAsync(context.Message.UserId, default);

        await context.RespondAsync(actionResult);
    }
}
