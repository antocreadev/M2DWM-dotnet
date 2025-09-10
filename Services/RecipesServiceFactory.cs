using ServicesContracts;

namespace Services
{
    public static class RecipesServiceFactory
    {
        public static IAbstractRecipesService CreateRecipesService()
        {
            return new ObjectRecipesService();
        }
    }
}
