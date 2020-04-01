using System;
using System.Collections.Generic;


namespace MASB.MyAirport.EF
{
    public class Vol
    {
        public Vol()
        {
            this.mesBagages = new HashSet<Bagage>();
        }
        public int VolID { get; set; }
        public int CIE  { get; set; }
        public string LIG { get; set; }
        public int  JEK{ get; set; }
        public DateTime DHC { get; set; }
        public string PKG { get; set; }
        public string IMM { get; set; }
        public int PAX { get; set; }
        public string DES { get; set; }



        /// Permet d'accéder au bagage d'un vol
      
        public virtual ICollection<Bagage> mesBagages { get; set; }



    }
}
