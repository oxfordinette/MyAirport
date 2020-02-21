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
        public char CODE_IATA { get; set; }
        public DateTime DATA_CREATION { get; set; }
        public char CLASSE { get; set; }
        public Byte PRIORITAIRE { get; set; }
        public char STA { get; set; }
        public char SSUR { get; set; }
        public char DESTINATION { get; set; }
        public string ESCALE { get; set; }
  
    }
}
