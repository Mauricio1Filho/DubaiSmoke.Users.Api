using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }
        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get { return _createdAt == default ? DateTime.Now : _createdAt; }
            set { _createdAt = value; }
        }
        public DateTime? UpdatedAt { get; set; }
        public string HashCode { get; set; }        
    }
   

}

