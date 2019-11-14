using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class Connection
    {
        public int Id { get; set; }
        public int MyId { get; set; }
        public int MyFriendId { get; set; }
        public bool Notify { get; set; }
        public DateTime DtCreated { get; set; }

        public virtual Cinemaddict My { get; set; }
        public virtual Cinemaddict MyFriend { get; set; }
    }
}
