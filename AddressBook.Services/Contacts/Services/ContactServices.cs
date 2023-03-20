using AddressBook.Core.Models.ViewModels;
using AddressBook.Data.Models.Contact;
using AddressBook.Infrastructure.EFCore.DBContext;
using AddressBook.Services.Contacts.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Services.Contacts.Services
{
    public class ContactServices : IContactServices
    {
        private readonly AddressBookDBContext _db;

        private readonly IMapper mapper;

        public ContactServices(AddressBookDBContext db, IMapper mapper)
        {
            this.mapper = mapper;
            this._db = db;
        }

        public void AddContact(Contact newContact)
        {
            this._db.Contacts.Add(newContact);
            this._db.SaveChanges();
        }

        public void ToggleFavorite(int id)
        {
            Contact contact = this._db.Contacts.Find(id);
            if (contact != null)
            {
                contact.IsFavorite ^= true;
            }
            this.UpdateContact(id, contact);
        }

        public void UpdateContact(int id, Contact updatedContact)
        {
            var existingContact = this._db.Contacts.Find(id);
            this._db.Contacts.Entry(existingContact).State = EntityState.Detached;
            this._db.Contacts.Update(updatedContact);
            this._db.SaveChanges();
        }

        public void DeleteContact(int id)
        {
            var obj = this._db.Contacts.Find(id);
            this._db.Contacts.Remove(obj);
            this._db.SaveChanges();
        }

        public ContactDetailsViewModel GetContactById(int id)
        {
            return mapper.Map<ContactDetailsViewModel>(this._db.Contacts.Find(id));
        }

        public List<ContactListViewModel> GetContactsList()
        {
            return mapper.Map<List<ContactListViewModel>>(this._db.Contacts.ToList());
        }
    }
}
