using EternityStore.Data.Repository;

namespace EternityStore.Data.UnitOfWork
{
    public interface IUnitOfWork
    
    {
       IAuthRepository AuthRepository { get; }
       IProductRepository ProductRepository { get; }
       IProductCategoryRepository ProductCategoryRepository { get; }
       IOrderRepository OrderRepository { get; }

        void Commit();
        void Rollback();
    }
}
