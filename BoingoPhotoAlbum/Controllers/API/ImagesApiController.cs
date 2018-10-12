using BoingoPhotoAlbum.Domain;
using BoingoPhotoAlbum.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BoingoPhotoAlbum.Controllers.API
{
    [RoutePrefix("api")]
    public class ImagesApiController : ApiController
    {
        ImageUserService imageUserService = new ImageUserService();

        [Route("{searchCondition}"), HttpGet]
        public HttpResponseMessage GetImages(string searchCondition)
        {
            try
            {
                ItemsResponse<GetImages> resp = new ItemsResponse<GetImages>();
                resp.Items = imageUserService.GetUserImages(searchCondition);
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                imageUserService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new SuccessResponse());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


    }
}