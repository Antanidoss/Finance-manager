﻿using AutoMapper;
using FinanceManager.Application.Common.DTO;
using FinanceManager.Application.Common.Mappings;
using FinanceManager.Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(assembly);

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ReportDTOProfile());
                mc.AddProfile(new DailyReportDTOProfile());
                mc.AddProfile(new AppUserDTOProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipe<,>));

            return services;
        }
    }
}
