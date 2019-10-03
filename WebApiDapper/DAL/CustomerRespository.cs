using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using System.Data.SqlClient;

namespace WebApplication2.DAL
{
    public class CustomerRespository : ICustomerRepository
    {
 
        private IDbConnection _db = new SqlConnection(Startup.ConnectionString);

        public List<Customer> GetCustomers(int amount, string sort)
        {
            //return this._db.Query<Customer>("SELECT TOP " + amount + " [CustomerID],[CustomerFirstName],[CustomerLastName],[IsActive] FROM [DESA2020].[CUSTOMER] ORDER BY CustomerID " + sort).ToList();

            using (_db)
            {
                return _db.Query<Customer>
                ("Select * From DESA2020.Customer").ToList();
            }

            //using (_db){
            //    return Dapper.SqlMapper.Query<Customer>(_db, "Select * From DESA2020.Customer").ToList();
            //}
        }

        public Customer GetSingleCustomer(int customerId)
        {
            return _db.Query<Customer>("SELECT[CustomerID],[CustomerFirstName],[CustomerLastName],[IsActive] FROM DESA2020.[Customer] WHERE CustomerID =@CustomerID", new { CustomerID = customerId }).SingleOrDefault();
        }

        public bool InsertCustomer(Customer ourCustomer)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer ourCustomer)
        {
            int rowsAffected = this._db.Execute(@"INSERT Customer([CustomerFirstName],[CustomerLastName],[IsActive]) values (@CustomerFirstName, @CustomerLastName, @IsActive)", new { CustomerFirstName = ourCustomer.CustomerFirstName, CustomerDescripcion = ourCustomer.IsActive, IsActive = true });

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteCustomer(int customerId)
        {
            int rowsAffected = this._db.Execute(@"DELETE FROM [jeremy].[Customer] WHERE CustomerID = @CustomerID", new { CustomerID = customerId });

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }

}
