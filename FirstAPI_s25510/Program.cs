using FirstAPI_s25510;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IMockAnimalDb, MockAnimalDb>();
builder.Services.AddSingleton<IMockVisitDb, MockVisitDb>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/animals", (IMockAnimalDb mockDb) =>
{
    return TypedResults.Ok(mockDb.GetAll());
});

app.MapPost("/animals", (Animal animal, IMockAnimalDb mockDb) =>
{
    mockDb.Add(animal);
    return TypedResults.Created();
});

app.MapGet("/animals/{id:int}", (int id, IMockAnimalDb mockDb) =>
{
    var animal = mockDb.GetAnimalById(id);
    return animal is not null ? TypedResults.Ok(animal) : Results.NotFound();
});

app.MapPut("/animals/{id:int}", (int id, Animal updatedAnimal, IMockAnimalDb mockDb) =>
{
    var success = mockDb.Update(id, updatedAnimal);
    return success ? Results.NoContent() : Results.NotFound();
});

app.MapDelete("/animals/{id:int}", (int id, IMockAnimalDb mockDb) =>
{
    var success = mockDb.Delete(id);
    return success ? Results.NoContent() : Results.NotFound();
});

app.MapGet("/visits", (IMockVisitDb mockAnimalDb) =>
{
    return TypedResults.Ok(mockAnimalDb.GetAll());
});

app.MapGet("/visits/{id:int}", (int id, IMockVisitDb mockVisitDb) =>
{
    List<Visit> visitsForAnimal = mockVisitDb.GetVisitsByAnimalId(id);
    return visitsForAnimal.Any() ? TypedResults.Ok(visitsForAnimal) : Results.NotFound();
});

app.MapPost("/visit", (Visit visit, IMockVisitDb mockDb) =>
{
    mockDb.Add(visit);
    return TypedResults.Created();
});

app.Run();