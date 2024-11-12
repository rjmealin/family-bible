using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using FamilyBible.api.Components;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using FamilyBible.api.Entities;
using Microsoft.Data.SqlClient;
using Dapper;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region BibleRoutes

app.MapGet("/api/bible", () => "Hello World!");

app.MapGet("/api/user-links", () => {
                IReadOnlyDictionary<string, object?> p = new Dictionary<string, object?>()
            {
                { "UserName", "Billy Bob" }
            };
    var compoenntResult = new RazorComponentResult(typeof(UserDashboard), p);
    return compoenntResult;
});

app.MapGet("/api/get-chapter/{bookId}/{chapterId}", async (HttpContext httpContext, int bookId, int chapterId) =>
{
    string connectionString = builder.Configuration.GetConnectionString("family-bible");
    using (var connection = new SqlConnection(connectionString))
    {
        var sql = "SELECT * FROM Verses Where Book = @bookId AND Chapter = @chapterId";
        var paramz = new { bookId = bookId, chapterId = chapterId };
        var verses = await connection.QueryAsync<VerseModel>(sql, paramz);
	
        IReadOnlyDictionary<string, object?> p = new Dictionary<string, object?>()
        {
            {"BookId", bookId},
            { "ChapterNumber",chapterId },
            {"Verses", verses}
        };
        var res = new RazorComponentResult(typeof(ChapterView), p);

        return res;

    }

    
    
});
#endregion

#region JsonUploading
app.MapGet("/api/json-uploading", async () =>
{
    //ok lets grab the local file en_bbe.json
    var bbe = System.IO.File.OpenText("bbe.json");
    
    var stringContent = bbe.ReadToEnd();

    var objs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ImportVerseModel>>(stringContent);
    
    
    string connectionString = builder.Configuration.GetConnectionString("family-bible");
    // 1. We will create a connection
    using (var connection = new SqlConnection(connectionString))
    {
        // 2. We will create an `INSERT` sql statement
        // public int Id { get; set; }
        // public int Chapter { get; set; }
        // public int Verse { get; set; }
        // public string? Text { get; set; }
        // public int Book { get; set; }
        // public string? Version { get; set; }
        var sql = "INSERT INTO Verses (Chapter, Verse, Text, Book,Version) VALUES (@Chapter, @Verse, @Text, @Book, @Version)";
        //
        // var verse = new VerseModel();
        // verse.Chapter = 1;
        // verse.Verse = 1;
        // verse.Text = "This is a test";
        // verse.Book = 1;
        // verse.Version = "bbe";
        for (var i = 1; i <= objs.Count; i++)
        {
            var book = objs[i - 1];
            for (var j = 1; j <= book.chapters.Count; j++)
            {
                var verses = book.chapters[j - 1];
                for (var k = 1; k <= verses.Count; k++)
                {
                    var verse = new VerseModel();
                    verse.Chapter = j;
                    verse.Verse = k;
                    verse.Text = verses[k - 1];
                    verse.Book = i;
                    verse.Version = "bbe";
                    
                    var rowsAffected = await connection.ExecuteAsync(sql, verse);
                }

                    
            }
                        
        }


        
        
    }
});
#endregion


app.Run();
