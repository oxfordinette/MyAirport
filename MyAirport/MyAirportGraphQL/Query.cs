using GraphQL.Types;
using MASB.MyAirport.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using MyAirportGraphQL.GraphQLType;

namespace MyAirportGraphQL
{
    public class AirportQuery : ObjectGraphType
    {
        public AirportQuery(MyAirportContext db)
        {
            Field<ListGraphType<BagageType>>(
                "bagages",
                resolve: context => db.Bagage.ToList());

        }
    }
}