using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlatform.Controllers
{
    public class ControllerContext
    {
        public BooksController BooksController { get; set; }
        public BookCardsController BookCardsController { get; set; }
        public CopiesController CopiesController { get; set; }
        public LibrariesController LibrariesController { get; set; }
        public LibraryCardsController LibraryCardsController { get; set; }
        public PublishersController PublishersController { get; set; }
        public UsersController UsersController { get; set; }


        public ControllerContext(AppDbContext context)
        {
            BooksController = new BooksController(context);
            BookCardsController = new BookCardsController(context);
            CopiesController = new CopiesController(context);
            LibrariesController = new LibrariesController(context);
            LibraryCardsController = new LibraryCardsController(context);
            PublishersController = new PublishersController(context);
            UsersController = new UsersController(context);
        }
    }
}
