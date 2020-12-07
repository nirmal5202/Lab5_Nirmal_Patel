using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5.Models
{
    public class Customer
    {
        public int customerId { get; set; }
        public string customerfname { get; set; }
        public string customerlname { get; set; }
        public string customerphone { get; set; }
        public string customerfullname { get { return "(ID: " + this.customerId + ") " + this.customerfname + " " + this.customerlname; } }

        //Validation function
        public bool Validate(string customerfname, string customerlname, string customerphone)
        {
            Int64 numPhone;

            if (string.IsNullOrEmpty(customerfname) || string.IsNullOrEmpty(customerlname) || string.IsNullOrEmpty(customerphone) || customerfname.Length < 2 || customerlname.Length < 2 || customerphone.Length != 10 || Int64.TryParse(customerphone, out numPhone) == false)
            {

                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
