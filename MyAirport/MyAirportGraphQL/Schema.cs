﻿using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MyAirportGraphQL
{
    public class AirportSchema:  Schema
    {
        public AirportSchema(IDependencyResolver resolver) : base(resolver)
        { Query = resolver.Resolve <AirportQuery>();
                }
    }
}
