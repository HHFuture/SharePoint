using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Human.SP.WebAPI.Controllers
{
    public class ChildController : ApiController
    {
 
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/AddChild/")]
        public HttpResponseMessage AddChild(Models.ChildModel childModel)
        {
             childModel = Repository.ChildRepository.AddChild(childModel);
            HttpRequestMessage msg = new HttpRequestMessage();

            return Request.CreateResponse(HttpStatusCode.OK, childModel);

        }

     
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/GetChildByID/{childID}")]
        public HttpResponseMessage GetChildByID(int childID)
        {
            //retrive Student data from NSIS
            List<Models.Child> _children = Repository.ChildRepository.GetChildByID(childID);
            HttpRequestMessage msg = new HttpRequestMessage();

            return Request.CreateResponse(HttpStatusCode.OK, _children);

        }


      
    }
}
