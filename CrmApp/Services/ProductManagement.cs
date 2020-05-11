using CrmApp.Options;
using CrmApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrmApp.Services
{
    public class ProductManagement
    {
        private CrmDbContext db;

        public ProductManagement(CrmDbContext _db)
        {
            db = _db;
        }


        //CRUD
        // create read update delete
        public Product CreateProduct(ProductOption prodOption)
        {
            Product product = new Product
            {
                 Name = prodOption.Name,
                 Price = prodOption.Price,
                 Quantity = prodOption.Quantity,
            };


            db.Products.Add(product);
            db.SaveChanges();

            return product;
        }

        public Product Update(ProductOption prodOption, int productId)
        {

            Product product = db.Products.Find(productId);

            if (prodOption.Name != null)
                product.Name = prodOption.Name;
            if (prodOption.Price != 0)
                product.Price = prodOption.Price;
            if (prodOption.Quantity != 0)
                product.Quantity = prodOption.Quantity;


            db.SaveChanges();
            return product;
        }
            public Product FindProductById(int id)
        {
            return db.Products.Find(id);
        }

        public bool DeleteProductById(int id)
        {

            Product product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Product> GetAllProducts()
        {
            return db.Products
                .ToList();
        }



    }
}
