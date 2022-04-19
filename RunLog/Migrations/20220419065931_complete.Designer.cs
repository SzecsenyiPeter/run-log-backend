﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RunLog.Data;

namespace RunLog.Migrations
{
    [DbContext(typeof(RunLogContext))]
    [Migration("20220419065931_complete")]
    partial class complete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RunLog.Model.Run", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompletedPlanId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("HeartRate")
                        .HasColumnType("int");

                    b.Property<int?>("RanById")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompletedPlanId");

                    b.HasIndex("RanById");

                    b.ToTable("Runs");
                });

            modelBuilder.Entity("RunLog.Model.RunPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("Instructions")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("RunPlan");
                });

            modelBuilder.Entity("RunLog.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CoachedById")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RunPlanId")
                        .HasColumnType("int");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoachedById");

                    b.HasIndex("RunPlanId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RunLog.Model.Run", b =>
                {
                    b.HasOne("RunLog.Model.RunPlan", "CompletedPlan")
                        .WithMany()
                        .HasForeignKey("CompletedPlanId");

                    b.HasOne("RunLog.Model.User", "RanBy")
                        .WithMany()
                        .HasForeignKey("RanById");

                    b.Navigation("CompletedPlan");

                    b.Navigation("RanBy");
                });

            modelBuilder.Entity("RunLog.Model.RunPlan", b =>
                {
                    b.HasOne("RunLog.Model.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("RunLog.Model.User", b =>
                {
                    b.HasOne("RunLog.Model.User", "CoachedBy")
                        .WithMany()
                        .HasForeignKey("CoachedById");

                    b.HasOne("RunLog.Model.RunPlan", null)
                        .WithMany("AssignedTo")
                        .HasForeignKey("RunPlanId");

                    b.Navigation("CoachedBy");
                });

            modelBuilder.Entity("RunLog.Model.RunPlan", b =>
                {
                    b.Navigation("AssignedTo");
                });
#pragma warning restore 612, 618
        }
    }
}