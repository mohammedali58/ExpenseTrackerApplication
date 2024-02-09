using AutoMapper;
using Domain.Common.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.Entity;

namespace Infrastructure
{
    public static class InfrastructureConfigurations
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configurations)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(configurations.GetConnectionString("WriteConnection"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                ));
            services.AddDbContext<ApplicationDbContext>(dbContextOptionsBuilder => 
                    dbContextOptionsBuilder.UseSqlite(configurations.GetConnectionString("WriteConnection")));

            services.AddScoped<IReadExpenseRepository, ReadExpenseRepository>(options =>
            {
                var sqlOption = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(configurations.GetConnectionString("ReadConnection"))
                .Options;
                var dbContext = new ApplicationDbContext(sqlOption);
                // Create repository and pass the dbContext
                return new ReadExpenseRepository(dbContext, options.GetService<IMapper>());

            });
            services.AddScoped<IWriteExpenseRepository, WriteExpenseRepository>(options =>
            {
                var sqlOption = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(configurations.GetConnectionString("WriteConnection"))
                .Options;
                var dbContext = new ApplicationDbContext(sqlOption);
                // Create repository and pass the dbContext
                return new WriteExpenseRepository(dbContext, options.GetService<IMapper>());

            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<ApplicationDbContextInitializer>();

            return services;

        }
    }
}
