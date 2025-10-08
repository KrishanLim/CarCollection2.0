using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarCollection.Models
{
    public class CarBrand
    {
        public int CarBrandId { get; set; }
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        public int FoundedYear { get; set; }
        public ICollection<CarModel> CarModels { get; set; }
    }
}
