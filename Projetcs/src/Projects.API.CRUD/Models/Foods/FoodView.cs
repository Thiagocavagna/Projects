using Projects.Foods.API.Domain.Entities;
using Projects.Base.Enumerations;

namespace Projects.Foods.API.Models.Foods
{
    public class FoodView
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public FoodType Type { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrate { get; set; }
        public decimal Fat { get; set; }

        public static implicit operator FoodView(Food food)
            => new()
            {
                Id = food.Id,
                Name = food.Name,
                Description = food.Description,
                Type = food.Type,
                Protein = food.Protein,
                Carbohydrate = food.Carbohydrate,
                Fat = food.Fat
            };
    }
}
