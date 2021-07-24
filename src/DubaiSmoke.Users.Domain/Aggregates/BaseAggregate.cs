using MongoDB.Bson;
using System;

namespace DubaiSmoke.Users.Domain.Aggregates
{
    public abstract class BaseAggregate
    {
        public ObjectId _id { get; set; }
        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get { return _createdAt == default ? DateTime.Now : _createdAt; }
            set { _createdAt = value; }
        }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string HashCode { get; set; }
    }
}
