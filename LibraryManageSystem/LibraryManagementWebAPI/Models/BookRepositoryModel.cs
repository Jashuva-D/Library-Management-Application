using System;

namespace LibraryManagementWebAPI.Models
{
    public class BookRepositoryModel
    {
        public string Edition { get; set; }
        public double Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public int NumberOfCopies { get; set; }

    }
}