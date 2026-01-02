using SemsTunez.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Domain.Entities
{
    public class Artist : BaseEntity
    {
        public string Name { get; private set; }
        public string? Bio { get; private set; }
        public string? ImageUrl { get; private set; }

        private Artist() { }

        public Artist(string name, string? bio = null, string? imageUrl = null)
        {
            Name = name;
            Bio = bio;
            ImageUrl = imageUrl;
        }
    }
}
