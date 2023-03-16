using AddressBook.Core.Models.ViewModels;
using AddressBook.Data.Models.Contact;
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
