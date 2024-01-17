using AwsSecretManager;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAmazonSecretsManager(builder.Configuration["Aws:Region"], builder.Configuration["Aws:SecretManagerName"]);
builder.Services.Configure<SecretCredentials>(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
