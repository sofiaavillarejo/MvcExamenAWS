using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using MvcExamenAWS.Data;
using MvcExamenAWS.Models;

namespace MvcExamenAWS.Repositories
{
    public class RepositoryComics
    {
        private ComicsContext context;

        public RepositoryComics(ComicsContext context)
        {
            this.context = context;
        }

        public async Task<List<Comic>> GetComicsAsync()
        {
            return await this.context.Comics.ToListAsync();
        }

        public async Task CreateComicAsync(string nombre, string imagen)
        {
            Comic c = new Comic
            {
                IdComic = await this.context.Comics.MaxAsync(c => c.IdComic) + 1,
                Nombre = nombre,
                Imagen = imagen
            };
            await this.context.Comics.AddAsync(c);
            await this.context.SaveChangesAsync();
        }
    }
}
