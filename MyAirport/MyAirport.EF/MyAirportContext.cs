using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Logging;

namespace MASB.MyAirport.EF
{


    public class MyAirportContext : DbContext
    {

        //Création de la factory
        public static readonly ILoggerFactory MyLoggerFactory
           = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<Vol> Vol { get; set; }
        public DbSet<Bagage> Bagage { get; set; }

        public MyAirportContext(DbContextOptions<MyAirportContext> options)
            : base(options)
        { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ///Récupére la chaine de connection
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MyAirport"].ConnectionString);
            ///On utilise la factory pour gérer les logs
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

      

    }
}
