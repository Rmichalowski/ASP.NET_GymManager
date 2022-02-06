using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymManager.Models;

namespace GymManager.Models
{
    public class MvcTrainerContext : DbContext
    {
        public MvcTrainerContext(DbContextOptions<MvcTrainerContext> options)
            : base(options)
        {
        }

        public DbSet<GymManager.Models.Trainer> Trainer { get; set; }

    }
}