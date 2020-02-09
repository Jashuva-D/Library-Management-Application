using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageSystem
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public string ID { get; set; } 
        public string Title { get; set; }
        public string GenreType { get; set; }
        public virtual List<Author> Authors { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<BookRepository> BookRepositories { get; set; }
        public Book()
        {
            Authors = new List<Author>();
            BookRepositories = new List<BookRepository>();
        }
    }
    [Table("Author")]
    public class Author
    {
        [Key]
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }

    }
    [Table("Publisher")]
    public class Publisher
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public long ContactNumber { get; set; }
        public virtual List<Book> Books { get; set; }
        public Publisher()
        {
            Books = new List<Book>();
        }
    }
    [Table("BookRepository")]
    public class BookRepository
    {
        [Key, ForeignKey("Book"), Column(Order = 1)]
        public string BookID { get; set; }
        [Key, ForeignKey("Publisher"), Column(Order = 2)]
        public string PublisherID { get; set; }
        [Key,Column(Order =3)]
        public string Edition { get; set; }

        public virtual Book Book { get; set; }
        public virtual Publisher Publisher { get; set; }

        public  DateTime PublishedDate { get; set; }
        public int NumberOfCopies { get; set; }
        public double Price { get; set; }

    }
    [Table("Member")]
    public class Member
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
    }
    [Table("MemberManager")]
    public class MemberManager
    {
        [Key, ForeignKey("Member"), Column(Order = 1)]
        public string MemberID { get; set; }
        [Key, ForeignKey("Book"), Column(Order = 2)]
        public string BookID { get; set; }

        public virtual Member Member { get; set; }
        public virtual Book Book { get; set; }

        public DateTime IssuedDate { get; set; }
        public DateTime ReceivedDate { get; set; }
    }
}
