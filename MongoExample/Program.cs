using MongoDB.Driver;

using MongoDB.Bson;
using MongoExample;

MongoClient client = new MongoClient("mongodb+srv://alizaeri:3gPJa7zPcsoawSWu@cluster0.o8vnfer.mongodb.net/?retryWrites=true&w=majority"); //som api nickel


var playlistCollection = client.GetDatabase("sample_mflix").GetCollection<Playlist>("playlist");

List<string> movieList = new List<string>();
movieList.Add("1234");

playlistCollection.InsertOne(new Playlist("nraboy", movieList));

FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("username", "nraboy");

List<Playlist> results = playlistCollection.Find(filter).ToList();

foreach(Playlist result in results) {
    Console.WriteLine(string.Join(", ", result.items));
}

UpdateDefinition<Playlist> update = Builders<Playlist>.Update.AddToSet<string>("items", "5678");

playlistCollection.UpdateOne(filter, update);

results = playlistCollection.Find(filter).ToList();

foreach(Playlist result in results) {
    Console.WriteLine(string.Join(", ", result.items));
}

playlistCollection.DeleteOne(filter);