namespace StackOverflowWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PostLink
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public int PostId { get; set; }

        public int RelatedPostId { get; set; }

        public int LinkTypeId { get; set; }
    }
}
