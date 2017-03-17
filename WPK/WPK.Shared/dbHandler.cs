using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WPK
{
    static class dbHandler
    {
        //SQLiteConnection connection;
        public static bool Login(string userName, string password)
        {

            return userName == "admin" && password == "admin" || true;
        }

        public static List<CustomerInfo> getCustomersFromCountry(string country)
        {
            using (var dbcon = new SQLiteConnection(App.dbPath))
            {
                if (country.ToLower() == "nl")
                {
                    return dbcon.Query<CustomerInfo>("Select * from CustomerInfo Where CountryCode ='" + country + "' or CountryCode not Like '__'");
                }
                else
                    return dbcon.Query<CustomerInfo>("Select * from CustomerInfo Where CountryCode ='" + country + "'");
            }
        }
  
        public static List<CustomerInfo> GetCustomers()
        {
            using (var dbcon = new SQLiteConnection(App.dbPath))
            {
                return dbcon.Query<CustomerInfo>("Select * from CustomerInfo");
            }
        }
    }
}
