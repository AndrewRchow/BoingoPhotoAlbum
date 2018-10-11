using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BoingoPhotoAlbum.Domain;
using BoingoPhotoAlbum.Services;
using BoingoPhotoAlbum.Interfaces;
using System.Net;

namespace BoingoPhotoAlbum.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        ImageUserService imageUserService = new ImageUserService();

        public ActionResult SaveUploadedFile()
        {
            bool isSavedSuccessfully = true;
            string fName = "";

            AddUser userModel = new AddUser();
            userModel.Name = Request.Form["name"].Split(',')[0];
            userModel.Email = Request.Form["email"].Split(',')[0];

            //Insert new user, if user with same name + email already exists then return their id.
            int userId = new ImageUserService().AddUser(userModel); 


            for (int i = 0; i < Request.Files.Count; i++)
            {
                //For each image uploaded, insert into db with connected userId
                HttpPostedFileBase file = Request.Files[i];
                fName = file.FileName;

                if (file != null && file.ContentLength > 0)
                {
                    AddPhotos imagesModel = new AddPhotos();

                    MemoryStream target = new MemoryStream();
                    file.InputStream.CopyTo(target);
                    byte[] data = target.ToArray();

                    imagesModel.Image = data;
                    imagesModel.Name = fName;
                    imagesModel.Description = Request.Form["description"].Split(',')[i];
                    imagesModel.UserId = userId;

                    imageUserService.AddImages(imagesModel);
                }
            }

            if (isSavedSuccessfully)
            {
                return Json(new { Message = fName });
            }
            else
            {
                return Json(new { Message = "Error in saving file" });
            }
        }
    }
}
