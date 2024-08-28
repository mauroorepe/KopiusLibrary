using KopiusLibrary.Model;
using KopiusLibrary.Repositories;
using KopiusLibrary.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])

        )};
    });


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("KopiusLibraryDev")));
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Biblioteca API V1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
