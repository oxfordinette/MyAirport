﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MASB.MyAirport.EF;

namespace MyAirportRazor
{
    public class IndexModelVol : PageModel
    {
        private readonly MASB.MyAirport.EF.MyAirportContext _context;

        public IndexModelVol(MASB.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public IList<Vol> Vol { get;set; }

        public async Task OnGetAsync()
        {
            Vol = await _context.Vol.ToListAsync();
        }
    }
}
