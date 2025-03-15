using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSA
{
    public class BrandBUS
    {
        public List<Brand> GetAll()
        {
            List<Brand> Brands = new BrandDAO().SelectAll();
            return Brands;
        }
        public Brand GetDetails(string Code)
        {
            Brand Brand = new BrandDAO().SelectByCode(Code);
            return Brand;
        }
        public List<Brand> Search(String keyword)
        {
            List<Brand> Brands = new BrandDAO().SelectByKeyword(keyword);
            return Brands;
        }
        public bool AddNew(Brand newBrand)
        {
            bool result = new BrandDAO().Insert(newBrand);
            return result;
        }

        public bool Update(Brand newBrand)
        {
            bool result = new BrandDAO().Update(newBrand);
            return result;
        }
        public bool Delete(string Code)
        {
            bool result = new BrandDAO().Delete(Code);
            return result;
        }
    }
}

