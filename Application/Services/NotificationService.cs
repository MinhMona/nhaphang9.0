using Domain.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services
{
    public class NotificationService : BackgroundService
    {
        public IBackgroundNotiQueue TaskQueue { get; }

        public NotificationService(IBackgroundNotiQueue taskQueue)
        {
            TaskQueue = taskQueue;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var workItem = await TaskQueue.DequeueAsync(stoppingToken);

                try
                {
                    await workItem(stoppingToken);
                }
                catch (Exception ex)
                {
                    
                }
            }
        }
    }
}
