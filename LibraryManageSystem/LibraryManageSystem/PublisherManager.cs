using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageSystem
{
   public class PublisherManager
    {
        public string Add(PublisherDTO dto)
        {

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new InvalidPublisherException("INVALID PUBLISHER NAME");
            if (dto.ContactNumber == 0)
                throw new InvalidPublisherException("INVALID PUBLISHER CONTACT NUMBER");
            Publisher publisher;
            var context = new LibraryDBContext();
            publisher = context.Publishers.SingleOrDefault(publisherL => publisherL.Name == dto.Name);
            if (publisher == null)
            {
                publisher = new Publisher();
                publisher.Name = dto.Name;
                publisher.ContactNumber = dto.ContactNumber;
                publisher.ID = dto.generateID();
                context.Publishers.Add(publisher);
                context.SaveChanges();
                return publisher.ID;
            }
            else
                return publisher.ID;
        }
        public Publisher Get(string Name)
        {
            var context = new LibraryDBContext();
            Publisher publisher = context.Publishers.SingleOrDefault(publisherL => publisherL.Name == Name);
            return publisher;
        }
        public Publisher GetByID(string ID)
        {
            var context = new LibraryDBContext();
            Publisher publisher = context.Publishers.SingleOrDefault(publisherL => publisherL.ID == ID);
            return publisher;
        }
        public IEnumerable<Publisher> GetAll()
        {
            var context = new LibraryDBContext();
            var publishers = context.Publishers.Include("Books").ToList();
            return publishers;
        }
        public bool Update(string ID,PublisherDTO dto)
        {
            var context = new LibraryDBContext();
            Publisher publisher = context.Publishers.SingleOrDefault(publisherL => publisherL.ID == ID);
            if (publisher == null)
            {
                throw new InvalidPublisherException("PUBLISHER NOT FOUND");
            }
            if (dto.Name != null)
                publisher.Name = dto.Name;
            if (dto.ContactNumber != 0)
                 publisher.ContactNumber = dto.ContactNumber;

            context.SaveChanges();    
            return true;
        }
        public bool Delete(string Name)
        {
            var context = new LibraryDBContext();
            Publisher publisher = context.Publishers.SingleOrDefault(publisherL=>publisherL.Name==Name);
            if (publisher == null)
                throw new InvalidPublisherException("PUBLISHER NOT FOUND");
            else
            {
                context.Publishers.Remove(publisher);
                context.SaveChanges();
            }
            return true;
        }
        public bool DeleteByID(string ID)
        {
            var context = new LibraryDBContext();
            Publisher publisher = context.Publishers.SingleOrDefault(publisherL => publisherL.ID == ID);
            if (publisher == null)
                throw new InvalidPublisherException("PUBLISHER NOT FOUND");
            context.Publishers.Remove(publisher);
            context.SaveChanges();
            return true;
                
        }
    }
}
