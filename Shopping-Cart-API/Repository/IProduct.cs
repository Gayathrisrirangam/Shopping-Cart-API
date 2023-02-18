using Shopping_Cart_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Repository
{
    public interface IProduct
    {
        public string SaveProduct(ProductT product);
        public string UpdateProduct(ProductT product);
        public string DeleteProduct(int ProductId);
        ProductT GetProduct(int ProductId);
        List<ProductT> GetAllProduct();
    }
}
