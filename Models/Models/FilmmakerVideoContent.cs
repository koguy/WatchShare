using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class FilmmakerVideoContent
    {
        public int Id { get; set; }
        public int FilmmakerId { get; set; }
        public int VideoContentId { get; set; }

        public virtual Filmmaker Filmmaker { get; set; }
        public virtual VideoContent VideoContent { get; set; }
    }
}
