namespace StackOverflowWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int Id { get; set; }

        public string AboutMe { get; set; }

        public int? Age { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        [StringLength(40)]
        public string DisplayName { get; set; }

        public int DownVotes { get; set; }

        [StringLength(40)]
        public string EmailHash { get; set; }

        public DateTime LastAccessDate { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        public int Reputation { get; set; }

        public int UpVotes { get; set; }

        public int Views { get; set; }

        [StringLength(200)]
        public string WebsiteUrl { get; set; }

        public int? AccountId { get; set; }
    }
}
