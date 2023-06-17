using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// custom
builder.Services.AddDbContext<CandidateManagementContext>(
        options => options.UseSqlServer("name=ConnectionStrings:CandidateManagement"));
builder.Services.AddScoped<CandidateProfileServices>();
builder.Services.AddScoped<HraccountServices>();
builder.Services.AddScoped<JobPostingServices>();

builder.Services.AddSession();
///////////////////

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//custom
app.UseSession();
/////////////////

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
