using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageSystem
{
    public class ConsoleOperations
    {
        static BookManager bookmanager = new BookManager();
        static AuthorManager authormanager = new AuthorManager();
        static PublisherManager publishermanager = new PublisherManager();
        static BookRepositoryManager bookRepositoryManager = new BookRepositoryManager();
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter your option");
                Console.WriteLine("1.AddBook");
                Console.WriteLine("2.GetAllBooks");
                Console.WriteLine("3.GetByGenre");
                Console.WriteLine("4.GetByAuthor");
                Console.WriteLine("5.GetByPublisher");
                Console.WriteLine("6.Add Edition to the existing book");
                Console.WriteLine("7.Delete Book By Edition");
                Console.WriteLine("8.Delete Book with all its editions");
                Console.WriteLine("9.Exit");
                Console.Write("Enter your choice : ");
                int choice = 0;
                int.TryParse(Console.ReadLine(), out choice);
                bool continuecheck = true;
                switch (choice)
                {
                    case 1:
                        try
                        {
                            AddBookOption();
                        }
                        catch (InvalidBookException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        catch (InvalidPublisherException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        catch (InvalidAuthorException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                            Console.WriteLine(exception.InnerException);
                        }

                        break;
                    case 2:
                        GetAllBooksOption();
                        break;
                    case 3:
                        GetBookByGenreOption();
                        break;
                    case 4:
                        GetByAuthorOption();
                        break;
                    case 5:
                        GetByPublisherOption();
                        break;
                    case 6:
                        AddEditionOption();
                        break;
                    case 7:
                        DeleteBookEdition();
                        break;
                    case 8:
                        DeleteBook();
                        break;
                    case 9:
                        Console.WriteLine("THANK YOU");
                        continuecheck = false;
                        break;
                    default:
                        Console.WriteLine("\n You have entered wrong option");
                        break;

                }
                if (continuecheck)
                {
                    Console.WriteLine("Do you want to continue Yes/No");
                    if (string.Equals("No", Console.ReadLine(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        Console.WriteLine("THANKYOU");
                        break;
                    }
                }
                else
                    break;

            }

        }
        /// <summary>
        /// This method reads the data of the book and sends the data to dto classes and call addbook method in bookmanager
        /// </summary>

        public static void AddBookOption()
        {
            BookDTO bookDTO = new BookDTO();
            AuthorDTO authorDTO = new AuthorDTO();
            PublisherDTO publisherDTO = new PublisherDTO();
            BookRepositoryDTO bookRepoDTO = new BookRepositoryDTO();

            Console.Write("\nEnter Title : ");
            bookDTO.Title = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("1.Science&Technology  2.Romance  3.Literature  4.Biography  5.History");
                Console.Write("\nSelect GenreType : ");
                int genre = 0;
                int.TryParse(Console.ReadLine(), out genre);
                if (genre == 0 || genre < 0 || genre > 5)
                {
                    Console.WriteLine("Please enter correct value");
                    continue;
                }
                else
                {
                    switch (genre)
                    {
                        case 1: bookDTO.GenreType = "Science&Technology";
                            break;
                        case 2: bookDTO.GenreType = "Romance";
                            break;
                        case 3: bookDTO.GenreType = "Literature";
                            break;
                        case 4: bookDTO.GenreType = "Biography";
                            break;
                        case 5: bookDTO.GenreType = "History";
                            break;
                        default: Console.WriteLine("Enter correct value");
                            break;
                    }
                    break;
                }
            }
            while (true)
            {
                Console.Write("\nEnter Author FirstName :");
                authorDTO.FirstName = Console.ReadLine();
                Console.Write("\nEnter Author LastName :");
                authorDTO.LastName = Console.ReadLine();
                bookDTO.AuthorDTOlist.Add(authorDTO);
                //Author author = authormanager.Get(authorDTO.FirstName);
                //if (author == null)
                //{
                //    bookDTO.AuthorIDlist.Add(authormanager.Add(authorDTO));
                //}
                //else
                //    bookDTO.AuthorIDlist.Add(author.ID);
                Console.Write("\n Do you want to enter more authors Yes/No : ");
                if (string.Equals("No", Console.ReadLine(), StringComparison.CurrentCultureIgnoreCase))
                    break;
            }

            Console.Write("\n Enter Publisher Name : ");
            publisherDTO.Name = Console.ReadLine();
            Console.Write("\n Enter Publisher MoblieNumber : ");
            publisherDTO.ContactNumber = long.Parse(Console.ReadLine());
            bookDTO.publisherDTO = publisherDTO;
            //Publisher publisher = publishermanager.Get(publisherDTO.Name);
            //if (publisher == null)
            //{
            //    bookDTO.publisherID = publishermanager.Add(publisherDTO);
            //}
            //else
            //    bookDTO.publisherID = publisher.ID;
            Console.Write("\n Enter Edition : ");
            bookRepoDTO.Edition = Console.ReadLine();
            Console.Write("\n Enter Price : ");
            bookRepoDTO.Price = Double.Parse(Console.ReadLine());
            Console.Write("\n Enter Number of Copies : ");
            int numberofbooks = 0;
            int.TryParse(Console.ReadLine(), out numberofbooks);
            bookRepoDTO.NumberOfCopies = numberofbooks;
            bookDTO.BookRepositoryDTO = bookRepoDTO;

            if (bookmanager.AddBook(bookDTO) != null)
                Console.WriteLine("BOOK ADDED SUCCESSFULLY");
            else
                Console.WriteLine("SOMETHING WENT WRONG IN ADDING BOOK");
        }
        /// <summary>
        /// This method get the all books from the list and displays the books
        /// </summary>
        public static void GetBookByGenreOption()
        {

            Console.WriteLine("Enter genre type");
            string genreType = Console.ReadLine();
            IEnumerable<Book> books = bookmanager.GetByGenre(genreType);
            if (!DisplayBooks(books))
                Console.WriteLine("No books found");

        }
        public static void GetAllBooksOption()
        {
            IEnumerable<Book> books = bookmanager.GetAll();
            if (!DisplayBooks(books))
                Console.WriteLine("No Books Found");
        }
        /// <summary>
        /// This method is for getting the books that are available in the database by using author name
        /// </summary>
        public static void GetByAuthorOption()
        {
            Console.WriteLine("Enter AuthorName ");
            string name = Console.ReadLine();
            Author author = authormanager.Get(name);

            var books = bookmanager.GetByAuthor(author.ID);
            if (!DisplayBooks(books))
                Console.WriteLine("No books Found");
        }
        /// <summary>
        /// This method allows you to get Books by specified Publisher
        /// </summary>
        public static void GetByPublisherOption()
        {
            Console.WriteLine("Enter Publisher Name : ");
            string name = Console.ReadLine();
            Publisher publisher = publishermanager.Get(name);
            IEnumerable<Book> books = bookmanager.GetByPublisher(publisher.ID);
            if (!DisplayBooks(books))
                Console.WriteLine("No books Found");

        }
        /// <summary>
        /// This method is for adding the new edition of the already available book
        /// </summary>
        public static void AddEditionOption()
        {
            Book book;
            while (true)
            {
                Console.WriteLine("Enter Title of the Book");
                string bookname = Console.ReadLine();
                book = bookmanager.GetByTitle(bookname);
                if (book == null)
                    Console.Write("\n No Book Found ");
                else
                    break;
                
            }
            BookRepositoryDTO bookRepoDTO = new BookRepositoryDTO();
            Console.WriteLine("Enter edition of the book");
            bookRepoDTO.Edition = Console.ReadLine();
            Console.WriteLine("Enter number of Books");
            int numberofbooks = int.Parse(Console.ReadLine());
            bookRepoDTO.PublishedDate = DateTime.Now;
            bookRepoDTO.BookID = book.ID;
            if (bookRepositoryManager.Add(book.ID,bookRepoDTO) != null)
                Console.WriteLine("Book Added Successfully");
        }
        /// <summary>
        /// This method deletes the book by specific edition
        /// </summary>
        public static void DeleteBookEdition()
        {
            try
            {
                Console.WriteLine("Enter title of the book");
                string Title = Console.ReadLine();
                Book book = bookmanager.GetByTitle(Title);

                Console.WriteLine("Enter edition of the book");
                string edition = Console.ReadLine();
                if (bookRepositoryManager.Delete(book.ID, edition))
                    Console.WriteLine("Book Deleted Successfully");
                else
                    Console.WriteLine("SOMETHING WENT WRONG");
            }catch(InvalidBookException invalidbook)
            {
                Console.WriteLine(invalidbook.Message);
            }

        }
        /// <summary>
        /// This method deletes the entire book
        /// </summary>
        public static void DeleteBook()
        {
            Console.WriteLine("Enter title of the book");
            string title = Console.ReadLine();
            Book book = bookmanager.GetByTitle(title);
            if (book == null)
            {
                Console.WriteLine("Book does not exist");
                return;
            }
            else
            {
                if (bookmanager.Delete(book.ID))
                    Console.WriteLine("Book deleted successfully");
            }

        }
        public static bool DisplayBooks(IEnumerable<Book> books)
        {
            bool booksFound = false;
            int bookCount = 0;
            foreach (var book in books)
            {
                
                booksFound = true;
                Console.WriteLine("\n"+ ++bookCount+"\t Title \t\t: " + book.Title);
                Console.WriteLine("\t Genre \t\t: " + book.GenreType);
                Console.Write("\t Authors\t: ");
                for (int i = 0; i < book.Authors.Count(); i++)
                {
                    if (i != 0)
                        Console.Write(",");
                    Console.Write(book.Authors[i].FirstName + " " + book.Authors[i].LastName);
                }
                Console.WriteLine("\n\t Publisher\t: " + book.Publisher.Name);
                foreach (var bookrepo in book.BookRepositories)
                {
                    Console.Write("\n\t Edition \t: " + bookrepo.Edition);
                    Console.Write("\n\t Price\t\t: " + bookrepo.Price);
                    Console.WriteLine("\n\t No.Of Copies\t: " + bookrepo.NumberOfCopies);
                }
            }
            return booksFound;
        }
    }
}
