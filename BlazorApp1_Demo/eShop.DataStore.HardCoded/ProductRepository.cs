using eShop.CoreBusiness.models;
using eShop.UseCases.PluginInterfaces.DataStore;

namespace eShop.DataStore.HardCoded
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products;
        public ProductRepository() 
        {
               products = new List<Product>()
              {
                new Product { Id = 495, Brand = "maybelline", Name = "Maybelline Face Studio Master Hi-Light Light Booster Bronzer", Price = 14.99, ImageLink = "https://images.unsplash.com/photo-1522337360788-8b13dee7a37e?w=500" },
                new Product { Id = 488, Brand = "maybelline", Name = "Maybelline Fit Me Bronzer", Price = 10.29, ImageLink = "https://images.unsplash.com/photo-1512496015851-a90fb38ba796?w=500" },
                new Product { Id = 477, Brand = "maybelline", Name = "Maybelline Facestudio Master Contour Kit", Price = 15.99, ImageLink = "https://images.unsplash.com/photo-1522337360788-8b13dee7a37e?w=500" },
                new Product { Id = 468, Brand = "maybelline", Name = "Maybelline Face Studio Master Hi-Light Light Booster Blush", Price = 14.99, ImageLink = "https://images.unsplash.com/photo-1512496015851-a90fb38ba796?w=500" },
                new Product { Id = 439, Brand = "maybelline", Name = "Maybelline Fit Me Blush", Price = 10.29, ImageLink = "https://images.unsplash.com/photo-1522337360788-8b13dee7a37e?w=500" },
                new Product { Id = 414, Brand = "maybelline", Name = "Maybelline Dream Bouncy Blush", Price = 11.99, ImageLink = "https://images.unsplash.com/photo-1512496015851-a90fb38ba796?w=500" },
                new Product { Id = 380, Brand = "maybelline", Name = "Maybelline Fit Me Shine-Free Foundation Stick", Price = 10.99, ImageLink = "https://images.unsplash.com/photo-1522337360788-8b13dee7a37e?w=500" },
                new Product { Id = 379, Brand = "maybelline", Name = "Maybelline Dream Matte Mousse Foundation", Price = 14.79, ImageLink = "https://images.unsplash.com/photo-1512496015851-a90fb38ba796?w=500" },
                new Product { Id = 366, Brand = "maybelline", Name = "Maybelline Mineral Power Natural Perfecting Powder Foundation", Price = 14.99, ImageLink = "https://images.unsplash.com/photo-1522337360788-8b13dee7a37e?w=500" },
                new Product { Id = 354, Brand = "maybelline", Name = "Maybelline Dream Velvet Foundation", Price = 18.49, ImageLink = "https://images.unsplash.com/photo-1512496015851-a90fb38ba796?w=500" },
                new Product { Id = 353, Brand = "maybelline", Name = "Maybelline Superstay Better Skin Foundation", Price = 14.99, ImageLink = "https://images.unsplash.com/photo-1522337360788-8b13dee7a37e?w=500" },
                new Product { Id = 339, Brand = "maybelline", Name = "Maybelline Dream Wonder Liquid Touch Foundation", Price = 14.99, ImageLink = "https://images.unsplash.com/photo-1512496015851-a90fb38ba796?w=500" },
                new Product { Id = 321, Brand = "maybelline", Name = "Maybelline Dream Liquid Mousse", Price = 14.79, ImageLink = "https://images.unsplash.com/photo-1522337360788-8b13dee7a37e?w=500" },
                new Product { Id = 320, Brand = "maybelline", Name = "Maybelline FIT ME! Matte + Poreless Foundation", Price = 10.99, ImageLink = "https://images.unsplash.com/photo-1512496015851-a90fb38ba796?w=500" },
                new Product { Id = 317, Brand = "maybelline", Name = "Maybelline Fit Me Foundation with SPF", Price = 10.99, ImageLink = "https://images.unsplash.com/photo-1522337360788-8b13dee7a37e?w=500" },
                new Product { Id = 309, Brand = "maybelline", Name = "Maybelline Expert Wear Eye Shadow Quad", Price = 8.99, ImageLink = "https://images.unsplash.com/photo-1512496015851-a90fb38ba796?w=500" },
                new Product { Id = 307, Brand = "maybelline", Name = "Maybelline Eyestudio Color Tattoo Concentrated Crayon", Price = 10.99, ImageLink = "https://images.unsplash.com/photo-1522337360788-8b13dee7a37e?w=500" },
                new Product { Id = 295, Brand = "maybelline", Name = "Maybelline The Nudes Eye Shadow Palette", Price = 17.99, ImageLink = "https://images.unsplash.com/photo-1512496015851-a90fb38ba796?w=500" },
                new Product { Id = 291, Brand = "maybelline", Name = "Maybelline Eye Studio Color Tattoo 24HR Cream Gel Shadow Leather", Price = 8.99, ImageLink = "https://images.unsplash.com/photo-1522337360788-8b13dee7a37e?w=500" },
                new Product { Id = 286, Brand = "maybelline", Name = "Maybelline The Nudes Eyeshadow Palette in The Blushed Nudes", Price = 17.99, ImageLink = "https://images.unsplash.com/photo-1512496015851-a90fb38ba796?w=500" }
              };
        }

        public Product GetProduct(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> GetProducts(string filter = null)
        {
            if (string.IsNullOrWhiteSpace(filter)) return products;
            return products.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
        }
    }
}
