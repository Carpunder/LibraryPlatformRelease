using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlatform.Controllers
{
    public class LibrariesController
    {
        private readonly AppDbContext _context;

        public LibrariesController()
        {
            _context = new AppDbContext();
        }

        public LibrariesController(AppDbContext context)
        {
            _context = context;
        }
    }
}
