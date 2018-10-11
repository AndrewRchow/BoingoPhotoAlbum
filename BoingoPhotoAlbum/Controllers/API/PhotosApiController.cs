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
    public class PhotosApiController : ApiController
    {
        ImageUserService imageUserService = new ImageUserService();

        [Route("images"), HttpGet]
        public HttpResponseMessage GetImages(Search model)
        {
            try
            {
                ItemsResponse<GetImages> resp = new ItemsResponse<GetImages>();
                resp.Items = imageUserService.GetUserImages(model);
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

   
    }
}