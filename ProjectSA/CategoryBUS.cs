using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSA
{
    public class CategoryBUS
    {
        public List<Category> GetAll()
        {
            List<Category> Categorys = new CategoryDAO().SelectAll();
            return Categorys;
        }
        public Category GetDetails(string Code)
        {
            Category Category = new CategoryDAO().SelectByCode(Code);
            return Category;
        }
        public List<Category> Search(String keyword)
        {
            List<Category> Categorys = new CategoryDAO().SelectByKeyword(keyword);
            return Categorys;
        }
        public bool AddNew(Category newCategory)
        {
            bool result = new CategoryDAO().Insert(newCategory);
            return result;
        }

        public bool Update(Category newCategory)
        {
            bool result = new CategoryDAO().Update(newCategory);
            return result;
        }
        public bool Delete(string Code)
        {
            bool result = new CategoryDAO().Delete(Code);
            return result;
        }
    }
}

