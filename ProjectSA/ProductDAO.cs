using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSA
{
    public class ProductDAO
    {
        String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        public List<Product> SelectAll()
        {
            List<Product> products = new List<Product>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "SELECT * FROM Products";
            SqlCommand com = new SqlCommand(strCom, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                Product product = new Product()
                {
                    Code = (int)dr["Code"],
                    Name = (String)dr["Name"],
                    Brand = (String)dr["Brand"],
                    BrandCode = (String)dr["BrandCode"],
                    Category = (String)dr["Category"],
                    CategoryCode = (String)dr["CategoryCode"],
                    Price = (int)dr["Price"]
                };
                products.Add(product);
            }
            con.Close();
            return products;
        }

        public Product SelectByCode(int Code)
        {
            Product product = null;
            SqlConnection con = new SqlConnection(strCon); con.Open();
            String strCom = "SELECT * FROM Products WHERE Code=@Code";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Code", Code));
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                product = new Product()
                {
                    Code = (int)dr["Code"],
                    Name = (String)dr["Name"],
                    Brand = (String)dr["Brand"],
                    BrandCode = (String)dr["BrandCode"],
                    Category = (String)dr["Category"],
                    CategoryCode = (String)dr["CategoryCode"],
                    Price = (int)dr["Price"]

                };
            }
            con.Close();
            return product;
        }
        public List<Product> SelectByKeyword(String keyword)
        {
            List<Product> products = new List<Product>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "SELECT * FROM Products WHERE Name LIKE @Keyword";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Keyword", "%" + keyword + "%"));
            SqlDataReader dr = com.ExecuteReader(); while (dr.Read())
            {
                Product product = new Product()
                {
                    Code = (int)dr["Code"],
                    Name = (String)dr["Name"],
                    Brand = (String)dr["Brand"],
                    BrandCode = (String)dr["BrandCode"],
                    Category = (String)dr["Category"],
                    CategoryCode = (String)dr["CategoryCode"],
                    Price = (int)dr["Price"]

                };
                products.Add(product);
            }
            con.Close();
            return products;
        }
        public bool Insert(Product newProduct)
        {
            bool result = false; SqlConnection con = new SqlConnection(strCon);
            con.Open();
            //String strCom = "INSERT INTO Products (Code,Name,Brand,BrandCode,Category,CategoryCode,Price) VALUES (@Code,@Name,@Brand,@BrandCode,@Category,@CategoryCode,@Price)";
            String strCom = "INSERT INTO Products (Name,Brand,BrandCode,Category,CategoryCode,Price) VALUES (@Name,@Brand,@BrandCode,@Category,@CategoryCode,@Price)";
            SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("@Code", newProduct.Code));
            com.Parameters.Add(new SqlParameter("@Name", newProduct.Name));
            com.Parameters.Add(new SqlParameter("@Brand", newProduct.Brand));
            com.Parameters.Add(new SqlParameter("@BrandCode", newProduct.BrandCode));
            com.Parameters.Add(new SqlParameter("@Category", newProduct.Category));
            com.Parameters.Add(new SqlParameter("@CategoryCode", newProduct.CategoryCode));
            com.Parameters.Add(new SqlParameter("@Price", newProduct.Price));
            try { result = com.ExecuteNonQuery() > 0; } catch { result = false; }
            con.Close();
            return result;
        }
        public bool Update(Product newProduct)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            //String strCom = "UPDATE Book SET Code=@Code,Name=@Name, Country=@Country WHERE Code = @Code";
            String strCom = "UPDATE Products SET Name=@Name,Brand=@Brand,BrandCode=@BrandCode,Category=@Category,CategoryCode=@CategoryCode,Price=@Price WHERE Code = @Code";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Code", newProduct.Code));
            com.Parameters.Add(new SqlParameter("@Name", newProduct.Name));
            com.Parameters.Add(new SqlParameter("@Brand", newProduct.Brand));
            com.Parameters.Add(new SqlParameter("@BrandCode", newProduct.BrandCode));
            com.Parameters.Add(new SqlParameter("@Category", newProduct.Category));
            com.Parameters.Add(new SqlParameter("@CategoryCode", newProduct.CategoryCode));
            com.Parameters.Add(new SqlParameter("@Price", newProduct.Price));
            try { result = com.ExecuteNonQuery() > 0; } catch { result = false; }
            con.Close();
            return result;
        }
        public bool Delete(int Code)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "DELETE FROM Products WHERE Code=@Code";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Code", Code));
            try { result = com.ExecuteNonQuery() > 0; } catch { result = false; }
            con.Close();
            return result;
        }
    }
}


