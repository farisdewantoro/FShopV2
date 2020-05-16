namespace FShopV2.Base
{
    public interface IStartupInitializer
    {
        void AddInitializer(IInitializer initializer);
    }
}