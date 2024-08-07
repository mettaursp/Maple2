﻿// <auto-generated />
using System;
using Maple2.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Maple2.Server.World.Migrations {
    [DbContext(typeof(Ms2Context))]
    [Migration("20221027102305_InitialCreate")]
    partial class InitialCreate {
        protected override void BuildTargetModel(ModelBuilder modelBuilder) {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Maple2.Database.Model.Account", b => {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");

                b.Property<DateTime>("CreationTime")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime(6)");

                b.Property<string>("Currency")
                    .IsRequired()
                    .HasColumnType("json");

                b.Property<DateTime>("LastModified")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnType("datetime(6)");

                b.Property<Guid>("MachineId")
                    .HasColumnType("binary(16)");

                b.Property<int>("MaxCharacters")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasDefaultValue(4);

                b.Property<long>("PremiumTime")
                    .HasColumnType("bigint");

                b.Property<long>("PrestigeExp")
                    .HasColumnType("bigint");

                b.Property<int>("PrestigeLevel")
                    .HasColumnType("int");

                b.Property<string>("Trophy")
                    .IsRequired()
                    .HasColumnType("json");

                b.Property<string>("Username")
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                b.HasKey("Id");

                b.HasIndex("Username")
                    .IsUnique();

                b.ToTable("account");
            });

            modelBuilder.Entity("Maple2.Database.Model.Buddy", b => {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");

                b.Property<long>("BuddyId")
                    .HasColumnType("bigint");

                b.Property<DateTime>("LastModified")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnType("datetime(6)");

                b.Property<string>("Message")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<long>("OwnerId")
                    .HasColumnType("bigint");

                b.Property<byte>("Type")
                    .HasColumnType("tinyint unsigned");

                b.HasKey("Id");

                b.HasIndex("BuddyId");

                b.HasIndex("OwnerId");

                b.ToTable("buddy");
            });

            modelBuilder.Entity("Maple2.Database.Model.Character", b => {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");

                b.Property<long>("AccountId")
                    .HasColumnType("bigint");

                b.Property<string>("Cooldown")
                    .IsRequired()
                    .HasColumnType("json");

                b.Property<DateTime>("CreationTime")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime(6)");

                b.Property<string>("Currency")
                    .IsRequired()
                    .HasColumnType("json");

                b.Property<DateTime>("DeleteTime")
                    .HasColumnType("datetime(6)");

                b.Property<string>("Experience")
                    .IsRequired()
                    .HasColumnType("json");

                b.Property<byte>("Gender")
                    .HasColumnType("tinyint unsigned");

                b.Property<int>("Job")
                    .HasColumnType("int");

                b.Property<DateTime>("LastModified")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnType("datetime(6)");

                b.Property<short>("Level")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("smallint")
                    .HasDefaultValue((short) 1);

                b.Property<int>("MapId")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                b.Property<string>("Profile")
                    .IsRequired()
                    .HasColumnType("json");

                b.Property<string>("SkinColor")
                    .IsRequired()
                    .HasColumnType("json");

                b.HasKey("Id");

                b.HasIndex("AccountId");

                b.HasIndex("Name")
                    .IsUnique();

                b.ToTable("character");
            });

            modelBuilder.Entity("Maple2.Database.Model.CharacterConfig", b => {
                b.Property<long>("CharacterId")
                    .HasColumnType("bigint");

                b.Property<string>("HotBars")
                    .HasColumnType("json");

                b.Property<string>("KeyBinds")
                    .HasColumnType("json");

                b.Property<DateTime>("LastModified")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnType("datetime(6)");

                b.Property<string>("SkillMacros")
                    .HasColumnType("json");

                b.Property<string>("StatAllocation")
                    .HasColumnType("json");

                b.Property<string>("Wardrobes")
                    .HasColumnType("json");

                b.HasKey("CharacterId");

                b.ToTable("character-config", (string) null);
            });

            modelBuilder.Entity("Maple2.Database.Model.CharacterUnlock", b => {
                b.Property<long>("CharacterId")
                    .HasColumnType("bigint");

                b.Property<string>("Emotes")
                    .IsRequired()
                    .HasColumnType("json");

                b.Property<string>("Expand")
                    .IsRequired()
                    .HasColumnType("json");

                b.Property<DateTime>("LastModified")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnType("datetime(6)");

                b.Property<string>("Maps")
                    .IsRequired()
                    .HasColumnType("json");

                b.Property<string>("Stamps")
                    .IsRequired()
                    .HasColumnType("json");

                b.Property<string>("Taxis")
                    .IsRequired()
                    .HasColumnType("json");

                b.Property<string>("Titles")
                    .IsRequired()
                    .HasColumnType("json");

                b.HasKey("CharacterId");

                b.ToTable("character-unlock", (string) null);
            });

            modelBuilder.Entity("Maple2.Database.Model.Club", b => {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");

                b.Property<DateTime>("CreationTime")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime(6)");

                b.Property<DateTime>("LastModified")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnType("datetime(6)");

                b.Property<long>("LeaderId")
                    .HasColumnType("bigint");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                b.HasKey("Id");

                b.HasIndex("LeaderId");

                b.HasIndex("Name")
                    .IsUnique();

                b.ToTable("club");
            });

            modelBuilder.Entity("Maple2.Database.Model.ClubMember", b => {
                b.Property<long>("ClubId")
                    .HasColumnType("bigint");

                b.Property<long>("CharacterId")
                    .HasColumnType("bigint");

                b.Property<DateTime>("CreationTime")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime(6)");

                b.HasKey("ClubId", "CharacterId");

                b.HasIndex("CharacterId");

                b.ToTable("club-member", (string) null);
            });

            modelBuilder.Entity("Maple2.Database.Model.Home", b => {
                b.Property<long>("AccountId")
                    .HasColumnType("bigint");

                b.Property<int>("ArchitectScore")
                    .HasColumnType("int");

                b.Property<byte>("Area")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValue((byte) 4);

                b.Property<byte>("Background")
                    .HasColumnType("tinyint unsigned");

                b.Property<byte>("Camera")
                    .HasColumnType("tinyint unsigned");

                b.Property<int>("CurrentArchitectScore")
                    .HasColumnType("int");

                b.Property<byte>("Height")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("tinyint unsigned")
                    .HasDefaultValue((byte) 3);

                b.Property<DateTime>("LastModified")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnType("datetime(6)");

                b.Property<byte>("Lighting")
                    .HasColumnType("tinyint unsigned");

                b.Property<string>("Message")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<string>("Passcode")
                    .HasColumnType("longtext");

                b.Property<string>("Permissions")
                    .IsRequired()
                    .HasColumnType("json");

                b.HasKey("AccountId");

                b.ToTable("home");
            });

            modelBuilder.Entity("Maple2.Database.Model.Item", b => {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");

                b.Property<int>("Amount")
                    .HasColumnType("int");

                b.Property<string>("Appearance")
                    .IsRequired()
                    .HasColumnType("json");

                b.Property<string>("Binding")
                    .HasColumnType("json");

                b.Property<string>("CoupleInfo")
                    .HasColumnType("json");

                b.Property<DateTime>("CreationTime")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime(6)");

                b.Property<string>("Enchant")
                    .HasColumnType("json");

                b.Property<DateTime>("ExpiryTime")
                    .HasColumnType("datetime(6)");

                b.Property<short>("GlamorForges")
                    .HasColumnType("smallint");

                b.Property<byte>("Group")
                    .HasColumnType("tinyint unsigned");

                b.Property<bool>("IsLocked")
                    .HasColumnType("tinyint(1)");

                b.Property<int>("ItemId")
                    .HasColumnType("int");

                b.Property<DateTime>("LastModified")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnType("datetime(6)");

                b.Property<string>("LimitBreak")
                    .HasColumnType("json");

                b.Property<long>("OwnerId")
                    .HasColumnType("bigint");

                b.Property<int>("Rarity")
                    .HasColumnType("int");

                b.Property<int>("RemainUses")
                    .HasColumnType("int");

                b.Property<short>("Slot")
                    .HasColumnType("smallint");

                b.Property<string>("Socket")
                    .HasColumnType("json");

                b.Property<string>("Stats")
                    .HasColumnType("json");

                b.Property<string>("SubType")
                    .HasColumnType("json");

                b.Property<int>("TimeChangedOption")
                    .HasColumnType("int");

                b.Property<string>("Transfer")
                    .HasColumnType("json");

                b.Property<long>("UnlockTime")
                    .HasColumnType("bigint");

                b.HasKey("Id");

                b.ToTable("item");
            });

            modelBuilder.Entity("Maple2.Database.Model.ItemStorage", b => {
                b.Property<long>("AccountId")
                    .HasColumnType("bigint");

                b.Property<short>("Expand")
                    .HasColumnType("smallint");

                b.Property<long>("Meso")
                    .HasColumnType("bigint");

                b.HasKey("AccountId");

                b.ToTable("item-storage", (string) null);
            });

            modelBuilder.Entity("Maple2.Database.Model.SkillTab", b => {
                b.Property<long>("CharacterId")
                    .HasColumnType("bigint");

                b.Property<long>("Id")
                    .HasColumnType("bigint");

                b.Property<DateTime>("CreationTime")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("datetime(6)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<string>("Skills")
                    .IsRequired()
                    .HasColumnType("json");

                b.HasKey("CharacterId", "Id");

                b.HasIndex("CharacterId");

                b.ToTable("skill-tab", (string) null);
            });

            modelBuilder.Entity("Maple2.Database.Model.UgcMap", b => {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");

                b.Property<int>("ApartmentNumber")
                    .HasColumnType("int");

                b.Property<DateTime>("ExpiryTime")
                    .HasColumnType("datetime(6)");

                b.Property<bool>("Indoor")
                    .HasColumnType("tinyint(1)");

                b.Property<DateTime>("LastModified")
                    .IsConcurrencyToken()
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnType("datetime(6)");

                b.Property<int>("MapId")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<int>("Number")
                    .HasColumnType("int");

                b.Property<long>("OwnerId")
                    .HasColumnType("bigint");

                b.HasKey("Id");

                b.HasIndex("MapId");

                b.HasIndex("OwnerId");

                b.ToTable("ugcmap", (string) null);
            });

            modelBuilder.Entity("Maple2.Database.Model.UgcMapCube", b => {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");

                b.Property<int>("ItemId")
                    .HasColumnType("int");

                b.Property<float>("Rotation")
                    .HasColumnType("float");

                b.Property<string>("Template")
                    .HasColumnType("json");

                b.Property<long>("UgcMapId")
                    .HasColumnType("bigint");

                b.Property<sbyte>("X")
                    .HasColumnType("tinyint");

                b.Property<sbyte>("Y")
                    .HasColumnType("tinyint");

                b.Property<sbyte>("Z")
                    .HasColumnType("tinyint");

                b.HasKey("Id");

                b.HasIndex("UgcMapId");

                b.ToTable("ugcmap-cube", (string) null);
            });

            modelBuilder.Entity("Maple2.Database.Model.Buddy", b => {
                b.HasOne("Maple2.Database.Model.Character", "BuddyCharacter")
                    .WithMany()
                    .HasForeignKey("BuddyId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Maple2.Database.Model.Character", null)
                    .WithMany()
                    .HasForeignKey("OwnerId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("BuddyCharacter");
            });

            modelBuilder.Entity("Maple2.Database.Model.Character", b => {
                b.HasOne("Maple2.Database.Model.Account", null)
                    .WithMany("Characters")
                    .HasForeignKey("AccountId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Maple2.Database.Model.CharacterConfig", b => {
                b.HasOne("Maple2.Database.Model.Character", null)
                    .WithOne()
                    .HasForeignKey("Maple2.Database.Model.CharacterConfig", "CharacterId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.OwnsOne("Maple2.Database.Model.SkillBook", "SkillBook", b1 => {
                    b1.Property<long>("CharacterConfigCharacterId")
                        .HasColumnType("bigint");

                    b1.Property<long>("ActiveSkillTabId")
                        .HasColumnType("bigint");

                    b1.Property<int>("MaxSkillTabs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b1.HasKey("CharacterConfigCharacterId");

                    b1.HasIndex("ActiveSkillTabId")
                        .IsUnique();

                    b1.ToTable("character-config");

                    b1.HasOne("Maple2.Database.Model.SkillTab", null)
                        .WithOne()
                        .HasForeignKey("Maple2.Database.Model.SkillBook", "ActiveSkillTabId")
                        .HasPrincipalKey("Maple2.Database.Model.SkillTab", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b1.WithOwner()
                        .HasForeignKey("CharacterConfigCharacterId");
                });

                b.Navigation("SkillBook");
            });

            modelBuilder.Entity("Maple2.Database.Model.CharacterUnlock", b => {
                b.HasOne("Maple2.Database.Model.Character", null)
                    .WithOne()
                    .HasForeignKey("Maple2.Database.Model.CharacterUnlock", "CharacterId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Maple2.Database.Model.Club", b => {
                b.HasOne("Maple2.Database.Model.Character", null)
                    .WithMany()
                    .HasForeignKey("LeaderId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Maple2.Database.Model.ClubMember", b => {
                b.HasOne("Maple2.Database.Model.Character", "character")
                    .WithMany()
                    .HasForeignKey("CharacterId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Maple2.Database.Model.Club", null)
                    .WithMany("Members")
                    .HasForeignKey("ClubId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("character");
            });

            modelBuilder.Entity("Maple2.Database.Model.Home", b => {
                b.HasOne("Maple2.Database.Model.Account", null)
                    .WithOne()
                    .HasForeignKey("Maple2.Database.Model.Home", "AccountId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Maple2.Database.Model.ItemStorage", b => {
                b.HasOne("Maple2.Database.Model.Account", null)
                    .WithOne()
                    .HasForeignKey("Maple2.Database.Model.ItemStorage", "AccountId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Maple2.Database.Model.SkillTab", b => {
                b.HasOne("Maple2.Database.Model.Character", null)
                    .WithMany()
                    .HasForeignKey("CharacterId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Maple2.Database.Model.UgcMapCube", b => {
                b.HasOne("Maple2.Database.Model.UgcMap", null)
                    .WithMany("Cubes")
                    .HasForeignKey("UgcMapId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Maple2.Database.Model.Account", b => {
                b.Navigation("Characters");
            });

            modelBuilder.Entity("Maple2.Database.Model.Club", b => {
                b.Navigation("Members");
            });

            modelBuilder.Entity("Maple2.Database.Model.UgcMap", b => {
                b.Navigation("Cubes");
            });
#pragma warning restore 612, 618
        }
    }
}
