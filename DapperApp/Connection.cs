using Dapper;
using DapperApp.DTO;
using DapperApp.Querys;
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

        #region Method
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
        #endregion

        #region DOG
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
        #endregion

        #region Widget
        public async Task AddWidgets(IEnumerable<Widget> widgets) {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperApp.Properties.Settings.dbTestConnectionString"].ConnectionString))
            {
                await conn.OpenAsync();
                using (var bulkCopy = new SqlBulkCopy(conn))
                {
                    //bulkCopy.BulkCopyTimeout = SqlTimeoutSeconds;
                    //bulkCopy.BatchSize = 500;
                    //bulkCopy.DestinationTableName = "Widgets";
                    //bulkCopy.EnableStreaming = true;
                    //using (var dataReader = widgets.ToDataReader())
                    //{
                    //    await bulkCopy.WriteToServerAsync(dataReader);
                    //}
                }
            }
        }
        #endregion

        #region Person
        public IEnumerable<Person> GetPersons()
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperApp.Properties.Settings.dbTestConnectionString"].ConnectionString))
            {
                db.Open();
                var sql = QuerysClass.SQL_One_to_one_Person;


                var result = db.Query<Person, Country, Person>(sql, (person, country) => {
                                                    if (country == null)
                                                    {
                                                        country = new Country { Residence = "" };
                                                    }
                                                    person.Residience = country;
                                                    return person;
                                                },splitOn: "Residence" ).ToList();

                return result;
            }
        }
        #endregion

        #region PesonOneToMany
        public IEnumerable<Person> GetPersonsOnetoMany()
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DapperApp.Properties.Settings.dbTestConnectionString"].ConnectionString))
            {
                db.Open();
                var sql = QuerysClass.SQL_One_to_many_Person;
                var remainingHorsemen = new Dictionary<int, Person>();
                var result = db.Query<Person, Country, Book,Person>(sql, (person, country, book) => {
                    //person
                    Person personEntity;
                    //trip
                    if (!remainingHorsemen.TryGetValue(person.Id, out personEntity))
                    {
                        remainingHorsemen.Add(person.Id, personEntity = person);
                    }
                    //country
                    if (personEntity.Residience == null)
                    {
                        if (country == null)
                        {
                            country = new Country { CountryName = "" };
                        }
                        personEntity.Residience = country;
                    }
                    //books
                    if (personEntity.Books == null)
                    {
                        personEntity.Books = new List<Book>();
                    }

                if (book != null)
                {
                    if (!personEntity.Books.Any(x => x.BookId == book.BookId))
                        {
                            personEntity.Books.Add(book);
                        }
                }

                return personEntity;
                }, splitOn: "CountryId,BookId");

                return result;
            }
        }
        #endregion
    }
}
