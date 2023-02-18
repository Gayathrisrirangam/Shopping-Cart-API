using Microsoft.EntityFrameworkCore;
using Shopping_Cart_API.Data;
using Shopping_Cart_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Cart_API.Repository
{
    public class ProductRepo : IProduct
    {
        private ShoppingCartDbContext _ShoppingCartDb;

        #region ProductRepo
        public ProductRepo(ShoppingCartDbContext shoppingCartDb)
        {
            _ShoppingCartDb = shoppingCartDb;
        }
        #endregion

        #region DeleteProduct
        /// <summary>
        /// Method for deleting product
        /// </summary>
        public string DeleteProduct(int ProductId)
        {
            string msg = "";
            ProductT delete = _ShoppingCartDb.ProductT.Find(ProductId);
            //storing the details of the Product in the obj 
            try
            {
                if (delete != null)
                {
                    _ShoppingCartDb.ProductT.Remove(delete);
                    _ShoppingCartDb.SaveChanges();
                    msg = "Product Deleted";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return msg;
        }
        #endregion


        #region GetAllProduct
        /// <summary>
        /// Method to get all the product
        /// </summary>
        public List<ProductT> GetAllProduct()
        {

            List<ProductT> product = _ShoppingCartDb.ProductT.ToList();
            return product;
        }
        #endregion


        #region GetProduct
        /// <summary>
        /// Method to get product by id
        /// </summary>
        public ProductT GetProduct(int ProductId)
        {
            try
            {
                ProductT product = _ShoppingCartDb.ProductT.Find(ProductId);
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        #region SaveProduct
        /// <summary>
        /// Method to save the product details
        /// </summary>
        public string SaveProduct(ProductT Product)
        {
            try
            {
                _ShoppingCartDb.ProductT.Add(Product);
                _ShoppingCartDb.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return "Product Saved";
        }
        #endregion


        #region UpdateProduct
        /// <summary>
        /// Method to Update product details
        /// </summary>
        public string UpdateProduct(ProductT Product)
        {
            try
            {
                _ShoppingCartDb.Entry(Product).State = EntityState.Modified;
                _ShoppingCartDb.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return "Product Updated";
        }
        #endregion
    }
}
