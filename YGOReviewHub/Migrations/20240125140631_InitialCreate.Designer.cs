﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YGOReviewHub.Data;

#nullable disable

namespace YGOReviewHub.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240125140631_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("YGOReviewHub.Models.Deck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DeckType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("YGOReviewHub.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeckId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeckId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("YGOReviewHub.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("ReviewerId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("yugiohCardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReviewerId");

                    b.HasIndex("yugiohCardId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("YGOReviewHub.Models.Reviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reviewers");
                });

            modelBuilder.Entity("YGOReviewHub.Models.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("YGOReviewHub.Models.YugiohCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("YugiohCards");
                });

            modelBuilder.Entity("YGOReviewHub.Models.YugiohCardOwner", b =>
                {
                    b.Property<int>("YugiohCardId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("YugiohCardId", "OwnerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("YugiohCardOwners");
                });

            modelBuilder.Entity("YGOReviewHub.Models.YugiohCardType", b =>
                {
                    b.Property<int>("YugiohCardId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("YugiohCardId", "TypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("YugiohCardTypes");
                });

            modelBuilder.Entity("YGOReviewHub.Models.Owner", b =>
                {
                    b.HasOne("YGOReviewHub.Models.Deck", "Deck")
                        .WithMany("Owners")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deck");
                });

            modelBuilder.Entity("YGOReviewHub.Models.Review", b =>
                {
                    b.HasOne("YGOReviewHub.Models.Reviewer", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YGOReviewHub.Models.YugiohCard", "yugiohCard")
                        .WithMany("Reviews")
                        .HasForeignKey("yugiohCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reviewer");

                    b.Navigation("yugiohCard");
                });

            modelBuilder.Entity("YGOReviewHub.Models.YugiohCardOwner", b =>
                {
                    b.HasOne("YGOReviewHub.Models.Owner", "Owner")
                        .WithMany("YugiohCardOwners")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YGOReviewHub.Models.YugiohCard", "YugiohCard")
                        .WithMany("YugiohCardOwners")
                        .HasForeignKey("YugiohCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("YugiohCard");
                });

            modelBuilder.Entity("YGOReviewHub.Models.YugiohCardType", b =>
                {
                    b.HasOne("YGOReviewHub.Models.Type", "Type")
                        .WithMany("YugiohCardTypes")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YGOReviewHub.Models.YugiohCard", "YugiohCard")
                        .WithMany("YugiohCardTypes")
                        .HasForeignKey("YugiohCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");

                    b.Navigation("YugiohCard");
                });

            modelBuilder.Entity("YGOReviewHub.Models.Deck", b =>
                {
                    b.Navigation("Owners");
                });

            modelBuilder.Entity("YGOReviewHub.Models.Owner", b =>
                {
                    b.Navigation("YugiohCardOwners");
                });

            modelBuilder.Entity("YGOReviewHub.Models.Reviewer", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("YGOReviewHub.Models.Type", b =>
                {
                    b.Navigation("YugiohCardTypes");
                });

            modelBuilder.Entity("YGOReviewHub.Models.YugiohCard", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("YugiohCardOwners");

                    b.Navigation("YugiohCardTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
