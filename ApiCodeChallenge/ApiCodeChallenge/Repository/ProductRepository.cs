using ApiCodeChallenge.Model;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiCodeChallenge.Repository
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> products = new List<Product>();
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DeleteProduct(int productId)
        {
            var pro = (from p in products
                        where p.ProductId == productId
                        select p).SingleOrDefault();
            products.Remove(pro);
        }

        public List<Product> GetProductByCategory(string category)
        {
            var pro = (from p in products
                        where p.Category == category
                        select p).ToList();
            return pro;
        }

        public Product GetProductById(int Id)
        {
            var pro = (from p in products
                        where p.ProductId == Id
                        select p).SingleOrDefault();
            return pro;
        }

        public List<Product> GetProductByName(string name)
        {
            var prod = (from p in products
                        where p.ProductName == name
                        select p).ToList();
            return prod;
        }

        public void UpdateProduct(Product product)
        {
            var pro = (from p in products
                        where p.ProductId == product.ProductId
                        select p).SingleOrDefault();
            pro.ProductName = product.ProductName;
            pro.Price = product.Price;
            pro.Category = product.Category;
            pro.Stock = product.Stock;
        }
    }
}
