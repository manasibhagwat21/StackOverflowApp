namespace StackOverflowWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vote
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public int? UserId { get; set; }

        public int? BountyAmount { get; set; }

        public int VoteTypeId { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
