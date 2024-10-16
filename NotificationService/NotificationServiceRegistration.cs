using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationService.data.mapper;
using NotificationService.data.Models;
using NotificationService.data.respositories;
using NotificationService.dto;
using NotificationService.helpers.json;
using NotificationService.interfaces;
using NotificationService.publisher;
using NotificationService.services;
using NotificationService.validators;
using System.Reflection;

namespace NotificationService
{
    public static class NotificationServiceRegistration
    {
        public static void RegisterServiceNotification(IServiceCollection services)
        {
            services.AddTransient<IHttpApiService, HttpApiService>();

            services.AddTransient<IImageTrackRepository, ImageTrackRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IJsonHelper, JsonHelper>();
            services.AddTransient<IImageTrackService, ImageTrackService>();
            services.AddTransient<IScanPriceService, ScanPriceService>();
            services.AddTransient<IMap<ProductDto,Product>,MapProduct>();
            services.AddTransient<ITasksServiceScanningPrices, TasksServiceScanningPrices>();
            services.AddTransient<IEmailServices, EmailServices>();
            services.AddTransient<IProductValidator, ProductValidator>();
            services.AddTransient<IJsonScanResponseValidator, JsonScanResponseValidator>();
            services.AddTransient<IImageTrackValidator, ImageTrackValidator>();
            services.AddTransient<IPriceChangeEventPublisher, PriceChangeEventPublisher>();

            services.Scan(scan => scan
            .FromAssembliesOf(typeof(UpdateCurrentPriceScanedPublisher))
            .AddClasses(classes => classes.AssignableTo(typeof(IPublisher<>)))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            

            services.AddSingleton<IConfiguration>(configuration);

            services.AddDbContext<TmpContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 26))));
        }
    }
}
