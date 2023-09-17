using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entities;

public partial class HumanResourceManagementContext : DbContext
{
    public HumanResourceManagementContext()
    {
    }

    public HumanResourceManagementContext(DbContextOptions<HumanResourceManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Allowance> Allowances { get; set; }

    public virtual DbSet<AllowanceType> AllowanceTypes { get; set; }

    public virtual DbSet<BonusType> BonusTypes { get; set; }

    public virtual DbSet<Bonuse> Bonuses { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Leave> Leaves { get; set; }

    public virtual DbSet<Payroll> Payrolls { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:surveynow.database.windows.net,1433;Initial Catalog=flowerbouquet;Persist Security Info=False;User ID=admin_sql;Password=Surveynowexe201@@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allowance>(entity =>
        {
            entity.HasKey(e => new { e.ContractId, e.AllowanceTypeId }).HasName("PK_ALLOWANCE");

            entity.ToTable("allowances");

            entity.Property(e => e.ContractId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("contract_id");
            entity.Property(e => e.AllowanceTypeId).HasColumnName("allowance_type_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amount");

            entity.HasOne(d => d.AllowanceType).WithMany(p => p.Allowances)
                .HasForeignKey(d => d.AllowanceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ALLOWANCE_ALLOWANCE_TYPE");

            entity.HasOne(d => d.Contract).WithMany(p => p.Allowances)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ALLOWANCE_CONTRACT");
        });

        modelBuilder.Entity<AllowanceType>(entity =>
        {
            entity.HasKey(e => e.AllowanceTypeId).HasName("PK_ALLOWANCE_TYPE");

            entity.ToTable("allowance_types");

            entity.Property(e => e.AllowanceTypeId)
                .ValueGeneratedNever()
                .HasColumnName("allowance_type_id");
            entity.Property(e => e.AllowanceName)
                .HasMaxLength(100)
                .HasColumnName("allowance_name");
        });

        modelBuilder.Entity<BonusType>(entity =>
        {
            entity.HasKey(e => e.BonusTypeId).HasName("PK__bonus_ty__D5E38EE3898C7AD2");

            entity.ToTable("bonus_types");

            entity.Property(e => e.BonusTypeId)
                .ValueGeneratedNever()
                .HasColumnName("bonus_type_id");
            entity.Property(e => e.BonusName)
                .HasMaxLength(100)
                .HasColumnName("bonus_name");
        });

        modelBuilder.Entity<Bonuse>(entity =>
        {
            entity.HasKey(e => e.BonusId).HasName("PK__bonuses__D0F870AE45218785");

            entity.ToTable("bonuses");

            entity.Property(e => e.BonusId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("bonus_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amount");
            entity.Property(e => e.BonusTypeId).HasColumnName("bonus_type_id");
            entity.Property(e => e.PayrollId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("payroll_id");
            entity.Property(e => e.Reason)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("reason");

            entity.HasOne(d => d.BonusType).WithMany(p => p.Bonuses)
                .HasForeignKey(d => d.BonusTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BONUS_BONUS_TYPE");

            entity.HasOne(d => d.Payroll).WithMany(p => p.Bonuses)
                .HasForeignKey(d => d.PayrollId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BONUS_PAYROLL");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PK_CONTRACT");

            entity.ToTable("contracts");

            entity.Property(e => e.ContractId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("contract_id");
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
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
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
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.ProbationaryPeriod).HasColumnName("probationary_period");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.TotalAllowance)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total_allowance");

            entity.HasOne(d => d.Department).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_CONTRACT_DEPARTMENT");

            entity.HasOne(d => d.Employee).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_CONTRACT_EMPLOYEE");

            entity.HasOne(d => d.Position).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK_CONTRACT_POSITION");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__departme__C2232422701EDC52");

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

            entity.HasIndex(e => e.IdentityCardNumber, "UQ__employee__0F01BC4167A87500").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__employee__AB6E616436045B10").IsUnique();

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("employee_id");
            entity.Property(e => e.Address)
                .HasMaxLength(256)
                .HasColumnName("address");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.EductionalLevel)
                .HasMaxLength(100)
                .HasColumnName("eductional_level");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.IdentityCardNumber)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("identity_card_number");
            entity.Property(e => e.IsFormer).HasColumnName("is_former");
            entity.Property(e => e.Major)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("major");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.PasswordKey).HasColumnName("password_key");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Leave>(entity =>
        {
            entity.HasKey(e => e.LeaveId).HasName("PK__leave__743350BC0386EC05");

            entity.ToTable("leave");

            entity.Property(e => e.LeaveId)
                .HasDefaultValueSql("(newid())")
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
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.Employee).WithMany(p => p.Leaves)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LEAVES_EMPLOYEE");
        });

        modelBuilder.Entity<Payroll>(entity =>
        {
            entity.HasKey(e => e.PayrollId).HasName("PK_PAYROLL");

            entity.ToTable("payrolls");

            entity.Property(e => e.PayrollId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("payroll_id");
            entity.Property(e => e.ContractId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("contract_id");
            entity.Property(e => e.DaysOff).HasColumnName("days_off");
            entity.Property(e => e.PayDate)
                .HasColumnType("date")
                .HasColumnName("pay_date");

            entity.HasOne(d => d.Contract).WithMany(p => p.Payrolls)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK_PAYROLL_CONTRACT");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__position__99A0E7A4E75CBFB1");

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
