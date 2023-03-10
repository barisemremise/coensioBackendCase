﻿// <auto-generated />
using CoensioBackendCase.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoensioBackendCase.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230309220115_updateQuestion4")]
    partial class updateQuestion4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CoensioBackendCase.Entities.Choice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("CoensioBackendCase.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AnswerId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("CoensioBackendCase.Entities.QuestionChoice", b =>
                {
                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<int>("ChoiceId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("QuestionId", "ChoiceId");

                    b.HasIndex("ChoiceId");

                    b.ToTable("QuestionChoices");
                });

            modelBuilder.Entity("CoensioBackendCase.Entities.Question", b =>
                {
                    b.HasOne("CoensioBackendCase.Entities.Choice", "Answer")
                        .WithMany()
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answer");
                });

            modelBuilder.Entity("CoensioBackendCase.Entities.QuestionChoice", b =>
                {
                    b.HasOne("CoensioBackendCase.Entities.Choice", "Choice")
                        .WithMany("QuestionChoices")
                        .HasForeignKey("ChoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoensioBackendCase.Entities.Question", "Question")
                        .WithMany("QuestionChoices")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Choice");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("CoensioBackendCase.Entities.Choice", b =>
                {
                    b.Navigation("QuestionChoices");
                });

            modelBuilder.Entity("CoensioBackendCase.Entities.Question", b =>
                {
                    b.Navigation("QuestionChoices");
                });
#pragma warning restore 612, 618
        }
    }
}
