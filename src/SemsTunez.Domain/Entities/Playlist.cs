using SemsTunez.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemsTunez.Domain.Entities
{
    public class Playlist : BaseEntity
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public bool IsPublic { get; private set; }

        private Playlist() { }

        public Playlist(Guid userId, string name, bool isPublic)
        {
            UserId = userId;
            Name = name;
            IsPublic = isPublic;
        }
    }
}
