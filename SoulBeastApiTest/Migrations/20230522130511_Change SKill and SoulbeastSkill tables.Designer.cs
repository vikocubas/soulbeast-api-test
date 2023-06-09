﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoulBeastApiTest.Data;

#nullable disable

namespace SoulBeastApiTest.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230522130511_Change SKill and SoulbeastSkill tables")]
    partial class ChangeSKillandSoulbeastSkilltables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SoulBeastApiTest.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rarity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SoulbeastId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SoulbeastId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("SoulBeastApiTest.Models.Medal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Dungeon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Medals");
                });

            modelBuilder.Entity("SoulBeastApiTest.Models.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("HomeTown")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("SoulBeastApiTest.Models.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("SoulBeastApiTest.Models.Soulbeast", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Element")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Soulbeasts");
                });

            modelBuilder.Entity("SoulBeastApiTest.Models.SoulbeastSkill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SoulbeastId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.ToTable("SoulbeastSkills");
                });

            modelBuilder.Entity("SoulBeastApiTest.Models.Item", b =>
                {
                    b.HasOne("SoulBeastApiTest.Models.Soulbeast", "Soulbeast")
                        .WithMany("Items")
                        .HasForeignKey("SoulbeastId");

                    b.Navigation("Soulbeast");
                });

            modelBuilder.Entity("SoulBeastApiTest.Models.Medal", b =>
                {
                    b.HasOne("SoulBeastApiTest.Models.Owner", "Owner")
                        .WithMany("Medals")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("SoulBeastApiTest.Models.Soulbeast", b =>
                {
                    b.HasOne("SoulBeastApiTest.Models.Owner", "Owner")
                        .WithMany("Soulbeasts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("SoulBeastApiTest.Models.SoulbeastSkill", b =>
                {
                    b.HasOne("SoulBeastApiTest.Models.Skill", "Skills")
                        .WithMany("SoulbeastSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("SoulBeastApiTest.Models.Owner", b =>
                {
                    b.Navigation("Medals");

                    b.Navigation("Soulbeasts");
                });

            modelBuilder.Entity("SoulBeastApiTest.Models.Skill", b =>
                {
                    b.Navigation("SoulbeastSkills");
                });

            modelBuilder.Entity("SoulBeastApiTest.Models.Soulbeast", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
