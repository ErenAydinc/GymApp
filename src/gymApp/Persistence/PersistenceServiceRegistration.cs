using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options => {
                var connectionString = configuration.GetConnectionString("GymApp");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                options.EnableSensitiveDataLogging();
            });
            //services.AddScoped<ISomeFeatureEntityRepository, SomeFeatureEntityRepository>();


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IBodyInformationRepository, BodyInformationRepository>();
            services.AddScoped<IMemberTypeRepository, MemberTypeRepository>();
            services.AddScoped<IUserMemberTypeMappingRepository, UserMemberTypeMappingRepository>();
            services.AddScoped<IMovementRepository, MovementRepository>();
            services.AddScoped<IImageUploadRepository, ImageUploadRepository>();
            services.AddScoped<IMovementImageUploadMappingRepository, MovementImageUploadMappingRepository>();

            return services;
        }
    }
}
