using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class PresensiMengajarService
{
    private readonly IMongoCollection<PresensiMengajar> _PresensiMengajarCollection;

    public PresensiMengajarService(
        IOptions<PresensiMengajarDatabaseSettings> PresensiMengajarDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            PresensiMengajarDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            PresensiMengajarDatabaseSettings.Value.DatabaseName);

        _PresensiMengajarCollection = mongoDatabase.GetCollection<PresensiMengajar>(
            PresensiMengajarDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<PresensiMengajar>> GetAsync() =>
        await _PresensiMengajarCollection.Find(_ => true).ToListAsync();

    public async Task<PresensiMengajar?> GetAsync(string id) =>
        await _PresensiMengajarCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(PresensiMengajar newBook) =>
        await _PresensiMengajarCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, PresensiMengajar updatedBook) =>
        await _PresensiMengajarCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _PresensiMengajarCollection.DeleteOneAsync(x => x.Id == id);
}