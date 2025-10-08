
namespace CarCollection.Models
{
    public class CarModel
    {
        public int CarModelId { get; set; }
        
        public string ModelName { get; set; }

        public string Type { get; set; }
        public decimal Price { get; set; }
      
        public int CarBrandId { get; set; }

        public CarBrand CarBrand { get; set; }
    }
}
