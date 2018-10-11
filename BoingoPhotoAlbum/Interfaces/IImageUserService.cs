using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BoingoPhotoAlbum.Domain;

namespace BoingoPhotoAlbum.Interfaces
{
    public interface IImageUserService
    {
        int AddUser(AddUser model);
        void AddImages(AddPhotos model);
        List<GetImages> GetUserImages(Search searchModel);
    }
}