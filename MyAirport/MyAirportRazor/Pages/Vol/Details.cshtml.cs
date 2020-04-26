using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MASB.MyAirport.EF;

namespace MyAirportRazor
{
    public class DetailsModelVol : PageModel
    {
        private readonly MASB.MyAirport.EF.MyAirportContext _context;

        public DetailsModelVol(MASB.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public Vol Vol { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vol = await _context.Vol.FirstOrDefaultAsync(m => m.VolID == id);

            if (Vol == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
