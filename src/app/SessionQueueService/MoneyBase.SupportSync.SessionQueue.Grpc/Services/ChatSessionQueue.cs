using Grpc.Core;
using System.Collections.Concurrent;

namespace MoneyBase.SupportSync.SessionQueue.Grpc.Services
{
    public class ChatSessionQueue : SessionQueueService.SessionQueueServiceBase
    {
        private readonly ConcurrentQueue<Session> _queue = new ConcurrentQueue<Session>();
        private readonly ConcurrentDictionary<string, Session> _sessions = new ConcurrentDictionary<string, Session>();

        public override Task<EnqueueSessionResponse> EnqueueSession(EnqueueSessionRequest request, ServerCallContext context)
        {
            var session = new Session
            {
                SessionId = request.SessionId,
                UserId = request.UserId,
                InitialMessage = request.InitialMessage
            };

            _queue.Enqueue(session);
            _sessions[session.SessionId] = session;

            var response = new EnqueueSessionResponse
            {
                Success = true,
                Message = "Session enqueued successfully"
            };

            return Task.FromResult(response);
        }

        public override Task<DequeueSessionResponse> DequeueSession(DequeueSessionRequest request, ServerCallContext context)
        {
            if (_queue.TryDequeue(out var session))
            {
                _sessions.TryRemove(session.SessionId, out _);
                var response = new DequeueSessionResponse
                {
                    SessionId = session.SessionId,
                    Success = true,
                    Message = "Session dequeued successfully"
                };
                return Task.FromResult(response);
            }
            else
            {
                var response = new DequeueSessionResponse
                {
                    Success = false,
                    Message = "No sessions available in queue"
                };
                return Task.FromResult(response);
            }
        }

        public override Task<GetQueueStatusResponse> GetQueueStatus(GetQueueStatusRequest request, ServerCallContext context)
        {
            var response = new GetQueueStatusResponse
            {
                TotalSessions = _queue.Count,
                ActiveSessions = _sessions.Count
            };

            return Task.FromResult(response);
        }

        public override Task<MarkSessionInactiveResponse> MarkSessionInactive(MarkSessionInactiveRequest request, ServerCallContext context)
        {
            if (_sessions.TryGetValue(request.SessionId, out var session))
            {
                session.Status = "inactive";
                var response = new MarkSessionInactiveResponse
                {
                    Success = true,
                    Message = "Session marked as inactive"
                };
                return Task.FromResult(response);
            }
            else
            {
                var response = new MarkSessionInactiveResponse
                {
                    Success = false,
                    Message = "Session not found"
                };
                return Task.FromResult(response);
            }
        }

        public override Task<GetSessionDetailsResponse> GetSessionDetails(GetSessionDetailsRequest request, ServerCallContext context)
        {
            if (_sessions.TryGetValue(request.SessionId, out var session))
            {
                var response = new GetSessionDetailsResponse
                {
                    SessionId = session.SessionId,
                    UserId = session.UserId,
                    Status = session.Status,
                    Messages = { session.Messages }
                };
                return Task.FromResult(response);
            }
            else
            {
                var response = new GetSessionDetailsResponse
                {
                    SessionId = request.SessionId,
                    Status = "Session not found"
                };
                return Task.FromResult(response);
            }
        }
    }

    public class Session
    {
        public string SessionId { get; set; }
        public string UserId { get; set; }
        public string InitialMessage { get; set; }
        public string Status { get; set; } = "active";
        public List<string> Messages { get; set; } = new List<string>();
    }
}
