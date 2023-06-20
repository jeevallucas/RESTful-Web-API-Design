using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace UAS_DRWA_2023.Models
{
    // Kelas Model
    public class Kelas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonElement("Nama")]
        public string Nama { get; set; }
    }

    // Mapel Model
    public class Mapel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonElement("Nama")]
        public string Nama { get; set; }

        [Required]
        [BsonElement("Kelas")]
        public string Kelas { get; set; }
    }

    // Guru Model
    public class Guru
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonElement("Nama")]
        public string Nama { get; set; }

        [Required]
        [BsonElement("Kelas")]
        public string Kelas { get; set; }

        [Required]
        [BsonElement("NIP")]
        public string NIP { get; set; }
    }

    // PresensiHarianGuru Model
    public class PresensiHarianGuru
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonElement("NIP")]
        public string NIP { get; set; }

        [Required]
        [BsonElement("Tgl")]
        public DateTime Tgl { get; set; }

        [Required]
        [BsonElement("Kehadiran")]
        public bool Kehadiran { get; set; }
    }

    // PresensiMengajar Model
    public class PresensiMengajar
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonElement("NIP")]
        public string NIP { get; set; }

        [Required]
        [BsonElement("Tgl")]
        public DateTime Tgl { get; set; }

        [Required]
        [BsonElement("Kehadiran")]
        public bool Kehadiran { get; set; }

        [Required]
        [BsonElement("Kelas")]
        public string Kelas { get; set; }
    }
}