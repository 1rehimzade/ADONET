using Pronia.Models;

namespace Pronia.ViewModels
{
    internal class DetailVM
    {
        public Product Product { get; set; }
        public List<Product> RelatedProducts { get; set; }
    }
}