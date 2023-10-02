﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Goc.Models;

public partial class GocContext : DbContext
{
    public GocContext()
    {
    }

    public GocContext(DbContextOptions<GocContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActionTypes> ActionTypes { get; set; }
    public virtual DbSet<ActionsLog> ActionsLog { get; set; }
    public virtual DbSet<Campaigns> Campaigns { get; set; }
    public virtual DbSet<Character> Characters { get; set; }
    public virtual DbSet<Evidences> Evidences { get; set; }
    public virtual DbSet<MessageTemplates> MessageTemplates { get; set; }
    public virtual DbSet<Messages> Messages { get; set; }
    public virtual DbSet<Missions> Missions { get; set; }
    public virtual DbSet<Team> Teams { get; set; }
    
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActionTypes>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(20);
        });

        modelBuilder.Entity<ActionsLog>(entity =>
        {
            entity.Property(e => e.Id).UseIdentityColumn();

            entity.Property(e => e.DateTimeFrom).HasColumnType("smalldatetime");

            entity.Property(e => e.DateTimeTo).HasColumnType("smalldatetime");

            entity.HasOne(d => d.ActionType)
                .WithMany(p => p.ActionsLog)
                .HasForeignKey(d => d.ActionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActionsLog_ActionTypes");

            entity.HasOne(d => d.TeamCharacter)
                .WithMany(p => p.ActionsLog)
                .HasForeignKey(d => d.TeamCharacterId)
                .HasConstraintName("FK_ActionsLog_TeamsCharacters");

            entity.HasOne(d => d.Mission)
                .WithMany(p => p.ActionsLog)
                .HasForeignKey(d => d.MissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActionsLog_Missions");

            entity.HasOne(d => d.Team)
                .WithMany(p => p.ActionsLog)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActionsLog_AffectedTeams");
        });

        modelBuilder.Entity<Campaigns>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

            entity.HasMany(d => d.Mission)
                .WithMany(p => p.Campaign)
                .UsingEntity<Dictionary<string, object>>(
                    "CampaignsMissions",
                    l => l.HasOne<Missions>().WithMany().HasForeignKey("MissionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CampaignsMissions_Missions"),
                    r => r.HasOne<Campaigns>().WithMany().HasForeignKey("CampaignId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CampaignsMissions_Campaigns"),
                    j =>
                    {
                        j.HasKey("CampaignId", "MissionId");

                        j.ToTable("CampaignsMissions");
                    });
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Attack)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(e => e.Bonus)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(e => e.Defense)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Story)
                .IsRequired()
                .HasMaxLength(500);
        });

        modelBuilder.Entity<Evidences>(entity =>
        {
            entity.Property(e => e.Id).UseIdentityColumn();

            entity.Property(e => e.Image)
                .IsRequired()
                .IsUnicode(false);

            entity.HasOne(d => d.ActionLog)
                .WithMany(p => p.Evidences)
                .HasForeignKey(d => d.ActionLogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evidences_ActionsLog");

            entity.HasOne(d => d.TeamCharacter)
                .WithMany(p => p.Evidences)
                .HasForeignKey(d => d.TeamCharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evidences_Characters");
        });

        modelBuilder.Entity<MessageTemplates>(entity =>
        {
            entity.Property(e => e.Id).HasMaxLength(50);

            entity.Property(e => e.Body)
                .IsRequired()
                .HasMaxLength(1000);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.ActionType)
                .WithMany(p => p.MessageTemplates)
                .HasForeignKey(d => d.ActionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MessageTemplates_ActionTypes");
        });

        modelBuilder.Entity<Messages>(entity =>
        {
            entity.Property(e => e.Id).UseIdentityColumn();

            entity.Property(e => e.DateTime).HasColumnType("smalldatetime");

            entity.Property(e => e.Message)
                .IsRequired()
                .HasMaxLength(1000);

            entity.HasOne(d => d.RecipientTeamNavigation)
                .WithMany(p => p.MessagesRecipientTeamNavigation)
                .HasForeignKey(d => d.RecipientTeam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_RecipientTeams");

            entity.HasOne(d => d.SenderTeamNavigation)
                .WithMany(p => p.MessagesSenderTeamNavigation)
                .HasForeignKey(d => d.SenderTeam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_SenderTeams");
        });

        modelBuilder.Entity<Missions>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

            entity.Property(e => e.Story)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(e => e.Instructions)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.StartDate).HasColumnType("smalldatetime");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.Property(e => e.Id).UseIdentityColumn();

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).UseIdentityColumn();

            entity.HasOne(d => d.Character)
                .WithMany(p => p.TeamsCharacters)
                .HasForeignKey(d => d.CharacterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamsCharacters_Characters");

            entity.HasOne(d => d.Team)
                .WithMany(p => p.TeamsCharacters)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamsCharacters_Teams");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}