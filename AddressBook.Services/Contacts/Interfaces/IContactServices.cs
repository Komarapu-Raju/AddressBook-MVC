using AddressBook.Data.Models.Contacts;
using AddressBook.DTO.ViewModels;

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
