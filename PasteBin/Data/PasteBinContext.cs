using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PasteBin.Models;

namespace PasteBin.Data
{
    public class PasteBinContext : DbContext
    {
        public PasteBinContext (DbContextOptions<PasteBinContext> options)
            : base(options)
        {
        }

        public DbSet<PasteBin.Models.Notes> Notes { get; set; } = default!;
    }
}
