using System;
using System.Collections.Generic;
using System.Text;

namespace WPK
{
    static class dbHandler
    {
        public static bool Login(string userName, string password)
        {
            return userName == "admin" && password == "admin" || true;
        }
        private static void OpenConnection()
        {

        }
        private static void CloseConnection()
        {

        }
        
        private static bool TestConnection()
        {
            return true;
        }

    }
}
