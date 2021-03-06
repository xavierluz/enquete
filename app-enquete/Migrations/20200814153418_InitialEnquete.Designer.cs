﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using app_enquete.contexto;

namespace app_enquete.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200814153418_InitialEnquete")]
    partial class InitialEnquete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("app_enquete.Domain.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("PollId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Description")
                        .HasName("IDX_OPTION_DESCRIPTION");

                    b.HasIndex("PollId");

                    b.ToTable("Option");
                });

            modelBuilder.Entity("app_enquete.Domain.Poll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Description")
                        .HasName("IDX_POLL_DESCRIPTION");

                    b.ToTable("Poll");
                });

            modelBuilder.Entity("app_enquete.Domain.View", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PollId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PollId")
                        .IsUnique()
                        .HasName("IDX_VIEW_POLL_ID");

                    b.ToTable("View");
                });

            modelBuilder.Entity("app_enquete.Domain.Vote", b =>
                {
                    b.Property<int>("PollId")
                        .HasColumnType("int");

                    b.Property<int>("OptionId")
                        .HasColumnType("int");

                    b.HasKey("PollId", "OptionId");

                    b.HasIndex("OptionId")
                        .IsUnique();

                    b.HasIndex("PollId")
                        .IsUnique();

                    b.ToTable("Vote");
                });

            modelBuilder.Entity("app_enquete.Domain.Option", b =>
                {
                    b.HasOne("app_enquete.Domain.Poll", "Poll")
                        .WithMany("Options")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("app_enquete.Domain.View", b =>
                {
                    b.HasOne("app_enquete.Domain.Poll", "Poll")
                        .WithOne("View")
                        .HasForeignKey("app_enquete.Domain.View", "PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("app_enquete.Domain.Vote", b =>
                {
                    b.HasOne("app_enquete.Domain.Option", "Option")
                        .WithOne("Vote")
                        .HasForeignKey("app_enquete.Domain.Vote", "OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("app_enquete.Domain.Poll", "Poll")
                        .WithOne("Vote")
                        .HasForeignKey("app_enquete.Domain.Vote", "PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
