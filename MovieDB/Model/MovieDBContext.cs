using MovieDB.Tables;
using System.Data.Entity;

namespace MovieDB.Model
{
    class MovieDBContext: DbContext
    {
        public MovieDBContext() : base("DbConnection"){}

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>()
                .HasMany<Movie>(a => a.Movies)
                .WithMany(m => m.Actors)
                .Map(ma =>
                {
                    ma.MapLeftKey("movie_id");
                    ma.MapRightKey("actor_id");
                    ma.ToTable("MoviesActors");
                });
            modelBuilder.Entity<Movie>()
                .HasMany<Actor>(m => m.Actors)
                .WithMany(a => a.Movies)
                .Map(ma =>
                {
                    ma.MapLeftKey("movie_id");
                    ma.MapRightKey("actor_id");
                    ma.ToTable("MoviesActors");
                });

            modelBuilder.Entity<Director>()
                .HasMany<Movie>(d => d.Movies)
                .WithMany(m => m.Directors)
                .Map(md =>
                {
                    md.MapLeftKey("movie_id");
                    md.MapRightKey("director_id");
                    md.ToTable("MoviesDirectors");
                });
            modelBuilder.Entity<Movie>()
                .HasMany<Director>(m => m.Directors)
                .WithMany(a => a.Movies)
                .Map(md =>
                {
                    md.MapLeftKey("movie_id");
                    md.MapRightKey("director_id");
                    md.ToTable("MoviesDirectors");
                });

            modelBuilder.Entity<Genre>()
                .HasMany<Movie>(g => g.Movies)
                .WithMany(m => m.Genres)
                .Map(md =>
                {
                    md.MapLeftKey("movie_id");
                    md.MapRightKey("genre_id");
                    md.ToTable("MoviesGenres");
                });
            modelBuilder.Entity<Movie>()
                .HasMany<Genre>(m => m.Genres)
                .WithMany(g => g.Movies)
                .Map(md =>
                {
                    md.MapLeftKey("movie_id");
                    md.MapRightKey("genre_id");
                    md.ToTable("MoviesGenres");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
