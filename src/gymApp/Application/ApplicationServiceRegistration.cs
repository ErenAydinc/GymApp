using Application.Features.Auths.Rules;
using Application.Features.BodyInformations.Rules;
using Application.Features.MemberTypes.Rules;
using Application.Features.MovementImageUploadMappings.Rules;
using Application.Features.Movements.Rules;
using Application.Features.OperationClaims.Rules;
using Application.Features.UserMemberTypeMappings.Rules;
using Application.Features.UserOperationClaims.Rules;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.ImageService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<BodyInformationBusinessRules>();
            services.AddScoped<MemberTypeBusinessRules>();
            services.AddScoped<UserOperationClaimBusinessRules>();
            services.AddScoped<OperationClaimBusinessRules>();
            services.AddScoped<UserMemberTypeMappingBusinessRules>();
            services.AddScoped<MovementBusinessRules>();
            services.AddScoped<MovementImageUploadMappingBusinessRules>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddScoped<IAuthService,AuthManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IImageService, ImageManager>();

            return services;

        }
    }
}