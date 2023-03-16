using AddressBook.Data.Models.Contacts;
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
            _dbContext = dBContext;
        }

        public void AddContact(Contact newContact)
        {
            _dbContext.Contacts.Add(newContact);
            _dbContext.SaveChanges();
        }

        public void UpdateContact(Contact updatedContact)
        {
            var existingContact = _dbContext.Contacts.Find(updatedContact.Id);
            if (existingContact != null)
            {
                _dbContext.Entry(existingContact).State = EntityState.Detached;
            }

            _dbContext.Contacts.Update(updatedContact);
            _dbContext.SaveChanges();
        }

        public void DeleteContact(int id)
        {
            var obj = _dbContext.Contacts.Find(id);
            _dbContext.Contacts.Remove(obj);
            _dbContext.SaveChanges();
        }

        public ContactDetailsViewModel GetContactById(int id)
        {
            return mapper.Map<ContactDetailsViewModel>(_dbContext.Contacts.Find(id));
        }

        public List<ContactListViewModel> GetContactsList()
        {
            return mapper.Map<List<ContactListViewModel>>(_dbContext.Contacts.ToList());
        }

        public bool DoesContactExist(int id)
        {
            return GetContactsList().Any(contact => contact.Id == id);
        }
    }
}
