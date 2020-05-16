namespace FShopV2.Base
{
    public interface IStartupInitializer:IInitializer
    {
        void AddInitializer(IInitializer initializer);
    }
}