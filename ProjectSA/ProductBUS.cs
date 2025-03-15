using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSA
{
    public class ProductBUS
    {
            public List<Product> GetAll()
            {
                List<Product> products = new ProductDAO().SelectAll();
                return products;
            }
            public Product GetDetails(int Code)
            {
                Product Product = new ProductDAO().SelectByCode(Code);
                return Product;
            }
            public List<Product> Search(String keyword)
            {
                List<Product> Products = new ProductDAO().SelectByKeyword(keyword);
                return Products;
            }
            public bool AddNew(Product newProduct)
            {
                bool result = new ProductDAO().Insert(newProduct);
                return result;
            }

            public bool Update(Product newProduct)
            {
                bool result = new ProductDAO().Update(newProduct);
                return result;
            }
            public bool Delete(int Code)
            {
                bool result = new ProductDAO().Delete(Code);
                return result;
            }
        }
    }


