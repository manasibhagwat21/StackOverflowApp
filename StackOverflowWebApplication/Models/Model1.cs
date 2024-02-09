using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace StackOverflowWebApplication.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public class YourViewModel
        {
            public List<Post> Posts { get; set; }
            public List<User> User { get; set; }
        }

        public virtual DbSet<Badge> Badges { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<LinkType> LinkTypes { get; set; }
        public virtual DbSet<PostLink> PostLinks { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostType> PostTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }
        public virtual DbSet<VoteType> VoteTypes { get; set; }

        public virtual DbSet<Res> Res { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LinkType>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<VoteType>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
