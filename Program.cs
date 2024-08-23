using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BenariMikronWebApp.Areas.Identity.Data;
using Microsoft.CodeAnalysis.Options;
using BenariMikronWebApp.Core;
using BenariMikronWebApp.Core.Repositories;
using BenariMikronWebApp.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Options;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using FastReport.Data;
using BenariMikronWebApp.Service;
using BenariMikronWebApp.Areas.UserManagement.Services;
using BenariMikronWebApp.Areas.UserManagement.Repositories;
using BenariMikronWebApp.Areas.UserManagement.Data;
using BenariMikronWebApp.Areas.PatientRegistration.Repositories;
using BenariMikronWebApp.Areas.Administration.Repositories;
using BenariMikronWebApp.Areas.HealthManagement.Repositories;
using BenariMikronWebApp.Areas.AccountingAndFinancial.Repositories;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
//{
//    options.SignIn.RequireConfirmedAccount = true;
//    options.Password.RequireNonAlphanumeric = false;
//}).AddDefaultTokenProviders().AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    //options.Password.RequiredLength = 5;
    //options.Password.RequiredUniqueChars = 1;
    options.Password.RequireNonAlphanumeric = false;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddSession();

//Script Auto Show Login Account First Time
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddMvc(options =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    options.Filters.Add(new AuthorizeFilter(policy));    
}).AddXmlSerializerFormatters().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

#region Authorization

AddAuthorizationPolicies();

#endregion

AddScope();

#region Areas Administration
builder.Services.AddScoped<ICountryRepository, ICountryRepository>();
builder.Services.AddScoped<IProvinceRepository, IProvinceRepository>();
builder.Services.AddScoped<ICityRepository, ICityRepository>();
builder.Services.AddScoped<IDistrictRepository, IDistrictRepository>();
builder.Services.AddScoped<ISubDistrictRepository, ISubDistrictRepository>();
builder.Services.AddScoped<IInsuranceRepository, IInsuranceRepository>();
builder.Services.AddScoped<ILastEducationRepository, ILastEducationRepository>();
builder.Services.AddScoped<IReligionRepository, IReligionRepository>();
builder.Services.AddScoped<IWorkingRepository, IWorkingRepository>();
builder.Services.AddScoped<IPromoRepository, IPromoRepository>();
#endregion

#region Areas Patient Registration
builder.Services.AddScoped<INewPatientRepository, INewPatientRepository>();
builder.Services.AddScoped<INewPatientExternalLaboratoriumRepository, INewPatientExternalLaboratoriumRepository>();
builder.Services.AddScoped<INewPatientExternalRadiologiRepository, INewPatientExternalRadiologiRepository>();
builder.Services.AddScoped<INewPatientExternalRehabilitasiMedikRepository, INewPatientExternalRehabilitasiMedikRepository>();
builder.Services.AddScoped<INewPatientExternalMedicalCheckUpRepository, INewPatientExternalMedicalCheckUpRepository>();
builder.Services.AddScoped<INewPatientExternalFasilitasRepository, INewPatientExternalFasilitasRepository>();
builder.Services.AddScoped<INewPatientExternalAmbulanceRepository, INewPatientExternalAmbulanceRepository>();
builder.Services.AddScoped<INewPatientExternalOptikRepository, INewPatientExternalOptikRepository>();
builder.Services.AddScoped<IReferenceRepository, IReferenceRepository>();
builder.Services.AddScoped<IReferenceTypeRepository, IReferenceTypeRepository>();
builder.Services.AddScoped<IReferenceDetailRepository, IReferenceDetailRepository>();
#endregion

#region Areas Health Management
builder.Services.AddScoped<IDoctorRepository, IDoctorRepository>();
builder.Services.AddScoped<IDoctorTypeRepository, IDoctorTypeRepository>();
builder.Services.AddScoped<IDoctorDepartmentRepository, IDoctorDepartmentRepository>();
builder.Services.AddScoped<IDoctorTitleRepository, IDoctorTitleRepository>();
builder.Services.AddScoped<IDoctorQueueTypeRepository, IDoctorQueueTypeRepository>();
builder.Services.AddScoped<IDoctorDepartmentLocationRepository, IDoctorDepartmentLocationRepository>();
builder.Services.AddScoped<ILastEducationRepository, ILastEducationRepository>();
builder.Services.AddScoped<IBloodTypeRepository, IBloodTypeRepository>();
builder.Services.AddScoped<IMultipleDoctorDepartmentRepository, IMultipleDoctorDepartmentRepository>();
builder.Services.AddScoped<IScheduleTodayRepository, IScheduleTodayRepository>();
builder.Services.AddScoped<IDayRepository, IDayRepository>();
#endregion

#region Areas Accounting And Financial
builder.Services.AddScoped<IBankRepository, IBankRepository>();
builder.Services.AddScoped<IBankCabangRepository, IBankCabangRepository>();
#endregion

builder.Services.AddScoped<IUserManagementService, UserManagementService>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaims>();

//Fast Report Depedency Add
FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.UseFastReport();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();

    endpoints.MapControllerRoute(
        name: "MyArea",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { 
        "Administrator", "SuperAdmin", "User", 
        
        "PendaftaranPasien",
        
        "PasienBaru", 
        "TambahPasienBaru", "UbahPasienBaru", "HapusPasienBaru",
        
        "PasienLuar", "PasienBayi" 
    };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

app.Run();

async void AddAuthorizationPolicies()
{
    //builder.Services.AddAuthorization(options =>
    //{
    //    options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
    //});    

    builder.Services.AddAuthorization(options =>
    {
        //options.AddPolicy(Constants.Policies.RequireAdmin, policy => policy.RequireRole(Constants.Roles.Admin));
        //options.AddPolicy(Constants.Policies.RequireManager, policy => policy.RequireRole(Constants.Roles.Manager));        
    });
}

void AddScope()
{
    builder.Services.AddScoped<IUserManagementRepository, UserManagementRepository>();
    builder.Services.AddScoped<IRoleRepository, RoleRepository>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
}