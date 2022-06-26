using System;

namespace LibraryPlatform.Models
{
    public class Copy
    {
        public Copy()
        {
            CopyId = Guid.NewGuid();
            IsAvailable = true;
            InLibrary = true;
            LibraryId = Guid.Empty;
            Library = null;
        }
        
        public Guid CopyId { get; set; }
        public int CopyNumber { get; set; }
        
        public bool IsAvailable { get; set; }
        
        public bool InLibrary { get; set; }
        
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        
        public Guid LibraryId { get; set; }
        public Library Library { get; set; }
        
    }
}