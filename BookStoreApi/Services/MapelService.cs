using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class MapelService
{
    private readonly IMongoCollection<Mapel> _MapelCollection;

    public MapelService(
        IOptions<MapelDatabaseSettings> MapelDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            MapelDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            MapelDatabaseSettings.Value.DatabaseName);

        _MapelCollection = mongoDatabase.GetCollection<Mapel>(
            MapelDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<Mapel>> GetAsync() =>
        await _MapelCollection.Find(_ => true).ToListAsync();

    public async Task<Mapel?> GetAsync(string id) =>
        await _MapelCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Mapel newBook) =>
        await _MapelCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, Mapel updatedBook) =>
        await _MapelCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _MapelCollection.DeleteOneAsync(x => x.Id == id);
}