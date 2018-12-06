using Dapper;
using DapperApp.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperApp
{
    public class Connection
    {

        
        public string ConnectionMethod()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperApp.Properties.Settings.dbTestConnectionString"].ConnectionString))
            {
                db.Open();
                var result = db.Query<string>("SELECT 'Hola mundo, estoy conextado :)'").Single();
                return result;
            }
        }

        public void MethodDump(){
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperApp.Properties.Settings.dbTestConnectionString"].ConnectionString))
            {
                db.Open();
                var scalar = db.Query<string>("SELECT GETDATE()").FirstOrDefault();
                var results = db.Query<DTO.myobject>(@"SELECT * FROM (
                                                VALUES (1,'one'),
                                                (2,'two'),
                                                (3,'three')
                                                ) AS mytable(id,name)");
                Console.WriteLine(results);
            }
        }

        public void MethodDog()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperApp.Properties.Settings.dbTestConnectionString"].ConnectionString))
            {
                db.Open();
                var @params = new { age = 3 };
                var sql = "SELECT * FROM dbo.Dogs WHERE Age = @age";
                IEnumerable<Dog> dogs = db.Query<Dog>(sql, @params).ToList();

                foreach (var item in dogs)
                {
                    Console.WriteLine(item.Id);
                }
            }
        }

        public IEnumerable<Dog> GetDogs() {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperApp.Properties.Settings.dbTestConnectionString"].ConnectionString))
            {
                db.Open();
                var sql = "SELECT * FROM dbo.Dog ORDER BY ID ASC";
                IEnumerable<Dog> dogs = db.Query<Dog>(sql).ToList();

                return dogs;
            }
        }

        public bool SaveDog() {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperApp.Properties.Settings.dbTestConnectionString"].ConnectionString))
            {
                db.Open();
                Dog dog = new Dog();
                dog.Name = "Doki";
                dog.Weight = 55;
                dog.Age = 4;
                
                
                var result = db.ExecuteScalar<int>("INSERT INTO Dog (Age,Name,Weight) VALUES (@Age,@Name,@Weight); SELECT SCOPE_IDENTITY(); ", dog);
                return result != 0;
            }
        }
    }
}
