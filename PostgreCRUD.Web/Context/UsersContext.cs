using Microsoft.EntityFrameworkCore;
using PostgreCRUD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgreCRUD.Web.Context
{
    public class UsersContext : DbContext
    {
        public UsersContext()
        {
        }

        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {

        }

        public DbSet<User> Users{get;set;}
    }
}
