using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vietjet.com.Models;

namespace Vietjet.com.Data
{
    public class VietjetcomContext : DbContext
    {
        public VietjetcomContext (DbContextOptions<VietjetcomContext> options)
            : base(options)
        {
        }

        public DbSet<Vietjet.com.Models.bay> bay { get; set; }
    }
}
