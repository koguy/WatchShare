using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class Cinemaddict
    {
        public Cinemaddict()
        {
            CinemaddictVideoContent = new HashSet<CinemaddictVideoContent>();
            Comment = new HashSet<Comment>();
            ConnectionMy = new HashSet<Connection>();
            ConnectionMyFriend = new HashSet<Connection>();
            Login = new HashSet<Login>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime DtCreated { get; set; }

        public virtual ICollection<CinemaddictVideoContent> CinemaddictVideoContent { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Connection> ConnectionMy { get; set; }
        public virtual ICollection<Connection> ConnectionMyFriend { get; set; }
        public virtual ICollection<Login> Login { get; set; }
    }
}
