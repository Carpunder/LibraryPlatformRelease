using System;
using System.Collections.Generic;

namespace LibraryPlatform.Models
{
    public class LibraryStock
    {
        public LibraryStock()
        {
            LibraryStockId = Guid.NewGuid();
        }
        
        public Guid LibraryStockId { get; set; }
        
        public List<Library> Libraries { get; set; }
    }
}