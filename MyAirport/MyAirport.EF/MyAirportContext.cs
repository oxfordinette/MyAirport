using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace MASB.MyAirport.EF
{


    public class MyAirportContext : DbContext
    {

            public DbSet<Vol> Vol { get; set; }
            public DbSet<Bagage> Bagage { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=MyAirport;Integrated Security=True");
            }
        }

    }

