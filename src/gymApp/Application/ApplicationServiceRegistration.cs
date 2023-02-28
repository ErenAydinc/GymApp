using Application.Features.Auths.Rules;
using Application.Features.BodyInformations.Rules;
using Application.Features.Categories.Rules;
using Application.Features.Companies.Rules;
using Application.Features.Customers.Rules;
using Application.Features.Movements.Rules;
using Application.Features.OperationClaims.Rules;
using Application.Features.PersonalTrainerStudents.Rules;
using Application.Features.UserOperationClaims.Rules;
using Application.Features.Users.Rules;
using Application.Features.UsersMovements.Rules;
using Application.Helpers;
using Application.Services.AuthService;
using Application.Services.MovementImageService;
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
            services.AddScoped<UserOperationClaimBusinessRules>();
            services.AddScoped<OperationClaimBusinessRules>();
            services.AddScoped<MovementBusinessRules>();
            services.AddScoped<CustomerBusinessRules>();
            services.AddScoped<CompanyBusinessRules>();
            services.AddScoped<PersonalTrainerStudentBusinessRules>();
            services.AddScoped<UsersMovementBusinessRules>();
            services.AddScoped<CategoryBusinessRules>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddScoped<IAuthService,AuthManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IMovementImageService, MovementImageManager>();
            services.AddScoped<IHelperService, HelperManager>();

            return services;

        }
    }
}