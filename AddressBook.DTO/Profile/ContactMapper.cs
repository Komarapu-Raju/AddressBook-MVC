using AddressBook.Data.Models.Contacts;
using AddressBook.DTO.ViewModels;
using AutoMapper;

namespace AddressBook.Helpers
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<Contact, ContactDetailsViewModel>().ReverseMap();
            CreateMap<Contact, ContactListViewModel>().ReverseMap();
        }
    }
}
