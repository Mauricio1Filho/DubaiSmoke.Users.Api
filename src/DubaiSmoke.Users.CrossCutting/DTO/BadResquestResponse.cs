using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.CrossCutting.DTO
{
    [ExcludeFromCodeCoverage]
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
