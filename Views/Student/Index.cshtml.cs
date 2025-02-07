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
    public class IndexModel : PageModel
    {
        private readonly ASPSampleRazor.Data.ApplicationDbContext _context;

        public IndexModel(ASPSampleRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Students.ToListAsync();
        }
    }
}
