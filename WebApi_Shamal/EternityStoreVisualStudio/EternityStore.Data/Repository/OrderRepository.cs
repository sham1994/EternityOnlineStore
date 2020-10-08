using AutoMapper;
using EternityStore.Data.Model;
using EternityStore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EternityStore.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IList<OrderForListDto>> GetOrders(int id)
        {
            //var orders = await _context.OrderHeaders.Include(p => p.).FirstOrDefaultAsync(c => c.Id == id);
            //return _mapper.Map<ProductCategoryForDetailDto>(category);

            //WORKING CODE///
            //var orders = await _context.OrderHeaders.Include(p => p.OrderDetails).AllAsync(c => c.User.Id == id);
            //return _mapper.Map<List<OrderForListDto>>(orders);

            throw new NotImplementedException();
        }

        public async Task<OrderForListDto> AddOrder(OrderForListDto orderForListDto)
        {
            //OrderHeader order = _mapper.Map<OrderHeader>(orderForListDto);
            try
            {
                OrderHeader order = _mapper.Map<OrderForListDto, OrderHeader>(orderForListDto);
                await _context.OrderHeaders.AddAsync(order).ConfigureAwait(false);


                return orderForListDto;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
