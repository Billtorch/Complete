using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmApp;
using CrmApp.Options;
using CrmApp.Repository;
using CrmApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CRMApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {

            return "Welcome to our product page";
        }

        [HttpGet("all")]
        public List<Product> getAllProduct()
        {
            using CrmDbContext db = new CrmDbContext();
            ProductManagement prodMangr = new ProductManagement(db);
            return db.Products.ToList();
        }

        [HttpGet("{id}")]
        public Product getProduct(int id)
        {
            using CrmDbContext db = new CrmDbContext();
            ProductManagement prodMangr = new ProductManagement(db);
            return prodMangr.FindProductById(id);
        }

        [HttpPost("")]
        public Product PostProduct(ProductOption prodOpt)
        {
            using CrmDbContext db = new CrmDbContext();
            ProductManagement prodMangr = new ProductManagement(db);
            return prodMangr.CreateProduct(prodOpt);

        }
        [HttpPut("{id}")]
        public Product PutProduct(int id, ProductOption prodOpt)
        {
            using CrmDbContext db = new CrmDbContext();
            ProductManagement prodMangr = new ProductManagement(db);
            return prodMangr.Update(prodOpt, id);
        }

        [HttpDelete("delete/{id}")]
        public bool DeleteProduct(int id)
        {
            using CrmDbContext db = new CrmDbContext();
            ProductManagement prodMangr = new ProductManagement(db);
            return prodMangr.DeleteProductById(id);
        }


    }
}
