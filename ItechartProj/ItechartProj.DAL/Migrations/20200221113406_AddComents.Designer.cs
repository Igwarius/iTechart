﻿// <auto-generated />
using System;
using ItechartProj.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ItechartProj.DAL.Migrations
{
    [DbContext(typeof(Context.Context))]
    [Migration("20200221113406_AddComents")]
    partial class AddComents
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ItechartProj.DAL.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("Viewers")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("ItechartProj.DAL.Models.Token", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Login");

                    b.ToTable("Token");
                });

            modelBuilder.Entity("ItechartProj.DAL.Models.Tag", b =>
                {
                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<int?>("NewsId")
                        .HasColumnType("int");

                    b.HasKey("TagName");

                    b.HasIndex("NewsId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("ItechartProj.DAL.Models.User", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Login");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ItechartProj.DAL.Models.Token", b =>
                {
                    b.HasOne("ItechartProj.DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Login")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ItechartProj.DAL.Models.Tag", b =>
                {
                    b.HasOne("ItechartProj.DAL.Models.News", null)
                        .WithMany("Tags")
                        .HasForeignKey("NewsId");
                });
#pragma warning restore 612, 618
        }
    }
}
