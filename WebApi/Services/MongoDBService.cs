using MongoExample.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoExample.Services;
public class MongoDBService
{
    private readonly IMongoCollection<StudentList> _studentCollection;
    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _studentCollection = database.GetCollection<StudentList>(mongoDBSettings.Value.CollectionName);
    }

    public async Task CreateAsync(StudentList studentList)
    {
        await _studentCollection.InsertOneAsync(studentList);
        return;
    }

    public async Task<List<StudentList>> GetAsync() 
    {
        return await _studentCollection.Find(new BsonDocument()).ToListAsync(); 
    }

    public async Task AddToStudentListAsync(string Id, string studentId)
    {
        FilterDefinition<StudentList> filter = Builders<StudentList>.Filter.Eq("Id", Id);
        UpdateDefinition<StudentList> update = Builders<StudentList>.Update.AddToSet<string>("items", studentId);
        await _studentCollection.UpdateOneAsync(filter, update);
        return;
    }

    public async Task DeleteAsync(string Id)
    {
        FilterDefinition<StudentList> filter = Builders<StudentList>.Filter.Eq("Id", Id);
        await _studentCollection.DeleteOneAsync(filter);
        return;
    }
}