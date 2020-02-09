using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementWebAPI.Models
{
    public class BookModel
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }  
        public PublisherModel Publisher { get; set; }
        public IEnumerable<AuthorModel> Authors { get; set; }
        public IEnumerable<BookRepositoryModel> Repositories { get; set; }
    }
}