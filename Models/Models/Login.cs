using System;
using System.Collections.Generic;

namespace Models.Models
{
    public partial class Login
    {
        public int Id { get; set; }
        public string AccountKey { get; set; }
        public string AccountSecret { get; set; }
        public string ConfirmationCode { get; set; }
        public int CinemaddictId { get; set; }
        public DateTime DtCreated { get; set; }

        public virtual Cinemaddict Cinemaddict { get; set; }
    }
}
