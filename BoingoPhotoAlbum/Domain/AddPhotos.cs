using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoingoPhotoAlbum.Domain
{
    public class AddPhotos
    {
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}