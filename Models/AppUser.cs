using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Add the following import (you do not need to use the nu-get package manager).
//We are obtaining the class IdentityUser from it (to inherit from it).
using Microsoft.AspNetCore.Identity;

namespace Lab5.Models
{
    public class AppUser : IdentityUser
    {

    }
}
