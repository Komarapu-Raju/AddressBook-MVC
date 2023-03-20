using AddressBook.Services.Contacts.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Data.Models.Contact;
using AddressBook.Core.Models.ViewModels;

namespace AddressBook.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactServices _contactServices;

        private readonly IMapper mapper;

        public ContactController(IContactServices contactServices, IMapper mapper)
        {
            this._contactServices = contactServices;
            this.mapper = mapper;
        }

        public IActionResult AddContact()
        {
            return View("ContactForm");
        }

        public IActionResult EditContact(int id)
        {
            return View("ContactForm", this.mapper.Map<Contact>(_contactServices.GetContactById(id)));
        }

        [HttpPost]
        public IActionResult ContactForm(int id, Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (this._contactServices.GetContactById(id) != null)
                {
                    this._contactServices.UpdateContact(id,contact);
                    return RedirectToAction("ContactDetails", new { id });
                }

                this._contactServices.AddContact(contact);
                return RedirectToAction("ContactDetails", new { this._contactServices.GetContactsList().Last<ContactListViewModel>().Id });
            }

            return View(contact);
        }

        public IActionResult ContactDetails(int id)
        {
            return View(this._contactServices.GetContactById(id));
        }

        public IActionResult DeleteContact(int id)
        {
            this._contactServices.DeleteContact(id);
            return RedirectToAction("Index");
        }

        public IActionResult FavoriteContact(int id)
        {
            _contactServices.ToggleFavorite(id);
            return RedirectToAction("ContactDetails", new { id });
        }

        public IActionResult Index()
        {
            ContactListViewModel? contact = this._contactServices.GetContactsList().FirstOrDefault();

            if (contact != null)
            {
                return RedirectToAction("ContactDetails", new { contact.Id });
            }

            return View();
        }

        public IActionResult CloseForm()
        {
            return RedirectToAction("Index");
        }

        public IActionResult ContactList()
        {
            ViewData["contactList"] = this._contactServices.GetContactsList();
            return ViewComponent("ContactList");
        }

        public IActionResult FavoriteContactList()
        {
            ViewData["contactList"] = this._contactServices.GetContactsList();
            return ViewComponent("FavoriteContactList");
        }
    }
}
