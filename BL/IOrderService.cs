using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tema2.Models;
using tema2.Utils;

namespace tema2.BL
{
    public interface IOrderService
    {
        List<ViewOrder> getAll();
        ViewOrder getOne(int id);
        Task update(Order entity);
        Task remove(Order entity);
        Task save(Order entity);
        Task modifyStatus(Order order, Status status);
        List<ViewOrder> showOrdersBetween(DateTime start, DateTime end);
        Task ProcessOrder(Order order, Dictionary<int, int> meals);
    }
}
