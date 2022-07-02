﻿using Maple2.Database.Extensions;
using Maple2.Database.Model.Metadata;
using Maple2.Model.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Maple2.Database.Context;

public sealed class MetadataContext : DbContext {
    public DbSet<TableChecksum> TableChecksum { get; set; } = null!;
    public DbSet<AnimationMetadata> AnimationMetadata { get; set; } = null!;
    public DbSet<ItemMetadata> ItemMetadata { get; set; } = null!;
    public DbSet<NpcMetadata> NpcMetadata { get; set; } = null!;
    public DbSet<MapMetadata> MapMetadata { get; set; } = null!;
    public DbSet<MapEntity> MapEntity { get; set; } = null!;
    public DbSet<QuestMetadata> QuestMetadata { get; set; } = null!;
    public DbSet<RideMetadata> RideMetadata { get; set; } = null!;
    public DbSet<SkillMetadata> SkillMetadata { get; set; } = null!;
    public DbSet<TableMetadata> TableMetadata { get; set; } = null!;
    public DbSet<UgcMapMetadata> UgcMapMetadata { get; set; } = null!;

    public MetadataContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TableChecksum>(Maple2.Database.Model.Metadata.TableChecksum.Configure);
        modelBuilder.Entity<AnimationMetadata>(ConfigureAnimationMetadata);
        modelBuilder.Entity<ItemMetadata>(ConfigureItemMetadata);
        modelBuilder.Entity<NpcMetadata>(ConfigureNpcMetadata);
        modelBuilder.Entity<MapMetadata>(ConfigureMapMetadata);
        modelBuilder.Entity<MapEntity>(ConfigureMapEntity);
        modelBuilder.Entity<QuestMetadata>(ConfigureQuestMetadata);
        modelBuilder.Entity<RideMetadata>(ConfigureRideMetadata);
        modelBuilder.Entity<SkillMetadata>(ConfigureSkillMetadata);
        modelBuilder.Entity<TableMetadata>(ConfigureTableMetadata);
        modelBuilder.Entity<UgcMapMetadata>(ConfigureUgcMapMetadata);
    }

    private static void ConfigureAnimationMetadata(EntityTypeBuilder<AnimationMetadata> builder) {
        builder.ToTable("animation");
        builder.HasKey(ani => ani.Model);
        builder.Property(ani => ani.Sequences).HasJsonConversion();
    }

    private static void ConfigureItemMetadata(EntityTypeBuilder<ItemMetadata> builder) {
        builder.ToTable("item");
        builder.HasKey(item => item.Id);
        builder.Property(item => item.SlotNames).HasJsonConversion();
        builder.Property(item => item.Property).HasJsonConversion();
        builder.Property(item => item.Limit).HasJsonConversion();
        builder.Property(item => item.Skill).HasJsonConversion();
    }

    private static void ConfigureNpcMetadata(EntityTypeBuilder<NpcMetadata> builder) {
        builder.ToTable("npc");
        builder.HasKey(npc => npc.Id);
        builder.Property(npc => npc.Stat).HasJsonConversion();
        builder.Property(npc => npc.Basic).HasJsonConversion();
        builder.Property(npc => npc.Action).HasJsonConversion();
        builder.Property(npc => npc.Dead).HasJsonConversion();
    }

    private static void ConfigureMapMetadata(EntityTypeBuilder<MapMetadata> builder) {
        builder.ToTable("map");
        builder.HasKey(map => map.Id);
        builder.Property(map => map.Property).HasJsonConversion();
        builder.Property(map => map.Limit).HasJsonConversion();
        builder.Property(map => map.CashCall).HasJsonConversion();
        builder.Property(map => map.EntranceBuffs).HasJsonConversion();
    }

    private static void ConfigureMapEntity(EntityTypeBuilder<MapEntity> builder) {
        builder.ToTable("map-entity");
        builder.HasKey(entity => new {entity.XBlock, Id = entity.Guid});
        builder.Property(entity => entity.Block).HasJsonConversion().IsRequired();
    }

    private static void ConfigureQuestMetadata(EntityTypeBuilder<QuestMetadata> builder) {
        builder.ToTable("quest");
        builder.HasKey(quest => quest.Id);
        builder.Property(quest => quest.Basic).HasJsonConversion();
        builder.Property(quest => quest.Require).HasJsonConversion();
        builder.Property(quest => quest.AcceptReward).HasJsonConversion();
        builder.Property(quest => quest.CompleteReward).HasJsonConversion();
    }

    private static void ConfigureRideMetadata(EntityTypeBuilder<RideMetadata> builder) {
        builder.ToTable("ride");
        builder.HasKey(ride => ride.Id);
        builder.Property(ride => ride.Basic).HasJsonConversion();
        builder.Property(ride => ride.Speed).HasJsonConversion();
        builder.Property(ride => ride.Stats).HasJsonConversion();
    }

    private static void ConfigureSkillMetadata(EntityTypeBuilder<SkillMetadata> builder) {
        builder.ToTable("skill");
        builder.HasKey(skill => skill.Id);
        builder.Property(skill => skill.Property).HasJsonConversion();
        builder.Property(skill => skill.State).HasJsonConversion();
        builder.Property(skill => skill.Levels).HasJsonConversion();
    }

    private static void ConfigureTableMetadata(EntityTypeBuilder<TableMetadata> builder) {
        builder.ToTable("table");
        builder.HasKey(table => table.Name);
        builder.Property(table => table.Table).HasJsonConversion().IsRequired();
    }

    private static void ConfigureUgcMapMetadata(EntityTypeBuilder<UgcMapMetadata> builder) {
        builder.ToTable("ugcmap");
        builder.HasKey(map => map.Id);
        builder.Property(map => map.Groups).HasJsonConversion().IsRequired();
    }
}
