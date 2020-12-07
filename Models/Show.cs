using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5.Models
{
    public class Show
    {
        public int showId { get; set; }
        public string showType { get; set; }
        public DateTime showDate { get; set; }

        public int cinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }


        public int customerId { get; set; }
        public virtual Customer Customer { get; set; }

        public string showname { get; set; }
        public string cinemaname { get; set; }
        public string customerlname { get; }
        public string customerfname { get; }
        public string customerfullname { get { return "(ID: " + this.customerId + ") " + this.customerfname + " " + this.customerlname; } }
        

        public bool Validate(string showType)
        {

            if (string.IsNullOrEmpty(showType))
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
