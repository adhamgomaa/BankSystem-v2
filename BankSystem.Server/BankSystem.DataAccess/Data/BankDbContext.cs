using System;
using Microsoft.EntityFrameworkCore;
using BankSystem.Shared.Entities;
namespace BankSystem.DataAccess.Data;

public partial class BankDbContext(DbContextOptions<BankDbContext> options) : DbContext(options)
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Person> People { get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Transfer> Transfers { get; set; }
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    public virtual DbSet<LoginAttempt> LoginAttempts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserID);

            entity.HasIndex(e => e.UserName, "UQ_Users_Username").IsUnique();
            entity.HasIndex(e => e.PersonID, "IX_Users_PersonId");
            entity.HasIndex(e => e.PersonID, "UQ_Users_PersonId").IsUnique();

            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Permissions)
                .IsRequired();
            entity.Property(e => e.IsActive)
                .IsRequired();

            entity.HasOne(e => e.Person)
                .WithOne(p => p.User)
                .HasForeignKey<User>(e => e.PersonID)
                .HasConstraintName("FK_UserInformation_People");
        });
            

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientID);

            entity.HasIndex(e => e.AccountNumber, "UQ_Clients_AccountNumber").IsUnique();
            entity.HasIndex(e => e.PersonID, "IX_Clients_PersonId");

            entity.Property(e => e.AccountNumber)
                .IsRequired();
            entity.Property(e => e.Balance)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
            entity.Property(e => e.PinCode)
                .IsRequired();

            entity.HasOne(c => c.Person)
                .WithOne(p => p.Client)
                .HasForeignKey<Client>(c => c.PersonID)
                .HasConstraintName("FK_ClientInformation_People");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonID);

            entity.HasIndex(e => e.Email, "UQ_People_Email").IsUnique();
            entity.HasIndex(e => e.Phone, "UQ_People_Phone").IsUnique();

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.SecondName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Gender)
                .IsRequired();
            entity.Property(e => e.BirthDate)
                .HasColumnType("datetime")
                .IsRequired();
        });
            

        modelBuilder.Entity<Transfer>(entity =>
        {
            entity.HasKey(e => e.TransferID);

            entity.HasIndex(e => e.SenderAcc, "IX_Transfers_SenderAcc");

            entity.Property(e => e.TransferDate)
                .HasColumnType("datetime")
                .IsRequired();
            entity.Property(e => e.SenderAcc)
                .IsRequired();
            entity.Property(e => e.ReceiverAcc)
                .IsRequired();
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
            entity.Property(e => e.CreatedByUserID)
                .IsRequired();

            entity.HasOne(t => t.User)
                .WithMany(u => u.Transfers)
                .HasForeignKey(t => t.CreatedByUserID)
                .HasConstraintName("FK_TransferLog_UserInformation");
        });
            

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.RefreshTokenId);

            entity.HasIndex(e => e.TokenFamilyId, "IX_RefreshTokens_TokenFamilyId").HasFillFactor(100);
            entity.HasIndex(e => e.TokenHash, "UQ_RefreshTokens_TokenHash").IsUnique();
            entity.HasIndex(e => new { e.UserId, e.ExpiresAt }, "IX_RefreshTokens_UserId_Active")
                .HasFilter("([RevokedAt] IS NULL)")
                .HasFillFactor(100);

            entity.Property(e => e.TokenHash)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreatedAt)
                .HasPrecision(0)
                .HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("datetime2")
                .IsRequired();
            entity.Property(e => e.RevokedAt)
                .HasColumnType("datetime2");
            entity.Property(e => e.TokenFamilyId).HasDefaultValueSql("(newid())");

            entity.Property(e => e.ReplacedByTokenId);

            entity.HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .HasConstraintName("FK_RefreshTokens_Users");
            entity.HasOne(rt => rt.ReplacedToken)
                .WithMany(r => r.InverseReplacedByToken)
                .HasForeignKey(rt => rt.ReplacedByTokenId)
                .HasConstraintName("FK_RefreshTokens_ReplacedBy");
        });
            

        modelBuilder.Entity<LoginAttempt>(entity =>
        {
            entity.HasKey(e => e.LoginAttemptId);

            entity.Property(e => e.UserId);
            entity.Property(e => e.AttemptedUserName)
                .HasMaxLength(256)
                .IsRequired();
            entity.Property(e => e.Succeeded)
                .IsRequired();
            entity.Property(e => e.AttemptedAtUtc)
                .HasColumnType("datetime2")
                .IsRequired();
            entity.Property(e => e.ClientIpAddress);
        });
            
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
