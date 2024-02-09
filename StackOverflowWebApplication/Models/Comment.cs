namespace StackOverflowWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public int PostId { get; set; }

        public int? Score { get; set; }

        [Required]
        [StringLength(700)]
        public string Text { get; set; }

        public int? UserId { get; set; }
    }
}
