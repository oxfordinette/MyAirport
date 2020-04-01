using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MASB.MyAirport.EF
{
    public class Bagage
    {
        public int BagageID { get; set; }
        public int VolID { get; set; }
        public Vol Vol { get; set; }
        public string CODE_IATA { get; set; }
        [Column(TypeName = "char(12)")]
        public DateTime DATA_CREATION { get; set; }
        public string CLASSE { get; set; }
        [Column(TypeName = "char(12)")]
        public Byte PRIORITAIRE { get; set; }
        public string STA { get; set; }
        [Column(TypeName = "char(12)")]
        public string SSUR { get; set; }
        [Column(TypeName = "char(12)")]
        public string DESTINATION { get; set; }
        [Column(TypeName = "char(12)")]
        public string ESCALE { get; set; }
 



    }
}