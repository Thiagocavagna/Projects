using Projects.Base.Enumerations;

namespace Projects.Foods.API.Models.Foods
{
    public class FoodRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public FoodType Type { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrate { get; set; }
        public decimal Fat { get; set; }
    }
}
