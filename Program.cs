using System.Text.Json;
var app = new GameDataParserApp();
var logger = new Logger("log.txt");

try
{
  app.Run();
}
catch (Exception ex)
{
  System.Console.WriteLine("Sorry fam, the application experienced an error" +
  "and will have to be closed :()");
  logger.Log(ex);
}

System.Console.WriteLine("Press any key to close.");
Console.ReadKey();

public class GameDataParserApp
{
  private readonly IUserInteractor _userInteractor;
  private readonly IGamesPrinter _gamesPrinter;
  private readonly IVideoGamesDeserializer _videoGamesDeserializer;
  public GameDataParserApp(IUserInteractor userInteractor, IGamesPrinter gamesPrinter, IVideoGamesDeserializer videoGamesDeserializer)
  {
    _userInteractor = userInteractor;
    _gamesPrinter = gamesPrinter;
    _videoGamesDeserializer = videoGamesDeserializer;
  }
  public void Run()
  {
    string fileName = _userInteractor.ReadValidFilePath();

    var fileContents = File.ReadAllText(fileName);
    var videoGames = _videoGamesDeserializer.DeserializeFrom(fileName, fileContents);
    _gamesPrinter.Print(videoGames);
  }

  public interface IVideoGamesDeserializer
  {
    public List<VideoGame> DeserializeFrom(string fileName, string fileContents);
  }

  public class VideoGamesDeserializer : IVideoGamesDeserializer
  {
    private readonly IUserInteractor _userInteractor;

    public VideoGamesDeserializer(IUserInteractor userInteractor)
    {
      _userInteractor = userInteractor;
    }
    public List<VideoGame> DeserializeFrom(string fileName, string fileContents)
    {
      try
      {
        return JsonSerializer.Deserialize<List<VideoGame>>(fileContents);
      }
      catch (JsonException ex)
      {
        _userInteractor.PrintError($"JSON in {fileName} file was not\r\nin a valid format. JSON body:");
        _userInteractor.PrintError($"{fileContents}");
        throw new JsonException($"{ex.Message} The file is: {fileName}", ex);
      }
    }
  }

  public interface IGamesPrinter
  {
    void Print(List<VideoGame> videoGames);
  }

  public class GamesPrinter : IGamesPrinter
  {
    private readonly IUserInteractor _userInteractor;
    public GamesPrinter(IUserInteractor userInteractor)
    {
      _userInteractor = userInteractor;
    }
    public void Print(List<VideoGame> videoGames)
    {
      if (videoGames.Count > 0)
      {
        _userInteractor.PrintMessage(Environment.NewLine + "Loaded games are:");
        foreach (VideoGame videoGame in videoGames)
        {
          _userInteractor.PrintMessage(videoGame.ToString());
          _userInteractor.PrintMessage("XXXXXXXX");
        }
      }
      else
      {
        System.Console.WriteLine("No games are present in the input file.");
      }
    }
  }

  public interface IUserInteractor
  {
    string ReadValidFilePath();
    void PrintMessage(string message);
    void PrintError(string message);
  }
  public class ConsoleUserInteractor : IUserInteractor {
    public void PrintMessage(string message)
    {
        System.Console.WriteLine(message);
      }

    public void PrintError(string message)
    {
            var originalColor = Console.ForegroundColor;
      Console.ForegroundColor = ConsoleColor.Red;
      System.Console.WriteLine(message);
      Console.ForegroundColor = originalColor;
    }
       public string ReadValidFilePath()
    {
      bool isFilePathValid = false;
      var fileName = default(string);
      do
      {
        if (fileName is null)
        {
          System.Console.WriteLine("The file name cannot be null");
        }
        else if (fileName == string.Empty)
        {
          System.Console.WriteLine("The file name cannot be empty");
        }
        else if (!File.Exists(fileName))
        {
          System.Console.WriteLine("The file does not exist");
        }
        else
        {
          isFilePathValid = true;
        }
      } while (!isFilePathValid);
      return fileName;
    }
}
}

public class VideoGame
{
  public string Title { get; }
  public int ReleaseYear { get; }
  public decimal Rating { get; }

  public VideoGame(string title, int releaseYear, decimal rating)
  {
    Title = title;
    ReleaseYear = releaseYear;
    Rating = rating;
  }

  public override string ToString() => $"{Title}; Which was released in {ReleaseYear} and was rated a {Rating}/5.";
}
