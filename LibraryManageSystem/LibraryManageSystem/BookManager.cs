using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageSystem
{
    public class BookManager
    {
        public BookRepositoryManager bookrepositorymanager = new BookRepositoryManager();
        public AuthorManager authormanager = new AuthorManager();
        public PublisherManager publishermanager = new PublisherManager();
        public string AddBook(BookDTO bookDTO)
        {
            
                if (string.IsNullOrEmpty(bookDTO.GenreType))
                    throw new InvalidBookException("Invalid GenreType");
                if (string.IsNullOrEmpty(bookDTO.Title))
                    throw new InvalidBookException("Invalid Title");
                if (bookDTO.publisherDTO == null)
                    throw new InvalidBookException("Invalid Publisher");
                if (bookDTO.AuthorDTOlist.Count() == 0)
                    throw new InvalidBookException("Book Must contain atleast one author");


                Book book;
                using (var context = new LibraryDBContext())
                {

                    book = context.Books.Include("Authors").Where(bookL => bookL.Title == bookDTO.Title).Select(bookL => bookL).SingleOrDefault();
                    if (book == null)
                    {
                        book = new Book();
                        book.Title = bookDTO.Title;
                        book.GenreType = bookDTO.GenreType;
                        book.ID = bookDTO.generateID();


                        foreach (var authordto in bookDTO.AuthorDTOlist)
                        {
                            string authorID = authormanager.Add(authordto);
                            Author author = context.Authors.Include("Books").Where(authorL => authorL.ID==authorID).Select(authorL => authorL).Single();
                            book.Authors.Add(author);
                        }
                        string publisherID = publishermanager.Add(bookDTO.publisherDTO);
                        Publisher publisher = context.Publishers.Where(publisherL => publisherL.ID == publisherID).Select(publisherL => publisherL).Single();
                        book.Publisher = publisher;
                       context.Books.Add(book);
                       context.SaveChanges();
                    }
                
                     bookDTO.BookRepositoryDTO.BookID = book.ID;
                
                     bookrepositorymanager.Add(book.ID,bookDTO.BookRepositoryDTO);
                }

                return book.ID;
            
        }
       
        public Book GetByTitle(string title)
        {
            var context = new LibraryDBContext();
            Book book = context.Books.Include("Authors")
                                    .SingleOrDefault(bookL => bookL.Title == title);
            return book;
        }
        public Book GetByID(string ID)
        {
            var context = new LibraryDBContext();
            Book book = context.Books.Include("Authors")
                                     .ToList()
                                     .SingleOrDefault(bookL => bookL.ID == ID);
            return book;
        }
        public IEnumerable<Book> GetByGenre(string GenreType)
        {
            var context = new LibraryDBContext();
            var books = context.Books.Include("Authors")
                                   .ToList()
                                   .Where(book => book.GenreType.ToLower().Contains( GenreType.ToLower()));
            return books;
        }
        public IEnumerable<Book> GetByAuthor(string ID)
        {
            var context = new LibraryDBContext();
            var books = from book in context.Books.Include("Authors")
                        from author in book.Authors
                        where author.ID == ID
                        select book;
            return books;
        }
        public IEnumerable<Book> GetByPublisher(string ID)
        {
            var context = new LibraryDBContext();
            var books = context.Books.Include("Authors")
                                   .ToList()
                                   .Where(book => book.Publisher.ID == ID);
            return books;
        }
        public IEnumerable<Book> GetAll()
        {
            var context = new LibraryDBContext();
            var books = context.Books.ToList();
            return books;
        }

        public bool Update(string BookID,BookDTO dto)
        {
            var context = new LibraryDBContext();
            Book book = context.Books.SingleOrDefault(bookL => bookL.ID== BookID);
            if (book == null)
                throw new InvalidBookException("BOOK NOT FOUND");
            if (dto.Title != null)
                book.Title = dto.Title;
            if (dto.GenreType != null)
                book.GenreType = dto.GenreType;
            if (dto.BookRepositoryDTO != null)
            {
                dto.BookRepositoryDTO.BookID = book.ID;
                if (!bookrepositorymanager.Update(book.ID,dto.BookRepositoryDTO.Edition,dto.BookRepositoryDTO))
                      throw new Exception("SOMETHING WENT WRONG");
            }
            context.SaveChanges();
            return true;
                   

        }
        public bool Delete(string ID)
        {
            var context = new LibraryDBContext();
            Book book = context.Books.SingleOrDefault(bookL => bookL.ID == ID);
            if (book == null)
                throw new InvalidBookException("BOOK NOT FOUND");
            else
                context.Books.Remove(book);
            context.SaveChanges();
            return true;
        }
        public bool Delete(string ID,string Edition)
        {
            var context = new LibraryDBContext();
            Book book = context.Books.SingleOrDefault(bookL => bookL.ID == ID);
            if (book == null)
                throw new InvalidBookException("BOOK NOT FOUND");
            else
            {
                bookrepositorymanager.Delete(ID, Edition);
                if(book.BookRepositories==null||book.BookRepositories.Count==0)
                    context.Books.Remove(book);
                context.SaveChanges();
            }
            return true;
        }
        
        
        
    }
}
