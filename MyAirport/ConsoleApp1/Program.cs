using System;
using System.Configuration;
using System.Linq;
using MASB.MyAirport.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Topshelf;

namespace MASB.MyAirport.Console
{

    class Program
    {
        public static readonly ILoggerFactory MyLoggerFactory
       = LoggerFactory.Create(builder => { builder.AddConsole(); });
        

        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello!");

        

        DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<MyAirportContext>();
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MyAirport"].ConnectionString);
            ///On utilise la factory pour gérer les logs
            
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);

            System.Console.WriteLine("MyAirport project bonjour!!");
            DbContextOptions<MyAirportContext> myOptions = (DbContextOptions<MyAirportContext>)optionsBuilder.Options;
            using (var db = new MyAirportContext(myOptions))
            {
                //// Create
                //System.Console.WriteLine("Création du vol LH1232");
                //Vol v1 = new Vol
                //{
                //    CIE = 1,
                //    DES = "BKK",
                //    DHC = Convert.ToDateTime("14/01/2020 16:45"),
                //    IMM = "eer",
                //    LIG = "1232",
                //    PKG = "r",
                //    PAX = 238
                //};
                //db.Add(v1);

                //System.Console.WriteLine("Creation vol SQ333");
                //Vol v2 = new Vol
                //{
                //    CIE = 1,
                //    DES = "CDG",
                //    DHC = Convert.ToDateTime("14/01/2020 18:20"),
                //    IMM = "TG43",
                //    LIG = "333",
                //    PKG = "R51",
                //    PAX = 423
                //};
                //db.Add(v2);

                System.Console.WriteLine("creation du bagage 012387364501");
                Bagage b1 = new Bagage
                {
                    CLASSE = "Y",
                    CODE_IATA = "012387364501",
                    DATA_CREATION = Convert.ToDateTime("14/01/2020 12:52"),
                    DESTINATION = "BEG",
                    VolID = 1
                };
                db.Add(b1);

                db.SaveChanges();
                System.Console.ReadLine();
                System.Console.WriteLine("Voici la liste des bagages disponibles");
                var bags = db.Bagage
                    .OrderBy(b => b.CODE_IATA);
                foreach (var b in bags)
                {
                    System.Console.WriteLine($"Le bagage {b.DATA_CREATION} heure");
                }
                System.Console.ReadLine();
                // Read
                System.Console.WriteLine("Voici la liste des vols disponibles");
                var vol = db.Vol
                    .OrderBy(v => v.CIE);
                foreach (var v in vol)
                {
                    System.Console.WriteLine($"Le vol {v.DHC} ");//{v.CIE}{v.LIG} N° {v.VolID} a destination de {v.DES} part à {v.DHC} heure");
                }
                System.Console.ReadLine();


                //// Update
                //System.Console.WriteLine($"Le bagage {b1.BagageID} est modifié pour être rattaché au vol {v1.VolID} => {v1.CIE}{v1.LIG}");
                //b1.VolID = v1.VolID;
                //db.SaveChanges();
                //System.Console.ReadLine();

                //// Delete vol et bagages du vol
                //System.Console.WriteLine($"Suppression du vol {v1.VolID} => {v1.CIE}{v1.LIG}");
                //db.Remove(v1);
                //db.SaveChanges();
                //System.Console.ReadLine();

            }


        }
    }
}
