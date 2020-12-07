using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5.Models
{
    

    public class MainUser : DbContext
    {
        
        public MainUser(DbContextOptions<MainUser> options) : base(options)
        {

        }

        public DbSet<Show> show { get; set; }
        public DbSet<Cinema> cinema { get; set; }
        public DbSet<Customer> customer { get; set; }
    }
}
