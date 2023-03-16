using AddressBook.Services.Contacts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.ViewComponents
{
    public class ContactListViewComponent : ViewComponent
    {
        private readonly IContactServices _contactServices;

        public ContactListViewComponent(IContactServices contactServices)
        {
            this._contactServices = contactServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["contactList"] = this._contactServices.GetContactsList();
            return await Task.FromResult((IViewComponentResult)View("ContactList"));
        }
    }
}
