using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace Sales.Messages.Events
{
    public class OrderCreated : IEvent
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public double Amount { get; set; }
    }
}
