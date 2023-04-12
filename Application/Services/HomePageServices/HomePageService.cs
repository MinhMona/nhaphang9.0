using Application.Utilities;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.HomeInterfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.HomePageServices
{
    public class HomePageService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceProvider;


        public HomePageService(IServiceScopeFactory serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var service= _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IUnitOfWork>();
            string data = await service.QueryRepository().ExcuteStoreNoneInput("CustomerBenefitJson", "CustomerBenefit");
            WriteDataToHomeJson.WriteData(data, "CustomerBenefit");
            data = await service.QueryRepository().ExcuteStoreNoneInput("CustomerTalkJson", "CustomerTalk");
            WriteDataToHomeJson.WriteData(data, "CustomerTalk");
            data = await service.QueryRepository().ExcuteStoreNoneInput("MenuJson", "Menu");
            WriteDataToHomeJson.WriteData(data, "Menu");
            data = await service.QueryRepository().ExcuteStoreNoneInput("ServiceJson", "Service");
            WriteDataToHomeJson.WriteData(data, "Service");
            data = await service.QueryRepository().ExcuteStoreNoneInput("StepJson", "Step");
            WriteDataToHomeJson.WriteData(data, "Step");
            data = await service.QueryRepository().ExcuteStoreNoneInput("WebConfigurationJson", "WebConfiguration");
            WriteDataToHomeJson.WriteData(data, "WebConfiguration");
        }
    }
}
