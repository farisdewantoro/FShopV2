using FShopV2.Base.MongoDB;
using FShopV2.Base.Types;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FShopV2.Base.Test.Fixture
{
    public abstract class MongoDbFixtureBase<TDocument> : IDisposable where TDocument : IIdentifiable
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<TDocument> _collection;
        public readonly IMongoRepository<TDocument> Repository;
        protected abstract string CollectionName { get; set; }
        protected abstract string ConnectionString { get; set; }
        protected abstract string DatabaseName { get; set; }
        bool _disposed = false;
        public MongoDbFixtureBase()
        {
            _client = new MongoClient(ConnectionString);
            _database = _client.GetDatabase(DatabaseName);
            _collection = _database.GetCollection<TDocument>(CollectionName);
            Repository = new MongoRepository<TDocument>(_database, CollectionName);
        }
        public void InitializeMongo()
            => new MongoDbInitializer(_database, null, new MongoDbOptions()).InitializeAsync().GetAwaiter().GetResult();
        

        public async Task GetMongoEntity(Guid expectedId, TaskCompletionSource<TDocument> receivedTask)
        {
            if (expectedId == null)
            {
                throw new ArgumentNullException(nameof(expectedId));
            }

            var entity = await _collection.Find(d => d.Id == expectedId).SingleOrDefaultAsync();

            if (entity == null)
            {
                receivedTask.TrySetCanceled();
                return;
            }

            receivedTask.TrySetResult(entity);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _client.DropDatabase(DatabaseName);
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}