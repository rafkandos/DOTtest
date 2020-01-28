﻿// <auto-generated />
using EngineeringTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EngineeringTest.Migrations
{
    [DbContext(typeof(ProvinceCityDBContext))]
    partial class ProvinceCityDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EngineeringTest.Models.City", b =>
                {
                    b.Property<int>("city_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city_name");

                    b.Property<string>("postal_code");

                    b.Property<int>("province_id");

                    b.Property<string>("type");

                    b.HasKey("city_id");

                    b.HasIndex("province_id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("EngineeringTest.Models.Province", b =>
                {
                    b.Property<int>("province_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("province");

                    b.HasKey("province_id");

                    b.ToTable("Province");
                });

            modelBuilder.Entity("EngineeringTest.Models.City", b =>
                {
                    b.HasOne("EngineeringTest.Models.Province", "Province")
                        .WithMany()
                        .HasForeignKey("province_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}