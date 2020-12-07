using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5.Models
{
    public class Cinema
    {
        public int cinemaId { get; set; }
        public string cinemaname { get; set; }
        public string cinemaphone { get; set; }
        public string cinemadetails { get { return "(ID: " + this.cinemaId + ") " + this.cinemaname; } }

        //Validation function
        public bool Validate(string cinemaname, string cinemaphone)
        {
            Int64 numPhone;

            if (string.IsNullOrEmpty(cinemaname) || string.IsNullOrEmpty(cinemaphone) || cinemaname.Length < 2 || cinemaphone.Length != 10 || Int64.TryParse(cinemaphone, out numPhone) == false)
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
