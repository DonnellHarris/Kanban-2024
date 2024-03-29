﻿// <auto-generated />
using KanbanApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KanbanApi.Migrations
{
    [DbContext(typeof(KanbanApiContext))]
    partial class KanbanApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Models.KBoard", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("KWorkspaceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KWorkspaceId");

                    b.ToTable("KBoards");
                });

            modelBuilder.Entity("DAL.Models.KColumn", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("KBoardId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KBoardId");

                    b.ToTable("KColumns");
                });

            modelBuilder.Entity("DAL.Models.KTask", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KColumnId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KColumnId");

                    b.ToTable("KTasks");
                });

            modelBuilder.Entity("DAL.Models.KUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KUsers");
                });

            modelBuilder.Entity("DAL.Models.KWorkspace", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("KUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KUserId");

                    b.ToTable("KWorkspaces");
                });

            modelBuilder.Entity("DAL.Models.KBoard", b =>
                {
                    b.HasOne("DAL.Models.KWorkspace", null)
                        .WithMany("Boards")
                        .HasForeignKey("KWorkspaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.KColumn", b =>
                {
                    b.HasOne("DAL.Models.KBoard", null)
                        .WithMany("Columns")
                        .HasForeignKey("KBoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.KTask", b =>
                {
                    b.HasOne("DAL.Models.KColumn", null)
                        .WithMany("Tasks")
                        .HasForeignKey("KColumnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.KWorkspace", b =>
                {
                    b.HasOne("DAL.Models.KUser", null)
                        .WithMany("Workspaces")
                        .HasForeignKey("KUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.KBoard", b =>
                {
                    b.Navigation("Columns");
                });

            modelBuilder.Entity("DAL.Models.KColumn", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("DAL.Models.KUser", b =>
                {
                    b.Navigation("Workspaces");
                });

            modelBuilder.Entity("DAL.Models.KWorkspace", b =>
                {
                    b.Navigation("Boards");
                });
#pragma warning restore 612, 618
        }
    }
}
