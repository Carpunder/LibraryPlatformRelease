using System;

namespace LibraryPlatform.Models
{
    public class LibraryCard
    {
        public LibraryCard() { 
            LibraryCardId = Guid.NewGuid();
        }
        public LibraryCard(Guid userId, int libraryCardNumber)
        {
            LibraryCardId = Guid.NewGuid();
            RegisterDate = DateTime.Now;
            LibraryId = Values.Values.CurrentLibraryValue;
            UserId = userId;
            LibraryCardNumber = libraryCardNumber;
        }
        
        public Guid LibraryCardId { get; set; }
        
        public int LibraryCardNumber { get; set; }
        
        public DateTime RegisterDate { get; set; }
        
        public Guid LibraryId { get; set; }
        public Library Library { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}