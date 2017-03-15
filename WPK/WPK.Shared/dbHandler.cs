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

        public static CustomerInfo[] GetCustomers()
        {
            CustomerInfo[] list = new CustomerInfo[10];
            list[0] = new CustomerInfo() { adress = "Schoutstraat 10a, 4204BC, Gorinchem, Nederland", name = "Floris BV", telephone = "0275-576643" };
            list[1] = new CustomerInfo() { adress = "Schoutstraat 12a, 4204BC, Gorinchem, Nederland", name = "Holland Corp", telephone = "0275-576643" };
            list[2] = new CustomerInfo() { adress = "Schoutstraat 14a, 4204BC, Gorinchem, Nederland", name = "Ijsco", telephone = "0275-576643" };
            list[3] = new CustomerInfo() { adress = "Schoutstraat 16a, 4204BC, Gorinchem, Nederland", name = "Flem", telephone = "0275-576643" };
            list[4] = new CustomerInfo() { adress = "Schoutstraat 18a, 4204BC, Gorinchem, Nederland", name = "Verschnikket", telephone = "0275-576643" };
            list[5] = new CustomerInfo() { adress = "Schoutstraat 20a, 4204BC, Gorinchem, Nederland", name = "Textbedrijf", telephone = "0275-576643" };
            list[6] = new CustomerInfo() { adress = "Schoutstraat 11a, 4204BC, Gorinchem, Nederland", name = "Woop", telephone = "0275-576643" };
            list[7] = new CustomerInfo() { adress = "Schoutstraat 13a, 4204BC, Gorinchem, Nederland", name = "Wagarble", telephone = "0275-576643" };
            list[8] = new CustomerInfo() { adress = "Schoutstraat 15a, 4204BC, Gorinchem, Nederland", name = "Flarf", telephone = "0275-576643" };
            list[9] = new CustomerInfo() { adress = "Schoutstraat 17a, 4204BC, Gorinchem, Nederland", name = "Myar", telephone = "0275-576643" };
            return list;
        }
    }
}
