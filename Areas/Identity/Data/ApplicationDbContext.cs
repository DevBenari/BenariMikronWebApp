using BenariMikronWebApp.Areas.AccountingAndFinancial.Models;
using BenariMikronWebApp.Areas.Administration.Models;
using BenariMikronWebApp.Areas.HealthManagement.Models;
using BenariMikronWebApp.Areas.Identity.Data;
using BenariMikronWebApp.Areas.PatientRegistration.Models;
using BenariMikronWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BenariMikronWebApp.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    #region Areas Administration
    public DbSet<Insurance> Insurances { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<SubDistrict> SubDistricts { get; set; }
    public DbSet<LastEducation> LastEducations { get; set; }
    public DbSet<Religion> Religions { get; set; }
    public DbSet<Working> Workings { get; set; }
    public DbSet<Promo> Promos { get; set; }
    #endregion

    #region Areas Patient Registration
    public DbSet<NewPatient> NewPatients { get; set; }
    public DbSet<ExternalPatientLaboratorium> ExternalPatientLaboratoriums { get; set; }
    public DbSet<ExternalPatientRadiologi> ExternalPatientRadiologis { get; set; }
    public DbSet<ExternalPatientRehabilitasiMedik> ExternalPatientRehabilitasiMediks { get; set; }
    public DbSet<ExternalPatientMedicalCheckUp> ExternalPatientMedicalCheckUps { get; set; }
    public DbSet<ExternalPatientFasilitas> ExternalPatientFasilitas { get; set; }
    public DbSet<ExternalPatientAmbulance> ExternalPatientAmbulances { get; set; }
    public DbSet<ExternalPatientOptik> ExternalPatientOptiks { get; set; }
    public DbSet<Reference> References { get; set; }
    public DbSet<ReferenceType> ReferenceTypes { get; set; }
    public DbSet<ReferenceDetail> ReferenceDetails { get; set; }
    #endregion

    #region Areas Accounting And Financial
    public DbSet<Bank> Banks { get; set; }
    public DbSet<BankCabang> BankCabangs { get; set; }
    #endregion

    #region Areas Health Management    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<DoctorType> DoctorTypes { get; set; }
    public DbSet<DoctorTitle> DoctorTitles { get; set; }
    public DbSet<DoctorQueueType> DoctorQueueTypes { get; set; }
    public DbSet<DoctorDepartment> DoctorDepartments { get; set; }    
    public DbSet<DoctorDepartmentLocation> DepartmentLocations { get; set; }
    public DbSet<BloodType> BloodTypes { get; set; }
    public DbSet<MultipleDoctorDepartment> MultipleDoctorDepartments { get; set; }
    public DbSet<ScheduleToday> ScheduleTodays { get; set; }
    public DbSet<Day> Days { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

        foreach (var foreignKey in builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.NamaDepan).HasMaxLength(255);
        builder.Property(u => u.NamaBelakang).HasMaxLength(255);
    }
}