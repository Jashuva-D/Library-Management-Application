using LibraryManagementWebAPI.Models;
using LibraryManageSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryManagementWebAPI.Controllers
{
    public class BooksController : ApiController
    {
        ModelFactory modelfactory = new ModelFactory();
        BookManager bookmanager;// = new BookManager();
        public BooksController(BookManager manager)
        {
            bookmanager = new BookManager();   
        }
        public IHttpActionResult Get()
        {
            var books = bookmanager.GetAll();
            var results = books.Select(book => modelfactory.Create(book));
            if (results == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(results);
            }
           
        }
        public IHttpActionResult Get(string ID)
        {
            var book = bookmanager.GetByID(ID);
            if (book == null)
                return null;
            var result = modelfactory.Create(book);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }
        [Route("api/books/title/{name}")]
        public IHttpActionResult GetByTitle(string name)
        {
            var book = bookmanager.GetByTitle(name);
            if (book == null) 
                 return null;
            var result = modelfactory.Create(book);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }
        [Route("api/books/genre/{genretype}")]
        public IHttpActionResult GetByGenre(string genretype)

        {
            var books = bookmanager.GetByGenre(genretype);
            if (books == null)
                return null;
            var result =books.Select(book=> modelfactory.Create(book));
            if (result.Count() != 0)
                return Ok(result);
            else
                return NotFound();
        }
        [Route("api/books/author/{id}")]
        public IHttpActionResult GetByAuthor(string id)
        {
            var books = bookmanager.GetByAuthor(id);
            if (books == null)
                return null;
            var result = books.Select(book => modelfactory.Create(book));
            if (result.Count() != 0)
                return Ok(result);
            else
                return NotFound();
        }
        [Route("api/books/publisher/{id}")]
        public IHttpActionResult GetByPublisher(string id)
        {
            var books = bookmanager.GetByPublisher(id);
            if (books == null)
                return null;
            var result = books.Select(book => modelfactory.Create(book));
            if (result.Count() != 0)
                return Ok(result);
            else
                return NotFound();
        }
        public HttpResponseMessage Post([FromBody] BookModel model)
        {
            try
            {
                BookDTO bookdto = modelfactory.Parse(model);
                string bookID = bookmanager.AddBook(bookdto);
                if (bookID == null)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "SOMETHING WENT WRONG");
                else
                    return Request.CreateResponse(HttpStatusCode.Created, "BOOK CREATED SUCCESSFULLY WITH ID : " + bookID);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpPut]
        [HttpPatch]
        public HttpResponseMessage Patch(string id, [FromBody] BookModel model)
        {
            try
            {
                BookDTO dto = modelfactory.Parse(model);
                if (bookmanager.Update(id,dto))
                    return Request.CreateResponse(HttpStatusCode.OK, "Updated Successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed");
            }
            catch (InvalidBookException bookEx)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, bookEx);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        
     
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                if (bookmanager.Delete(id))
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Deletion failed");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
        }

        [Route("api/books/{id}/{edition}")]
        public HttpResponseMessage Delete(string id,string edition)
        {
            try
            {
                if (bookmanager.Delete(id,edition))
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Deletion failed");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
    }
}
