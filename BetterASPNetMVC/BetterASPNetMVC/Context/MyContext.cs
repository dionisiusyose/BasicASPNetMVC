
using BetterASPNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BetterASPNetMVC.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("BetterASPNetMVC") { }

        public DbSet<Department> Departments { get; set; }
    }
}