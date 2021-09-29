using System.Collections.Generic;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Super_Shop.Models;

namespace Super_Shop.Repositories
{
    public class ContactRepository
    {

        public List<Contact> FindAll()
        {
            using (var context = new ContextFactory().CreateDbContext(null))
            {
                return context.Contacts.Include(c => c.Hero).ToList();
            }
        }

        public Contact FindById(int ID)
        {
            using (var context = new ContextFactory().CreateDbContext(null))
            {
                return context.Contacts.Include(c => c.Hero).First(c => c.ID == ID);
            }
        }
        public Contact Save(Contact contact)
        {
            using (var context = new ContextFactory().CreateDbContext(null))
            {
                EntityEntry<Contact> savedContact = context.Contacts.Add(contact);
                context.Entry(contact.Hero).State = EntityState.Unchanged;
                context.SaveChanges();
                return savedContact.Entity;
            }

        }
    }
}