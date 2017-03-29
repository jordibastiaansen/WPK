using System.Collections.Generic;
using SQLite;

namespace WPK
{
    static class dbHandler
    {
        /// <summary>
        /// login check for the application
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool Login(string userName, string password)
        {
#if DEBUG
            return true;
#endif
            return userName == "Buitendienst" && password == "$(@!PM";
        }

        /// <summary>
        /// gets a list of customers of a country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public static List<CustomerInfo> getCustomersFromCountry(string country)
        {
            using (SQLiteConnection dbcon = new SQLiteConnection(App.dbPath))
            {
                if (country.ToLower() == "nl")
                {
                    return dbcon.Query<CustomerInfo>("Select * from CustomerInfo Where CountryCode ='" + country + "' or CountryCode not Like '__' order by Name");
                }
                else
                    return dbcon.Query<CustomerInfo>("Select * from CustomerInfo Where CountryCode ='" + country + "' order by Name");
            }
        }
  
        /// <summary>
        /// gets a list of all customers in the database
        /// </summary>
        /// <returns></returns>
        public static List<CustomerInfo> GetCustomers()
        {
            using (SQLiteConnection dbcon = new SQLiteConnection(App.dbPath))
            {
                return dbcon.Query<CustomerInfo>("Select * from CustomerInfo order by Name");
            }
        }
    }
}
