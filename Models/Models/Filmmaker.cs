using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class Filmmaker
    {
        public Filmmaker()
        {
            FilmmakerVideoContent = new HashSet<FilmmakerVideoContent>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTime? Birthday { get; set; }
        public string Professions { get; set; }

        public virtual ICollection<FilmmakerVideoContent> FilmmakerVideoContent { get; set; }
    }
}
