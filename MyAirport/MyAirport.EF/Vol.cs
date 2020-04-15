using System;
using System.Collections.Generic;


namespace MASB.MyAirport.EF
{

    /// <summary>
    /// Class Vol, représente une instance de Vol
    /// </summary>
    public class Vol
    {
        /// <summary>
        /// Clé primaire de la classe vol
        /// </summary>
        public Vol()
        {
            this.mesBagages = new HashSet<Bagage>();
        }
        /// <summary>
        /// Numéro du Vol
        /// </summary>
        public int VolID { get; set; }
     /// <summary>
     /// Compagnie du vol
     /// </summary>
        public int CIE  { get; set; }
        /// <summary>
        /// Ligne du Vol
        /// </summary>
        public string LIG { get; set; }
        public int  JEK{ get; set; }
        /// <summary>
        /// Dernier horaire connu du Vol
        /// </summary>
        public DateTime DHC { get; set; }
        /// <summary>
        /// Numéro de parking
        /// </summary>
        public string PKG { get; set; }
        public string IMM { get; set; }
        /// <summary>
        /// Nombre de passager
        /// </summary>
        public int PAX { get; set; }
        /// <summary>
        /// Destination du Vol
        /// </summary>
        public string DES { get; set; }

      //public Vol() { }


        // Permet d'accéder au bagage d'un vol
        /// <summary>
        /// Constructeur d'une instance Vol
        /// </summary>
      
      //public virtual Vol ? Vol { get; set; }
       public virtual ICollection<Bagage> mesBagages { get; set; }
       
       

        /*    public virtual ICollection<Bagage>? mesBagages { get; set; }
         *    public Vol(String compagnie, string ligne, DateTime dhc)
               {
                   Compagnie = compagnie;
                   Ligne = ligne;
                   Dhc = dhc;
                   mesBagages = null;
               }*/



    }
}
