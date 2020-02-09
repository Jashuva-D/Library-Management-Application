using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageSystem
{
    public class BookRepositoryManager
    {
        public BookRepository Add(string BookID,BookRepositoryDTO bookRepositoryDTO)
        {
            var context = new LibraryDBContext();
            Book book = context.Books.Include("Publisher").ToList()
                                   .SingleOrDefault(bookL=>bookL.ID==BookID);
            BookRepository bookRepo = new BookRepository();
            bookRepo.Publisher = book.Publisher;
            bookRepo.Book = book;
            if (bookRepositoryDTO.NumberOfCopies == 0)
                throw new InvalidBookException("NUMBER OF COPIES MUST BE GREATER THAN ZERO");
            else
                bookRepo.NumberOfCopies = bookRepositoryDTO.NumberOfCopies;
            if (bookRepositoryDTO.Edition == null)
                throw new InvalidBookException("INVALID BOOK EDITION");
            else
                bookRepo.Edition = bookRepositoryDTO.Edition;
            if (bookRepositoryDTO.Price == 0)
                throw new InvalidBookException("INVALID PRICE");
            else
                bookRepo.Price = bookRepositoryDTO.Price;
            bookRepo.PublishedDate = DateTime.Now;
            //if (bookRepositoryDTO.PublishedDate == null)
            //    throw new InvalidBookException("INVALID pUBLISHED DATE");
            //else
            //    bookRepo.PublishedDate = bookRepositoryDTO.PublishedDate;
            context.BookRepository.Add(bookRepo);
            book.BookRepositories.Add(bookRepo);
            context.SaveChanges();

            return bookRepo;
        }
        public IEnumerable<BookRepository> Get(string BookID)
        {
            var context = new LibraryDBContext();
            var books = context.BookRepository.ToList()
                                              .Where(bookRepo => bookRepo.BookID == BookID);
            return books;
        }
        public BookRepository Get(string BookID,string Edition)
        {
            var context = new LibraryDBContext();
            BookRepository bookrepo = context.BookRepository.SingleOrDefault(record => record.BookID == BookID && record.Edition == Edition);
            return bookrepo;
        }
        public bool Update(string BookID,string Edition,BookRepositoryDTO bookRepoDTO)
        {
            var context = new LibraryDBContext();
            var bookRepo = context.BookRepository.SingleOrDefault(repo => repo.BookID == BookID && repo.Edition == Edition);
            if (bookRepo == null)
                return false;
            if(bookRepoDTO.NumberOfCopies!=0)
              bookRepo.NumberOfCopies = bookRepoDTO.NumberOfCopies;
            if (bookRepoDTO.Price != 0)
                bookRepo.Price = bookRepoDTO.Price;
            context.SaveChanges();
            return true;
           
        }
        public bool Delete(string BookID,string Edition)
        {
            var context = new LibraryDBContext();
            var bookRepo = context.BookRepository.ToList().SingleOrDefault(bookrepo => bookrepo.BookID == BookID && bookrepo.Edition == Edition);
            if (bookRepo == null)
                throw new InvalidBookException("Book Does not exist");
            context.BookRepository.Remove(bookRepo);
            context.SaveChanges();
            return true;
        }
    }
}
