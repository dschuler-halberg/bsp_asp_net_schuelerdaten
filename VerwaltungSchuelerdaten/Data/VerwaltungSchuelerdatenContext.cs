﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VerwaltungSchuelerdaten.Models;

namespace VerwaltungSchuelerdaten.Data
{
  public class VerwaltungSchuelerdatenContext : DbContext
  {
    public VerwaltungSchuelerdatenContext(DbContextOptions<VerwaltungSchuelerdatenContext> options)
        : base(options)
    {
    
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Klasse>()
          .HasOne<SchuelerDaten>(s => s.KlassenSprecherIn);
      modelBuilder.Entity<Klasse>()
             .HasMany<SchuelerDaten>(s => s.Schueler)
             .WithOne(x => x.Klasse);

    }

    public DbSet<VerwaltungSchuelerdaten.Models.SchuelerDaten> SchuelerDaten { get; set; }

    public DbSet<VerwaltungSchuelerdaten.Models.Klasse> Klasse { get; set; }
    public DbSet<VerwaltungSchuelerdaten.Models.Note> Note { get; set; }

    
  }
}
