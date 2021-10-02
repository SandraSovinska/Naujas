using EShop.Models;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Services
{
    public class EShopsServices

    {

        private string connection;
        public EShopsServices()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();

            connection = config.GetValue<string>("ConnectionStrings:DefaultConnection");
        }
        public List<EShops> GetEShops()
        {

            MySqlConnection conn = new MySqlConnection(connection);

            conn.Open();

            var eShops = new List<EShops>();

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT barCode,nameOfProducts ,kindOfProduct ,product,priceProduct  FROM eshopas";

                var reader = cmd.ExecuteReader();

                using (reader)
                {

                    while (reader.Read())
                    {
                        var eShop = new EShops(
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(1),
                            reader.GetString(0),
                            reader.GetDecimal(4)
                            
                         );

                        eShops.Add(eShop);
                    }
                }
            }

            return eShops;
        }


        public EShops GetEShop(string barCode)
        {
            MySqlConnection conn = new MySqlConnection(connection);

            conn.Open();
            using (var cmd = conn.CreateCommand())
            {

                cmd.CommandText = "SELECT barCode,nameOfProducts,kindOfProduct,product,priceProduct FROM e-shopas WHERE barCode =@barCode";
                cmd.Parameters.Add(
                        new MySqlParameter()
                        {
                            ParameterName = "@barCode",
                            DbType =System.Data.DbType.String,
                            Value = barCode
                        }
                        );
                var reader = cmd.ExecuteReader();

                using (reader)
                {
                    reader.Read();

                    return new EShops(
                         reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(1),
                            reader.GetString(0),
                            reader.GetDecimal(4));

                }
            }
        }
        public void CreateEShops(EShops eShop)
        {
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO e-shopas (barCode,nameOfProducts ,kindOfProduct ,product,priceProduct) " +
                    "VALUES(@barCode,@nameOfProducts,@kindOfProduct, @product,@priceProduct)";

                cmd.Parameters.Add(
                        new MySqlParameter()
                        {
                            ParameterName = "@barCode",
                            DbType = System.Data.DbType.String,
                            Value = eShop.BarCode
                        }
                        );

                cmd.Parameters.Add(
                        new MySqlParameter()
                        {
                            ParameterName = "@nameOfProducts",
                            DbType = System.Data.DbType.String,
                            Value = eShop.NameOfProducts

                        }
                        );
                cmd.Parameters.Add(
                        new MySqlParameter()
                        {
                            ParameterName = "@kindOfProduct",
                            DbType = System.Data.DbType.String,
                            Value = eShop.KindOfProduct

                        }
                        );

                cmd.Parameters.Add(
                       new MySqlParameter()
                       {
                           ParameterName = "@priceProduct",
                           DbType = System.Data.DbType.DateTime,
                           Value = eShop.PriceProduct

                       }
                       );


                cmd.ExecuteNonQuery();
            }

        }
    }
}
           
        
    

