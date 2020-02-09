using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageSystem
{
   public class AuthorManager
    {
        public string Add(AuthorDTO dto)
        {
            if (string.IsNullOrEmpty(dto.FirstName))
                throw new InvalidAuthorException("INVALID AUTHOR FIRSTNAME");
            if (string.IsNullOrEmpty(dto.LastName))
                throw new InvalidAuthorException(" INVALID AUTHOR LASTNAME");

            Author author;
            var context = new LibraryDBContext();
            author = context.Authors.SingleOrDefault(authorL =>( authorL.FirstName+authorL.LastName) == (dto.FirstName+dto.LastName));
            if (author == null)
            {
                author = new Author();
                author.FirstName = dto.FirstName;
                author.LastName = dto.LastName;
                author.ID = dto.generateID();
                context.Authors.Add(author);
                context.SaveChanges();
                return author.ID;
            }
            else
                return author.ID;
        }
        public Author Get(string Name)
        {
            var context = new LibraryDBContext();
            Author author = context.Authors.SingleOrDefault(authorL => (authorL.FirstName + authorL.LastName).Contains(Name));
            return author;
        }
        public Author GetByID(string ID)
        {
            var context = new LibraryDBContext();
            Author author = context.Authors.Include("Books").SingleOrDefault(authorL => authorL.ID == ID);
            return author;
        }
        public bool Update(AuthorDTO dto)
        {
            var context = new LibraryDBContext();
            Author author = context.Authors.SingleOrDefault(authorL => (authorL.FirstName + authorL.LastName).Contains(dto.FirstName));
            if (author == null)
                  throw new InvalidPublisherException("AUTHOR NOT FOUND");
            if (dto.FirstName != null)
                author.FirstName = dto.FirstName;
            if (dto.LastName != null)
                author.LastName = dto.LastName;
            context.SaveChanges();

            return true;
        }
        public bool Delete(string Name)
        {
            var context = new LibraryDBContext();
            Author author = context.Authors.SingleOrDefault(authorL => (authorL.FirstName + authorL.LastName).Contains(Name));
            if (author == null)
                throw new InvalidPublisherException("AUTHOR NOT FOUND");
            else
            {
                context.Authors.Remove(author);
                context.SaveChanges();
            }
            return true;
        }
        public bool DeleteByID(string ID)
        {
            var context = new LibraryDBContext();
            var author = context.Authors.SingleOrDefault(authorL => authorL.ID == ID);
            if (author == null)
                throw new InvalidAuthorException("AUTHOR NOT FOUND");
            context.Authors.Remove(author);
            context.SaveChanges();
            return true;
        }
        public IEnumerable<Author> GetAll()
        {
            var context = new LibraryDBContext();
            var authors = context.Authors.Include("Books").ToList();
            return authors;
        }
    }
}
