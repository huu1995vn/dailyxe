using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
 
namespace WebCore.API.Models
{
    public class Product
    {
        public ObjectId Id { get; set; }
        [BsonElement("ProductId")]
        public int ProductId { get; set; }
        [BsonElement("ProductName")]
        public string ProductName { get; set; }
        [BsonElement("Price")]
        public int Price { get; set; }
       
      
    }
}