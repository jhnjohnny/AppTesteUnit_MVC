using AppTesteUnit.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTesteUnit.MVC.Data
{
    public class AppTesteUnitDbContext : DbContext
    {
        public AppTesteUnitDbContext(DbContextOptions<AppTesteUnitDbContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuario { get; set; }
    }
}
