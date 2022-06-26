using System;

namespace LibraryPlatform.Models
{
    public class User
    {
        public User()
        {
            UserId = Guid.NewGuid();
        }

        public User(string fio, string passport, string phone, string address)
        {
            UserId = Guid.NewGuid();
            FIO = fio;
            Passport = passport;
            Phone = phone;
            Address = address;
        }

        public Guid UserId { get; set; }
        
        public string FIO { get; set; }
        
        public string Passport { get; set; }
        
        public string Phone { get; set; }
        
        public string Address { get; set; }
    }
}