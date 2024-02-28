using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWebModel.Entity
{
    public class Video
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Thumb { get; set; }
        public string? Cateroty { get; set; }
        public bool? Sub { get; set; }
        public string? LinkVideo { get; set; }
        public string? Description { get; set; }
        public long? View { get; set; }
        public long? Like { get; set; }
        public virtual ICollection<Actor>? Actors { get; set; }
    }
}
