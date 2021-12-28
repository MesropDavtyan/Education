using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManager.Services
{
    public class ContactRepository
    {
        private const string CacheKey = "ContactStore";
        HttpContext ctx = HttpContext.Current;

        public ContactRepository()
        {
            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    Contact[] contacts = new Contact[]
                    {
                        new Contact
                        {
                            Id = 1,
                            Name = "Mesrop Davtyan"
                        },
                        new Contact
                        {
                            Id = 2,
                            Name = "Babken Petrosyan"
                        }
                    };

                    ctx.Cache[CacheKey] = contacts;
                }
            }
        }

        public Contact[] GetAllContacts()
        {
            Contact[] contacts = null;

            if (ctx != null)
            {
                contacts = (Contact[])ctx.Cache[CacheKey];
            }
            else
            {
                contacts = new Contact[]
                {
                    new Contact
                    {
                        Id = 0,
                        Name = "David Kalantaryan"
                    }
                };
            }

            return contacts;
        }

        public bool SaveContact(Contact contact)
        {
            if (ctx != null)
            {
                try
                {
                    List<Contact> currentData = ((Contact[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(contact);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool UpdateContact(Contact contact)
        {
            if (ctx != null)
            {
                try
                {
                    List<Contact> currentData = ((Contact[])ctx.Cache[CacheKey]).ToList();
                    if (currentData.Find(cd => cd.Id == contact.Id) != null)
                    {
                        currentData.Find(cd => cd.Id == contact.Id).Name = contact.Name;
                        ctx.Cache[CacheKey] = currentData.ToArray();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool DeleteContact(int id)
        {
            if (ctx != null)
            {
                try
                {
                    List<Contact> currentData = ((Contact[])ctx.Cache[CacheKey]).ToList();
                    Contact removableContact = currentData.Find(cd => cd.Id == id);
                    currentData.Remove(removableContact);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}