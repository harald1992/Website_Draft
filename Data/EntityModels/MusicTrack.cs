using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityModels
{
    public class MusicTrack
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        //public byte[] Image { get; set; }

        //public byte[] AudioFile { get; set; } 

        //public IFormFile Picture { get; set; } 
        //public string FileLocation { get; set; }

    }
}
