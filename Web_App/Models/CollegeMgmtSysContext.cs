using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web_App.Models;

public partial class CollegeMgmtSysContext : DbContext
{
    public CollegeMgmtSysContext()
    {
    }

    public CollegeMgmtSysContext(DbContextOptions<CollegeMgmtSysContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CasteCategoryMst> CasteCategoryMsts { get; set; }

    public virtual DbSet<FacultyMst> FacultyMsts { get; set; }

    public virtual DbSet<GenderMst> GenderMsts { get; set; }

    public virtual DbSet<StudentDetailsMst> StudentDetailsMsts { get; set; }

    public virtual DbSet<SubjectAppliedMst> SubjectAppliedMsts { get; set; }

    public virtual DbSet<SubjectMst> SubjectMsts { get; set; }

    public virtual DbSet<UserLoginDetail> UserLoginDetails { get; set; }

    public virtual DbSet<UserTypeMst> UserTypeMsts { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=BOOK-6RVOBV6LHM;Database=College_Mgmt_Sys;Integrated Security=True;\nPersist Security Info=False;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CasteCategoryMst>(entity =>
        {
            entity.HasKey(e => e.PkCastCategoryId);

            entity.ToTable("CasteCategory_mst");

            entity.Property(e => e.PkCastCategoryId).HasColumnName("Pk_CastCategoryId");
            entity.Property(e => e.Alias)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FacultyMst>(entity =>
        {
            entity.HasKey(e => e.PkFacultyId);

            entity.ToTable("Faculty_Mst");

            entity.Property(e => e.PkFacultyId).HasColumnName("Pk_FacultyId");
            entity.Property(e => e.Alias)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FacultyName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GenderMst>(entity =>
        {
            entity.HasKey(e => e.PkGenderId);

            entity.ToTable("Gender_mst");

            entity.Property(e => e.PkGenderId).HasColumnName("Pk_GenderId");
            entity.Property(e => e.Alias)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GenderName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StudentDetailsMst>(entity =>
        {
            entity.HasKey(e => e.PkStudentId);

            entity.ToTable("StudentDetails_Mst");

            entity.Property(e => e.PkStudentId).HasColumnName("Pk_StudentId");
            entity.Property(e => e.AadharNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FatherName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FkCastCategoryId).HasColumnName("Fk_CastCategoryId");
            entity.Property(e => e.FkFacultyId).HasColumnName("Fk_facultyId");
            entity.Property(e => e.FkGenderId).HasColumnName("Fk_GenderId");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GuardianContactNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MotherName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PermanentAddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PostalAddress)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.FkCastCategory).WithMany(p => p.StudentDetailsMsts)
                .HasForeignKey(d => d.FkCastCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentDetails_Mst_CasteCategory_mst");

            entity.HasOne(d => d.FkFaculty).WithMany(p => p.StudentDetailsMsts)
                .HasForeignKey(d => d.FkFacultyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentDetails_Mst_Faculty_Mst");

            entity.HasOne(d => d.FkGender).WithMany(p => p.StudentDetailsMsts)
                .HasForeignKey(d => d.FkGenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentDetails_Mst_Gender_mst");
        });

        modelBuilder.Entity<SubjectAppliedMst>(entity =>
        {
            entity.HasKey(e => e.PkSubjectAppliedId);

            entity.ToTable("SubjectApplied_Mst");

            entity.Property(e => e.PkSubjectAppliedId).HasColumnName("Pk_SubjectAppliedId");
            entity.Property(e => e.FkStudentId).HasColumnName("Fk_studentId");
            entity.Property(e => e.FkSubjectPaperId).HasColumnName("Fk_SubjectPaperId");
            entity.Property(e => e.FkSubjectgroupId).HasColumnName("Fk_subjectgroupId");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.FkStudent).WithMany(p => p.SubjectAppliedMsts)
                .HasForeignKey(d => d.FkStudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubjectApplied_Mst_StudentDetails_Mst");

            entity.HasOne(d => d.FkSubjectPaper).WithMany(p => p.SubjectAppliedMsts)
                .HasForeignKey(d => d.FkSubjectPaperId)
                .HasConstraintName("FK_SubjectApplied_Mst_Subject_Mst");
        });

        modelBuilder.Entity<SubjectMst>(entity =>
        {
            entity.HasKey(e => e.PkSubjectId);

            entity.ToTable("Subject_Mst");

            entity.Property(e => e.PkSubjectId).HasColumnName("Pk_SubjectId");
            entity.Property(e => e.FkFacultyId).HasColumnName("Fk_FacultyId");
            entity.Property(e => e.FkSubjectPaperGroupId).HasColumnName("Fk_SubjectPaperGroupId");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.FkFaculty).WithMany(p => p.SubjectMsts)
                .HasForeignKey(d => d.FkFacultyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subject_Mst_Faculty_Mst");
        });

        modelBuilder.Entity<UserLoginDetail>(entity =>
        {
            entity.HasKey(e => e.PkUserId);

            entity.ToTable("User_Login_Details");

            entity.Property(e => e.PkUserId).HasColumnName("Pk_UserId");
            entity.Property(e => e.EncryptedPassword)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Encrypted_Password");
            entity.Property(e => e.FkUserTypeId).HasColumnName("Fk_UserTypeId");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SaltKey)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Salt_Key");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.FkUserType).WithMany(p => p.UserLoginDetails)
                .HasForeignKey(d => d.FkUserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Login_Details_UserType_mst");
        });

        modelBuilder.Entity<UserTypeMst>(entity =>
        {
            entity.HasKey(e => e.PkUserTypeId);

            entity.ToTable("UserType_mst");

            entity.Property(e => e.PkUserTypeId).HasColumnName("Pk_UserTypeId");
            entity.Property(e => e.Alias)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
