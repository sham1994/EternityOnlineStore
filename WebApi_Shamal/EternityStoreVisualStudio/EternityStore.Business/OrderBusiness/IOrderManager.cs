using EternityStore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EternityStore.Business.OrderBusiness
{
    public interface IOrderManager
    {
        Task<IList<OrderForListDto>> GetOrders(int id);
        Task<OrderForListDto> AddOrder(OrderForListDto orderForListDto);
    }
}
