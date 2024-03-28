using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities.Base
{
    public class BaseEntity <T> 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; set; }
        private DateTime CreationDate { get; set; }
        private DateTime ModificationDate { get; set; }
        public bool IsActive { get; set; } = true;

        public void SetCreationDate()
        {
            CreationDate = DateTime.UtcNow;
        }

        public void SetModificationDate()
        {
            ModificationDate = DateTime.UtcNow;
        }






    }
}
