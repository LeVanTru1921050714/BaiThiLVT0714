using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BaiThiLVT.Models;

    public class LTQLDbContext : DbContext
    {
        public LTQLDbContext (DbContextOptions<LTQLDbContext> options)
            : base(options)
        {
        }

        public DbSet<BaiThiLVT.Models.LVTCau3> LVTCau3 { get; set; } = default!;
    }
