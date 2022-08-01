using MongoDB.Driver;

MongoClient client = new MongoClient("mongodb+srv://tim:mongodb@testcluster.cbjs6.mongodb.net/?retryWrites=true&w=majority");


// Create a new collection called "playlists" in the "test" database.
var playlistCollection = client.GetDatabase("sample_mflix").GetCollection<Playlist>("playlist");

// Create an object movieList that is to be inserted the items in the playlist.
List<string> movieList = new List<string>();
movieList.Add("movie1");
playlistCollection.InsertOne(new Playlist("yaboi", movieList ));

// Filters the playlist collection to find the playlist with the username "yaboi".
FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("username", "yaboi");
List<Playlist> results = playlistCollection.Find(filter).ToList();

// Prints the items under the username yaboi
foreach (Playlist result in results) {
  Console.WriteLine(string.Join(", ", result.items));
}

// Updates 'items' in the playlist collection to add 'movie2' to the list to the playlist with the username 'yaboi'.
UpdateDefinition<Playlist> update = Builders<Playlist>.Update.AddToSet<string>("items", "movie2");
playlistCollection.UpdateOne(filter, update);

// Printers the updated playlist.
results = playlistCollection.Find(filter).ToList();
foreach (Playlist result in results) {
  Console.WriteLine(string.Join(", ", result.items));
}