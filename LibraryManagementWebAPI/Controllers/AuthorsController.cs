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
    public class AuthorsController : ApiController
    {
        public AuthorManager authormanager;
        public ModelFactory modelfactory;
        public AuthorsController()
        {
            authormanager = new AuthorManager();
            modelfactory = new ModelFactory();        }
        public IEnumerable<AuthorModel> Get()
        {
            var authors = authormanager.GetAll();
            var results = authors.Select(author => modelfactory.Create(author));
            return results;

        }
        public HttpResponseMessage Get(string id)
        {
            var author = authormanager.GetByID(id);
            var result = modelfactory.Create(author);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        public HttpResponseMessage Post([FromBody] AuthorModel model)
        {
            try
            {
                AuthorDTO dto = modelfactory.Parse(model);
                var authorID = authormanager.Add(dto);
                if (authorID != null)
                    return Request.CreateResponse(HttpStatusCode.OK, "Author Added Successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Adding Author Failed");
            }
            catch(InvalidAuthorException ex)
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
        public HttpResponseMessage Patch(string id, AuthorModel model)
        {
            try
            {
                AuthorDTO dto = modelfactory.Parse(model);
                if (authormanager.Update(dto))
                    return Request.CreateResponse(HttpStatusCode.OK, "Updated Successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Update Failed");
            }
            catch (InvalidAuthorException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                if (authormanager.DeleteByID(id))
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Deletion Failed");
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
