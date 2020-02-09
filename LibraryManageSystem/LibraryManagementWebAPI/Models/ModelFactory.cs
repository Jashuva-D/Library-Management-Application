using LibraryManageSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementWebAPI.Models
{
    public class ModelFactory
    {
        public AuthorManager authormanager = new AuthorManager();
        public PublisherManager publishermanager = new PublisherManager();
        public BookModel Create(Book book)
        {
            return new BookModel()
            {
                ID = book.ID,
                Title = book.Title,
                Genre = book.GenreType,
                Publisher = Create(book.Publisher),
                Authors = book.Authors.Select(author => Create(author)),
                Repositories = book.BookRepositories.Select(repo => Create(repo))
            };
        }
        public AuthorModel Create(Author author)
        {
            return new AuthorModel()
            {
                ID = author.ID,
                Name = author.FirstName + " " + author.LastName
            };
        }
        public PublisherModel Create(Publisher publisher)
        {
            return new PublisherModel()
            {
                ID = publisher.ID,
                Name = publisher.Name,
                Contact = publisher.ContactNumber
            };
        }
        public BookRepositoryModel Create(BookRepository repo)
        {
            return new BookRepositoryModel()
            {
                Edition = repo.Edition,
                NumberOfCopies = repo.NumberOfCopies,
                Price = repo.Price,
                PublishedDate = repo.PublishedDate
            };
        }
        public BookDTO Parse(BookModel model)
        {
            BookDTO bookdto = new BookDTO();
            
            PublisherDTO publisherdto = new PublisherDTO();
            if(model.Title!=null)
                     bookdto.Title = model.Title;
            if(model.Genre!=null)
                     bookdto.GenreType = model.Genre;
            if (model.Authors != null)
            {
                foreach (AuthorModel authormodel in model.Authors)
                {
                    if(authormodel!=null)
                         bookdto.AuthorDTOlist.Add(Parse(authormodel));
                }
            }
            if(model.Publisher!=null)
                   bookdto.publisherDTO = Parse(model.Publisher);
            if(model.Repositories!=null)
                foreach (BookRepositoryModel bookrepomodel in model.Repositories)
                {
                    if (bookrepomodel != null)
                        bookdto.BookRepositoryDTO = Parse(bookrepomodel);
                }



            return bookdto;


        }
        public AuthorDTO Parse(AuthorModel model)
        {
            AuthorDTO authordto = new AuthorDTO();
           
            if (model.Name != null)
            {
                string[] namesplit = model.Name.Split(new char[] { ' ' });
                authordto.FirstName = namesplit[0];
                authordto.LastName = namesplit[1];
            }
            
            return authordto;
        }
        public PublisherDTO Parse(PublisherModel model)
        {
            
            PublisherDTO publisherdto = new PublisherDTO();
            if(model.Name!=null)
                   publisherdto.Name = model.Name;
            if(model.Contact!=0)
                   publisherdto.ContactNumber = model.Contact;
            return publisherdto;
        }
        public BookRepositoryDTO Parse(BookRepositoryModel model)
        {
            BookRepositoryDTO bookrepodto = new BookRepositoryDTO();
            bookrepodto.Edition = model.Edition;
            bookrepodto.NumberOfCopies = model.NumberOfCopies;
            bookrepodto.Price = model.Price;
            bookrepodto.PublishedDate = model.PublishedDate;

            return bookrepodto;
        }

       

        
    }
}