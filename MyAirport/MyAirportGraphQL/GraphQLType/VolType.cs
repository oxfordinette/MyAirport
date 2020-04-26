using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using MASB.MyAirport.EF;

namespace MyAirportGraphQL.GraphQLType
{
    public class VolType : ObjectGraphType<Vol>
    {
        public VolType()
        {
      
            Field(x => x.PKG);
            Field(x => x.DHC);
            Field(x => x.JEK);
            Field(x => x.LIG);
            Field(x => x.CIE);
            Field(x => x.VolID);
            Field(x => x.IMM);
            Field(x => x.PAX);
            Field(x => x.DES);
        }
    }
}
