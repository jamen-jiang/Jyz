﻿// <auto-generated />
using System;
using Jyz.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jyz.Infrastructure.Data.Migrations
{
    [DbContext(typeof(JyzContext))]
    [Migration("20200820071738_updatedb3")]
    partial class updatedb3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Jyz.Domain.Dictionary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category")
                        .HasMaxLength(50);

                    b.Property<string>("Code")
                        .HasMaxLength(50);

                    b.Property<Guid>("CreatedBy");

                    b.Property<string>("CreatedByName")
                        .IsRequired();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsEnable");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<Guid?>("PId");

                    b.Property<string>("Remark")
                        .HasMaxLength(500);

                    b.Property<int?>("Sort");

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<string>("UpdatedByName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Value")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Dictionary");
                });

            modelBuilder.Entity("Jyz.Domain.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedBy");

                    b.Property<string>("CreatedByName")
                        .IsRequired();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsEnable");

                    b.Property<string>("Md5")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Remark")
                        .HasMaxLength(500);

                    b.Property<long?>("Size");

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<string>("UpdatedByName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("File");
                });

            modelBuilder.Entity("Jyz.Domain.LogLogin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Browser")
                        .HasMaxLength(200);

                    b.Property<string>("City")
                        .HasMaxLength(50);

                    b.Property<string>("IP")
                        .HasMaxLength(200);

                    b.Property<bool>("IsSuccess");

                    b.Property<DateTime>("LoginOn");

                    b.Property<string>("Os")
                        .HasMaxLength(200);

                    b.Property<string>("UserAgent")
                        .HasMaxLength(500);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("LogLogin");
                });

            modelBuilder.Entity("Jyz.Domain.LogOperate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApiMethod")
                        .HasMaxLength(50);

                    b.Property<string>("ApiName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ApiUrl")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Browser")
                        .HasMaxLength(200);

                    b.Property<string>("City")
                        .HasMaxLength(50);

                    b.Property<long>("ElapsedMilliseconds");

                    b.Property<string>("IP")
                        .HasMaxLength(200);

                    b.Property<bool>("IsSuccess");

                    b.Property<DateTime>("LogOn");

                    b.Property<string>("Os")
                        .HasMaxLength(200);

                    b.Property<string>("Request");

                    b.Property<string>("Response");

                    b.Property<string>("Type")
                        .HasMaxLength(50);

                    b.Property<string>("UserAgent")
                        .HasMaxLength(500);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("LogOperate");
                });

            modelBuilder.Entity("Jyz.Domain.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Controller")
                        .HasMaxLength(50);

                    b.Property<Guid>("CreatedBy");

                    b.Property<string>("CreatedByName")
                        .IsRequired();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Icon")
                        .HasMaxLength(200);

                    b.Property<bool>("IsEnable");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid?>("PId");

                    b.Property<string>("Remark")
                        .HasMaxLength(500);

                    b.Property<int?>("Sort");

                    b.Property<int>("Type");

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<string>("UpdatedByName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("VueUri")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Module");
                });

            modelBuilder.Entity("Jyz.Domain.Operate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid>("CreatedBy");

                    b.Property<string>("CreatedByName")
                        .IsRequired();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Icon")
                        .HasMaxLength(200);

                    b.Property<bool>("IsEnable");

                    b.Property<Guid>("ModuleId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasMaxLength(500);

                    b.Property<int?>("Sort");

                    b.Property<int>("Type");

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<string>("UpdatedByName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Operate");
                });

            modelBuilder.Entity("Jyz.Domain.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedBy");

                    b.Property<string>("CreatedByName")
                        .IsRequired();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Fax")
                        .HasMaxLength(50);

                    b.Property<bool>("IsEnable");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid?>("PId");

                    b.Property<string>("Remark")
                        .HasMaxLength(500);

                    b.Property<int?>("Sort");

                    b.Property<string>("Telephone")
                        .HasMaxLength(50);

                    b.Property<int>("Type");

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<string>("UpdatedByName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("Jyz.Domain.Organization_User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("OrganizationId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserId");

                    b.ToTable("Organization_User");
                });

            modelBuilder.Entity("Jyz.Domain.Privilege", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Access")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("AccessValue")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Master")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MasterValue")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Operation");

                    b.HasKey("Id");

                    b.ToTable("Privilege");
                });

            modelBuilder.Entity("Jyz.Domain.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedBy");

                    b.Property<string>("CreatedByName")
                        .IsRequired();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsEnable");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasMaxLength(500);

                    b.Property<int?>("Sort");

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<string>("UpdatedByName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Jyz.Domain.Role_Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("OrganizationId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("RoleId");

                    b.ToTable("Role_Organization");
                });

            modelBuilder.Entity("Jyz.Domain.Role_User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("RoleId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("Role_User");
                });

            modelBuilder.Entity("Jyz.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar")
                        .HasMaxLength(500);

                    b.Property<Guid>("CreatedBy");

                    b.Property<string>("CreatedByName")
                        .IsRequired();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsEnable");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasMaxLength(500);

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<string>("UpdatedByName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Jyz.Domain.Operate", b =>
                {
                    b.HasOne("Jyz.Domain.Module", "Module")
                        .WithMany("Operates")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jyz.Domain.Organization_User", b =>
                {
                    b.HasOne("Jyz.Domain.Organization", "Organization")
                        .WithMany("Organization_User")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Jyz.Domain.User", "User")
                        .WithMany("Organization_User")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jyz.Domain.Role_Organization", b =>
                {
                    b.HasOne("Jyz.Domain.Organization", "Organization")
                        .WithMany("Role_Organization")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Jyz.Domain.Role", "Role")
                        .WithMany("Role_Organization")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jyz.Domain.Role_User", b =>
                {
                    b.HasOne("Jyz.Domain.Role", "Role")
                        .WithMany("Role_User")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Jyz.Domain.User", "User")
                        .WithMany("Role_User")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
