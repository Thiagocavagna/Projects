using Projects.Base.Enumerations;
using Upside.Base.Domain;

namespace Projects.API.CRUD.Domain.Entities
{
    public class Food : Entity
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public FoodType Type { get; private set; }
        public decimal Protein { get; private set; }
        public decimal Carbohydrate { get; private set; }
        public decimal Fat { get; private set; }

        public Food(string name, string description, FoodType type, decimal protein, decimal carbohydrate, decimal fat)
        {
            Name = name;
            Description = description;
            Type = type;
            Protein = protein;
            Carbohydrate = carbohydrate;
            Fat = fat;
        }
    }
}
