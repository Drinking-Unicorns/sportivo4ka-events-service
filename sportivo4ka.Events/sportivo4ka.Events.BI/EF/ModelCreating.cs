using Microsoft.EntityFrameworkCore;
using sportivo4ka.Events.Data.Attributes;
using sportivo4ka.Events.Data.Entity;
using sportivo4ka.Events.General.Expansions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportivo4ka.Events.EF
{
    public partial class ServiceDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
