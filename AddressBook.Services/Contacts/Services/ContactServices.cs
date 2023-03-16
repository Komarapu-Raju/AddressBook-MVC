using AddressBook.Data.Models.Contact;
using AddressBook.DTO.ViewModels;
using AddressBook.Infrastructure.DBContext;
using AddressBook.Services.Contacts.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Services.Contacts.Services
{
    public class ContactServices : IContactServices
    {
        private readonly AddressBookDBContext _dbContext;

        private readonly IMapper mapper;

        public ContactServices(AddressBookDBContext dBContext, IMapper mapper)
        {
            this.mapper = mapper;
            this._dbContext = dBContext;
        }

        public void AddContact(Contact newContact)
        {
            this._dbContext.Contacts.Add(newContact);
            this._dbContext.SaveChanges();
        }

        public void UpdateContact(int id, Contact updatedContact)
        {
            var existingContact = this._dbContext.Contacts.Find(id);

            if (existingContact != null)
            {
                this._dbContext.Entry(existingContact).State = EntityState.Detached;
            }

            this._dbContext.Contacts.Update(updatedContact);
            this._dbContext.SaveChanges();
        }

        public void DeleteContact(int id)
        {
            var obj = this._dbContext.Contacts.Find(id);
            this._dbContext.Contacts.Remove(obj);
            this._dbContext.SaveChanges();
        }

        public ContactDetailsViewModel GetContactById(int id)
        {
            return mapper.Map<ContactDetailsViewModel>(this._dbContext.Contacts.Find(id));
        }

        public List<ContactListViewModel> GetContactsList()
        {
            return mapper.Map<List<ContactListViewModel>>(this._dbContext.Contacts.ToList());
        }
    }
}
