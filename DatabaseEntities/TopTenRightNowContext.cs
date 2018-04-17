namespace DatabaseEntities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TopTenRightNowContext : DbContext
    {
        public TopTenRightNowContext()
            : base("name=TopTenRightNowContext")
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<UserRanking> UserRankings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(e => e.UserRankings)
                .WithRequired(e => e.Movie)
                .WillCascadeOnDelete(false);
        }
    }
}
