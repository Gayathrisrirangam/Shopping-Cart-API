using Shopping_Cart_API.Models;
using Shopping_Cart_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Services
{
    public class ProductService
    {
        public IProduct _ProductRepository;

        public ProductService(IProduct Product)
        {
            _ProductRepository = Product;
        }

        public string SaveProduct(ProductT Product)
        {
            return _ProductRepository.SaveProduct(Product);
        }

        public string DeleteProduct(int ProductId)
        {
            return _ProductRepository.DeleteProduct(ProductId);
        }

        public string UpdateProduct(ProductT Product)
        {
            return _ProductRepository.UpdateProduct(Product);
        }

        public ProductT GetProduct(int ProductId)
        {
            return _ProductRepository.GetProduct(ProductId);
        }

        public List<ProductT> GetAllProduct()
        {
            return _ProductRepository.GetAllProduct();
        }
    }
}
