using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Services
{
    public interface IDatabaseService
    {

        string CreateProductWarehouse(ProductWarehouse pw);
    }


    public class DatabaseService : IDatabaseService
    {

        private IConfiguration _configuration;

        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateProductWarehouse(ProductWarehouse pw)
        {

            int newPwOID = -1;
            using var con = new SqlConnection(_configuration.GetConnectionString("Prod"));
            using var com = new SqlCommand("TAN.dbo.AddProductToWarehouse", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@IdProduct", pw.IdProduct);
            com.Parameters.AddWithValue("@IdWarehouse", pw.IdWarehouse);
            com.Parameters.AddWithValue("@Amount", pw.Amount);
            com.Parameters.AddWithValue("@CreatedAt", pw.CreatedAt);

            try
            {
                con.Open();

   
                newPwOID = (int) com.ExecuteNonQuery();
                return "Success. New PW has been created with the id " + newPwOID.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
            finally
            {

                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
