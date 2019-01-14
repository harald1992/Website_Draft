using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.EntityModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class MusicComposingController : Controller
    {
        private IMusicTrackService _MusicTracks;
        private readonly IHostingEnvironment hostingEnvironment;

        public MusicComposingController(IMusicTrackService musicTracks, IHostingEnvironment he)
        {
            _MusicTracks = musicTracks;
            hostingEnvironment = he;
        }

        public IActionResult Index()
        {
            var musicTrackList = _MusicTracks.GetAll();

            var listingResult = musicTrackList.Select(result => new MusicTrackListingModel
            {
                Id = result.Id,
                Name = result.Name,
                ImageUrl = result.ImageUrl,
                ImagePresentationSrc = "images/" + result.ImageUrl
            });

            var model = new MusicTrackList()
            {
                MusicTracks = listingResult
            };

            return View(model);
        }

        public IActionResult Create(string name, IFormFile image)
        {
            if (image != null)
            {
                // wwwRoot/images
                var imagesFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                var imageUrl = Path.Combine(imagesFolder, Path.GetFileName(image.FileName));

                image.CopyTo(new FileStream(imageUrl, FileMode.Create));
                //File moet nu in de wwwroot/images folder ziten.

                //Alleen de naam is genoeg om te laten zien, src="" is erop aangepast. 
                //Ivm security mag je niet een vol path bijv C://users/ etc bereiken vanuit frontend.
                CreateMusicTrackInDB(name, Path.GetFileName(image.FileName));
            }
            return RedirectToAction("Index");
        }

        public void CreateMusicTrackInDB(string name, string imgUrl)
        {
            MusicTrack trackToCreate = new MusicTrack
            {
                Name = name,
                ImageUrl = imgUrl
            };
            _MusicTracks.Add(trackToCreate);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            MusicTrack trackToDelete = _MusicTracks.GetById(id);
            _MusicTracks.Remove(trackToDelete);
            return RedirectToAction("Index");
        }

    }
}