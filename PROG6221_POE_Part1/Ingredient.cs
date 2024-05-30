namespace PROG6221_POE_Part1
{
    public class Ingredient
    {
        public string Name { get; }
        public double Quantity { get; set; }
        public string Unit { get; }
        public double Calories { get; }
        public FoodGroup SelectedFoodGroup { get; }

        private double originalQuantity;

        public Ingredient(string? name, double quantity, string? unit, double calories, FoodGroup selectedFoodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            SelectedFoodGroup = selectedFoodGroup;
        }

        public void Scale(double factor)
        {
            Quantity = originalQuantity * factor;
        }

        public void Reset()
        {
            Quantity = originalQuantity;
        }
    }
}
