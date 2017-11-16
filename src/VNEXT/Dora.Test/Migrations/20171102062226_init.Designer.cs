using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Dora.Test;

namespace Dora.Test.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171102062226_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dora.Domain.Entities.System.Dict", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnName("Key");

                    b.Property<string>("Type")
                        .HasColumnName("Type");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("LastAction")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<DateTime>("UpdateTime");

                    b.Property<string>("UpdateUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 64);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("Value")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Key", "Type");

                    b.ToTable("System_Dicts");
                });
        }
    }
}
