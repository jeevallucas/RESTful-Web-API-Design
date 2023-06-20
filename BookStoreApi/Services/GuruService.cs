using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class GuruService
{
    private readonly IMongoCollection<Guru> _guruCollection;

    public GuruService(
        IOptions<GuruDatabaseSettings> GuruDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            GuruDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            GuruDatabaseSettings.Value.DatabaseName);

        _guruCollection = mongoDatabase.GetCollection<Guru>(
            GuruDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<Guru>> GetAsync() =>
        await _guruCollection.Find(_ => true).ToListAsync();

    public async Task<Guru?> GetAsync(string id) =>
        await _guruCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Guru newBook) =>
        await _guruCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, Guru updatedBook) =>
        await _guruCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _guruCollection.DeleteOneAsync(x => x.Id == id);
}