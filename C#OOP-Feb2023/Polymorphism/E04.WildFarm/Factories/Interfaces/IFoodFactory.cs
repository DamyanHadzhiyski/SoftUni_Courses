using E04.WildFarm.Models.Interfaces;

namespace E04.WildFarm.Factories.Interfaces
{
    public interface IFoodFactory
    {
        IFood Create(string type, int qunatity);
    }
}
