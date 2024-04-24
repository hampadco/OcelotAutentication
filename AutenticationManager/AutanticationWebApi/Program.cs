var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<JwtTokenHandler>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the WebApplication instance
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add JWT authentication middleware
app.UseAuthentication();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();