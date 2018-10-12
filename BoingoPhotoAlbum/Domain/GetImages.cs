using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoingoPhotoAlbum.Domain
{
    public class GetImages
    {
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
    }
}