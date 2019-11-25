using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class VideoContent
    {
        public VideoContent()
        {
            CinemaddictVideoContent = new HashSet<CinemaddictVideoContent>();
            Comment = new HashSet<Comment>();
            FilmmakerVideoContent = new HashSet<FilmmakerVideoContent>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public string Description { get; set; }
        public decimal? Rating { get; set; }
        public string Images { get; set; }
        public DateTime DtCreated { get; set; }

        public virtual ICollection<CinemaddictVideoContent> CinemaddictVideoContent { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<FilmmakerVideoContent> FilmmakerVideoContent { get; set; }
    }
}
