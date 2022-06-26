using System;
using System.Collections.Generic;

namespace LibraryPlatform.Models
{
    public class Library
    {
        public Library()
        {
            LibraryId = Guid.NewGuid();
            Copies = new List<Copy>();
            LibraryCards = new List<LibraryCard>();
        }
        
        public Guid LibraryId { get; set; }
        
        public string Address { get; set; }
        public string CodeNumber { get; set; }
        public string Number { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        
        public Guid LibraryStockId { get; set; }
        public LibraryStock LibraryStock { get; set; }
        
        public List<Copy> Copies { get; set; }
        
        public List<LibraryCard> LibraryCards { get; set; }
    }
}