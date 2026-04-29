using System.Net.Http.Headers;

//Create ASP.net web application and use API Controllers.
var builder = WebApplication.CreateBuilder(args);

/*FOR ME:
* In ASP.NET, API controllers are specialized classes that handle
* incoming HTTP requests  (like GET, POST, or DELETE) 
* and return data responses rather than visual web
* pages. They serve as the primary entry point for RESTful services,
* facilitating communication between a client (like a mobile app or a
* React frontend) and the server's business logic */
builder.Services.AddControllers();
builder.Services.AddOpenApi(); //Swagger/OpenAPI docs

const string MarketDataClientName = "MarketData";

//Configure client/app baseURL and secret tokens for request
builder.Services.AddHttpClient(MarketDataClientName, (sp, client) =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var baseUrl = configuration["MarketData:BaseUrl"] ?? "https://api.marketdata.app";
    var token = configuration["MarketData:Token"];

    client.BaseAddress = new Uri(baseUrl.TrimEnd('/') + "/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    if (!string.IsNullOrWhiteSpace(token))
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());
});

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();
