using AddressBook.DTO.ViewModels;
using AddressBook.Services.Contacts.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Data.Models.Contact;

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
        public IActionResult ContactForm(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (this._contactServices.GetContactById(contact.Id) != null)
                {
                    this._contactServices.UpdateContact(contact.Id,contact);
                    return RedirectToAction("ContactDetails", new { contact.Id });
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
    }
}
