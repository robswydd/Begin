using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactManager.Services;
using ContactManager.Models;


namespace ContactManager.Controllers
{

    public class ContactController : ApiController
    {
        private ContactRepository contactRepository;

        public ContactController()
        {
            contactRepository = new ContactRepository();
        }

        public HttpResponseMessage Post(Contact contact)
        {
            this.contactRepository.SaveContact(contact);
            var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);
            return response;
        }

        public Contact[] Get()
        {
            return contactRepository.GetAllContacts();
        //    return new Contact[]
        //      {
        //new Contact
        //{
        //    Id = 1,
        //    Name = "Glenn Block"
        //},
        //new Contact
        //{
        //    Id = 2,
        //    Name = "Dan Roth"
        //}
        //      };

        }
    }
}
