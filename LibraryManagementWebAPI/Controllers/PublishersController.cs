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
    public class PublishersController : ApiController
    {
        ModelFactory modelfactory ;
        PublisherManager publishermanager;
        public PublishersController()
        {
            modelfactory = new ModelFactory();
            publishermanager = new PublisherManager();
        }
        public IEnumerable<PublisherModel> Get()
        {
            var publishers = publishermanager.GetAll();
            var results = publishers.Select(publisher => modelfactory.Create(publisher));
            return results;
        }
        public PublisherModel Get(string id)
        {
            var publisher = publishermanager.GetByID(id);
            var result = modelfactory.Create(publisher);
            return result;
        }
        public HttpResponseMessage Post([FromBody] PublisherModel model)
        {
            try
            {
                PublisherDTO dto = modelfactory.Parse(model);
                var ID = publishermanager.Add(dto);
                if (ID != null)
                    return Request.CreateResponse(HttpStatusCode.Created, "Publisher Added Successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Adding Publisher Failed");
            }
            catch(InvalidPublisherException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpPatch]
        [HttpPut]
        public HttpResponseMessage Patch(string id,[FromBody] PublisherModel model)
        {
            try
            {
                PublisherDTO dto = modelfactory.Parse(model);
                if (publishermanager.Update(id,dto))
                    return Request.CreateResponse(HttpStatusCode.OK, "Publisher Updated Successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Updating Publisher Failed");
            }
            catch (InvalidPublisherException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
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
                if (publishermanager.DeleteByID(id))
                    return Request.CreateResponse(HttpStatusCode.OK, "Publisher Deleted Successfully");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Deleting Publisher Failed");
            }
            catch (InvalidPublisherException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
