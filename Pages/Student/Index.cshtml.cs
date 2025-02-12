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

        public IList<StudentModel> StudentModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            StudentModel = await _context.Students.ToListAsync();
        }
    }
}
