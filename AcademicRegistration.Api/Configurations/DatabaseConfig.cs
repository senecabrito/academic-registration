using AcademicRegistration.Data.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace AcademicRegistration.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["MSSQLServerSQLConnection:MSSQLServerSQLConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("Connection string not found", nameof(connectionString));

            services.AddDbContext<MSSQLContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }

    }
}
