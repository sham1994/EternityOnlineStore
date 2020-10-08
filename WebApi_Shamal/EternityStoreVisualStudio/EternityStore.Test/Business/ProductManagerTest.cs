using EternityStore.Business.ProductsBusiness;
using EternityStore.Data.Repository;
using EternityStore.Data.UnitOfWork;
using EternityStore.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EternityStore.Test.Business
{
    [TestClass]
    public class ProductManagerTest
    {
        Mock<IUnitOfWork> _mockUnitOfWork;
        Mock<IProductRepository> _mockProductRepository;
        ProductManager productManager;
        ProductForDetailDto productForDetailDto;
        ProductForListDto productForListDto;
        
        [TestInitialize]
        public void TestInitialize()
        {
            productForDetailDto = new ProductForDetailDto()
            {
                Id = 1,
                Name = "TestItem",
                UnitPrice = 12,
                Qty = 5,
                Description = "Test Item for testing",
                ProductCategoryId = 1,
                PhotoUrl = "www.google.lk"

            };

            productForListDto = new ProductForListDto()
            {
                Id = 1,
                Name = "TestProductList Item",
                UnitPrice = 12,
                ProductCategoryId = 1,
                PhotoUrl= "www.google.lk"
            };

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockProductRepository = new Mock<IProductRepository>();
            //_mockProductRepository.Setup(m =>m.GetProducts()).ReturnsAsync(productForListDto);
            _mockProductRepository.Setup(m => m.GetProduct(1)).ReturnsAsync(productForDetailDto);
            _mockUnitOfWork.Setup(m => m.ProductRepository).Returns(_mockProductRepository.Object);
        }

        [TestMethod]
        public void GetProducts_WhenSuccessful_ReturnProductAsync()
        {
            productManager = new ProductManager(_mockUnitOfWork.Object);
            var productObject = productManager.GetProduct(1);
            Assert.AreEqual("TestItem", productObject.Result.Name);
        }



    }
}
