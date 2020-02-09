using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageSystem
{
    public class BookDTO
    {
        public static int IdGenerator = 50;
        public string Title { get; set; }
        public string GenreType { get; set; }
        public BookRepositoryDTO BookRepositoryDTO { get; set; }
        public PublisherDTO publisherDTO { get; set; }
        public List<AuthorDTO> AuthorDTOlist = new List<AuthorDTO>();
        public string generateID()
        {

            return "BOOK-" + ++IdGenerator;
        }
    }
    public class AuthorDTO
    {
        public static int IdGenerator = 50;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string generateID()
        {
            return "AUTH-" + ++IdGenerator;
        }

    }
    public class PublisherDTO
    {
        public static int IdGenerator = 50;
        public string Name { get; set; }
        public long ContactNumber { get; set; }
        public string generateID()
        {
            return "PUB-" + ++IdGenerator;
        }
    }
    public class BookRepositoryDTO
    {
        public string BookID { get; set; }
        public string Edition { get; set; }
        public DateTime PublishedDate { get; set; }
        public int NumberOfCopies { get; set; }
        public double Price { get; set; }
    }
    public class CustomerDTO
    {

        public static int IdGenerator = 0;
        public string Name { get; set; }
        public string Email { get; set; }
        public long MobileNumber { get; set; }
        public string generateID()
        {
            return "CUST-" + ++IdGenerator;
        }
    }
}
