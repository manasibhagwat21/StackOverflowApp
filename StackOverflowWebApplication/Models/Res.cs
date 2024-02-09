namespace StackOverflowWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Res
    {
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public int TotalVotes { get; set; }
        public string DisplayName { get; set; }
        public int Reputation { get; set; }
    }

}
