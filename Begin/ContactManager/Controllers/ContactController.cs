using ContactManager.Models;
using ContactManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactManager.Controllers
{
    public class ContactController : ApiController
    {
        private ContactRepository contactRepository;

        public ContactController()
        {
            this.contactRepository = new ContactRepository();
        }

        [HttpGet]
        public Contact[] GetContacts()
        {
            return contactRepository.GetAllContacts();
        }


        [HttpGet]
        [Route("api/Contacts2")]
        public Contact[] GetContacts2()
        {
            return contactRepository.GetAllContacts();
        }

        //[HttpPost]
        //public bool PostContact(Contact contact)
        //{
        //    return contactRepository.SaveContact(contact);
        //}

        [HttpPost]
        public HttpResponseMessage PostContact(Contact contact)
        {
            this.contactRepository.SaveContact(contact);

            HttpResponseMessage response = Request.CreateResponse<Contact>(HttpStatusCode.Created, contact);
            return response;
        }

        [HttpPut]
        public bool UpdateContact(Contact contact)
        {
            return contactRepository.UpdateContact(contact);
        }

        [HttpDelete]
        public bool DeleteContact(int id)
        {
            return contactRepository.DeleteContact(id);
        }
    }
}
