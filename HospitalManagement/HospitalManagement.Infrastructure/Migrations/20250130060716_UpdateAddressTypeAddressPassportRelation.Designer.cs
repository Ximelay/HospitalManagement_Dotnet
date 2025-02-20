﻿// <auto-generated />
using System;
using HospitalManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalManagement.Infrastructure.Migrations
{
    [DbContext(typeof(HospitalDbContext))]
    [Migration("20250130060716_UpdateAddressTypeAddressPassportRelation")]
    partial class UpdateAddressTypeAddressPassportRelation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("AddressTypeId")
                        .HasColumnType("int");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressTypeId");

                    b.HasIndex("PatientId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.AddressType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("AddressTypes");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Diagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Diagnoses");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext");

                    b.Property<int>("SpecializationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Hospitalization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConditionDescription")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("HospitalizationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("HospitalizationReasonId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HospitalizationReasonId");

                    b.HasIndex("PatientId");

                    b.ToTable("Hospitalizations");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.HospitalizationReason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ReasonName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("HospitalizationReason");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.MedicalCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("MedicalCards");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.MedicalHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DiagnosisId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastVisitDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MedicalCardId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NextVisitDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosisId");

                    b.HasIndex("MedicalCardId");

                    b.ToTable("MedicalHistories");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.MedicalProcedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("MedicalHistoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProcedureDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ProcedureName")
                        .HasColumnType("longtext");

                    b.Property<int>("ProcedureTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Recommendations")
                        .HasColumnType("longtext");

                    b.Property<string>("Results")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("MedicalHistoryId");

                    b.HasIndex("ProcedureTypeId");

                    b.ToTable("MedicalProcedures");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Passport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("SeriesNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("Passport");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("InsurancePolicyNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("WorkplaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkplaceId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.ProcedureType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ProcedureType");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Specialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Workplace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("WorkplaceName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Workplaces");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Address", b =>
                {
                    b.HasOne("HospitalManagement.Domain.Entities.AddressType", "AddressTypeEntity")
                        .WithMany("Addresses")
                        .HasForeignKey("AddressTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagement.Domain.Entities.Patient", "Patient")
                        .WithMany("Addresses")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddressTypeEntity");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Doctor", b =>
                {
                    b.HasOne("HospitalManagement.Domain.Entities.Specialization", "Specialization")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Hospitalization", b =>
                {
                    b.HasOne("HospitalManagement.Domain.Entities.HospitalizationReason", "HospitalizationReason")
                        .WithMany("Hospitalizations")
                        .HasForeignKey("HospitalizationReasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagement.Domain.Entities.Patient", "Patient")
                        .WithMany("Hospitalizations")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HospitalizationReason");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.MedicalCard", b =>
                {
                    b.HasOne("HospitalManagement.Domain.Entities.Patient", "Patient")
                        .WithOne("MedicalCard")
                        .HasForeignKey("HospitalManagement.Domain.Entities.MedicalCard", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.MedicalHistory", b =>
                {
                    b.HasOne("HospitalManagement.Domain.Entities.Diagnosis", "Diagnosis")
                        .WithMany("MedicalHistories")
                        .HasForeignKey("DiagnosisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagement.Domain.Entities.MedicalCard", "MedicalCard")
                        .WithMany("MedicalHistories")
                        .HasForeignKey("MedicalCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diagnosis");

                    b.Navigation("MedicalCard");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.MedicalProcedure", b =>
                {
                    b.HasOne("HospitalManagement.Domain.Entities.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagement.Domain.Entities.MedicalHistory", "MedicalHistory")
                        .WithMany()
                        .HasForeignKey("MedicalHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagement.Domain.Entities.ProcedureType", "ProcedureType")
                        .WithMany("MedicalProcedures")
                        .HasForeignKey("ProcedureTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("MedicalHistory");

                    b.Navigation("ProcedureType");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Passport", b =>
                {
                    b.HasOne("HospitalManagement.Domain.Entities.Patient", "Patient")
                        .WithOne("Passport")
                        .HasForeignKey("HospitalManagement.Domain.Entities.Passport", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Patient", b =>
                {
                    b.HasOne("HospitalManagement.Domain.Entities.Workplace", "Workplace")
                        .WithMany("Patients")
                        .HasForeignKey("WorkplaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workplace");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.AddressType", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Diagnosis", b =>
                {
                    b.Navigation("MedicalHistories");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.HospitalizationReason", b =>
                {
                    b.Navigation("Hospitalizations");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.MedicalCard", b =>
                {
                    b.Navigation("MedicalHistories");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Patient", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Hospitalizations");

                    b.Navigation("MedicalCard");

                    b.Navigation("Passport");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.ProcedureType", b =>
                {
                    b.Navigation("MedicalProcedures");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Specialization", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("HospitalManagement.Domain.Entities.Workplace", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
