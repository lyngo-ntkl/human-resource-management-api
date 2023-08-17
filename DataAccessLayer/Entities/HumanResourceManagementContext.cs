using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects.Models;

public partial class HumanResourceManagementContext : DbContext
{
    public HumanResourceManagementContext()
    {
    }

    public HumanResourceManagementContext(DbContextOptions<HumanResourceManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Leave> Leaves { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    private static IConfiguration GetConfiguration()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
        return configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(GetConfiguration()["ConnectionStrings:database"]);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PK_CONTRACT");

            entity.ToTable("contracts");

            entity.Property(e => e.ContractId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("contract_id");
            entity.Property(e => e.Allowance)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("allowance");
            entity.Property(e => e.AnnualLeave).HasColumnName("annual_leave");
            entity.Property(e => e.BasicSalary)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("basic_salary");
            entity.Property(e => e.ContractAnnex)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("contract_annex");
            entity.Property(e => e.ContractFile)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("contract_file");
            entity.Property(e => e.ContractTerm).HasColumnName("contract_term");
            entity.Property(e => e.ElectronicSignature)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("electronic_signature");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("employee_id");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.LaborContractType).HasColumnName("labor_contract_type");
            entity.Property(e => e.ProbationaryPeriod).HasColumnName("probationary_period");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Employee).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_CONTRACT_EMPLOYEE");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__departme__C2232422860943A4");

            entity.ToTable("departments");

            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("department_name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK_EMPLOYEE");

            entity.ToTable("employees");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("employee_id");
            entity.Property(e => e.Address)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Gender)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.IdentityCardNumber)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("identity_card_number");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.PositionId).HasColumnName("position_id");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_EMPLOYEE_DEPARTMENT");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK_EMPLOYEE_POSITION");
        });

        modelBuilder.Entity<Leave>(entity =>
        {
            entity.HasKey(e => e.LeaveId).HasName("PK__leaves__743350BCF68C072F");

            entity.ToTable("leaves");

            entity.Property(e => e.LeaveId)
                .ValueGeneratedNever()
                .HasColumnName("leave_id");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("employee_id");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.Reason)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("reason");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.Employee).WithMany(p => p.Leaves)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LEAVES_EMPLOYEE");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__position__99A0E7A41FE1F2A1");

            entity.ToTable("positions");

            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.PositionName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("position_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
