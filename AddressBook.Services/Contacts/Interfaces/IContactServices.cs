using AddressBook.Core.Models.ViewModels;
using AddressBook.Data.Models.Contact;

namespace AddressBook.Services.Contacts.Interfaces
{
    public interface IContactServices
    {
        void AddContact(Contact newContact);

        void UpdateContact(int id, Contact updatedContact);

        void DeleteContact(int id);

        ContactDetailsViewModel GetContactById(int id);

        List<ContactListViewModel> GetContactsList();
    }
}
