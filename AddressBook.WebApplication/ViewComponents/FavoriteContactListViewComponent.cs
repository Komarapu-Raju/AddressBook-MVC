using AddressBook.Services.Contacts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.WebApplication.ViewComponents
{
    public class FavoriteContactListViewComponent : ViewComponent
    {
        public IContactServices _contactServices;

        public FavoriteContactListViewComponent(IContactServices contactServices)
        {
            this._contactServices = contactServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["contactList"] = this._contactServices.GetContactsList();
            return await Task.FromResult((IViewComponentResult)View("FavoriteContactList"));
        }
    }
}
