using System;
using Microsoft.EntityFrameworkCore;
using CoensioBackendCase.Entities;
using Microsoft.Extensions.Hosting;

namespace CoensioBackendCase.Context
{
	public class DataContext: DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		public DbSet<Question> Questions { get; set; }

		public DbSet<Choice> Choices { get; set; }

        public DbSet<QuestionChoice> QuestionChoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionChoice>()
                .HasKey(qc => new { qc.QuestionId, qc.ChoiceId });

            modelBuilder.Entity<QuestionChoice>()
                .HasOne(qc => qc.Question)
                .WithMany(q => q.QuestionChoices)
                .HasForeignKey(qc => qc.QuestionId);

            modelBuilder.Entity<QuestionChoice>()
                .HasOne(qc => qc.Choice)
                .WithMany(c => c.QuestionChoices)
                .HasForeignKey(qc => qc.ChoiceId);

            modelBuilder.Entity<QuestionChoice>()
                .Ignore(e => e.Question);

            modelBuilder.Entity<Choice>()
                .Ignore(e => e.QuestionChoices);
        }
    }
}

