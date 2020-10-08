using AutoMapper;
using EternityStore.Data.Repository;

namespace EternityStore.Data.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DataContext _datacontext;
        private readonly IMapper _mapper;
        private IAuthRepository _authRepository;
        private IProductRepository _productRepository;
        private IProductCategoryRepository _productCategoryRepository;
        private IOrderRepository _orderRepository;

        public UnitOfWork(DataContext datacontext, IMapper mapper)
        {
            _datacontext = datacontext;
            _mapper = mapper;
        }

        public IAuthRepository AuthRepository
        {
            get { return _authRepository ??= new AuthRepository(_datacontext, _mapper); }
        }

        public IProductRepository ProductRepository 
        {
            get { return _productRepository ??= new ProductRepository(_datacontext,_mapper); }
        }

        public IProductCategoryRepository ProductCategoryRepository { 
            get { return _productCategoryRepository ??= new ProductCategoryRepository(_datacontext, _mapper); }
        }

       public IOrderRepository OrderRepository
        {
            get { return _orderRepository ??= new OrderRepository(_datacontext, _mapper); }
        }

     


        public void Commit()
        {
            _datacontext.SaveChangesAsync();
        }

        public void Rollback()
        {
            _datacontext.DisposeAsync();
        }
    }
}
