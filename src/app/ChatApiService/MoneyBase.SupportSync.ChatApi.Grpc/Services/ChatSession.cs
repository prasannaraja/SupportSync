
using Grpc.Core;

namespace MoneyBase.SupportSync.ChatApi.Grpc.Services;

public class ChatSession : SessionService.SessionServiceBase
{
    private readonly ILogger<ChatSession> _logger;
    public ChatSession(ILogger<ChatSession> logger) => _logger = logger;

    //CreateSession (CreateSessionRequest) returns (CreateSessionResponse)
    public override async Task<CreateSessionResponse> CreateSession(CreateSessionRequest request, ServerCallContext context)
    {
        return await Task.FromResult(new CreateSessionResponse());
    }
}
