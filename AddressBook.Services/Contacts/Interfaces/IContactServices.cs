using AddressBook.Data.Models.Contacts;
using AddressBook.DTO.ViewModels;

namespace AddressBook.Services.Contacts.Interfaces
{
    public interface IContactServices
    {
        void AddContact(Contact newContact);

        void UpdateContact(Contact updatedContact);

        void DeleteContact(int id);

        ContactDetailsViewModel GetContactById(int id);

        List<ContactListViewModel> GetContactsList();

        bool DoesContactExist(int id);
    }
}
