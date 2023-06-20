using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class KelassService
{
    private readonly IMongoCollection<Kelass> _KelassCollection;

    public KelassService(
        IOptions<KelassDatabaseSettings> KelassDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            KelassDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            KelassDatabaseSettings.Value.DatabaseName);

        _KelassCollection = mongoDatabase.GetCollection<Kelass>(
            KelassDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<Kelass>> GetAsync() =>
        await _KelassCollection.Find(_ => true).ToListAsync();

    public async Task<Kelass?> GetAsync(string id) =>
        await _KelassCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Kelass newBook) =>
        await _KelassCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, Kelass updatedBook) =>
        await _KelassCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _KelassCollection.DeleteOneAsync(x => x.Id == id);
}