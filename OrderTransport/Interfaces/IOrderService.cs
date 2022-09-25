using OrderTransport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderTransport.Interfaces
{
    public interface IOrderService
    {
        List<OrderScheduleViewModel> GetOrderSchedule();
    }
}
