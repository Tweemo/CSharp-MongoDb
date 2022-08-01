using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Playlist {

  public ObjectId _id { get; set; }
  public string username { get; set; } = null!;
  public List<string> items { get; set; } = null!;
  public Playlist(string username, List<string> movieIds) {
    this.username = username;
    this.items = movieIds;
  }
}