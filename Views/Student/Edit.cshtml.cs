using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPSampleRazor.Data;
using ASPSampleRazor.Model;

namespace ASPSampleRazor.Views.Student
{
    public class EditModel : PageModel
    {
        private readonly ASPSampleRazor.Data.ApplicationDbContext _context;

        public EditModel(ASPSampleRazor.Data.ApplicationDbContext context)
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

            var studentmodel =  await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            if (studentmodel == null)
            {
                return NotFound();
            }
            StudentModel = studentmodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentModelExists(StudentModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentModelExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
