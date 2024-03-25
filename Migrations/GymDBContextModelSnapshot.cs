﻿// <auto-generated />
using System;
using GymManagementWebAPI.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymManagementWebAPI.Migrations
{
    [DbContext(typeof(GymDBContext))]
    partial class GymDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GymManagementWebAPI.DAL.Entities.GymWallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("TransactionNo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("PackageId");

                    b.HasIndex(new[] { "TransactionNo" }, "UQ__GymWalle__554342D9E32326E0")
                        .IsUnique();

                    b.ToTable("GymWallet", (string)null);
                });

            modelBuilder.Entity("GymManagementWebAPI.DAL.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("date");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("TrainerId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("TrainerId");

                    b.HasIndex(new[] { "UserId" }, "UQ__Member__1788CC4D3F642D54")
                        .IsUnique();

                    b.HasIndex(new[] { "PasswordHash" }, "UQ__Member__D60E46A267952CA0")
                        .IsUnique();

                    b.ToTable("Member", (string)null);
                });

            modelBuilder.Entity("GymManagementWebAPI.DAL.Entities.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Package", (string)null);
                });

            modelBuilder.Entity("GymManagementWebAPI.DAL.Entities.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Slot")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Trainer", (string)null);
                });

            modelBuilder.Entity("GymManagementWebAPI.DAL.Entities.GymWallet", b =>
                {
                    b.HasOne("GymManagementWebAPI.DAL.Entities.Member", "Member")
                        .WithMany("GymWallets")
                        .HasForeignKey("MemberId")
                        .IsRequired()
                        .HasConstraintName("FK__GymWallet__Membe__412EB0B6");

                    b.HasOne("GymManagementWebAPI.DAL.Entities.Package", "Package")
                        .WithMany("GymWallets")
                        .HasForeignKey("PackageId")
                        .IsRequired()
                        .HasConstraintName("FK__GymWallet__Packa__403A8C7D");

                    b.Navigation("Member");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("GymManagementWebAPI.DAL.Entities.Member", b =>
                {
                    b.HasOne("GymManagementWebAPI.DAL.Entities.Trainer", "Trainer")
                        .WithMany("Members")
                        .HasForeignKey("TrainerId")
                        .HasConstraintName("FK__Member__TrainerI__3C69FB99");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("GymManagementWebAPI.DAL.Entities.Member", b =>
                {
                    b.Navigation("GymWallets");
                });

            modelBuilder.Entity("GymManagementWebAPI.DAL.Entities.Package", b =>
                {
                    b.Navigation("GymWallets");
                });

            modelBuilder.Entity("GymManagementWebAPI.DAL.Entities.Trainer", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
