﻿// <auto-generated />
using ItechartProj.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ItechartProj.DAL.Migrations
{
    [DbContext(typeof(Contexts))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ItechartProj.DAL.Models.RefreshTokens", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Login");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("ItechartProj.DAL.Models.User", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Login");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ItechartProj.DAL.Models.RefreshTokens", b =>
                {
                    b.HasOne("ItechartProj.DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Login")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}