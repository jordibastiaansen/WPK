namespace WPK
{
    public class CustomerInfo
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }

        /// <summary>
        /// returns the full adress for displaying and navigation.
        /// </summary>
        public string FullAdress
        {
            get { return string.Format("{1}{0} {2}{0} {3}",",",Adress, Code, City); }
        }
        /// <summary>
        /// returns the phonenumber with +
        /// </summary>
        public string FormatPhoneNumber
        {
            get { return "+" + PhoneNumber; }
        }
        
    }
}
