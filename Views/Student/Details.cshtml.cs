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
    public class DetailsModel : PageModel
    {
        private readonly ASPSampleRazor.Data.ApplicationDbContext _context;

        public DetailsModel(ASPSampleRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
