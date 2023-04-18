
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace ShoppingCartWebApplicationUI.Repositories
{
    public class HomeRepository:IHomeRepository
    {
        private readonly ApplicationDbContext _db;
        public HomeRepository(ApplicationDbContext _db)
        {
            this._db = _db;
        }
        public async Task<IEnumerable<Product>> GetProducts(string sTerm="", int genreId=0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Product> products = await (from product in _db.Products
                         join genre in _db.Genres
                         on product.GenreId equals genre.Id
                         where string.IsNullOrWhiteSpace(sTerm) ||(product!=null && product.ProductName.ToLower().StartsWith(sTerm))
                         select new Product
                         {
                             Id = product.Id,
                             Image = product.Image,
                             VendorName = product.VendorName,
                             ProductName = product.ProductName,
                             GenreId = product.GenreId,
                             Price = product.Price,
                             GenreName = genre.GenreName
                         }
                       ).ToListAsync();
            if(genreId>0)
            {
                products = products.Where(a=>a.GenreId==genreId).ToList();
            }

            return products;
        }
    }
}
