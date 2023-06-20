using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class PresensiHarianGuruuService
{
    private readonly IMongoCollection<PresensiHarianGuruu> _PresensiHarianGuruuCollection;

    public PresensiHarianGuruuService(
        IOptions<PresensiHarianGuruuDatabaseSettings> PresensiHarianGuruuDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            PresensiHarianGuruuDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            PresensiHarianGuruuDatabaseSettings.Value.DatabaseName);

        _PresensiHarianGuruuCollection = mongoDatabase.GetCollection<PresensiHarianGuruu>(
            PresensiHarianGuruuDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<PresensiHarianGuruu>> GetAsync() =>
        await _PresensiHarianGuruuCollection.Find(_ => true).ToListAsync();

    public async Task<PresensiHarianGuruu?> GetAsync(string id) =>
        await _PresensiHarianGuruuCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(PresensiHarianGuruu newBook) =>
        await _PresensiHarianGuruuCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, PresensiHarianGuruu updatedBook) =>
        await _PresensiHarianGuruuCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _PresensiHarianGuruuCollection.DeleteOneAsync(x => x.Id == id);
}