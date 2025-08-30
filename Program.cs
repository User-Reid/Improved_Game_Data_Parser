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
  public void Run()
  {
    bool isFileRead = false;
var fileContents = default(string);
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
        fileContents = File.ReadAllText(fileName);
        isFileRead = true;
      }
} while (!isFileRead);

List<VideoGame> videoGames = default;
try
{
  videoGames = JsonSerializer.Deserialize<List<VideoGame>>(fileContents);
}
catch (JsonException ex)
{
  var originalColor = Console.ForegroundColor;
  Console.ForegroundColor = ConsoleColor.Red;
  Console.WriteLine($"JSON in {fileName} file was not\r\nin a valid format. JSON body:");
  System.Console.WriteLine($"{fileContents}");
  Console.ForegroundColor = originalColor;
  
  throw new JsonException($"{ex.Message} The file is: {fileName}", ex);
}

if (videoGames.Count > 0)
{
  System.Console.WriteLine();
  System.Console.WriteLine("Loaded games are:");
  foreach (VideoGame videoGame in videoGames)
  {
    System.Console.WriteLine(videoGame);
    System.Console.WriteLine("XXXXXXXX");
  }
}
else
{
  System.Console.WriteLine("No games are present in the input file.");
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
