using AddressBook.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.DBContext
{
    public class AddressBookDBContext : DbContext
    {
        public AddressBookDBContext(DbContextOptions<AddressBookDBContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
