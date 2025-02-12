using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASPSampleRazor.Data;
using ASPSampleRazor.Model;

namespace ASPSampleRazor.Views.Student
{
    public class CreateModel : PageModel
    {
        private readonly ASPSampleRazor.Data.ApplicationDbContext _context;

        public CreateModel(ASPSampleRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentModel StudentModel { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Students.Add(StudentModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
