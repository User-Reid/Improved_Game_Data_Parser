public interface IVideoGamesDeserializer
  {
    public List<VideoGame> DeserializeFrom(string fileName, string fileContents);
  }
