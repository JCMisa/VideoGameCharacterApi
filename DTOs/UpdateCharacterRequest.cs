using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameCharacterApi.DTOs
{
    public class UpdateCharacterRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Game { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}