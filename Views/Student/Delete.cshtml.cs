using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASPSampleRazor.Data;
using ASPSampleRazor.Model;

namespace ASPSampleRazor.Views.Student
{
    public class DeleteModel : PageModel
    {
        private readonly ASPSampleRazor.Data.ApplicationDbContext _context;

        public DeleteModel(ASPSampleRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentModel StudentModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentmodel = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);

            if (studentmodel is not null)
            {
                StudentModel = studentmodel;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentmodel = await _context.Students.FindAsync(id);
            if (studentmodel != null)
            {
                StudentModel = studentmodel;
                _context.Students.Remove(StudentModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
