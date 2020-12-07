using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Importing Entity Framework (you have to use the nu-get package manager here).
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//Importing from the models folder.
using Lab5.Models;
using Microsoft.AspNetCore.Identity;

namespace Lab5.Models
{
    public class AppUser : IdentityUser
    {

    }
}
