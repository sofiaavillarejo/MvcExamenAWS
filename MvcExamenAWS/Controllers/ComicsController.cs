using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using MvcExamenAWS.Models;
using MvcExamenAWS.Repositories;
using MvcExamenAWS.Services;

namespace MvcExamenAWS.Controllers
{
    public class ComicsController : Controller
    {
        private RepositoryComics repo;
        private ServiceStorageS3 service;

        public ComicsController(RepositoryComics repo, ServiceStorageS3 service)
        {
            this.repo = repo;
            this.service = service;
        }
        
        public async Task<IActionResult> Index()
        {
            List<Comic> comics = await this.repo.GetComicsAsync();
            return View(comics);
        }

        public IActionResult CreateComic()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComic(IFormFile file, Comic c)
        {
            using (Stream stream = file.OpenReadStream())
            {
                await this.service.UploadFileAsync(file.FileName, stream);
                c.Imagen = file.FileName;
            }
            await this.repo.CreateComicAsync(c.Nombre, c.Imagen);
            return RedirectToAction("Index");
        }
    }
}
