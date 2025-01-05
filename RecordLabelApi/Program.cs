using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RecordLabelApi.Context;
using RecordLabelApi.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<ISingleRepository, SingleRepository>();
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddDbContext<RecordLabelContext>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "your-issuer",
            ValidAudience = "your-audience",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-very-strong-secret-keyqwqwwqqwqwqw"))
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();
app.UseCors(x => { x.SetIsOriginAllowed(origin => true); x.AllowAnyMethod(); x.AllowAnyHeader(); });
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
