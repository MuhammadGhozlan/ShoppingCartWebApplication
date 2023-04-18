namespace ShoppingCartWebApplicationUI.Repositories
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Product>> GetProducts(string sTerm = "", int genreId = 0);
    }
}