using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class CinemaddictVideoContent
    {
        public int Id { get; set; }
        public int CinemaddictId { get; set; }
        public int VideoContentId { get; set; }
        public int Type { get; set; }
        public decimal? Rating { get; set; }
        public DateTime DtCreated { get; set; }

        public virtual Cinemaddict Cinemaddict { get; set; }
        public virtual VideoContent VideoContent { get; set; }
    }
}
