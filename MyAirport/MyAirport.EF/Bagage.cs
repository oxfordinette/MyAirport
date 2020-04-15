using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MASB.MyAirport.EF
{
    public class Bagage
    {
        public int BagageID { get; set; }
        public int VolID { get; set; }
        //public Vol Vol { get; set; }

        public virtual Vol? Vol { get; set; }

        [StringLength(16)]
        [Display(Name = "Code IATA")]
        public string CODE_IATA { get; set; }
        public DateTime DATA_CREATION { get; set; }
        public string CLASSE { get; set; }
        public Byte PRIORITAIRE { get; set; }
        public string STA { get; set; }
        public string SSUR { get; set; }
        public string DESTINATION { get; set; }
        public string ESCALE { get; set; }
 
        public Bagage() { }



    }
}