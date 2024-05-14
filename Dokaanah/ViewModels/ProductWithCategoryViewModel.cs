using Dokaanah.Models;
using System.ComponentModel.DataAnnotations;

namespace Dokaanah.ViewModels
{
    public class ProductWithCategoryViewModel
    {
        // Product Data
        
        public List<Category> categories { get; set; }
        //public List<Category> categories { get; set; }
        
    }
}
