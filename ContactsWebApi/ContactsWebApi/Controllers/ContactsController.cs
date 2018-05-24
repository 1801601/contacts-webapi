using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsWebApi.Models;
using ContactsWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/contacts")]
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }


        // GET api/contacts
        [HttpGet]
        public IActionResult Get()
        {
            List<Contact> contacts = _contactService.GetContacts();
            return new JsonResult(contacts);
        }

        // GET api/contacts/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Contact contact = _contactService.GetContactById(id);
            return new JsonResult(contact);
        }
    }
}