using System;

namespace LibraryPlatform.Models
{
    public class BookCard
    {
        public BookCard()
        {
            BookCardId = Guid.NewGuid();
            DateOfIssue = DateTime.Now;
            DateOfService = DateOfIssue.AddMonths(1);
            IsReturned = false;
            LibraryCardId = Values.Values.CurrentLibraryValue;
        }

        public BookCard(Copy copy)
        {
            BookCardId = Guid.NewGuid();
            DateOfIssue = DateTime.Now;
            DateOfService = DateOfIssue.AddMonths(1);
            IsReturned = false;
            Copy = copy;
        }

        public BookCard(Copy copy, DateTime dateOfService)
        {
            BookCardId = Guid.NewGuid();
            DateOfIssue = DateTime.Now;
            DateOfService = dateOfService;
            IsReturned = false;
            Copy = copy;
        }

        public Guid BookCardId { get; set; }
        
        public string BookCardNumber { get; set; }
        
        public DateTime DateOfIssue { get; set; }
        
        public DateTime DateOfService { get; set; }
        
        public bool IsReturned { get; set; }
        
        public Guid CopyId { get; set; }
        public Copy Copy { get; set; }
        
        public Guid LibraryCardId { get; set; }
        public LibraryCard LibraryCard { get; set; }
    }
}