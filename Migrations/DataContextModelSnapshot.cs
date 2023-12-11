﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fin_back.Data;

#nullable disable

namespace fin_back.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "8e8056e6-206d-49d1-a353-36147b9370b9",
                            Name = "Member",
                            NormalizedName = "MEMBER"
                        },
                        new
                        {
                            Id = "e9ad01f6-c8ad-4db4-9a88-5c8cb13b81a1",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(1024)
                        .HasColumnType("longtext");

                    b.HasKey("LoginProvider", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(36)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("fin_back.Data.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("fin_back.Data.Entities.Organization", b =>
                {
                    b.Property<int?>("RegNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("OrgAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OrgEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OrgName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OrgType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RegNum");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("fin_back.Data.Entities.OrganizationIndicators", b =>
                {
                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.Property<int>("RegNum")
                        .HasColumnType("int");

                    b.Property<byte[]>("BalanceFile")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("CashFlowFile")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("ProfitNLossFile")
                        .HasColumnType("longblob");

                    b.HasKey("Year", "RegNum");

                    b.HasIndex("RegNum");

                    b.ToTable("OrganizationIndicators");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("fin_back.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("fin_back.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("fin_back.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("fin_back.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("fin_back.Data.Entities.Organization", b =>
                {
                    b.HasOne("fin_back.Data.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("fin_back.Data.Entities.OrganizationIndicators", b =>
                {
                    b.HasOne("fin_back.Data.Entities.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("RegNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("fin_back.Models.Indicators.FinancialIndicators", "FinancialIndicators", b1 =>
                        {
                            b1.Property<int>("OrganizationIndicatorsYear")
                                .HasColumnType("int");

                            b1.Property<int>("OrganizationIndicatorsRegNum")
                                .HasColumnType("int");

                            b1.Property<double>("CoverageRatio")
                                .HasColumnType("double");

                            b1.Property<double>("Leverage")
                                .HasColumnType("double");

                            b1.HasKey("OrganizationIndicatorsYear", "OrganizationIndicatorsRegNum");

                            b1.ToTable("OrganizationIndicators");

                            b1.ToJson("FinancialIndicators");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationIndicatorsYear", "OrganizationIndicatorsRegNum");
                        });

                    b.OwnsOne("fin_back.Models.Indicators.LiquidityIndicators", "LiquidityIndicators", b1 =>
                        {
                            b1.Property<int>("OrganizationIndicatorsYear")
                                .HasColumnType("int");

                            b1.Property<int>("OrganizationIndicatorsRegNum")
                                .HasColumnType("int");

                            b1.Property<double>("AccountsPayTurnover")
                                .HasColumnType("double");

                            b1.Property<double>("AccountsRecTurnover")
                                .HasColumnType("double");

                            b1.Property<double>("CurrentLiquidity")
                                .HasColumnType("double");

                            b1.Property<double>("FastLiquidity")
                                .HasColumnType("double");

                            b1.Property<double>("FinancialCycle")
                                .HasColumnType("double");

                            b1.Property<double>("FreeCashFlow")
                                .HasColumnType("double");

                            b1.Property<double>("ReservesTurnover")
                                .HasColumnType("double");

                            b1.HasKey("OrganizationIndicatorsYear", "OrganizationIndicatorsRegNum");

                            b1.ToTable("OrganizationIndicators");

                            b1.ToJson("LiquidityIndicators");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationIndicatorsYear", "OrganizationIndicatorsRegNum");
                        });

                    b.OwnsOne("fin_back.Models.Indicators.ProfitabilityIndicators", "ProfitabilityIndicators", b1 =>
                        {
                            b1.Property<int>("OrganizationIndicatorsYear")
                                .HasColumnType("int");

                            b1.Property<int>("OrganizationIndicatorsRegNum")
                                .HasColumnType("int");

                            b1.Property<double>("ReturnOnAssets")
                                .HasColumnType("double");

                            b1.Property<double>("ReturnOnEquity")
                                .HasColumnType("double");

                            b1.Property<double>("ReturnOnInvestment")
                                .HasColumnType("double");

                            b1.HasKey("OrganizationIndicatorsYear", "OrganizationIndicatorsRegNum");

                            b1.ToTable("OrganizationIndicators");

                            b1.ToJson("ProfitabilityIndicators");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationIndicatorsYear", "OrganizationIndicatorsRegNum");
                        });

                    b.Navigation("FinancialIndicators");

                    b.Navigation("LiquidityIndicators");

                    b.Navigation("Organization");

                    b.Navigation("ProfitabilityIndicators");
                });
#pragma warning restore 612, 618
        }
    }
}