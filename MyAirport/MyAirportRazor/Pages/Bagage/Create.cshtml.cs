using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MASB.MyAirport.EF;

namespace MyAirportRazor
{
    public class CreateModelBagage : PageModel
    {
        private readonly MASB.MyAirport.EF.MyAirportContext _context;

        public CreateModelBagage(MASB.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
           var vols = _context.Vol
                .Select(v => new
                {
                    v.VolID,
                    DES = $"{v.CIE} {v.LIG} : {v.DHC.ToShortDateString()}"
                }).ToList();
            ViewData["VolID"] = new SelectList(vols, "VolID", "DES");
            return Page();
        }

        [BindProperty]
        public Bagage Bagage { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bagage.Add(Bagage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
