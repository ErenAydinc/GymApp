using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Core.Application.Pipelines.Authorization;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
                                        RequestHandlerDelegate<TResponse> next)
    {
        List<string>? userRoles = _httpContextAccessor.HttpContext.User.ClaimRoles();

        if (userRoles == null) throw new AuthorizationException("Claims not found.");
        
        bool isNotMatchedARoleClaimWithRequestRoles =
            userRoles.FirstOrDefault(userRoles => request.Roles.Any(role => role == userRoles)).IsNullOrEmpty();
        if (isNotMatchedARoleClaimWithRequestRoles) throw new AuthorizationException("You are not authorized.");

        TResponse response = await next();
        return response;
    }
}