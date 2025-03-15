using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
namespace ProjectSA
{
    public class BrandDAO
    {
        String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        public List<Brand> SelectAll()
        {
            List<Brand> brands = new List<Brand>();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "SELECT * FROM Brand";
            SqlCommand com = new SqlCommand(strCom, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                Brand Brand = new Brand()
                {
                    Code = (String)dr["Code"],
                    Name = (String)dr["Name"],
                    Country = (String)dr["Country"]
                };
                brands.Add(Brand);
            }
            con.Close();
            return brands;
        }
        public Brand SelectByCode(string Code)
        {
            Brand brand = null;
            SqlConnection con = new SqlConnection(strCon); con.Open();
            String strCom = "SELECT * FROM Brand WHERE Code=@Code";
            SqlCommand com = new SqlCommand(strCom, con); 
            com.Parameters.Add(new SqlParameter("@Code", Code));
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                brand = new Brand()
                {
                    Code = (String)dr["Code"],
                    Name = (String)dr["Name"],
                    Country = (String)dr["Country"]
                };
            }
            con.Close();
            return brand;
        }
        public List<Brand> SelectByKeyword(String keyword)
        {
            List<Brand> brands = new List<Brand>();
            SqlConnection con = new SqlConnection(strCon); con.Open();
            String strCom = "SELECT * FROM Brand WHERE Name LIKE @Keyword";
            SqlCommand com = new SqlCommand(strCom, con); com.Parameters.Add(new SqlParameter("@Keyword", "%" + keyword + "%"));
            SqlDataReader dr = com.ExecuteReader(); while (dr.Read())
            {
                Brand brand = new Brand()
                {
                    Code = (String)dr["Code"],
                    Name = (String)dr["Name"],
                    Country = (String)dr["Country"]
                };
                brands.Add(brand);
            }
            con.Close();
            return brands;
        }
        public bool Insert(Brand newBrand)
        {
            bool result = false; SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "INSERT INTO Brand (Code,Name, Country) VALUES (@Code,@Name, @Country)";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Code", newBrand.Code));
            com.Parameters.Add(new SqlParameter("@Name", newBrand.Name));
            com.Parameters.Add(new SqlParameter("@Country", newBrand.Country));

            try { result = com.ExecuteNonQuery() > 0; } catch { result = false; }
            con.Close();
            return result;
        }
        public bool Update(Brand newBrand)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            //String strCom = "UPDATE Book SET Code=@Code,Name=@Name, Country=@Country WHERE Code = @Code";
            String strCom = "UPDATE Brand SET Name=@Name, Country=@Country WHERE Code = @Code";
            SqlCommand com = new SqlCommand(strCom, con); 
            com.Parameters.Add(new SqlParameter("@Code", newBrand.Code));
            com.Parameters.Add(new SqlParameter("@Name", newBrand.Name));
            com.Parameters.Add(new SqlParameter("@Country", newBrand.Country));

            try { result = com.ExecuteNonQuery() > 0; } catch { result = false; }
            con.Close();
            return result;
        }
        public bool Delete(string Code)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "DELETE FROM Brand WHERE Code=@Code";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@Code", Code));
            try { result = com.ExecuteNonQuery() > 0; } catch { result = false; }
            con.Close();
            return result;
        }
    }
}

