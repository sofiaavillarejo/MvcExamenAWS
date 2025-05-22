using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using MvcExamenAWS.Models;
using MvcExamenAWS.Repositories;

namespace MvcExamenAWS.Controllers
{
    public class ComicsController : Controller
    {
        private RepositoryComics repo;

        public ComicsController(RepositoryComics repo)
        {
            this.repo = repo;
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
        public async Task<IActionResult> CreateComic(Comic c)
        {
            await this.repo.CreateComicAsync(c.Nombre, c.Imagen);
            return RedirectToAction("Index");
        }
    }
}
