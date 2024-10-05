using Microsoft.Extensions.DependencyInjection;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Domain.Entities.Cliente;
using Infrastructure.Repositories;
using Application.SeedOfWork;

namespace Infrastructure
{
     public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {

          services.AddDbContext<Loan_DbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DbConn")));
             //.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

            services.AddScoped<IUnitOfWork>(unit=> unit.GetRequiredService<Loan_DbContext>());

            services.AddScoped<IClienteRepository, ClienteRepositoryImplementation>();
            return services;
        }
    }
}
