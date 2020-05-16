using System.Threading.Tasks;

namespace FShopV2.Base.MongoDB
{
    public interface IMongoDbSeeder
    {
        Task SeedAsync();
    }
}