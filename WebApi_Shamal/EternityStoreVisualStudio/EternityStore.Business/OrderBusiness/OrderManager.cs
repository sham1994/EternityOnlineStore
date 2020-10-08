using EternityStore.Data.UnitOfWork;
using EternityStore.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EternityStore.Business.OrderBusiness
{
    public class OrderManager : IOrderManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderForListDto> AddOrder(OrderForListDto orderForListDto)
        {
            try
            {
                await _unitOfWork.OrderRepository.AddOrder(orderForListDto).ConfigureAwait(false);
                _unitOfWork.Commit();
                return orderForListDto;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                _unitOfWork.Rollback();
                return null;
            }
        }

        public async Task<IList<OrderForListDto>> GetOrders(int id)
        {
            try
            {

                return await _unitOfWork.OrderRepository.GetOrders(id);
            }
            catch(Exception)
            {
                _unitOfWork.Rollback();
                return null;
            }
        }
    }
}
