using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Core_OdeToCode.Entities;

namespace CoreOdeToCode.Migrations
{
    [DbContext(typeof(OdeToCodeDbContext))]
    [Migration("20160526055501_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core_OdeToCode.Entities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cuisine");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 80);

                    b.HasKey("Id");
                });
        }
    }
}
