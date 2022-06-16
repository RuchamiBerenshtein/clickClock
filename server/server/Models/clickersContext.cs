using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace server.Models
{
    public partial class clickersContext : DbContext
    {
        public clickersContext()
        {
        }

        public clickersContext(DbContextOptions<clickersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameQuestion> GameQuestions { get; set; }
        public virtual DbSet<GameUser> GameUsers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=clickers;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => e.AnsId)
                    .HasName("PK__Table__24CE1E3F36A854C2");

                entity.ToTable("answers");

                entity.Property(e => e.AnsId).HasColumnName("ans_Id");

                entity.Property(e => e.AnsContent)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("ans_content");

                entity.Property(e => e.QuestId).HasColumnName("quest_Id");

                entity.HasOne(d => d.Quest)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_question");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("games");

                entity.Property(e => e.GameId).HasColumnName("game_Id");

                entity.Property(e => e.CountQuestions).HasColumnName("count_questions");

                entity.Property(e => e.DateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("date_time");

                entity.Property(e => e.Manager).HasColumnName("manager");

                entity.HasOne(d => d.ManagerNavigation)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.Manager)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_manager");
            });

            modelBuilder.Entity<GameQuestion>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.QuestId });

                entity.ToTable("game_question");

                entity.Property(e => e.GameId).HasColumnName("game_Id");

                entity.Property(e => e.QuestId).HasColumnName("quest_Id");

                entity.Property(e => e.Index).HasColumnName("index");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameQuestions)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_game_quest");

                entity.HasOne(d => d.Quest)
                    .WithMany(p => p.GameQuestions)
                    .HasForeignKey(d => d.QuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_question_game");
            });

            modelBuilder.Entity<GameUser>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.UserId });

                entity.ToTable("game_user");

                entity.Property(e => e.GameId).HasColumnName("game_Id");

                entity.Property(e => e.UserId).HasColumnName("user_Id");

                entity.Property(e => e.CorrectAnswers).HasColumnName("correct_answers");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameUsers)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_game");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GameUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.QuestId)
                    .HasName("PK__question__9A0E7CF562A49349");

                entity.ToTable("questions");

                entity.Property(e => e.QuestId).HasColumnName("quest_Id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("content");

                entity.Property(e => e.Correctanswer)
                    .HasColumnName("correctanswer")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Timer)
                    .HasColumnName("timer")
                    .HasDefaultValueSql("((30))");

                entity.HasOne(d => d.CorrectanswerNavigation)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.Correctanswer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("[fk_correct_answer]");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_Id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
