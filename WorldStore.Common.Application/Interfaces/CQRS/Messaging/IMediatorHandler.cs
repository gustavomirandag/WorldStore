using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorldStore.Common.Domain.Application.CQRS.Messaging
{
    public interface IMediatorHandler
    {
        Task<bool> EnqueueAsync<T>(T command, string queueName);
    }
}
