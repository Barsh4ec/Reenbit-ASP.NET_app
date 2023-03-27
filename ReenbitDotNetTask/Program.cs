using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ReenbitDotNetTask.Data;
using Syncfusion.Blazor;
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTQ2Njk5OUAzMjMxMmUzMTJlMzMzNUJheUpnM1RJM2Z5Tm8vQ1o3T1hvUXo3YzEwZXV0K1VvTU1adFdCYWtJaVk9;Mgo DSMBaFt QHFqVkNrWE5FaV1CX2BZf1N8QWBTfVlgBShNYlxTR3ZcQFhiSXpQdEJqXnlY;Mgo DSMBMAY9C3t2VFhhQlJBfVtdXHxLflF1VWJZdVpzfldBcC0sT3RfQF5jSnxWd0VnWn1ZeX1WQA==;Mgo DSMBPh8sVXJ1S0d X1RPckBDQmFJfFBmRGNTe116dl1WESFaRnZdQV1gS3tSdkFgW3decHxT;MTQ2NzAwM0AzMjMxMmUzMTJlMzMzNW12blkvT2xKOHVvdVdOYXJLNG9KYUg5T2ZuZ2dCK1VQMVZkaUZPcWhCWFk9;NRAiBiAaIQQuGjN/V0d XU9Hc1RGQmJWfFN0RnNYf1R0d19EaEwgOX1dQl9gSX1Rc0RjXXxceHRRQWY=;ORg4AjUWIQA/Gnt2VFhhQlJBfVtdXHxLflF1VWJZdVpzfldOcC0sT3RfQF5jSnxWd0VnWn1WcHJRQA==;MTQ2NzAwNkAzMjMxMmUzMTJlMzMzNWEwR1BQVExOcFpNL1JmaWNzT2J6R2F3ODRSYk4wYlBhbFhyN2Faa3R1ZTg9;MTQ2NzAwN0AzMjMxMmUzMTJlMzMzNW9FVnRSWkFsRU00NEdxMHF2R1FsdmRPRDdRc0NkWjNLbmVLRWQvNGZmT3M9;MTQ2NzAwOEAzMjMxMmUzMTJlMzMzNWJLNUZwL0pQU3VCdUtPeURXcDkxaUZNR2VjUXhXb0JPS3hJclFZSGdYdUk9;MTQ2NzAwOUAzMjMxMmUzMTJlMzMzNVRHSGNSMzF1YXoxS21kUzZndDkwa3ROdkViRGh6ZmUxaU1MYkpCOU1jTWc9;MTQ2NzAxMEAzMjMxMmUzMTJlMzMzNUJheUpnM1RJM2Z5Tm8vQ1o3T1hvUXo3YzEwZXV0K1VvTU1adFdCYWtJaVk9");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddHttpClient();

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

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
