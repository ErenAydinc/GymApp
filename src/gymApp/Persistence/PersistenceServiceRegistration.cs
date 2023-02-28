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
            services.AddScoped<IMovementRepository, MovementRepository>();
            services.AddScoped<IMovementImageRepository, MovementImageRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICustomerToMovementMappingRepository, CustomerToMovementMappingRepository>();
            services.AddScoped<IPersonalTrainerStudentRepository, PersonalTrainerStudentRepository>();
            services.AddScoped<IUsersMovementRepository, UsersMovementRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
