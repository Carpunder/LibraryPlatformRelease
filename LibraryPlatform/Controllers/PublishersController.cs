using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryPlatform.Models;

namespace LibraryPlatform.Controllers
{
    public class PublishersController
    {
        private readonly AppDbContext _context;

        public PublishersController()
        {
            _context = new AppDbContext();
        }

        public PublishersController(AppDbContext context)
        {
            _context = context;
        }

        public bool AddPublisher(Publisher publisher)
        {
            try
            {
                if(publisher.City == null || publisher.Name == null || publisher.Phone == null)
                    return false;
                _context.Publishers.Add(new Publisher
                {
                    PublisherId = publisher.PublisherId,
                    City = publisher.City,
                    Name = publisher.Name,
                    Phone = publisher.Phone,
                });
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool UpdatePublisher(Publisher publisher)
        {
            try
            {
                if (publisher.City == null || publisher.Name == null || publisher.Phone == null)
                    return false;
                var temp = _context.Publishers.FirstOrDefault(x => x.PublisherId == publisher.PublisherId);
                temp.Name = publisher.Name;
                temp.City = publisher.City;
                temp.Phone = publisher.Phone;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool DeletePublisher(Publisher publisher)
        {
            try
            {
                var temp = _context.Publishers.FirstOrDefault(x => x.PublisherId == publisher.PublisherId);
                _context.Publishers.Remove(temp);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
