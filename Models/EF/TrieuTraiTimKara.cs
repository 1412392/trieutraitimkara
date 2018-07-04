namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TrieuTraiTimKara : DbContext
    {
        public TrieuTraiTimKara()
            : base("name=TrieuTraiTimKara")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<KaraReqest> KaraReqests { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Media_Account> Media_Account { get; set; }
        public virtual DbSet<Media_Singer> Media_Singer { get; set; }
        public virtual DbSet<MediaType> MediaTypes { get; set; }
        public virtual DbSet<Singer> Singers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<KaraReqest>()
                .Property(e => e.guestemail)
                .IsUnicode(false);

            modelBuilder.Entity<Media>()
                .Property(e => e.ListAccountID)
                .IsUnicode(false);

            modelBuilder.Entity<Media>()
               .Property(e => e.ListSingerID)
               .IsUnicode(false);

            modelBuilder.Entity<KaraReqest>()
               .Property(e => e.guestphone)
               .IsUnicode(false);

            modelBuilder.Entity<MediaType>()
                .HasMany(e => e.Media)
                .WithOptional(e => e.MediaType1)
                .HasForeignKey(e => e.mediatype);
        }
    }
}
