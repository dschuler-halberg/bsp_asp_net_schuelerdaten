using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VerwaltungSchuelerdaten.Models;

namespace VerwaltungSchuelerdaten.Data
{
    public class VerwaltungSchuelerdatenContext : DbContext
    {
        public VerwaltungSchuelerdatenContext (DbContextOptions<VerwaltungSchuelerdatenContext> options)
            : base(options)
        {
        }

        public DbSet<VerwaltungSchuelerdaten.Models.SchuelerDaten> SchuelerDaten { get; set; }
    }
}
