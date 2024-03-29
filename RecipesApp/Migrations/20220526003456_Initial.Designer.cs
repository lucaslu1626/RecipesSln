﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipesApp.Models;

#nullable disable

namespace RecipesApp.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20220526003456_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RecipesApp.Models.Discussion", b =>
                {
                    b.Property<long>("DiscussionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DiscussionID"), 1L, 1);

                    b.Property<string>("DiscussionDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscussionPost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscussionRecipe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscussionUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DiscussionID");

                    b.HasIndex("DiscussionUser");

                    b.ToTable("Discussions");
                });

            modelBuilder.Entity("RecipesApp.Models.Recipe", b =>
                {
                    b.Property<long>("RecipeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RecipeID"), 1L, 1);

                    b.Property<string>("RecipeCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipeCreator")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RecipeIngredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipeInstructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RecipeRating")
                        .HasColumnType("decimal(3,1)");

                    b.HasKey("RecipeID");

                    b.HasIndex("RecipeCreator");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipesApp.Models.User", b =>
                {
                    b.Property<long>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserID"), 1L, 1);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserPW")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RecipesApp.Models.Discussion", b =>
                {
                    b.HasOne("RecipesApp.Models.User", "User")
                        .WithMany("Discussions")
                        .HasForeignKey("DiscussionUser")
                        .HasPrincipalKey("UserName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RecipesApp.Models.Recipe", b =>
                {
                    b.HasOne("RecipesApp.Models.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("RecipeCreator")
                        .HasPrincipalKey("UserName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RecipesApp.Models.User", b =>
                {
                    b.Navigation("Discussions");

                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}
