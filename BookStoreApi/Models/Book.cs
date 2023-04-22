using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Models;

public class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string BookName { get; set; } = null!;

    [Required]
    [Range(0, 999)]
    public decimal Price { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Category { get; set; } = null!;

    [Required]
    public string Author { get; set; } = null!;
}