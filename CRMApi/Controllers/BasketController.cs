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
    public class BasketController : ControllerBase
    {

        private readonly ILogger<BasketController> _logger;

        public BasketController(ILogger<BasketController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {

            return "Welcome to our basket page";
        }

        [HttpGet("all")]
        public List<Basket> getAllBasket()
        {
            using CrmDbContext db = new CrmDbContext();
            BasketManagement bskMangr = new BasketManagement(db);
            return db.Baskets.ToList();
        }

        [HttpGet("{id}")]
        public List<Basket> GetBasket(int id)
        {
            using CrmDbContext db = new CrmDbContext();
            BasketManagement basktMangr = new BasketManagement(db);
            return basktMangr.FindCustomerBaskets(id);
        }

        [HttpPost("")]
        public Basket PostBasket(BasketOption bskOpt)
        {
            using CrmDbContext db = new CrmDbContext();
            BasketManagement bskMangr = new BasketManagement(db);
            return bskMangr.CreateBasket(bskOpt);

        }


        [HttpDelete("delete/{id}")]
        public bool DeleteBasket(int id)
        {
            using CrmDbContext db = new CrmDbContext();
            BasketManagement bskMangr = new BasketManagement(db);
            return bskMangr.DeleteBasketById(id);
        }



    }
}
