using System.Collections.Generic;

namespace DubaiSmoke.Users.CrossCutting.DTO
{
    public class BadRequestResponse
    {
        public List<ValidationError> _errors { get; set; } = new List<ValidationError>();
    }
    public class ValidationError
    {
        public string field { get; set; }
        public List<string> messages { get; set; } = new List<string>();
    }
}
