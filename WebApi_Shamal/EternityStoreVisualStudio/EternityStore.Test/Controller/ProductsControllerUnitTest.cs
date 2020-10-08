using AutoMapper;
using EternityStore.API.Controllers;
using EternityStore.Data.Repository;
using EternityStore.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace EternityStore.Test.Controller
{
    [TestClass]

    /////// WRITE FOR BUSINESS LAYER IMP
    public class ProductsControllerUnitTest
    {
        ProductsController _productsController;
        //IProductRepository repo, IMapper mapper, ILogger<ProductsController> logger
        Mock<IProductRepository> _productRepositoryMock;
        Mock<IMapper> _mapperMock;
        //using Castle.Core.Logging; not this one 
        Mock<ILogger<ProductsController>> _loggerMock;

        [TestInitialize]
        public void ProductsControllerInitialize()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<ProductsController>>();
            
        }

        //GetProducts()
        [TestMethod]
        public async System.Threading.Tasks.Task GetProducts_WhenSuccessful_ReturnProductListAsync()
        {
            //GetProductList_Successful
            //GetProductList_WithError401

            IList<ProductForListDto> productsObj = new List<ProductForListDto>();
            ProductForListDto product = new ProductForListDto();
            product.Id = 1;
            product.Name = "TestProduct";
            product.ProductCategoryId = 1;
            productsObj.Add(product);
            //mock setup
            _productRepositoryMock.Setup(s => s.GetProducts()).ReturnsAsync(productsObj);
            //_productsController = new ProductsController(_productRepositoryMock.Object, _mapperMock.Object);

            IActionResult actionResult = await _productsController.GetProducts();

            //System.Threading.Tasks.Task<IActionResult> returnproduct = _productsController.GetProducts();
            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)actionResult).StatusCode);
          }
        //public async System.Threading.Tasks.Task GetProducts_WhenUnSuccessful() { }
    }
}
