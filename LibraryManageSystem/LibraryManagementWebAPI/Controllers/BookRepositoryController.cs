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
    public class BookRepositoryController : ApiController
    {
        ModelFactory modelfactory;
        BookRepositoryManager bookrepomanager ;
        public BookRepositoryController()
        {
            modelfactory = new ModelFactory();
            bookrepomanager = new BookRepositoryManager();
        }
        public IEnumerable<BookRepositoryModel> Get(string id)

        {
            var bookrepos = bookrepomanager.Get(id);
            var results = bookrepos.Select(repo => modelfactory.Create(repo));
            return results;
        }
        [Route("api/bookrepository/{id},{edition}")]
        public BookRepositoryModel Get(string id,string edition)
        {
            var bookrepo = bookrepomanager.Get(id, edition);
            var result = modelfactory.Create(bookrepo);
            return result;
        }
        public HttpResponseMessage Post(string id,[FromBody]BookRepositoryModel model)
        {
            try
            {
                BookRepositoryDTO dto = modelfactory.Parse(model);
                BookRepository record = bookrepomanager.Add(id,dto);
                if (record == null)
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "ADDING BOOK REPOSITORY FAILED");
                else
                    return Request.CreateResponse(HttpStatusCode.Created, "BOOK REPOSITORY ADDED SUCCESSFULLY");
            }
            catch(InvalidBookException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpPut]
        [HttpPatch]
        [Route("api/bookrepository/{id},{edition}")]
        public HttpResponseMessage Patch(string id,string edition,[FromBody] BookRepositoryModel model)
        {
            try
            {
                BookRepositoryDTO dto = modelfactory.Parse(model);
                if (bookrepomanager.Update(id,edition,dto))
                    return Request.CreateResponse(HttpStatusCode.OK, "BOOK RECORD UPDATED SUCCESSFULLY");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "UPDATION FAILED");
            }
            catch(InvalidBookException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [Route("api/bookrepository/{id},{edition}")]
        public HttpResponseMessage Delete(string id, string edition)
        {
            try
            {
                if (bookrepomanager.Delete(id, edition))
                    return Request.CreateResponse(HttpStatusCode.OK, "BOOK RECORD DELETED SUCCESSFULLY");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "BOOK RECORD DELETION FAILED");
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
